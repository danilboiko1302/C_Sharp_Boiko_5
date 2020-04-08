using System;
using System.Diagnostics;
namespace TaskManager.Models
{
    internal class SingleModule
    {
        #region Fields

        private readonly ProcessModule _module;

        #endregion

        public string Name
        {
            get { return _module.ModuleName; }
        }

        public string Filepath
        {

            get
            {
                try
                {
                    return _module.FileName;
                }
                catch (Exception) 
                {
                    return "Access denied";
                }
            }

        }

        internal SingleModule(ProcessModule module)
        {
            _module = module;
        }
    }
}
