using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TerminalForBeginners
{
    public partial class MainForm : Form
    {
        private const int LIST_MARGIN = 10;

        static private FileBrowserProvider _fileBrowserProvider;
        static private ConsoleController _consoleController;
        static private CommandListManager _commandListManager;
        public MainForm()
        {
            InitializeComponent();
            _fileBrowserProvider = new FileBrowserProvider(this.directoryTree);
            _fileBrowserProvider.PopulateTree();
            this.directoryTree.NodeMouseClick +=
                new TreeNodeMouseClickEventHandler(this.directoryTree_NodeMouseClick);
            this.directoryTree.NodeMouseDoubleClick +=
                new TreeNodeMouseClickEventHandler(this.directoryTree_NodeDoubleMouseClick);
            this.fileView.ItemActivate += FileView_ItemActivate;
            this.fileView.ItemSelectionChanged += FileView_ItemSelectionChanged;
            this.backButton.Click += BackButton_Click;
            if (_fileBrowserProvider.RootHasParent())
                this.backButton.Enabled = true;
            else
                this.backButton.Enabled = false;

            this.FormClosing +=
                new FormClosingEventHandler(this.FormClosingHandler);
            this.stopButton.Click += StopButton_Click;
            this.executeButton.Click += ExecuteButton_Click;


            _consoleController = new ConsoleController(consoleControl);
            _consoleController.OnDirChange += _consoleController_OnDirChange;
            _consoleController.StartConsole();

            _commandListManager = new CommandListManager();
            PopulateCommandLists();
        }

        public delegate void DirChangeEventHandler(object sender, DirChangeArgs args);

        void directoryTree_NodeMouseClick(object sender,
        TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            _consoleController.PlaceConsoleInput("cd " + _fileBrowserProvider.GetPathFromNode(newSelected));
            directoryTree.BeginUpdate();
            _fileBrowserProvider.AddGrandchildNodes(newSelected);
            directoryTree.EndUpdate();

            updateFileView(newSelected);
        }

        void FormClosingHandler(Object sender, FormClosingEventArgs e)
        {
            consoleControl.StopProcess();
        }

        /***********************************************
         * Mostly copied from:
         * https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/creating-an-explorer-style-interface-with-the-listview-and-treeview?view=netframeworkdesktop-4.8
         **/
        void updateFileView(TreeNode selectedNode)
        {
            fileView.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)selectedNode.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File")};

                item.SubItems.AddRange(subItems);
                item.Tag = file;
                fileView.Items.Add(item);
            }

            fileView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void FileView_ItemActivate(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            _consoleController.PlaceConsoleInput(PutInQuotes(GetFilePathFromListItem(listView.SelectedItems[0])));
            _consoleController.ExecuteFromConsole();
        }

        private void FileView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _consoleController.PlaceConsoleInput(PutInQuotes(GetFilePathFromListItem(e.Item)));
            }
        }

        private string PutInQuotes(string text)
        {
            return '"' + text + '"';
        }

        private string GetFilePathFromListItem(ListViewItem item)
        {
            FileInfo info = (FileInfo)item.Tag;
            return info.FullName.Remove(0, _fileBrowserProvider.WorkingDirectory.FullName.TrimEnd('\\').Length + 1);
        }

        private void directoryTree_NodeDoubleMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string relativePath = _fileBrowserProvider.GetPathFromNode(e.Node);
            _consoleController.ChangeDirectory(relativePath);
        }

        private void _consoleController_OnDirChange(object sender, DirChangeArgs args)
        {
            ChangeTreeRoot(args.RelativePath);
        }

        private void ChangeTreeRoot(string relativePath)
        {
            _fileBrowserProvider.ReRootTree(relativePath);
            if (_fileBrowserProvider.RootHasParent())
                backButton.Enabled = true;
            else
                backButton.Enabled = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _consoleController.PlaceConsoleInput("cd ..\\");
            _consoleController.ChangeDirectory("..\\");
            updateFileView(directoryTree.Nodes[0]);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _consoleController.StopConsoleProgram();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            _consoleController.ExecuteFromConsole();
        }

        private void PopulateCommandLists()
        {
            int leftSide = 0;
            if (_commandListManager.CommandLists.Count == 0)
                return;
            int distanceBetweenLists = listBoxPanel.Width / _commandListManager.CommandLists.Count;
            int listWidth = distanceBetweenLists - LIST_MARGIN;

            foreach (var commandCollection in _commandListManager.CommandLists)
            {
                var label = new Label();
                var listBox = new ListBox();
                commandCollection.SetupLabel(label, new Point(leftSide, 0));
                listBoxPanel.Controls.Add(label);
                commandCollection.SetupListBox(listBox, new Point(leftSide, label.Height), new Size(listWidth, listBoxPanel.Height - label.Height));
                listBoxPanel.Controls.Add(listBox);
                leftSide += distanceBetweenLists;
            }
        }

    }
}
