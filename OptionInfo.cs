namespace TerminalForBeginners
{
    internal class OptionInfo
    {
        private string _name;
        private string _text;
        private string _description;
        private bool _required;
        private bool _needTextBox;
        private bool _needBrowseButton;

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

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }

        public bool NeedTextBox
        {
            get { return _needTextBox; }
            set { _needTextBox = value; }
        }

        public bool NeedBrowseButton
        {
            get { return _needBrowseButton; }
            set { _needBrowseButton = value; }
        }
    }
}
