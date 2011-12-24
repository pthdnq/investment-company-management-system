using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class Menu : BasePage
    {
        /// <summary>
        /// UserID
        /// </summary>
        public string UserID
        {
            get
            {
                if (ViewState["UserID"] == null)
                {
                    return null;
                }

                return ViewState["UserID"].ToString();
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserID = Request.QueryString["ID"];

                BindTree();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定树
        /// </summary>
        private void BindTree()
        {
            UserManage _manage = new UserManage();
            UserInfo _info = _manage.GetUserByObjectID(UserID);
            if (_info != null)
            {
                string[] arrayParentNodes = _info.Menu.Split(';');
                foreach (string parentItem in arrayParentNodes)
                {
                    if (!string.IsNullOrEmpty(parentItem))
                    {
                        string[] arrayNodes = parentItem.Split('$');
                        ExtAspNet.TreeNode parentNode = FindTreeNodeByID(arrayNodes[0]);
                        if (parentNode != null)
                        {
                            parentNode.Checked = true;
                        }
                        arrayNodes = arrayNodes[1].Split(',');
                        foreach (string item in arrayNodes)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                ExtAspNet.TreeNode node = FindTreeNodeByID(item.Split(':')[0]);
                                int value = Convert.ToInt32(item.Split(':')[1]);
                                if (node != null)
                                {
                                    node.Checked = true;
                                    switch (value)
                                    {
                                        case 1:
                                            node.Nodes[0].Checked = true;
                                            break;
                                        case 2:
                                            node.Nodes[1].Checked = true;
                                            break;
                                        case 3:
                                            node.Nodes[0].Checked = true;
                                            node.Nodes[1].Checked = true;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private ExtAspNet.TreeNode FindTreeNodeByID(string nodeID)
        {
            if (string.IsNullOrEmpty(nodeID))
                return null;

            foreach (ExtAspNet.TreeNode node in rootNode.Nodes)
            {
                if (node.NodeID == nodeID)
                    return node;
                foreach (ExtAspNet.TreeNode subNode in node.Nodes)
                {
                    if (subNode.NodeID == nodeID)
                        return subNode;
                }
            }

            return null;
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

        /// <summary>
        /// 获取已选中的节点的值
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetSelectedNodes(ExtAspNet.TreeNode node)
        {
            if (node == null)
                return string.Empty;

            string nodesValue = string.Empty;
            //if (node.Checked)
            //{
            //    if (node.Nodes.Count > 0)
            //    {
            //        if (node.Nodes[0].Leaf)
            //        {

            //        }
            //    }
            //}

            return nodesValue;
        }

        #endregion

        #region 页面事件

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
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SaveEvent(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserID))
                return;

            UserManage _manage = new UserManage();
            UserInfo _info = _manage.GetUserByObjectID(UserID);
            if (_info != null)
            {
                string nodesValue = string.Empty;
                bool isParentChecked = false;
                foreach (ExtAspNet.TreeNode node in rootNode.Nodes)
                {
                    isParentChecked = false;
                    foreach (ExtAspNet.TreeNode subNode in node.Nodes)
                    {
                        if (subNode.Checked)
                        {
                            if (isParentChecked == false)
                            {
                                nodesValue += node.NodeID + "$";
                                isParentChecked = true;
                            }

                            nodesValue += subNode.NodeID + ":";
                            int i = 0;
                            if (subNode.Nodes[0].Checked)
                                i += 1;
                            if (subNode.Nodes[1].Checked)
                                i += 2;
                            nodesValue += i.ToString() + ",";
                        }
                    }
                    if (isParentChecked)
                        nodesValue += ";";
                }

                _info.Menu = nodesValue;
                int result = _manage.UpdateUser(_info);
                if (result == -1)
                {
                    this.CloseEvent(null, null);
                }
                else
                {
                    Alert.Show("保存菜单失败!");
                }
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseEvent(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        #endregion
    }
}