using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace CyberneticsProtector
{
    public partial class frmForgotPassword : System.Web.UI.Page
    {
        Login L = new Login();
        BusinessLayer LBAL = new BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LBAL.LoginId = txtUserName.Text;
                LBAL.HintQuestion = ddlHintQuestion.SelectedItem.Text;
                LBAL.Answer = txtAnswer.Text;
                string password = "Your Password: " + LBAL.ForgotPassWord();
                globalFunctions.Alert(password.ToUpper(), Page);
                //Page.RegisterClientScriptBlock("Employee", "<script>alert('Your Password: " + password.ToUpper() + "')</script>");

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message;
            }
            finally
            {

            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            globalFunctions.ResetControls(this);
            txtUserName.Focus();
        }
    }
}