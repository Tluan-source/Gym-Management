using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagemement.Connection;

namespace GymManagemement.Service
{
    public class Load_Membership
    {
        ConnDB conn = new ConnDB();
        private void ResetIdentity(ref string err)
        {
            string sql = @"DECLARE @maxId INT;
                        SELECT @maxID = ISNULL(MAX(CAST(membership_id AS INT)), 0) FROM memberships;
                        DBCC CHECKIDENT('memberships', RESEED, @maxId); ";
            using (var cmd = new SqlCommand(sql))
            {
                try
                {
                    conn.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
                }
                catch (SqlException ex)
                {
                    err = ex.Message;
                }
            }
        }
        public string GetNextMembershipId()
        {
            string query = "SELECT MAX(CAST(membership_id AS INT)) FROM memberships";
            var ds = conn.ExecuteQueryData(query, CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != DBNull.Value)
            {
                int maxId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                return (maxId + 1).ToString();
            }
            else
            {
                return "1"; // Nếu bảng trống
            }
        }
        public List<Loadmembership> GetMembership()
        {
            string query = "SELECT " +
                    "mbs.membership_id, " +
                    "mbs.name, " +
                    "mbs.duration_days, " +
                    "mbs.price, " +
                "COUNT(mb.membership_id) AS member_count " +
                "FROM memberships mbs " +
                "LEFT JOIN members mb ON mbs.membership_id = mb.membership_id " +
                "GROUP BY " +
                    "mbs.name, " +
                    "mbs.membership_id, " +
                    "mbs.duration_days, " +
                    "mbs.price;";

            var ds = conn.ExecuteQueryData(query, CommandType.Text);
            List<Loadmembership> list = new List<Loadmembership>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Loadmembership mem = new Loadmembership
                {
                    Id = dr["membership_id"].ToString(),
                    Name = dr["name"].ToString(),
                    Durations = dr["duration_days"].ToString() + " Days",
                    Price = dr["price"].ToString() + " VNĐ",
                    Quantity = dr["member_count"].ToString() + " subscribers",
                    status = "Active"
                };
                list.Add(mem);
            }
            return list;
        }
        public bool AddMembership(Loadmembership membership, ref string err)
        {
            string sql = "INSERT INTO memberships (name, duration_days, price) VALUES (@name, @duration_days, @price)";
            using (var cmd = new SqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@name", membership.Name);
                cmd.Parameters.AddWithValue("@duration_days", membership.Durations);
                cmd.Parameters.AddWithValue("@price", membership.Price);
                try
                {
                    conn.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
                    return true;
                }
                catch (SqlException ex)
                {
                    err = ex.Message;
                    return false;
                }
            }
        }
        public bool DeleteMembership(Loadmembership membershipId, ref string err)
        {
            string deletesql = "DELETE FROM memberships WHERE membership_id = @membership_id";
            using (var cmd = new SqlCommand(deletesql))
            {
                cmd.Parameters.AddWithValue("@membership_id", membershipId.Id);
                bool delete = conn.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
                if (!delete)
                    return false;
            }
            ResetIdentity(ref err);

            return string.IsNullOrEmpty(err);
        }
        public bool UpdateMemberShip(Loadmembership membership, ref string err)
        {
            MessageBox.Show($"ID: {membership.Id}, Name: {membership.Name}, Duration: {membership.Durations}, Price: {membership.Price}");
            
            string query = @"UPDATE memberships SET
                             name = @name,
                             duration_days = @duration_days,
                             price = @price
                             WHERE membership_id = @membership_id";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@membership_id", membership.Id);
            cmd.Parameters.AddWithValue("@name", membership.Name);
            cmd.Parameters.AddWithValue("@duration_days", membership.Durations);
            cmd.Parameters.AddWithValue("@price", membership.Price);

            return conn.MyExecuteNonQuery(cmd,CommandType.Text, ref err);
        }
    }
}
