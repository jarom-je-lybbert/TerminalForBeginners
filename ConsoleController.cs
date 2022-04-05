using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace TerminalForBeginners
{
    internal class ConsoleController
    {
        private readonly ConsoleControl.ConsoleControl consoleControl;
        public delegate void DirChangeEventHandler(object sender, DirChangeArgs args);


        public ConsoleController()
        {
            consoleControl = null;
        }

        public ConsoleController(ConsoleControl.ConsoleControl consoleControl)
        {
            this.consoleControl = consoleControl;
            this.consoleControl.OnConsoleInput += ConsoleControl_OnConsoleInput;
        }

        private void ConsoleControl_OnConsoleInput(object sender, ConsoleControl.ConsoleEventArgs args)
        {
            if (args.Content.TrimStart().StartsWith("cd "))
            {
                FireOnDirChange(args.Content.TrimStart().Remove(0, 3));
            }
        }

        public bool StartConsole()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            consoleControl.StartProcess(processStartInfo);
            return consoleControl.IsProcessRunning;
        }

        public void PlaceConsoleInput(string consoleInput, bool replaceCurrent = true)
        {
            consoleControl.PlaceInput(consoleInput, Color.White, replaceCurrent);
        }

        public void ExecuteFromConsole()
        {
            consoleControl.WritePlacedInput();
        }

        public void StopConsoleProgram()
        {
            consoleControl.SendStopSig();
        }

        public void ChangeDirectory(string relativePath)
        {
            consoleControl.WriteInput("cd " + relativePath, Color.White, false);
        }

        private void FireOnDirChange(string relativePath)
        {
            OnDirChange?.Invoke(this, new DirChangeArgs(relativePath));
        }

        public event DirChangeEventHandler OnDirChange;
    }
}
