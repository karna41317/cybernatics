using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Drawing;

namespace CyberneticsProtector.Defense
{
    public partial class frmCaseAssignToAgency : System.Web.UI.Page
    {
        BusinessLayer obj = new BusinessLayer();
        static int Result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCaseDetails();
                GetAgencyDetailsForCase();
            }
        }

        private void GetCaseDetails()
        {
            DataTable dtCaseDetails = obj.GetCaseDetails();
            globalFunctions.BindDropDownList(ddlCase, dtCaseDetails, "CaseId", "CaseName");
        }

        private void GetAgencyDetailsForCase()
        {
            DataTable dtCaseDetails = obj.GetAgencyDetailsForCase();
            globalFunctions.BindDropDownList(ddlAgency, dtCaseDetails, "UserId", "Name");
        }

        protected void BtnCase_Click(object sender, EventArgs e)
        {
            try
            {
                obj.CaseId = Convert.ToInt32(ddlCase.SelectedValue);
                obj.AgencyId = Convert.ToInt32(ddlAgency.SelectedValue);
                Result = obj.AssignCaseToAgency();
                if (Result > 0)
                {
                    lblMessage.Text = "Case Assigned Successfully...";
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

        protected void BtnClear_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}