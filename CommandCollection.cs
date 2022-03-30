using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TerminalForBeginners
{
    internal class CommandCollection
    {
        private string _name;
        private List<CommandInfo> _commands;

        public CommandCollection()
        {
            Name = "";
            Commands = new List<CommandInfo>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<CommandInfo> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        public void SetupLabel(Label label, Point location)
        {
            label.Text = _name;
            label.Location = location;
        }
        public void SetupListBox(ListBox listBox, Point location, Size size)
        {
            listBox.Items.Clear();
            foreach (var command in _commands)
            {
                listBox.Items.Add(command.Command);
            }
            listBox.Location = location;
            listBox.Size = size;
        }
    }
}
