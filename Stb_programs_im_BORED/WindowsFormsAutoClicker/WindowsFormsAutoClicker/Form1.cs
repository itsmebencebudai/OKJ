using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsAutoClicker
{
    public partial class Form1 : Form
    {
        private Button startButton;
        private Button stopButton;
        private Label clickCountLabel;
        private int clickCount;
        private Timer timer1;
        private Button speedUpButton;
        private Button speedDownButton;
        private TextBox speedTextBox;
        private Label messageLabel;
        private TextBox clickPositionTextBox;
        private Button messageUIButton;
        private CheckBox alwaysOnTopCheckBox;
        private StreamWriter logStreamWriter;
        private ComboBox mouseButtonComboBox;
        private Label chooseMouse;


        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_START_ID = 1;
        private const int HOTKEY_STOP_ID = 2;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Default interval: 1 second
        private int clickInterval = 1000;

        // Constants for mouse events
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;

        private Color backgroundColor = Color.White;
        private Color buttonColor = Color.LightGray;

        public Form1()
        {
            InitializeComponents();
            ApplyCustomization();

            // Register hotkeys when the form is created.
            RegisterHotKey(Handle, HOTKEY_START_ID, 0, (int)Keys.F5);
            RegisterHotKey(Handle, HOTKEY_STOP_ID, 0, (int)Keys.F6);
        }

        private void ApplyCustomization()
        {
            this.BackColor = backgroundColor;
            this.startButton.BackColor = buttonColor;
            this.stopButton.BackColor = buttonColor;
            this.speedUpButton.BackColor = buttonColor;
            this.speedDownButton.BackColor = buttonColor;
            this.clickPositionTextBox.BackColor = buttonColor;
            this.speedTextBox.BackColor = buttonColor;
            this.messageLabel.BackColor = backgroundColor;
            this.messageUIButton.BackColor = buttonColor;
        }

        private void CustomizeUI()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    backgroundColor = colorDialog.Color;

                    // You can add more elements for customization if needed.
                    buttonColor = ControlPaint.Light(backgroundColor);

                    ApplyCustomization();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unregister hotkeys when the form is closing.
            UnregisterHotKey(Handle, HOTKEY_START_ID);
            UnregisterHotKey(Handle, HOTKEY_STOP_ID);
        }

        private void InitializeComponents()
        {
            // ComboBox for mouse button selection
            this.mouseButtonComboBox = new ComboBox
            {
                Location = new Point(95, 160),
                Size = new Size(100, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.mouseButtonComboBox.Items.AddRange(new string[] { "Left", "Right", "Middle" });
            this.mouseButtonComboBox.SelectedIndex = 0; // Default to left mouse button

            this.logStreamWriter = new StreamWriter("AutoClickerLog.txt", true); // Create or append to the log file

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            this.Text = "Auto Clicker";

            this.startButton = new Button
            {
                Text = "Start | F5",
                Location = new Point(10, 40),
                Size = new Size(80, 23)
            };
            this.startButton.Click += StartButton_Click;

            this.stopButton = new Button
            {
                Text = "Stop | F6",
                Location = new Point(10, 70),
                Size = new Size(80, 23)
            };
            this.stopButton.Click += StopButton_Click;

            this.clickCountLabel = new Label
            {
                Text = "Click Count: 0",
                Location = new Point(95, 45),
                Size = new Size(80, 23)
            };

            this.timer1 = new Timer
            {
                Interval = clickInterval
            };
            this.timer1.Tick += Timer1_Tick;

            this.speedUpButton = new Button
            {
                Text = "Speed Up",
                Location = new Point(10, 100),
                Size = new Size(80, 23)
            };
            this.speedUpButton.Click += SpeedUpButton_Click;

            this.speedDownButton = new Button
            {
                Text = "Speed Down",
                Location = new Point(10, 130), // Adjusted Y-coordinate to place it below Speed Up button
                Size = new Size(80, 23)
            };
            this.speedDownButton.Click += SpeedDownButton_Click;

            this.clickPositionTextBox = new TextBox
            {
                Location = new Point(95, 71),
                Size = new Size(80, 23),
                ReadOnly = true
            };

            this.speedTextBox = new TextBox
            {
                Location = new Point(95, 101),
                Size = new Size(80, 23),
                ReadOnly = true,
                Text = clickInterval.ToString() + " ms"
            };

            this.messageLabel = new Label
            {
                Location = new Point(95, 135),
                Size = new Size(200, 23)
            };

            this.messageUIButton = new Button
            {
                Text = "UI customization",
                Location = new Point(10, 10),
                Size = new Size(100,23)
            };
            this.messageUIButton.Click += MessageUIButton_Click;

            this.alwaysOnTopCheckBox = new CheckBox
            {
                Text = "Always On Top",
                Location = new Point(115, 11),
                Size = new Size(120, 23),
                Checked = false
            };
            this.alwaysOnTopCheckBox.CheckedChanged += AlwaysOnTopCheckBox_CheckedChanged;

            this.chooseMouse = new Label
            {
                Text = "Mouse button: ",
                Location = new Point(10,163),
                Size = new Size(100,30)
            };

            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.clickCountLabel);
            this.Controls.Add(this.speedUpButton);
            this.Controls.Add(this.speedDownButton);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.clickPositionTextBox);
            this.Controls.Add(this.messageUIButton);
            this.Controls.Add(this.alwaysOnTopCheckBox);
            this.Controls.Add(this.mouseButtonComboBox);
            this.Controls.Add(this.chooseMouse);

        }

        private void AlwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopCheckBox.Checked;
        }

        private void MessageUIButton_Click(object sender, EventArgs e)
        {
            CustomizeUI();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.clickCount = 0;
            this.clickCountLabel.Text = "Click Count: 0";

            // Start the auto clicker.
            this.timer1.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            // Stop the auto clicker.
            this.timer1.Stop();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Get the current mouse position.
            Point currentPosition = Cursor.Position;

            // Get the selected mouse button from the combo box.
            int selectedMouseButton = GetSelectedMouseButton();

            // Simulate mouse button click based on the selection.
            switch (selectedMouseButton)
            {
                case MOUSEEVENTF_LEFTDOWN:
                case MOUSEEVENTF_LEFTUP:
                case MOUSEEVENTF_RIGHTDOWN:
                case MOUSEEVENTF_RIGHTUP:
                case MOUSEEVENTF_MIDDLEDOWN:
                case MOUSEEVENTF_MIDDLEUP:
                    mouse_event(selectedMouseButton, currentPosition.X, currentPosition.Y, 0, 0);
                    break;
                default:
                    break;
            }

            // Increment the click count.
            this.clickCount++;

            // Update the click count label.
            this.clickCountLabel.Text = "Click Count: " + this.clickCount;

            // Update the click position text box.
            this.clickPositionTextBox.Text = $"  X: {currentPosition.X}  Y: {currentPosition.Y}  ";

            // Log the details of the click.
            LogClickDetails(currentPosition);
        }

        // Helper method to get the selected mouse button from the combo box.
        private int GetSelectedMouseButton()
        {
            switch (mouseButtonComboBox.SelectedIndex)
            {
                case 0: // Left
                    return MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
                case 1: // Right
                    return MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP;
                case 2: // Middle
                    return MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP;
                default:
                    return MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
            }
        }

        private void SpeedUpButton_Click(object sender, EventArgs e)
        {
            // Increase the speed by reducing the interval.
            if (clickInterval > 100) // Ensure that the interval doesn't go below 100 milliseconds.
            {
                clickInterval -= 100;
                this.timer1.Interval = clickInterval;

                this.speedTextBox.Text = clickInterval.ToString() + " ms";

                messageLabel.Text = "Click speed increased!";
            }
            else
            {
                messageLabel.Text = "Cannot increase click speed further.";
            }
        }
        private void SpeedDownButton_Click(object sender, EventArgs e)
        {
            // Decrease the speed by increasing the interval.
            if (clickInterval < 5000) // Ensure that the interval doesn't go above 5000 milliseconds.
            {
                clickInterval += 100;
                this.timer1.Interval = clickInterval;

                this.speedTextBox.Text = clickInterval.ToString() + " ms";

                messageLabel.Text = "Click speed decreased!";
            }
            else
            {
                messageLabel.Text = "Cannot decrease click speed further.";
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();

                if (id == HOTKEY_START_ID)
                {
                    // Start the auto-clicker.
                    StartAutoClicker();
                }
                else if (id == HOTKEY_STOP_ID)
                {
                    // Stop the auto-clicker.
                    StopAutoClicker();
                }
            }
        }

        private void StartAutoClicker()
        {
            this.clickCount = 0;
            this.clickCountLabel.Text = "Click Count: 0";

            // Start the auto clicker.
            this.timer1.Start();
        }

        private void StopAutoClicker()
        {
            // Stop the auto clicker.
            this.timer1.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U) // Ctrl + U for UI customization
            {
                CustomizeUI();
            }
        }

        private void LogClickDetails(Point clickPosition)
        {
            // Log the details to the file.
            string logDetails = $"Timestamp: {DateTime.Now}, Coordinates: ( X: {clickPosition.X}, Y: {clickPosition.Y} )";
            logStreamWriter.WriteLine(logDetails);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Close the log file when the form is closing.
            logStreamWriter.Close();

            base.OnFormClosing(e);
        }
    }
}
