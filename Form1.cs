﻿using System;
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
            this.backButton.Click += BackButton_Click;
            if (_fileBrowserProvider.RootHasParent())
                this.backButton.Enabled = true;
            else
                this.backButton.Enabled = false;

            this.FormClosing +=
                new FormClosingEventHandler(this.FormClosingHandler);
            this.stopButton.Click += StopButton_Click;

            _consoleController = new ConsoleController(consoleControl);
            _consoleController.StartConsole();

            _commandListManager = new CommandListManager();
            PopulateCommandLists();
        }

        void directoryTree_NodeMouseClick(object sender,
        TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            _consoleController.PutConsoleInput("cd " + _fileBrowserProvider.GetPathFromNode(newSelected));
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
                fileView.Items.Add(item);
            }

            fileView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void directoryTree_NodeDoubleMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _fileBrowserProvider.ReRootTree(e.Node);
            if (!backButton.Enabled && _fileBrowserProvider.RootHasParent())
                backButton.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _fileBrowserProvider.ReRootTreeToParent();
            if (!_fileBrowserProvider.RootHasParent())
                backButton.Enabled = false;
            updateFileView(directoryTree.Nodes[0]);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            
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
