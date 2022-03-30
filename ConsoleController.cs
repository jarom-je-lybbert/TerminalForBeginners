using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalForBeginners
{
    internal class ConsoleController
    {
        private ConsoleControl.ConsoleControl consoleControl;

        public ConsoleController()
        {
            consoleControl = null;
        }

        public ConsoleController(ConsoleControl.ConsoleControl consoleControl)
        {
            this.consoleControl = consoleControl;
        }

        public bool StartConsole()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            consoleControl.StartProcess(processStartInfo);
            return consoleControl.IsProcessRunning;
        }

        public void EnterConsoleInput(string consoleInput)
        {
            consoleControl.Select();
            SendKeys.Send(consoleInput);
        }

        public void ExecuteFromConsole()
        {
            EnterConsoleInput("{ENTER}");
        }

        public void StopConsoleExecution()
        {
            EnterConsoleInput("^C");
        }
    }
}
