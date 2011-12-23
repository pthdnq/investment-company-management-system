using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class Menu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Menu_NodeCheck(object sender, ExtAspNet.TreeCheckEventArgs e)
        {
            if (!e.Node.Leaf)
            {
                CheckTreeNode(e.Node.Nodes, e.Checked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="isChecked"></param>
        private void CheckTreeNode(ExtAspNet.TreeNodeCollection nodes, bool isChecked)
        {
            foreach (ExtAspNet.TreeNode node in nodes)
            {
                node.Checked = isChecked;
                if (!node.Leaf)
                {
                    CheckTreeNode(node.Nodes, isChecked);
                }
            }

        }
    }
}