using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace TerminalForBeginners
{
    internal class FileBrowserProvider
    {
        public TreeView Tree;

        public FileBrowserProvider()
        {
            Tree = null;
        }

        public FileBrowserProvider(TreeView tree)
        {
            Tree = tree;
        }

        public void PopulateTree()
        {
            DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            PopulateTree(info);
        }

        public void PopulateTree(DirectoryInfo info)
        {
            if (info.Exists)
            {
                WorkingDirectory = info;
                TreeNode rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                AddChildNodes(rootNode);
                AddGrandchildNodes(rootNode);
                RootFileBrowser(rootNode);
                rootNode.Expand();
            }
        }

        public void ReRootTree(string path)
        {
            path = path.TrimStart();
            if (!path.Contains(':') && !path.StartsWith("\\") && !path.StartsWith("/"))
            {
                path = WorkingDirectory.FullName + '\\' + path;
            }
            DirectoryInfo info;
            try
            {
                info = new DirectoryInfo(path);
            }
            catch (DirectoryNotFoundException ex)
            { return; }
            PopulateTree(info);
        }

        public void AddChildNodes(TreeNode node)
        {
            DirectoryInfo info = (DirectoryInfo)node.Tag;
            if (node.Nodes.Count == 0 && info.Exists)
            {
                try
                {
                    AddNodesFromDirectoryInfos(node, info.GetDirectories());
                }
                catch (UnauthorizedAccessException ex)
                {
                    
                }
            }
        }
        public void AddGrandchildNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                DirectoryInfo childInfo = (DirectoryInfo)childNode.Tag;
                if (childNode.Nodes.Count == 0 && childInfo.Exists)
                {
                    try
                    {
                        AddNodesFromDirectoryInfos(childNode, childInfo.GetDirectories());
                    }
                    catch(UnauthorizedAccessException ex)
                    {

                    }
                    catch(DirectoryNotFoundException ex)
                    {
                        node.Nodes.Remove(childNode);
                        AddGrandchildNodes(node);
                        return;
                    }
                }
            }
        }

        public bool RootHasParent()
        {
            DirectoryInfo treeRootInfo = Tree.Nodes[0].Tag as DirectoryInfo;
            return treeRootInfo.Parent != null;
        }

        public string GetPathFromNode(TreeNode node)
        {
            int firstBackslashIndex = node.FullPath.IndexOf('\\');
            if (firstBackslashIndex == -1)
                return "";
            return node.FullPath.Remove(0, firstBackslashIndex + 1);
        }

        private void AddNodesFromDirectoryInfos(TreeNode nodeToAddTo, DirectoryInfo[] infos)
        {
            foreach (DirectoryInfo info in infos)
            {
                if (!info.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    TreeNode childNode = new TreeNode(info.Name);
                    childNode.Tag = info;
                    nodeToAddTo.Nodes.Add(childNode);
                }
            }
        }

        private void RootFileBrowser(TreeNode node)
        {
            Tree.Nodes.Clear();
            Tree.Nodes.Add(node);
        }

        public DirectoryInfo WorkingDirectory
        {
            get { return _workingDirectory; }
            private set { _workingDirectory = value; }
        }

        private DirectoryInfo _workingDirectory;
    }
}
