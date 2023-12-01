using System;
using System.Windows;

namespace TaskManagerWPF
{
    public partial class AddTaskWindow : Window
    {
        public Task Task { get; set; }

        public AddTaskWindow()
        {
            InitializeComponent();
            Task = new Task();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Set the task properties from user input
            Task.Name = nameTextBox.Text;
            Task.Description = descriptionTextBox.Text;
            Task.DueDate = dueDatePicker.SelectedDate ?? DateTime.Now;

            // Check if an item is selected in the ComboBox
            if (priorityComboBox.SelectedItem != null)
            {
                Task.Priority = priorityComboBox.SelectedItem.ToString();
            }

            // Close the window
            DialogResult = true;
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            DialogResult = false;
        }
    }
}
