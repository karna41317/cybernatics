using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Drawing;

namespace CyberneticsProtector.Defense
{
    public partial class frmAddCaseDetails : System.Web.UI.Page
    {
        BusinessLayer obj = new BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                obj.CaseName = txtCaseName.Text;
                obj.Description = txtDescription.Text;
                obj.FileContent = globalFunctions.UploadFile(FileUpload1);
                obj.FileName = FileUpload1.FileName;
                int Result = obj.InsertCaseDetails();
                if (Result > 0)
                {
                    lblMessage.Text = "Case Registration Successfully...";
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Case Registration Failed....Try Again";
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
    }
}