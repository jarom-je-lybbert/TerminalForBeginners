using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalForBeginners
{
    internal class CommandInfo
    {
        private string _command;
        private string _description;
        private List<OptionInfo> _options;

        CommandInfo() {
            _options = new List<OptionInfo>();
        }

        CommandInfo(string command, string description, List<OptionInfo> options)
        {
            _command = command;
            _description = description;
            _options = options;
        }

        public string Command
        { 
            get => _command;
            set => _command = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public List<OptionInfo> Options
        {
            get => _options;
            set => _options = value;
        }

        public void addOption(OptionInfo newOption)
        {
            _options.Add(newOption);
        }

        public override string ToString()
        {
            return Command;
        }
    }
}
