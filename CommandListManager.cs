using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TerminalForBeginners
{
    internal class CommandListManager
    {
        private List<CommandCollection> _commandLists;

        public CommandListManager()
        {
            _commandLists = getCommandListsFromFile();
        }

        public List<CommandCollection> CommandLists
        {
            get { return _commandLists; }
            set { _commandLists = value; }
        }

        private List<CommandCollection> getCommandListsFromFile()
        {
            string commandDataJson = TerminalForBeginners.Properties.Resources.commandData;
            List<CommandCollection> commandCollection = JsonConvert.DeserializeObject<List<CommandCollection>>(commandDataJson);
            return commandCollection;
        }
    }
}
