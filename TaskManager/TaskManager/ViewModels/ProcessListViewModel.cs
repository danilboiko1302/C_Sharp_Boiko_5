using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TaskManager.Models;
using TaskManager.Tools;
using TaskManager.Windows;

namespace TaskManager.ViewModels
{
    internal class ProcessListViewModel: BaseViewModel
    {
      

        private ObservableCollection<SingleProcess> _processes;
        private bool _isControlEnabled = true;
        private SingleProcess _selectedProcess;

        private Thread _workingThread;
        private readonly CancellationToken _token;
        private readonly CancellationTokenSource _tokenSource;

      
        private RelayCommand<object> _sortById;
        private RelayCommand<object> _sortByName;
        private RelayCommand<object> _sortByIsActive;
        private RelayCommand<object> _sortByCpuPercents;
        private RelayCommand<object> _sortByRamAmount;
        private RelayCommand<object> _sortByThreadsNumber;
        private RelayCommand<object> _sortByUser;
        private RelayCommand<object> _sortByFilepath;
        private RelayCommand<object> _sortByStartingTime;
      
        private RelayCommand<object> _endTask;
        private RelayCommand<object> _openFolder;
        private RelayCommand<object> _showThreads;
        private RelayCommand<object> _showModules;
        
        public SingleProcess SelectedProcess
        {
            get => _selectedProcess;
            set
            {
                _selectedProcess = value;
                OnPropertyChanged();
            }
        }

        public bool IsControlEnabled
        {
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SingleProcess> Processes
        {
            get => _processes;
            private set
            {
                _processes = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> EndTask
        {
            get
            {
                return _endTask ??= new RelayCommand<object>(
                    EndTaskImplementation, o=>CanExecuteCommand());
            }
        }

        public RelayCommand<object> OpenFolder
        {
            get
            {
                return _openFolder ??= new RelayCommand<object>(
                    OpenFolderImplementation, o => CanExecuteCommand());
            }
        }

        public RelayCommand<object> ShowThreads
        {
            get
            {
                return _showThreads ??= new RelayCommand<object>(
                    ShowThreadsImplementation, o => CanExecuteCommand());
            }
        }

        public RelayCommand<object> ShowModules
        {
            get
            {
                return _showModules ??= new RelayCommand<object>(
                    ShowModulesImplementation, o => CanExecuteCommand());
            }
        }

        public RelayCommand<object> SortById
        {
            get
            {
                return _sortById ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 0));
            }
        }
        public RelayCommand<object> SortByName
        {
            get
            {
                return _sortByName ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 1));
            }
        }
        public RelayCommand<object> SortByIsActive
        {
            get
            {
                return _sortByIsActive ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 2));
            }
        }
        public RelayCommand<object> SortByCpuPercents
        {
            get
            {
                return _sortByCpuPercents ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 3));
            }
        }
        public RelayCommand<object> SortByRamAmount
        {
            get
            {
                return _sortByRamAmount ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 4));
            }
        }
        public RelayCommand<object> SortByThreadsNumber
        {
            get
            {
                return _sortByThreadsNumber ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 5));
            }
        }
        public RelayCommand<object> SortByUser
        {
            get
            {
                return _sortByUser ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 6));
            }
        }
        public RelayCommand<object> SortByFilepath
        {
            get
            {
                return _sortByFilepath ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 7));
            }
        }
        public RelayCommand<object> SortByStartingTime
        {
            get
            {
                return _sortByStartingTime ??= new RelayCommand<object>(o =>
                    SortImplementation(o, 8));
            }
        }
        

        private async void EndTaskImplementation(object obj)
        {
            await Task.Run(() => { 
            if (_selectedProcess.checkAvailability())
            {
                SelectedProcess?.ProcessItself?.Kill(); //_selectedProcess.ID
                StationManager.DeleteProcess(ref _selectedProcess);
                StationManager.UpdateProcessList();
                SelectedProcess = null;
                Processes = new ObservableCollection<SingleProcess>(StationManager.ProcessList);
            }
            else
            {
                MessageBox.Show("Have no access");
            }
            }, _token);
    }
        
        private void OpenFolderImplementation(object obj)
        {
            try
            {
                Process.Start("explorer.exe",
                    _selectedProcess.Filepath.Substring(0,
                        _selectedProcess.Filepath.LastIndexOf("\\", StringComparison.Ordinal)));
            }
            catch (Exception )
            {
                MessageBox.Show("Error while accessing processing data");
            }
        }

        private void ShowModulesImplementation(object obj)
        {
            IsControlEnabled = false;
            try
            {
                ShowModulesWindow smw = new ShowModulesWindow(ref _selectedProcess);
                smw.ShowDialog();
            }
            catch (Exception )
            {
                MessageBox.Show("Error occurred while processing modules info");
            }
            IsControlEnabled = true;
        }

        private void ShowThreadsImplementation(object obj)
        {
            IsControlEnabled = false;
            try
            {
                ShowThreadsWindow smw = new ShowThreadsWindow(ref _selectedProcess);
                smw.ShowDialog();
            }
            catch (Exception )
            {
                MessageBox.Show("Error occurred while processing threads info");
            }
            IsControlEnabled = true;
        }

        private async void SortImplementation(object obj, int param)
        {
            await Task.Run(() =>
            {
                try
                {
                    StationManager.SortingParameter = param;
                    StationManager.UpdateProcessList();
                    Processes = new ObservableCollection<SingleProcess>(StationManager.ProcessList);
                }
                catch (Exception )
                {
                    MessageBox.Show("Error occurred while accessing process data");
                }
            });
         }

        
        internal ProcessListViewModel()
        {
            _processes = new ObservableCollection<SingleProcess>(StationManager.ProcessList);
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            StartWorkingThread();
            StationManager.StopThreads += StopWorkingThread;
        }

        private void StartWorkingThread()
        {
            _workingThread = new Thread(WorkingThreadProcess);
            _workingThread.Start();
        }

        private void WorkingThreadProcess()
        {
            while (!_token.IsCancellationRequested)
            {
                var temp = -1;
                if (SelectedProcess != null)
                {
                    temp = SelectedProcess.ID;
                }

                StationManager.UpdateProcessList();

                Processes = new ObservableCollection<SingleProcess>(StationManager.ProcessList);

                foreach (var p in Processes)
                {
                    if (p.ID == temp)
                    {
                        SelectedProcess = p;
                        break;
                    }
                }
                Thread.Sleep(2000);
                
                if (_token.IsCancellationRequested)
                    break;
            }
        }

        internal void StopWorkingThread()
        {
            _tokenSource.Cancel();
            _workingThread.Join(1000);
            _workingThread.Abort();
            _workingThread = null;
        }

        private bool CanExecuteCommand()
        {
            return SelectedProcess != null;
        }
    }
}
