using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Drawing;
using System.IO;

namespace CyberneticsProtector
{
    public partial class frmAgencyRegistration : System.Web.UI.Page
    {
        bool Avail = false;
        byte[] _photo;
        BusinessLayer BL = new BusinessLayer();        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                lblId.Text = "";
                BL.UserId = BL.GetUserId();
                BL.LoginId = txtLoginId.Text;
                Avail = BL.CheckLoginId(txtLoginId.Text);
                if (Avail == true)
                {
                    BL.LoginId = txtLoginId.Text;
                    BL.PassWord = txtPassword.Text;
                    BL.FirstName = txtFName.Text;
                    BL.LastName = txtLName.Text;
                    BL.HintQuestion = ddlHintQuestion.SelectedItem.Text;
                    BL.Answer = txtAnswer.Text;
                    BL.DateOfBirth = txtDOB.SelectedDate;
                    BL.Address = txtAddress.Text;
                    BL.ContactNo = txtPhoneNo.Text;
                    BL.EmailId = txtEmailId.Text;
                    BL.FileContent = globalFunctions.UploadFile(FileUpload1);
                    BL.FileName = FileUpload1.FileName;
                    bool Result = BL.InsertAgencyRegistration();
                    if (Result == false)
                    {
                        lblMessage.Text = "User Registration Failed....Try Again";
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "User Registration Successfully...";
                        lblMessage.ForeColor = Color.Green;
                        lblMessage.Visible = true;
                    }

                }
                else
                {
                    lblId.Text = "LoginId Already Exists...You are Enter Another Name";
                    lblId.ForeColor = Color.Red;
                    lblId.Visible = true;
                    txtLoginId.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
               
            }

        }
        //private void PreapareByteArray()
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
        //        {
        //            _photo = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);

        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Photo Not Uploded...!");
        //    }

        //}
        protected void btnClear_Click(object sender, EventArgs e)
        {
            //foreach (Control control in Field1.Controls)
            //{
            //    if (control is TextBox)
            //        ((TextBox)control).Text = "";
            //}
            //foreach (Control control in Fieldset1.Controls)
            //{
            //    if (control is TextBox)
            //        ((TextBox)control).Text = "";
            //    if (control is DropDownList)
            //        ((DropDownList)control).SelectedIndex = 0;
            //}
            globalFunctions.ResetControls(this);
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtLoginIdChanged(object sender, EventArgs e)
        {
            //BPELuser.UserLoginId = txtLoginId.Text;
            Avail = BL.CheckLoginId(txtLoginId.Text);
            if (Avail == true)
            {

                lblId.Text = "LoginId Not Exists...Complete Another Data";
                lblId.ForeColor = Color.Green;
                lblId.Visible = true;

            }
            else
            {
                //Page.RegisterClientScriptBlock("gopi", "<script>alert('LoginId Already Exists...You are Enter Another Name')</script>");
                globalFunctions.Alert("LoginId Already Exists...You are Enter Another Name", Page);
                //lblId.Text = "LoginId Already Exists...You are Enter Another Name";
                //lblId.ForeColor = Color.Red;
                //lblId.Visible = true;
                txtLoginId.Text = "";
            }
        }

    }
}