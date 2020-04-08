using System;
using System.Windows;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowThreadsWindow.xaml
    /// </summary>
    public partial class ShowThreadsWindow : Window
    {
        public ShowThreadsWindow(ref SingleProcess proc)
        {
            InitializeComponent();
            ShowThreadsViewModel vm = new ShowThreadsViewModel(ref proc);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}