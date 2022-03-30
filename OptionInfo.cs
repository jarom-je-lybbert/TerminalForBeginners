using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalForBeginners
{
    internal class OptionInfo
    {
        private string _name;
        private string _text;
        private string _description;
        private bool _textBox;
        private bool _fileBrowse;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool TextBox
        {
            get { return _textBox; }
            set { _textBox = value; }
        }

        public bool FileBrowse
        {
            get { return _fileBrowse; }
            set { _fileBrowse = value; }
        }
    }
}
