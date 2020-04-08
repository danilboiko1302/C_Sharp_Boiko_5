using System;
using System.Diagnostics;

namespace TaskManager.Models
{
    internal class SingleThread
    {
        #region Fields

        private readonly ProcessThread _thread;

        #endregion

        public int Id
        {
            get { return _thread.Id; }
        }

        public ThreadState State
        {

            get
            {
                return _thread.ThreadState;
                
            }

        }

        public DateTime StartingTime
        {
            get { return _thread.StartTime; }
        }
        internal SingleThread(ProcessThread thread)
        {
            _thread = thread;
        }
    }
}
