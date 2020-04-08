using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TaskManager.Models;
using TaskManager.Tools;

namespace TaskManager.ViewModels
{
    internal class ShowThreadsViewModel : BaseViewModel
    {
        private ObservableCollection<SingleThread> _threads;

        public string ProcessName
        {
            get;
        }

        public ObservableCollection<SingleThread> Threads
        {
            get
            {

                return _threads;

            }
            private set
            {
                _threads= value;
                OnPropertyChanged();
            }
        }

        public Action CloseAction { get; set; }

        internal ShowThreadsViewModel(ref SingleProcess process)
        {
            Threads = new ObservableCollection<SingleThread>();
            ObservableCollection<SingleThread> tmp = new ObservableCollection<SingleThread>();
            ProcessName = process.Name;
            int id = process.ID;
            foreach (ProcessThread thread in process.ThreadsCollection)
            {
                tmp.Add(new SingleThread(thread));
            }
            Threads = tmp;
        }
    }
}
