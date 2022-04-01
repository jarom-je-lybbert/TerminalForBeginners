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
        private readonly ConsoleControl.ConsoleControl consoleControl;

        public ConsoleController()
        {
            consoleControl = null;
        }

        public ConsoleController(ConsoleControl.ConsoleControl consoleControl)
        {
            inputStart = 0;
            this.consoleControl = consoleControl;
            this.consoleControl.ProcessInterface.OnProcessOutput += ProcessInterface_OnProcessOutput;
        }

        private void ProcessInterface_OnProcessOutput(object sender, ConsoleControlAPI.ProcessEventArgs args)
        {
            if (consoleControl.IsDisposed || consoleControl.InternalRichTextBox.IsDisposed)
                return;

            inputStart = consoleControl.InternalRichTextBox.SelectionStart;
        }

        public bool StartConsole()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            consoleControl.StartProcess(processStartInfo);
            return consoleControl.IsProcessRunning;
        }

        public void PutConsoleInput(string consoleInput, bool replaceCurrent = true)
        {
            consoleControl.Invoke((Action)(() =>
            {
                consoleControl.InternalRichTextBox.Select();
                if (replaceCurrent == true)
                    ClearConsoleInput();
                SendKeys.SendWait(consoleInput);
            }
            ));
        }

        public void ExecuteFromConsole()
        {
            PutConsoleInput("{ENTER}", false);
        }

        public void StopConsoleExecution()
        {
            PutConsoleInput("^C", false);
        }

        private void ClearConsoleInput()
        {
            int numInputChars = consoleControl.InternalRichTextBox.TextLength - inputStart;
            string backspaces = "";
            for (int i = 0; i < numInputChars; i++)
            {
                backspaces += "{BS}";
            }
            SendKeys.SendWait(backspaces);
        }

        private int inputStart;
    }
}
