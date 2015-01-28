using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        //Create object of Binary tree class
        BinaryTree BTree = new BinaryTree();

        /// <summary>
        /// When clicking add in the GUI the insert method is called from binary tree, the txtnumber is tryparsed to get string to int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtNumber.Text != string.Empty)
            {
                int value;
                int.TryParse(txtNumber.Text, out value);

                BTree.Insert(value);
                txtNumber.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
        }

        /// <summary>
        /// Calls the find method from the binary tree, a created node is set to the result of the find mehtod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            int value;
            int.TryParse(txtNumber.Text, out value);
            TreeNode temp = new TreeNode(value);
            TreeNode test = BTree.Root;
            temp = (BTree.FindValue2(value, ref test));

        }

        /// <summary>
        /// Calls the delete method from binarytree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            int.TryParse(txtNumber.Text, out value);
            if(BTree.Delete(value))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("The value was not found");
            }
        }

        /// <summary>
        /// Calls the findparent method from binarytree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int value;
            int.TryParse(txtNumber.Text, out value);
            TreeNode tempnode = BTree.Root;
            TreeNode parentnode = BTree.FindParent(value, ref tempnode, ref tempnode);
            if (parentnode != null)
            {
                MessageBox.Show(parentnode.Value.ToString());
            }
            else
                MessageBox.Show("Not found");
        }

        /// <summary>
        /// Calls the indorder traversal method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            BTree.InorderTraversal();
        }


       

    }
}
