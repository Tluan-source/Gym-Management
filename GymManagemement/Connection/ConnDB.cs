using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagemement.Connection
{
    internal class ConnDB
    {
        string ConnString = "Data Source=(local);Initial Catalog=Gym;User ID=sa;Password=270405";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;

        public ConnDB()
        {
            conn = new SqlConnection(ConnString);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryData(string sql, CommandType ct)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            comm.CommandText = sql;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool MyExecuteNonQuery(SqlCommand cmd, CommandType ct, ref string error)
        {
            bool f = false;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = ct;
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public int ExecuteScalar(string sql)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            comm.CommandText = sql;
            int result = Convert.ToInt32(comm.ExecuteScalar());
            conn.Close();
            return result;
        }
    }
}
