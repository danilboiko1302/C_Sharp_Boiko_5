using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using TaskManager.Models;

namespace TaskManager.Tools
{
    internal static class StationManager
    {
        #region Fields
        public static event Action StopThreads;
        private static List<SingleProcess> _processList;
        #endregion

        #region Properties
        internal static List<SingleProcess> ProcessList
        {
            get { return _processList; }
        }

        internal static int SortingParameter { get; set; }
        #endregion

        internal static void Initialize()
        {
            SortingParameter = 1;
            _processList = new List<SingleProcess>();
            UpdateProcessList();
        }

        internal static void DeleteProcess(ref SingleProcess p)
        {
            _processList.Remove(p);
        }

        internal static void UpdateProcessList()
        {
           //_processList.Clear();
           AddMissingProcesses();
           SortProcessList();
        }

        internal static void SortProcessList()
        {            
            switch (SortingParameter)
            {
                case 0:
                    _processList = (from u in _processList
                                      orderby u.ID
                                      select u).ToList();
                    break;

                case 1:
                    _processList = (from u in _processList
                                      orderby u.Name
                                      select u).ToList();
                    break;
                case 2:
                    _processList = (from u in _processList
                                      orderby u.IsActive
                                      select u).ToList();
                    break;
                case 3:
                    _processList = (from u in _processList
                                      orderby u.CPUPercents descending 
                                      select u).ToList();
                    break;
                case 4:
                    _processList = (from u in _processList
                                      orderby u.RAMAmount descending 
                                      select u).ToList();
                    break;
                case 5:
                    _processList = (from u in _processList
                                      orderby u.Threads descending 
                                      select u).ToList();
                    break;
                case 6:
                    _processList = (from u in _processList
                                      orderby u.User descending 
                                      select u).ToList();
                    break;
                case 7:
                    _processList= (from u in _processList
                                      orderby u.Filepath
                                      select u).ToList();
                    break;
                default:
                    _processList = (from u in _processList
                                      orderby u.StartingTime descending 
                                      select u).ToList();
                    break;
            }
        }

        private static void AddMissingProcesses()
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item != null)
                {
                    if(!FoundTheSameInProcessList(item.Id))
                   _processList.Add(new SingleProcess(item));
                }
            }
        }

        private static bool FoundTheSameInProcessList(int processId)
        {
            foreach (var item in _processList)
            {
                if (processId == item.ID)
                {
                    return true;
                }
            }
            return false;
        }



        internal static void CloseApp()
        {
            MessageBox.Show("Shutting Down");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
