using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace CyberneticsProtector.Defense
{
    public partial class frmAcceptAgency : System.Web.UI.Page
    {
        BusinessLayer obj = new BusinessLayer();
        int UserId, Result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAgencyDetails();
            }

        }

        private void GetAgencyDetails()
        {
            DataTable dtGetAgencyDetails = obj.GetAgencyDetails();
            gvAgency.DataSource = dtGetAgencyDetails;
            gvAgency.DataBind();
        }

        protected void gvAgency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                obj.UserId = Convert.ToInt32(e.CommandArgument.ToString());
                Result = obj.AcceptAgency();
                if (Result > 0)
                {
                    GetAgencyDetails();
                }

            }
        }
    }
}