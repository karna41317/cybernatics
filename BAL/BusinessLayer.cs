using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BAL
{
    public class BusinessLayer:Properties
    {
        static int i;
        public int GetUserId()
        {
            return Convert.ToInt32(DataAccessLayer.ExecuteScalar("Sp_GetUserId"));
        }

        public bool CheckLoginId(string UserLoginId)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@LoginId", UserLoginId);
            p[0].SqlDbType = SqlDbType.VarChar;
            DataTable dt = DataAccessLayer.ExecuteDataTable("Sp_CheckUserLoginId", p);

            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool InsertAgencyRegistration()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[9];

                p[0] = new SqlParameter("@UserId",UserId);
                p[0].SqlDbType = SqlDbType.Int;

                p[1] = new SqlParameter("@FirstName",FirstName);
                p[1].SqlDbType = SqlDbType.VarChar;

                p[2] = new SqlParameter("@LastName",LastName);
                p[2].SqlDbType = SqlDbType.VarChar;

                p[3] = new SqlParameter("@DateOfBirth",DateOfBirth);
                p[3].SqlDbType = SqlDbType.DateTime;

                p[4] = new SqlParameter("@Address",Address);
                p[4].SqlDbType = SqlDbType.VarChar;

                p[5] = new SqlParameter("@EmailId",EmailId);
                p[5].SqlDbType = SqlDbType.VarChar;

                p[6] = new SqlParameter("@ContactNo",ContactNo);
                p[6].SqlDbType = SqlDbType.VarChar;

                p[7] = new SqlParameter("@Photo",FileContent);

                p[8] = new SqlParameter("@PhotoFileName",FileName);
                p[8].SqlDbType = SqlDbType.VarChar;

                DataAccessLayer.ExecuteNonQuery("Sp_InsertUserRegistration", p);

                SqlParameter[] p1 = new SqlParameter[6];
                p1[0] = new SqlParameter("@UserId",UserId);
                p1[0].SqlDbType = SqlDbType.Int;

                p1[1] = new SqlParameter("@LoginId",LoginId);
                p1[1].SqlDbType = SqlDbType.VarChar;

                p1[2] = new SqlParameter("@PassWord",PassWord);
                p1[2].SqlDbType = SqlDbType.VarChar;

                p1[3] = new SqlParameter("@HintQuestion",HintQuestion);
                p1[3].SqlDbType = SqlDbType.VarChar;

                p1[4] = new SqlParameter("@Answer",Answer);
                p1[4].SqlDbType = SqlDbType.VarChar;

                p1[5] = new SqlParameter("@Role","Agency_P");
                p1[5].SqlDbType = SqlDbType.VarChar;

                DataAccessLayer.ExecuteNonQuery("Sp_LoginInsert", p1);
                return true;
            }
            catch (Exception ex)
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@UserId",UserId);
                p[0].SqlDbType = SqlDbType.Int;
                DataAccessLayer.ExecuteNonQuery("Sp_LoginIdDelete", p);
                return false;
            }
            finally
            {
                
            }
        }

        public string GetUserLogin(out int id)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[4];

                p[0] = new SqlParameter("@LoginId",LoginId);
                p[1] = new SqlParameter("@PassWord",PassWord);
                p[2] = new SqlParameter("@Role", SqlDbType.VarChar, 20);
                p[2].Direction = ParameterDirection.Output;
                p[3] = new SqlParameter("@UserId", SqlDbType.Int);
                p[3].Direction = ParameterDirection.Output;
                DataAccessLayer.ExecuteDataSet("Sp_GetUserLogin", p);
                id = Convert.ToInt32(p[3].Value);
                return p[2].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                
            }
        }



        public bool InsertAgentRegistration()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@UserId", UserId);
                p[0].SqlDbType = SqlDbType.Int;

                p[1] = new SqlParameter("@FirstName", FirstName);
                p[1].SqlDbType = SqlDbType.VarChar;

                p[2] = new SqlParameter("@LastName", LastName);
                p[2].SqlDbType = SqlDbType.VarChar;

                p[3] = new SqlParameter("@DateOfBirth", DateOfBirth);
                p[3].SqlDbType = SqlDbType.DateTime;

                p[4] = new SqlParameter("@Address", Address);
                p[4].SqlDbType = SqlDbType.VarChar;

                p[5] = new SqlParameter("@EmailId", EmailId);
                p[5].SqlDbType = SqlDbType.VarChar;

                p[6] = new SqlParameter("@ContactNo", ContactNo);
                p[6].SqlDbType = SqlDbType.VarChar;

                p[7] = new SqlParameter("@Photo", FileContent);

                p[8] = new SqlParameter("@PhotoFileName", FileName);
                p[8].SqlDbType = SqlDbType.VarChar;

                p[9] = new SqlParameter("@AgencyId", AgencyId);
                p[9].SqlDbType = SqlDbType.Int;

                DataAccessLayer.ExecuteNonQuery("Sp_InsertAgentRegistration", p);

                SqlParameter[] p1 = new SqlParameter[4];
                p1[0] = new SqlParameter("@UserId", UserId);
                p1[0].SqlDbType = SqlDbType.Int;

                p1[1] = new SqlParameter("@LoginId", LoginId);
                p1[1].SqlDbType = SqlDbType.VarChar;

                p1[2] = new SqlParameter("@PassWord", PassWord);
                p1[2].SqlDbType = SqlDbType.VarChar;

                p1[3] = new SqlParameter("@Role", "Agent");
                p1[3].SqlDbType = SqlDbType.VarChar;

                DataAccessLayer.ExecuteNonQuery("Sp_LoginInsert1", p1);
                return true;
            }
            catch (Exception ex)
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@UserId", UserId);
                p[0].SqlDbType = SqlDbType.Int;
                DataAccessLayer.ExecuteNonQuery("Sp_LoginIdDelete", p);
                return false;
            }
            finally
            {

            }
        }

       

        public int ChangePassword()
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@UserName",LoginId);
            p[1] = new SqlParameter("@OldPassWord",PassWord);
            p[2] = new SqlParameter("@NewPassWord",NewPassWord);
            p[3] = new SqlParameter("@Result", SqlDbType.Int);
            p[3].Direction = ParameterDirection.Output;
            DataAccessLayer.ExecuteNonQuery("Sp_ChangePassWord", p);
            return Convert.ToInt32(p[3].Value);
        }

        public string ForgotPassWord()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@UserName",LoginId);
                p[1] = new SqlParameter("@HintQuestion",HintQuestion);
                p[2] = new SqlParameter("@Answer",Answer);
                p[3] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50);
                p[3].Direction = ParameterDirection.Output;
                DataAccessLayer.ExecuteNonQuery("Sp_ForgotPassWord", p);
                return p[3].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
            finally
            {

            }
        }

        public DataTable GetAgencyDetails()
        {
            return DataAccessLayer.ExecuteDataTable("Sp_GetAgencyDetails");
        }

        public int AcceptAgency()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@UserId", UserId);
            return DataAccessLayer.ExecuteNonQuery("Sp_AcceptAgency", p);
        }

        public int InsertCaseDetails()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@CaseName", CaseName);
                p[1] = new SqlParameter("@Description", Description);
                p[2] = new SqlParameter("@FileContent", FileContent);
                p[3] = new SqlParameter("@FileName", FileName);
                return DataAccessLayer.ExecuteNonQuery("Sp_InsertCaseDetails", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
            finally
            {

            }
        }

        public DataTable GetCaseDetails()
        {
            return DataAccessLayer.ExecuteDataTable("Sp_ViewCaseDetails");
        }

        public DataTable GetAgencyDetailsForCase()
        {
            return DataAccessLayer.ExecuteDataTable("Sp_GetAgencyDetailsForCase");
        }

        public int AssignCaseToAgency()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@CaseId", CaseId);
                p[1] = new SqlParameter("@AgencyId", AgencyId);
                return DataAccessLayer.ExecuteNonQuery("Sp_AssignCaseToAgency", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
        }

        public DataTable GetCaseDetailsFromDefense()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgencyId", AgencyId);
            return DataAccessLayer.ExecuteDataTable("Sp_ViewCaseDetailsFromDefense",p);
        }

        public DataTable Download()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CaseId", CaseId);
            return DataAccessLayer.ExecuteDataTable("Sp_Download", p);
        }

        public DataTable GetAgentDetails()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgencyId", AgencyId);
            return DataAccessLayer.ExecuteDataTable("Sp_GetAgentDetails", p);
        }

        public int AssignCaseToAgent()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@CaseId", CaseId);
                p[1] = new SqlParameter("@AgentId", AgentId);
                return DataAccessLayer.ExecuteNonQuery("Sp_AssignCaseToAgent", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
        }

        public DataTable GetCaseDetailsFromAgency()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return DataAccessLayer.ExecuteDataTable("Sp_ViewCaseDetailsFromAgency", p);
        }
    }
}
