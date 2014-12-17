using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Drawing;

namespace CyberneticsProtector.Agency
{
    public partial class frmViewCaseDetails : System.Web.UI.Page
    {
        BusinessLayer obj = new BusinessLayer();
        static int Result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCaseDetailsFromDefense();
                GetAgentDetails();
            }

        }

        private void GetAgentDetails()
        {
            obj.AgencyId = Convert.ToInt32(Session["UserId"].ToString());
            DataTable dtGetAgentDetails = obj.GetAgentDetails();
            globalFunctions.BindDropDownList(ddlAgent, dtGetAgentDetails, "UserId","Name");
            
        }

        private void GetCaseDetailsFromDefense()
        {
            obj.AgencyId = Convert.ToInt32(Session["UserId"].ToString());
            DataTable dtCaseDetailsFromDefense = obj.GetCaseDetailsFromDefense();
            gvCaseFromDefense.DataSource = dtCaseDetailsFromDefense;
            gvCaseFromDefense.DataBind();
        }

        protected void gvCaseFromDefense_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                try
                {
                    obj.CaseId = Convert.ToInt32(e.CommandArgument.ToString());
                    DataTable dtDownload = obj.Download();
                    globalFunctions.DownloadFile(dtDownload, Page);
                }
                catch (Exception ex)
                {
                    //throw new NotImplementedException();
                }
            }
            else if (e.CommandName == "Assign")
            {
                try
                {
                    Session["CaseId"] = Convert.ToInt32(e.CommandArgument.ToString());
                    //Session["CaseId"] = obj.CaseId;
                    this.ModalPopupExtender1.Show();
                    pnlmessage1.Visible = true;
                    
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                obj.AgentId = Convert.ToInt32(ddlAgent.SelectedValue);
                obj.CaseId = Convert.ToInt32(Session["CaseId"].ToString());
                Result = obj.AssignCaseToAgent();
                if (Result > 0)
                {
                    lblMessage.Text = "Case Assigned To Agent Successfully...";
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Case Assigned Failed....Try Again";
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}