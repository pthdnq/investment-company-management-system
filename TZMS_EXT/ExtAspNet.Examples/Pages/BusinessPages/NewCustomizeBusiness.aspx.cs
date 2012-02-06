using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business.BusinessManage;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class NewCustomizeBusiness : BasePage
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 报销单ID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }

                return ViewState["ApplyID"].ToString();
            }
            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        /// <summary>
        /// 报销单ID
        /// </summary>
        public bool IsComplete
        {
            get
            {
                if (ViewState["CurrentState"] == null)
                {
                    return false;
                }

                return Convert.ToBoolean(ViewState["CurrentState"]);
            }
            set
            {
                ViewState["CurrentState"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OperatorType = Request.QueryString["Type"];
                ApplyID = Request.QueryString["ID"];

                switch (OperatorType)
                {
                    case "Add":
                        tabOperateHistory.Hidden = true;
                        BindSigner();
                        imgBalanceMoney.Hidden = true;
                        imgPreMoney.Hidden = true;
                        dpkSignTime.SelectedDate = DateTime.Now;
                        tbxCostMoney.Enabled = false;
                        tbxOtherMoney.Enabled = false;
                        taaOtherMoneyExplain.Readonly = true;
                        break;

                    case "View":
                        BindSigner();
                        BindBusinessInfo();
                        BindOperateHistory();
                        DisableAllControls();
                        break;

                    case "Change":
                        BindSigner();
                        BindBusinessInfo();
                        BindOperateHistory();
                        DisableAllControls();
                        btnSubmit.Enabled = true;
                        tbxCostMoney.Enabled = true;
                        tbxOtherMoney.Enabled = true;
                        taaOtherMoneyExplain.Enabled = false;
                        break;

                    case "Edit":
                        BindSigner();
                        BindBusinessInfo();
                        BindOperateHistory();
                        tbxCostMoney.Enabled = false;
                        tbxOtherMoney.Enabled = false;
                        taaOtherMoneyExplain.Enabled = false;
                        break;

                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定签订人
        /// </summary>
        private void BindSigner()
        {
            ddlstSigner.Items.Clear();

            //if (!CurrentChecker.Contains(CurrentUser))
            //{
                ddlstSigner.Items.Add(new ExtAspNet.ListItem(CurrentUser.Name, CurrentUser.ObjectId.ToString()));
            //}

            //foreach (UserInfo user in CurrentChecker)
            //{
            //    ddlstSigner.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            //}

            ddlstSigner.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定业务信息
        /// </summary>
        private void BindBusinessInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(ApplyID);
            if (_info != null)
            {
                ddlstSigner.SelectedValue = _info.SignerID.ToString();
                dpkSignTime.SelectedDate = _info.SignTime;
                tbxCompanyName.Text = _info.CompanyName;
                tbxSumMoney.Text = _info.SumMoney.ToString();
                tbxPreMoney.Text = _info.PreMoney.ToString();
                tbxBalanceMoney.Text = _info.BalanceMoney.ToString();
                tbxContact.Text = _info.Contact;
                tbxContactPhoneNumber.Text = _info.ContactPhoneNumber;
                tbxCostMoney.Text = _info.CostMoney.ToString();
                tbxOtherMoney.Text = _info.OtherMoney.ToString();
                taaOtherMoneyExplain.Text = _info.OtherMoneyExplain;
                taaContent.Text = _info.Content;
                taaOther.Text = _info.Other;

                if (_info.BalanceMoneyType != 1)
                    imgBalanceMoney.Hidden = true;
                if (_info.PreMoneyType != 1)
                    imgPreMoney.Hidden = true;

                if (_info.State >= 1)
                    IsComplete = true;

                // 多选框.
                string[] arrayCells = _info.BusinessCells.Split(',');
                foreach (string cell in arrayCells)
                {
                    if (!string.IsNullOrEmpty(cell))
                    {
                        switch (cell)
                        {
                            case "1":
                                cbxCMBG.Checked = true;
                                cbxCMBG.Enabled = IsComplete;
                                if (!IsComplete)
                                {
                                    cbxZCZBBG.Checked = false;
                                    cbxZCZBBG.Enabled = false;
                                }
                                break;
                            case "2":
                                cbxGDMCBG.Checked = true;
                                cbxGDMCBG.Enabled = IsComplete;
                                break;
                            case "3":
                                cbxZCZBBG.Checked = true;
                                cbxZCZBBG.Enabled = IsComplete;
                                if (!IsComplete)
                                {
                                    cbxCMBG.Checked = false;
                                    cbxCMBG.Enabled = false;
                                    cbxGDBG.Checked = false;
                                    cbxGDBG.Enabled = false;
                                }
                                break;
                            case "4":
                                cbxJYCSBG.Checked = true;
                                cbxJYCSBG.Enabled = IsComplete;
                                break;
                            case "5":
                                cbxFDDBRBG.Checked = true;
                                cbxFDDBRBG.Enabled = IsComplete;
                                break;
                            case "6":
                                cbxGDBG.Checked = true;
                                cbxGDBG.Enabled = IsComplete;
                                if (!IsComplete)
                                {
                                    cbxZCZBBG.Checked = false;
                                    cbxZCZBBG.Enabled = false;
                                }
                                break;
                            case "7":
                                cbxSSZBBG.Checked = true;
                                cbxSSZBBG.Enabled = IsComplete;
                                break;
                            case "8":
                                cbxGSLXBG.Checked = true;
                                cbxGSLXBG.Enabled = IsComplete;
                                break;
                            case "9":
                                cbxYYQXBG.Checked = true;
                                cbxYYQXBG.Enabled = IsComplete;
                                break;
                            case "10":
                                cbxJYFWBG.Checked = true;
                                cbxJYFWBG.Enabled = IsComplete;
                                break;
                            case "11":
                                cbxZXDJ.Checked = true;
                                cbxZXDJ.Enabled = IsComplete;
                                break;
                            case "12":
                                cbxFGSBG.Checked = true;
                                cbxFGSBG.Enabled = IsComplete;
                                break;
                            case "13":
                                cbxFGSZX.Checked = true;
                                cbxFGSZX.Enabled = IsComplete;
                                break;
                            case "14":
                                cbxZCNJ.Checked = true;
                                cbxZCNJ.Enabled = IsComplete;
                                break;
                            case "15":
                                cbxTSNJ.Checked = true;
                                cbxTSNJ.Enabled = IsComplete;
                                break;
                            case "16":
                                cbxJTYWBL.Checked = true;
                                cbxJTYWBL.Enabled = IsComplete;
                                break;
                            default:
                                break;
                        }
                    }
                }

                // 杂项.
                if (_info.CheckOther == "1")
                    CheckBox1.Checked = true;
            }
        }

        /// <summary>
        /// 绑定操作历史
        /// </summary>
        private void BindOperateHistory()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            BusinessManage _manage = new BusinessManage();
            List<BusinessRecordInfo> lstRecord = _manage.GetBusinessRecordByCondition(" BusinessID = '" + ApplyID + "' and State >= 1 order by CheckDateTime desc");

            lstRecord.Sort(delegate(BusinessRecordInfo x, BusinessRecordInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridoperateHistory.RecordCount = lstRecord.Count;
            this.gridoperateHistory.DataSource = lstRecord;
            this.gridoperateHistory.DataBind();

        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisableAllControls()
        {
            btnSubmit.Enabled = false;
            ddlstSigner.Required = false;
            ddlstSigner.ShowRedStar = false;
            ddlstSigner.Enabled = false;
            dpkSignTime.Required = false;
            dpkSignTime.ShowRedStar = false;
            dpkSignTime.Enabled = false;
            tbxCompanyName.Required = false;
            tbxCompanyName.ShowRedStar = false;
            tbxCompanyName.Enabled = false;
            tbxContact.Enabled = false;
            tbxContactPhoneNumber.Enabled = false;
            tbxSumMoney.Required = false;
            tbxSumMoney.ShowRedStar = false;
            tbxSumMoney.Enabled = false;
            tbxPreMoney.Required = false;
            tbxPreMoney.ShowRedStar = false;
            tbxPreMoney.Enabled = false;
            tbxBalanceMoney.Required = false;
            tbxBalanceMoney.ShowRedStar = false;
            tbxBalanceMoney.Enabled = false;
            CheckBox1.Enabled = false;
            tbxCostMoney.Enabled = false;
            tbxOtherMoney.Enabled = false;
            taaOtherMoneyExplain.Readonly = true;
            taaContent.Required = false;
            taaContent.ShowRedStar = false;
            taaContent.Enabled = false;
            taaOther.Enabled = false;
            cbxCMBG.Enabled = false;
            cbxGDMCBG.Enabled = false;
            cbxZCZBBG.Enabled = false;
            cbxJYCSBG.Enabled = false;
            cbxFDDBRBG.Enabled = false;
            cbxGDBG.Enabled = false;
            cbxSSZBBG.Enabled = false;
            cbxGSLXBG.Enabled = false;
            cbxYYQXBG.Enabled = false;
            cbxJYFWBG.Enabled = false;
            cbxZXDJ.Enabled = false;
            cbxFGSBG.Enabled = false;
            cbxFGSZX.Enabled = false;
            cbxZCNJ.Enabled = false;
            cbxTSNJ.Enabled = false;
            cbxJTYWBL.Enabled = false;
        }

        /// <summary>
        /// 保存普通业务信息
        /// </summary>
        private void SaveBusinessInfo()
        {
            if (string.IsNullOrEmpty(OperatorType))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = null;
            int result = 3;

            string strCell = GetCells();
            if (string.IsNullOrEmpty(strCell))
            {
                Alert.Show("请选择业务!");
                return;
            }

            if (OperatorType == "Add")
            {
                // 创建业务实例.
                _info = new BusinessInfo();
                _info.ObjectID = Guid.NewGuid();
                _info.CreaterID = CurrentUser.ObjectId;
                _info.CreaterName = CurrentUser.Name;
                _info.CreaterAccountNo = CurrentUser.AccountNo;
                _info.CreaterDept = CurrentUser.Dept;
                _info.CreateTime = DateTime.Now;
                _info.SignerID = new Guid(ddlstSigner.SelectedValue);
                _info.SignerName = ddlstSigner.SelectedText;
                _info.SignTime = Convert.ToDateTime(dpkSignTime.SelectedDate);
                _info.CompanyName = tbxCompanyName.Text.Trim();
                _info.SumMoney = Convert.ToDecimal(tbxSumMoney.Text.Trim());
                _info.PreMoney = Convert.ToDecimal(tbxPreMoney.Text.Trim());
                _info.BalanceMoney = Convert.ToDecimal(tbxBalanceMoney.Text.Trim());
                _info.Contact = tbxContact.Text.Trim();
                _info.ContactPhoneNumber = tbxContactPhoneNumber.Text.Trim();
                _info.CostMoney = 0;
                _info.OtherMoney = 0;
                _info.OtherMoneyExplain = "";
                _info.Content = taaContent.Text.Trim();
                _info.Other = taaOther.Text.Trim();
                _info.State = 0;
                _info.CurrentUserID = CurrentUser.ObjectId;
                _info.IsDelete = false;
                _info.BusinessCells = strCell;
                _info.BusinessType = 1;

                // 杂项.
                if (CheckBox1.Checked)
                    _info.CheckOther = "1";

                // 创建签订记录.
                BusinessRecordInfo _recordInfo = new BusinessRecordInfo();
                _recordInfo.ObjectID = Guid.NewGuid();
                _recordInfo.CheckerID = CurrentUser.ObjectId;
                _recordInfo.CheckerName = CurrentUser.Name;
                _recordInfo.CheckDateTime = _info.CreateTime;
                _recordInfo.State = 1;
                _recordInfo.CurrentBusiness = 0;
                _recordInfo.BusinessID = _info.ObjectID;

                _manage.AddNewBusinessRecord(_recordInfo);

                // 创建待办理记录.
                _recordInfo = new BusinessRecordInfo();
                _recordInfo.ObjectID = Guid.NewGuid();
                _recordInfo.CheckerID = CurrentUser.ObjectId;
                _recordInfo.CheckerName = CurrentUser.Name;
                _recordInfo.State = 0;
                _recordInfo.CurrentBusiness = Convert.ToInt32(_info.BusinessCells.Split(',')[0]);
                _recordInfo.BusinessID = _info.ObjectID;

                _manage.AddNewBusinessRecord(_recordInfo);

                _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                result = _manage.AddNewBusiness(_info);
            }
            else if (OperatorType == "Edit")
            {
                _info = _manage.GetBusinessByObjectID(ApplyID);
                if (_info != null)
                {
                    _info.SignerID = new Guid(ddlstSigner.SelectedValue);
                    _info.SignerName = ddlstSigner.SelectedText;
                    _info.SignTime = Convert.ToDateTime(dpkSignTime.SelectedDate);
                    _info.CompanyName = tbxCompanyName.Text.Trim();
                    _info.SumMoney = Convert.ToDecimal(tbxSumMoney.Text.Trim());
                    _info.PreMoney = Convert.ToDecimal(tbxPreMoney.Text.Trim());
                    _info.BalanceMoney = Convert.ToDecimal(tbxBalanceMoney.Text.Trim());
                    _info.Contact = tbxContact.Text.Trim();
                    _info.ContactPhoneNumber = tbxContactPhoneNumber.Text.Trim();
                    _info.CostMoney = 0;
                    _info.OtherMoney = 0;
                    _info.OtherMoneyExplain = "";
                    _info.Content = taaContent.Text.Trim();
                    _info.Other = taaOther.Text.Trim();
                    _info.State = 0;
                    _info.CurrentUserID = CurrentUser.ObjectId;
                    _info.IsDelete = false;
                    _info.BusinessType = 1;
                    _info.BusinessCells += "," + strCell;

                    // 创建待办理记录.
                    BusinessRecordInfo _recordInfo = null;
                    if (CheckBox1.Checked)
                        _info.CheckOther = "1";

                    if (_info.State != 0)
                    {
                        _recordInfo = new BusinessRecordInfo();
                        _recordInfo.ObjectID = Guid.NewGuid();
                        _recordInfo.CheckerID = CurrentUser.ObjectId;
                        _recordInfo.CheckerName = CurrentUser.Name;
                        _recordInfo.State = 0;
                        _recordInfo.CurrentBusiness = Convert.ToInt32(_info.BusinessCells.Split(',')[0]); ;
                        _recordInfo.BusinessID = _info.ObjectID;

                        _manage.AddNewBusinessRecord(_recordInfo);

                        _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                    }
                    
                    result = _manage.UpdateBusiness(_info);
                }
            }
            else if (OperatorType == "Change")
            {
                _info = _manage.GetBusinessByObjectID(ApplyID);
                if (_info != null)
                {
                    string strExplain = string.Empty;
                    strExplain = "业务总监" + CurrentUser.Name;
                    if (Decimal.Compare(_info.CostMoney, Convert.ToDecimal(tbxCostMoney.Text.Trim())) != 0)
                    {
                        _info.CostMoney = Convert.ToDecimal(tbxCostMoney.Text.Trim());
                        strExplain += "变更成本金额为" + _info.CostMoney.ToString() + "元";
                    }

                    if (Decimal.Compare(_info.OtherMoney, Convert.ToDecimal(tbxOtherMoney.Text.Trim())) != 0)
                    {
                        if (strExplain != "业务总监" + CurrentUser.Name)
                        {
                            strExplain += ",";
                        }
                        _info.OtherMoney = Convert.ToDecimal(tbxOtherMoney.Text.Trim());
                        strExplain += "变更其它金额为" + _info.OtherMoney.ToString() + "元";
                    }

                    if (strExplain != "业务总监" + CurrentUser.Name)
                    {
                        strExplain += ";";
                        taaOtherMoneyExplain.Text += strExplain;
                        _info.OtherMoneyExplain += strExplain;
                    }

                    result = _manage.UpdateBusiness(_info);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("创建定制业务失败!");
            }
        }

        /// <summary>
        /// 根据已选择的多选框获取Cells
        /// </summary>
        /// <returns></returns>
        private string GetCells()
        {
            string strCells = string.Empty;

            if (cbxCMBG.Checked)
            {
                strCells += strCells.Length == 0 ? "1" : ",1";
            }
            if (cbxGDMCBG.Checked)
            {
                strCells += strCells.Length == 0 ? "2" : ",2";
            }
            if (cbxZCZBBG.Checked)
            {
                strCells += strCells.Length == 0 ? "3" : ",3";
            }
            if (cbxJYCSBG.Checked)
            {
                strCells += strCells.Length == 0 ? "4" : ",4";
            }
            if (cbxFDDBRBG.Checked)
            {
                strCells += strCells.Length == 0 ? "5" : ",5";
            }
            if (cbxGDBG.Checked)
            {
                strCells += strCells.Length == 0 ? "6" : ",6";
            }
            if (cbxSSZBBG.Checked)
            {
                strCells += strCells.Length == 0 ? "7" : ",7";
            }
            if (cbxGSLXBG.Checked)
            {
                strCells += strCells.Length == 0 ? "8" : ",8";
            }
            if (cbxYYQXBG.Checked)
            {
                strCells += strCells.Length == 0 ? "9" : ",9";
            }
            if (cbxJYFWBG.Checked)
            {
                strCells += strCells.Length == 0 ? "10" : ",10";
            }
            if (cbxZXDJ.Checked)
            {
                strCells += strCells.Length == 0 ? "11" : ",11";
            }
            if (cbxFGSBG.Checked)
            {
                strCells += strCells.Length == 0 ? "12" : ",12";
            }
            if (cbxFGSZX.Checked)
            {
                strCells += strCells.Length == 0 ? "13" : ",13";
            }
            if (cbxZCNJ.Checked)
            {
                strCells += strCells.Length == 0 ? "14" : ",14";
            }
            if (cbxTSNJ.Checked)
            {
                strCells += strCells.Length == 0 ? "15" : ",15";
            }
            if (cbxJTYWBL.Checked)
            {
                strCells += strCells.Length == 0 ? "16" : ",16";
            }

            return strCells;
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 名称变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxCMBG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCMBG.Checked)
            {
                if (cbxZCZBBG.Checked)
                {
                    Alert.Show("增资和名称不可同时变更!");
                }
                if (IsComplete)
                    cbxZCZBBG.Checked = !cbxCMBG.Checked;
            }
        }

        /// <summary>
        /// 增资变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxZCZBBG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxZCZBBG.Checked)
            {
                if (cbxCMBG.Checked)
                {
                    Alert.Show("增资和名称不可同时变更!");
                }
                if (cbxGDBG.Checked)
                {
                    Alert.Show("增资和股权不可同时变更!");
                }

                if (!IsComplete)
                {
                    cbxCMBG.Checked = !cbxZCZBBG.Checked;
                    cbxGDBG.Checked = !cbxZCZBBG.Checked;
                }
            }
        }

        /// <summary>
        /// 股权变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxGDBG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGDBG.Checked)
            {
                if (cbxZCZBBG.Checked)
                {
                    Alert.Show("增资和股权不可同时变更!");
                }
                if (!IsComplete)
                    cbxZCZBBG.Checked = !cbxGDBG.Checked;
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveBusinessInfo();
        }

        /// <summary>
        /// 审批历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridoperateHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[2] = new BusinessManage().ConvertBusinessTypeToString(false, Convert.ToInt32(e.Values[2].ToString()));
            }
        }

        #endregion

        protected void tbxPreMoney_TextChanged(object sender, EventArgs e)
        {
            decimal sumMoney = 0;
            if (Decimal.TryParse(tbxSumMoney.Text.Trim(), out sumMoney))
            {
                if (string.IsNullOrEmpty(tbxPreMoney.Text.Trim()))
                {
                    tbxBalanceMoney.Text = sumMoney.ToString();
                }
                else
                {
                    decimal preMoney = 0;
                    if (decimal.TryParse(tbxPreMoney.Text.Trim(), out preMoney))
                    {
                        tbxBalanceMoney.Text = (sumMoney - preMoney).ToString();
                    }
                }

            }
        }
    }
}