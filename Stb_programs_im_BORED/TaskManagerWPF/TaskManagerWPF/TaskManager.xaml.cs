using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace TaskManagerWPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>();
            taskListBox.ItemsSource = Tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to add a task
            AddTaskWindow addTaskWindow = new AddTaskWindow();
            if (addTaskWindow.ShowDialog() == true)
            {
                // Add the task to the list
                Tasks.Add(addTaskWindow.Task);
            }
        }
    }
}
