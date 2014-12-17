using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public sealed class DataAccessLayer
    {
        #region GetConnectionString
        /// <summary>
        /// returns the connection string from the Web.Config
        /// </summary>
        /// <returns></returns>
        private static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }
        #endregion

        #region ExecuteDataTable
        // <summary>
        // Executes a stored procedure and returns a DataTable with the results.
        // </summary>
        // <param name="storedProcedureName">Name of the stored procedure to execute</param>
        // <returns></returns>
        /// <summary>
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataTable ExecuteDataTable(string storedProcedureName)
        {
            return ExecuteDataTable(storedProcedureName, null);
        }

        // <summary>
        // Executes a stored procedure with parameters and returns a DataTable with the results.
        // </summary>
        // <param name="storedProcedureName">Name of the stored procedure to execute</param>
        // <param name="arrParam">Parameters required by the stored procedure</param>
        // <returns>DataTable containing the result</returns>
        // <remarks></remarks>
        public static DataTable ExecuteDataTable(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataTable dt;

            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("storedProcedureName");
            }

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(getConnectionString()))
            {
                cnn.Open();

                // Define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    // Handle the parameters
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);
                    }
                }

            }
            return dt;
        }
        #endregion

        #region ExecuteNonQuery
        public static DataTable ExecuteDataTable4Text(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataTable dt;

            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("storedProcedureName");
            }

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(getConnectionString()))
            {
                cnn.Open();

                // Define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = storedProcedureName;

                    // Handle the parameters
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);
                    }
                }

            }
            return dt;
        }

        /// <summary>
        /// Executes a stored procedure that does not return a dataTable and returns the
        /// first output parameter.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="arrParam">Parameters required by the stored procedure</param>
        /// <returns>First output parameter</returns>
        public static int ExecuteNonQuery(string storedProcedureName, params SqlParameter[] arrParam)
        {
            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("storedProcedureName");
            }

            int retVal = 0;
            SqlParameter firstOutputParameter = null;

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(getConnectionString()))
            {
                cnn.Open();


                // Define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;

                    // Handle the parameters
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                        {
                            cmd.Parameters.Add(param);

                            // Find the first integer out parameter
                            if (firstOutputParameter == null &&
                                    param.Direction == ParameterDirection.Output &&
                                    param.SqlDbType == SqlDbType.Int)
                                firstOutputParameter = param;
                        }
                    }

                    // Execute the stored procedure
                    retVal = cmd.ExecuteNonQuery();

                    // Return the first output parameter value
                    if (firstOutputParameter != null)
                        retVal = (int)firstOutputParameter.Value;
                }
            }
            return retVal;
        }

        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(string storedProcedureName)
        {
            return ExecuteScalar(storedProcedureName, null);
        }
        public static object ExecuteScalar(string storedProcedureName, params SqlParameter[] arrParam)
        {
            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("storedProcedureName");
            }

            object retVal = new object();
            SqlParameter firstOutputParameter = null;

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(getConnectionString()))
            {
                cnn.Open();


                // Define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = 0;

                    // Handle the parameters
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                        {
                            cmd.Parameters.Add(param);

                            // Find the first integer out parameter
                            if (firstOutputParameter == null &&
                                    param.Direction == ParameterDirection.Output &&
                                    param.SqlDbType == SqlDbType.Int)
                                firstOutputParameter = param;
                        }
                    }

                    // Execute the stored procedure
                    retVal = cmd.ExecuteScalar();

                    // Return the first output parameter value
                    if (firstOutputParameter != null)
                        retVal = firstOutputParameter.Value;
                }
            }
            return retVal;
        }
        #endregion

        #region ExecuteDataSet
        // <summary>
        // Executes a stored procedure and returns a DataSet with the results.
        // </summary>
        // <param name="storedProcedureName">Name of the stored procedure to execute</param>
        // <returns></returns>
        /// <summary>
        /// Executes a Stored procedure with out input parameters
        /// </summary>
        /// <returns>returns the DataSet executed by the DB Object</returns>
        public static DataSet ExecuteDataSet(string storedProcedureName)
        {
            return ExecuteDataSet(storedProcedureName, null);
        }

        // <summary>
        // Executes a stored procedure with parameters and returns a DataSet with the results.
        // </summary>
        // <param name="storedProcedureName">Name of the stored procedure to execute</param>
        // <param name="arrParam">Parameters required by the stored procedure</param>
        // <returns>DataTable containing the result</returns>
        // <remarks></remarks>
        /// <summary>
        /// Overloaded mwthod which executes a Stored procedure with array of input parameters
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataSet ds;

            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("storedProcedureName");
            }

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(getConnectionString()))
            {
                cnn.Open();

                // Define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    // Handle the parameters
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }

            }
            return ds;
        }
        #endregion

        #region Parameter
        // <summary>
        // Creates a Parameter
        // </summary>
        // <param name="parameterName">Name of the parameter</param>
        // <param name="parameterValue">Value of the parameter</param>
        // <returns>SqlParameter object</returns>
        // <remarks>The parameter name should be the same as the
        // proeprty name</remarks>
        public static SqlParameter Parameter(string parameterName, object parameterValue)
        {
            return Parameter(parameterName, parameterValue, false);
        }

        // <summary>
        // Creates a Parameter
        // </summary>
        // <param name="parameterName">Name of the parameter</param>
        // <param name="parameterValue">Value of the parameter</param>
        // <param name="isOutput">True if the parameter should be an output parameter</param>
        // <returns>SqlParameter object</returns>
        // <remarks>The parameter name should be the same as the
        // proeprty name</remarks>
        public static SqlParameter Parameter(string parameterName, object parameterValue, bool isOutput)
        {
            SqlParameter param = new SqlParameter();

            // Set the name
            param.ParameterName = parameterName;

            // Set the value
            param.Value = parameterValue ?? DBNull.Value;

            // Set the direction
            if (isOutput)
                param.Direction = ParameterDirection.Output;

            return param;
        }
        #endregion
    }
}
