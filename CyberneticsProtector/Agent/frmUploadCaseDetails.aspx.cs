using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace CyberneticsProtector.Agent
{
    public partial class frmUploadCaseDetails : System.Web.UI.Page
    {
        BusinessLayer obj = new BusinessLayer();
        static int Result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCaseDetailsFromDefense();
            }

        }

        private void GetCaseDetailsFromDefense()
        {
            obj.AgentId = Convert.ToInt32(Session["UserId"].ToString());
            DataTable dtCaseDetailsFromAgency = obj.GetCaseDetailsFromAgency();
            gvCaseFromAgency.DataSource = dtCaseDetailsFromAgency;
            gvCaseFromAgency.DataBind();
        }

        protected void gvCaseFromAgency_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    throw new NotImplementedException();
                }
            }
        }
    }
}