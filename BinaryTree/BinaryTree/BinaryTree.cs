using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    /// <summary>
    /// Class Binary Tree
    /// </summary>
    class BinaryTree
    {
        /// <summary>
        /// Variables root which will be the root node, numberlist which will hold the values returned by the inordertraversal
        /// </summary>
        private TreeNode root = null;
        private int size = 0;
        List<int> numberlist = new List<int>();

        /// <summary>
        /// Method insert which will add a new node to the tree through the add method unless there isnt a root, then create a root.
        /// </summary>
        /// <param name="value">int value for the tree</param>
        /// <returns>the node created with the param value</returns>
        public TreeNode Insert(int value)
        {
            TreeNode node = new TreeNode(value);
            try
            {
                if (root == null)
                    root = node;
                else Add(node, ref root); size++; return node;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Add method which adds a node to the binary tree
        /// </summary>
        /// <param name="currentNode">current node which the recursive method is in</param>
        /// <param name="previousTreeNode">previous node where the treenode came from</param>
        private void Add(TreeNode currentNode, ref TreeNode previousTreeNode)
        {
            try
            {   
                if (currentNode.Value > previousTreeNode.Value)
                {
                    TreeNode newTreeNode = new TreeNode(currentNode.Value);
                    if (previousTreeNode.Right == null)
                    {
                        previousTreeNode.Right = newTreeNode;
                    }
                    else
                    {
                        bool isNotNull;
                        if (previousTreeNode.Right != null)
                        {
                            isNotNull = true;
                        }
                        else
                        {
                            isNotNull = false;
                        }
                        while (isNotNull)
                        {
                            TreeNode tempNode = new TreeNode(previousTreeNode.Right.Value);
                            tempNode = previousTreeNode.Right;
                            Add(currentNode, ref tempNode);
                            if (currentNode.Right == null)
                            {
                                isNotNull = false;
                            }
                        }
                    }
                }

                if (currentNode.Value < previousTreeNode.Value)
                {
                    TreeNode newTreeNode = new TreeNode(currentNode.Value);
                    if (previousTreeNode.Left == null)
                    {
                        previousTreeNode.Left = newTreeNode;
                    }
                    else
                    {
                        bool isNotNull;
                        if (previousTreeNode.Left != null)
                        {
                            isNotNull = true;
                        }
                        else
                        {
                            isNotNull = false;
                        }
                        while (isNotNull)
                        {
                            TreeNode tempNode = new TreeNode(previousTreeNode.Left.Value);
                            tempNode = previousTreeNode.Left;
                            Add(currentNode, ref tempNode);
                            if (currentNode.Left == null)
                            {
                                isNotNull = false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error!");
            }
        }

        /// <summary>
        /// Method for finding a specified value in the binary tree
        /// </summary>
        /// <param name="value">value which is to be searched for</param>
        /// <param name="root">root which is the root of the binary tree at first and then the previous node as its called recursivly</param>
        /// <returns>this method unless the value is found then root</returns>
        public TreeNode FindValue2(int value, ref TreeNode root)
        {
            if(root == null)
            {
                return null;
            }
            if (root.Value == value)
            {
                MessageBox.Show("Found");
                return root;
            }
            else
            {
                if (value > root.Value)
                {
                    if (root.Right != null)
                    {
                        TreeNode temp = root.Right;
                        return FindValue2(value, ref temp);
                    }
                    else
                    {
                        MessageBox.Show("Not Found");
                        return null;
                    }
                    
                }
                if (value < root.Value)
                {
                    if (root.Left != null)
                    {
                        TreeNode temp = root.Left;
                        return FindValue2(value, ref temp);
                    }
                    else
                    {
                        MessageBox.Show("Not Found");
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("Not Found");
                    return null;
                }
            }
        }

        /// <summary>
        /// Method find parent which finds the parent node of a desired value
        /// </summary>
        /// <param name="value">The value of the node which we search and in return get its parent</param>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public TreeNode FindParent(int value, ref TreeNode parent, ref TreeNode node)
        {
            TreeNode parentnode = parent;
            TreeNode thisnode = node;

            if (node == null)
            {
                return null;
            }
            if (node.Value == value)
            {
                return parentnode;
            }

            if (node.Value > value)
            {
                parentnode = thisnode;
                thisnode = thisnode.Left;
                return FindParent(value, ref parentnode, ref thisnode);
            }

            if (node.Value < value)
            {
                parentnode = thisnode;
                thisnode = thisnode.Right;               
                return FindParent(value, ref parentnode, ref thisnode);
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Meothod to find the most left node on right side of tree
        /// </summary>
        /// <param name="nodeToDelete"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode LeftMostNodeOnRight(TreeNode nodeToDelete, ref TreeNode parent)
        {
            parent = nodeToDelete;
            nodeToDelete = nodeToDelete.Right;
            while (nodeToDelete.Left != null)
            {
                parent = nodeToDelete;
                nodeToDelete = nodeToDelete.Left;
                return nodeToDelete;
            }
            return nodeToDelete;
        }

        /// <summary>
        /// Method to delete a value from the tree and rearange the nodes children(if it has any)
        /// </summary>
        /// <param name="value">Desired value to delete</param>
        public bool Delete(int value)
        {

            TreeNode Parent = FindParent(value, ref root, ref root);

            TreeNode found = FindValue2(value, ref root);
            if (found == null) 
            {
                return false;
            }
  
            if (Parent.Left == found)
            {
                if (found.Left == null && found.Right == null)
                {
                    Parent.Left = null;
                   
                    return true;
                }
                if (found.Left != null && found.Right == null)
                {
                    Parent.Left = found.Left;
                    found = null;
                   
                    return true;
                }
                if (found.Left == null && found.Right != null)
                {
                    Parent.Left =  found.Right;
                    found = null;
                  
                    return true;
                }
                else
                {
                    Parent.Left = found.Right;
                    Add(found.Left, ref root);
                    found = null;
                  
                    return true;
                }
                
            }
            if (Parent.Right == found)
            {
                if (found.Left == null && found.Right == null)
                {
                    Parent.Right = null;
               
                    return true;
                }
                if (found.Left != null && found.Right == null)
                {
                    found.Left = Parent.Right;
                    found = null;

                    return true;
                }
                if (found.Left == null && found.Right != null)
                {
                    found.Right = Parent.Right;
                    found = null;

                    return true;
                }
                else
                {
                    found.Right = Parent.Right;
                    Add(found.Left, ref root);
                    found = null;

                    return true;
                }
            }   
            if (Parent == Root)
            {
                if (Root.Left != null && Root.Right != null)
                {
                    TreeNode Temp = Root.Right;
                    Root = Root.Left;
                    Add(Temp, ref root);
                    return true;
                }
                if (Root.Right != null)
                {
                    Root = Root.Right;
                    return true;
                }
                if  (Root.Left != null)
                {
                    Root = Root.Left;
                    return true;
                }
                Root = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Inorder traversal method which finds all values in the tree and then prints them in order of low to high.
        /// </summary>
        public void InorderTraversal()
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            if(root != null)
            {
                q.Enqueue(root);
                while (q.Count > 0)
                {
                    TreeNode n = q.Dequeue();
                    numberlist.Add(n.Value);

                    if (n.Left != null)
                    {
                        q.Enqueue(n.Left);
                    }
                    if (n.Right != null)
                    {
                        q.Enqueue(n.Right);
                    }

                }
                string test = null;
                numberlist.Sort();
                foreach (int i in numberlist)
                {
                    test += (i + ", ");
                }
                MessageBox.Show(test);
            }
            else
            {
                MessageBox.Show("Binary Tree is Empty");
            }
            numberlist.Clear();
        }


       



        /// <summary>
        /// Propert for the root node
        /// </summary>
        public TreeNode Root
        {
            get { return root; }
            set { root = value; }
        }
    }

    

}
