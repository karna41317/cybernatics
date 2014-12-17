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
    public partial class frmViewCaseDetails : System.Web.UI.Page
    {
        BusinessLayer obj = new BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCaseDetails();
            }

        }

        private void GetCaseDetails()
        {
            DataTable dtCaseDetails = obj.GetCaseDetails();
            gvCase.DataSource = dtCaseDetails;
            gvCase.DataBind();
        }
    }
}