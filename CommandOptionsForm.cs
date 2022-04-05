using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalForBeginners
{
    public partial class CommandOptionsForm : Form
    {
        public CommandOptionsForm()
        {
            InitializeComponent();
        }

        internal CommandOptionsForm(CommandInfo commandInfo, ConsoleController consoleController)
        {
            InitializeComponent();
            this.consoleController = consoleController;
            checkBoxes = new List<CheckBox>();
            BuildOptionsDisplay(commandInfo);
            okayButton.Click += OkayButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void BuildOptionsDisplay(CommandInfo commandInfo)
        {
            commandInfoLabel.Text = commandInfo.Command;
            commandDescLabel.Text = commandInfo.Description;
            int yLocation = 0;
            foreach (var option in commandInfo.Options)
            {
                Panel optionDisplay = BuildOptionDisplay(option);
                optionDisplay.Location = new Point(0, yLocation);
                optionsPanel.Controls.Add(optionDisplay);
                yLocation += 20;
            }
        }

        private Panel BuildOptionDisplay(OptionInfo optionInfo)
        {
            int nextXLocation = 0;

            Panel panel = new Panel();
            panel.AutoSize = true;
            panel.MaximumSize = new Size(600, 20);

            CheckBox checkBox = new CheckBox();
            checkBox.Height = 15;
            checkBox.Width = 15;
            checkBox.Name = optionInfo.Name;
            checkBox.Location = new Point(nextXLocation, 0);
            checkBox.Text = optionInfo.Text;
            panel.Controls.Add(checkBox);
            checkBoxes.Add(checkBox);
            nextXLocation += checkBox.Width;
           
            if (optionInfo.Required)
            {
                checkBox.Checked = true;
                checkBox.Enabled = false;
            }

            Label textLabel = new Label();
            textLabel.AutoSize = true;
            textLabel.Text = optionInfo.Text;
            textLabel.Location = new Point(nextXLocation, 0);
            textLabel.MaximumSize = new Size(20, 15);
            panel.Controls.Add(textLabel);
            nextXLocation += textLabel.Width;

            TextBox textBox = new TextBox();
            if (optionInfo.NeedTextBox)
            {
                textBox.Location = new Point(nextXLocation, 0);
                textBox.MaximumSize = new Size(50, 15);
                panel.Controls.Add(textBox);
                checkBox.Tag = textBox;
                nextXLocation += textBox.Width;
            }

            Button button = new Button();
            if (optionInfo.NeedBrowseButton)
            {
                button.Location = new Point(nextXLocation, 0);
                button.MaximumSize = new Size(50, 25);
                button.Text = "Browse";
                button.Tag = textBox;
                button.Click += Browse_Button_Click;
                panel.Controls.Add(button);
                nextXLocation += button.Width;
            }

            Label descriptionLabel = new Label();
            descriptionLabel.AutoSize = true;
            descriptionLabel.Text = optionInfo.Name + " - " + optionInfo.Description;
            descriptionLabel.Location = new Point(nextXLocation, 0);
            descriptionLabel.MaximumSize = new Size(600, 15);


        
            panel.Controls.Add(descriptionLabel);
            return panel;
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ((TextBox)((Button)sender).Tag).Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            string resultCommand = commandInfoLabel.Text;
            foreach (CheckBox check in checkBoxes)
            {
                if (check.Checked)
                {
                    if (check.Text != String.Empty)
                    {
                        resultCommand += " " + check.Text;
                    }
                    if (check.Tag != null)
                    {
                        resultCommand += " " + ((TextBox)check.Tag).Text;
                    }
                }
            }
            consoleController.PlaceConsoleInput(resultCommand);
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private ConsoleController consoleController;
        private List<CheckBox> checkBoxes;
    }
}
