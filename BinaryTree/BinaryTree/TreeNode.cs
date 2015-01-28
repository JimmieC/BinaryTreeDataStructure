using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// Treenode Class
    /// </summary>
    class TreeNode
    {
        private int value;
        private TreeNode left;
        private TreeNode right;
        /// <summary>
        /// Constructor for Treenode, initializes variables
        /// </summary>
        /// <param name="value">value of type int</param>
        public TreeNode(int value)
        {
            this.value = value; 
            left = null; 
            right = null;    
        }

        /// <summary>
        /// Property for Value
        /// </summary>
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Property for Left node
        /// </summary>
        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }
        /// <summary>
        /// Property for Right node
        /// </summary>
        public TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
