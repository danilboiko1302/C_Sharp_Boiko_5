using System;
using System.Windows;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowModulesWindow.xaml
    /// </summary>
    public partial class ShowModulesWindow : Window
    {
        public ShowModulesWindow(ref SingleProcess proc)
        {
            InitializeComponent();
            ShowModulesViewModel vm = new ShowModulesViewModel(ref proc);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}