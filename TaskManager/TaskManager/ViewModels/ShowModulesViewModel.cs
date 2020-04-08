using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TaskManager.Models;
using TaskManager.Tools;

namespace TaskManager.ViewModels
{
    internal class ShowModulesViewModel: BaseViewModel
    {
        private ObservableCollection<SingleModule> _modules;

        public string ProcessName
        {
            get;
        }

        public ObservableCollection<SingleModule> Modules
        {
            get
            {
                
                return _modules;
                
            }
            private set
            {
                _modules = value;
                OnPropertyChanged();
            }
        }

        public Action CloseAction { get; set; }

        internal ShowModulesViewModel(ref SingleProcess process)
        {
            Modules = new ObservableCollection<SingleModule>();
            ObservableCollection<SingleModule> tmp = new ObservableCollection<SingleModule>();
            ProcessName = process.Name;
            int id = process.ID;
            foreach (ProcessModule module in process.Modules)
            {
                tmp.Add(new SingleModule(module));
            }
            Modules = tmp;
        }
    }
}
