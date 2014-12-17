using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace CyberneticsProtector.Agent
{
    public partial class frmChangePassword : System.Web.UI.Page
    {
        BusinessLayer LBAL = new BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LBAL.LoginId = txtUserName.Text.Trim();
                LBAL.PassWord = txtOldPassword.Text.Trim();
                LBAL.NewPassWord = txtNewPassword.Text.Trim();
                int Result = LBAL.ChangePassword();
                if (Result == 1)
                {
                    //Page.RegisterClientScriptBlock("Employee", "<script>alert('Your Password Changed to:" + txtNewPassword.Text.ToUpper() + "')</script>");
                    globalFunctions.Alert("Your Password Changed to: " + txtNewPassword.Text.ToUpper(), Page);
                }
                else if (Result == 2)
                {
                    globalFunctions.Alert("Old Password and New Password Should Be Different", Page);
                }
                else
                {
                    globalFunctions.Alert("Wrong UserName/Password", Page);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message.ToString();
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            globalFunctions.ResetControls(this);
            txtUserName.Focus();
        }
    }
}