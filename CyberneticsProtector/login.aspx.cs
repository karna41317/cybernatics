using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Web.Security;
using BAL;

namespace CyberneticsProtector
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.Url.ToString();
            string[] split = url.Split('/');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "Agency")
                {
                    lblLogin.Text = "Agency Login";
                }
                else if (split[i] == "Agent")
                {
                    lblLogin.Text = "Agent Login";
                    //lnkForgot.Visible = true;
                    //lnksignup.Visible = true;
                }
                else if (split[i] == "Defense")
                {
                    lblLogin.Text = "Defense Login";
                    //lnkForgot.Visible = true;
                }
            }
        }

        //protected void btnSignIn_Click(object sender, EventArgs e)
        //{
        //    if (FormsAuthentication.Authenticate(txtLoginId.Text, txtPassWord.Text))
        //    {
        //        Session["UserName"] = txtLoginId.Text.Trim();
        //        Session.Timeout = 60;
        //        FormsAuthentication.RedirectFromLoginPage("Defense", false);
        //    }
            

        //}
        BusinessLayer BL = new BusinessLayer();   
        protected void LoginButton_Click(object sender, ImageClickEventArgs e)
        {
            Session["Id"] = null;
            Session["Name"] = null;
            string str1 = null;
            string[] LoginId = null;
            try
            {
                if (txtLoginId.Text.Contains("/"))
                {
                    string str = txtLoginId.Text;
                    LoginId = str.Split('/');
                    BL.LoginId = LoginId[0].ToString();
                    BL.PassWord = LoginId[1].ToString();
                    str1 = LoginId[0].ToString();
                }
                else
                {
                    BL.LoginId = txtLoginId.Text.Trim();
                    BL.PassWord = txtPassWord.Text.Trim();
                    str1 = txtLoginId.Text.Trim();
                }

                int id;
                if (FormsAuthentication.Authenticate(txtLoginId.Text,txtPassWord.Text))
                {
                    Session["UserName"] = txtLoginId.Text.Trim();
                    Session["Id"] =999;
                    Session.Timeout = 60;
                    FormsAuthentication.RedirectFromLoginPage("Defense", false);
                }
                else
                {
                    string Role = BL.GetUserLogin(out id);
                    if (Role== "Agency")
                    {
                        Session["Id"] = id;
                        Session["UserId"] = id;
                        Session["UserName"] = str1;
                        FormsAuthentication.RedirectFromLoginPage("Agency", false);
                    }
                    else if (Role== "Agent")
                    {
                        Session["Id"] = id;
                        Session["UserId"] = id;
                        Session["UserName"] = str1;
                        FormsAuthentication.RedirectFromLoginPage("Agent", false);
                    }
                    else if (Role == "NoUser")
                        lblMsg.Text = "User Name and PassWord Mismatch....Try again.";
                }

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }

        }
    }
}