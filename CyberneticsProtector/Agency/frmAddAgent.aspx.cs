using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Drawing;

namespace CyberneticsProtector.Agency
{
    public partial class frmAddAgent : System.Web.UI.Page
    {
        bool Avail = false;
        //byte[] _photo;
        string strUserId = "",strPassword="";
        BusinessLayer BL = new BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] GenerateList = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                Random r = new Random();
                strUserId = "Agent";
                //for (int i = 0; i < 6; i++)
                //{
                //    int j;
                //    j = r.Next(GenerateList.Length);
                //    strUserId += GenerateList[j];
                //}
                string[] GenerateList1 = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                for (int i = 0; i < 6; i++)
                {
                    int j;
                    j = r.Next(GenerateList1.Length);
                    strPassword += GenerateList[j];
                }
                    BL.LoginId = strUserId;
                    BL.UserId = BL.GetUserId();
                    BL.PassWord = strPassword;
                    BL.FirstName = txtFName.Text;
                    BL.LastName = txtLName.Text;
                    BL.DateOfBirth =Convert.ToDateTime(txtDOB1.Text);
                    BL.Address = txtAddress.Text;
                    BL.ContactNo = txtPhoneNo.Text;
                    BL.EmailId = txtEmailId.Text;
                    BL.FileContent = globalFunctions.UploadFile(FileUpload1);
                    BL.FileName = FileUpload1.FileName;
                    BL.AgencyId = Convert.ToInt32(Session["UserId"].ToString());
                    bool Result = BL.InsertAgentRegistration();
                    if (Result == false)
                    {
                        lblMessage.Text = "Agent Registration Failed....Try Again";
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Agent Registration Successfully...";
                        lblMessage.ForeColor = Color.Green;
                        lblMessage.Visible = true;
                        string body="Your UserName="+strUserId+" and Password="+strPassword+"";
                        globalFunctions.sendMail("admin@gmail.com", txtEmailId.Text, "Check Your Password", body);
                    }
                //else
                //{
                //    lblId.Text = "LoginId Already Exists...You are Enter Another Name";
                //    lblId.ForeColor = Color.Red;
                //    lblId.Visible = true;
                //    txtLoginId.Text = "";
                //}
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
            finally
            {

            }

        }
        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            globalFunctions.ResetControls(this);
        }
    }
}