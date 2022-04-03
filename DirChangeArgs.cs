using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalForBeginners
{
    public class DirChangeArgs : EventArgs
    {
        public DirChangeArgs()
        { }

        public DirChangeArgs(string relativePath)
        {
            RelativePath = relativePath;
        }

        public string RelativePath
        {
            get;
            private set;
        }
    }
}
