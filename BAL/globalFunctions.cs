using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


namespace BAL
{
    public class globalFunctions
    {
        public static void Alert(string str, Page p)
        {
            string scr = "<script type=\"text/javascript\">" + "alert(\"" + str + "\");" + "</script>";
            p.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "scr", scr, false);
        }

        public static void BindDropDownList(DropDownList ddl, DataTable dt, string Value, string TextItem)
        {
            try
            {
                ddl.DataSource = dt;
                ddl.DataTextField = TextItem;
                ddl.DataValueField = Value;
                ddl.DataBind();
                ddl.Items.Insert(0, "--Select--");
                ddl.Items[0].Value = "0";
            }
            catch
            {
                throw new Exception("Not Bind In DropDownList...!");
            }
        }

        public static void BindHintQuestion(DropDownList ddl)
        {
            try
            {
                ddl.Items.Insert(0, "--Select Hint Question--");
                ddl.Items.Insert(1, "What is your pet name?");
                ddl.Items.Insert(2, "What is your father name?");
                ddl.Items.Insert(3, "What is your mother name?");
                ddl.Items.Insert(4, "What is your school name?");
                ddl.Items.Insert(5, "What is your college name?");
            }
            catch
            {
                throw new Exception("Not Bind In DropDownList...!");
            }
        }

        public static void ResetControls(Control Parent)
        {
            foreach (Control C in Parent.Controls)
            {
                if (C.Controls.Count > 0)
                {
                    ResetControls(C);
                }
                else
                {
                    switch (C.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)C).Text = "";
                            break;
                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)C).SelectedIndex = 0;
                            break;
                    }
                }
            }
        }

        public static string sendMail(string fromEmail, string toEmail, string subject, string body)
        {
            MailMessage mailer = new MailMessage();
            mailer.IsBodyHtml = true;
            mailer.From = new MailAddress(fromEmail);
            mailer.To.Add(new MailAddress(toEmail));
            mailer.Subject = subject;
            mailer.Body = body;
            mailer.BodyEncoding = Encoding.GetEncoding(1256);
            SmtpClient smtp = new SmtpClient("localhost");
            try
            {
                smtp.Send(mailer);
                return "ok";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public static string sendMailThroughNet(string YourEmailId, string YourPassword, string ToEmailId, string Password)
        {
            try
            {
                MailMessage msgobj;
                SmtpClient serverobj = new SmtpClient();
                serverobj.Credentials = new NetworkCredential(YourEmailId, YourPassword);
                serverobj.Port = 25;
                serverobj.Host = "Smtp.gmail.com";
                serverobj.EnableSsl = true;
                msgobj = new MailMessage();
                msgobj.From = new MailAddress(YourEmailId, "Hyderbad", System.Text.Encoding.UTF8);
                msgobj.To.Add(ToEmailId);
                msgobj.Subject = "Checking Your PassWord";
                msgobj.Body = "Your Password Is:" + Password;
                msgobj.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                serverobj.Send(msgobj);
                return "ok";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public static string RandomNumber()
        {
            Random num = new Random();
            return num.Next(45678).ToString();
        }

        public static string RandomPassword()
        {
            string[] GeneratePWDList ={ "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                          "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                          "0","1","2","3","4","5","6","7","8","9"};
            string Password = "";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                int j;
                j = r.Next(GeneratePWDList.Length);
                Password += GeneratePWDList[j];
            }
            return Password;
        }

        public static byte[] UploadFile(FileUpload File)
        {
            if (File.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(File.PostedFile.InputStream))
                {
                    return reader.ReadBytes(File.PostedFile.ContentLength);
                }
            }
            else
            {
                throw new Exception("File Not Uploded...!");
            }
        }

        public static void DownloadFile(DataTable dtDownload, Page p)
        {
            try
            {
                //Retrive Form DataBase
                byte[] FileContent = (byte[])dtDownload.Rows[0]["FileContent"];
                string FileName = dtDownload.Rows[0]["FileName"].ToString();
                //Download File
                string[] fileSplit = FileName.Split('.');
                int Loc = fileSplit.Length;
                string FileExtention = "." + fileSplit[Loc - 1];
                p.Response.ClearContent();
                p.Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                BinaryWriter bw = new BinaryWriter(p.Response.OutputStream);
                bw.Write(FileContent);
                bw.Close();
                p.Response.ContentType = globalFunctions.ReturnExtension(FileExtention);
                p.Response.End();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message + "");
            }

        }

        private static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".docx":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                case ".doc":
                    return "application/ms-word";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
