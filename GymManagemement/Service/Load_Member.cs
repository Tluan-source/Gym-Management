using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagemement.Connection;

namespace GymManagemement.Service
{
    public class Load_Member
    {
        ConnDB conn = new ConnDB();
        private void ResetIdentity(ref string err)
        {
            string sql = @"DECLARE @maxId INT;
                        SELECT @maxID = ISNULL(MAX(CAST(member_id AS INT)), 0) FROM members;
                        DBCC CHECKIDENT('members', RESEED, @maxId); ";
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
        public string GetNextMemberId()
        {
            string query = "SELECT MAX(CAST(member_id AS INT)) FROM members";
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
        public List<Loadmember> Getmember()
        {
            string query = "SELECT members.member_id, members.full_name, members.phone, members.email, " +
                "members.gender, members.date_of_birth, members.join_date, " +
                "memberships.name, members.training_type, members.trainer_id, trainers.full_name AS trainers_name " +
                "FROM members " +
                "JOIN memberships ON members.membership_id = memberships.membership_id " +
                "LEFT JOIN trainers ON members.trainer_id = trainers.trainer_id";

            var ds = conn.ExecuteQueryData(query, CommandType.Text);
            List<Loadmember> list = new List<Loadmember>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Loadmember mem = new Loadmember
                {
                    Id = dr["member_id"].ToString(),
                    FullName = dr["full_name"].ToString(),
                    Phone = dr["phone"].ToString(),
                    Email = dr["email"].ToString(),
                    Gender = dr["gender"].ToString(),
                    DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]),
                    JoinDate = Convert.ToDateTime(dr["join_date"]),
                    Membership = dr["name"].ToString(),
                    TrainingType = dr["training_type"].ToString(),
                    Trainer = dr["trainers_name"] != DBNull.Value ? dr["trainers_name"].ToString() : ""
                };
                list.Add(mem);
            }

            return list;
        }
        public bool AddMember(Loadmember mem, ref string err)
        {
            string query = @"INSERT INTO members
                            VALUES (@full_name, @phone, @email, @gender, @date_of_birth, @join_date, @membership_id, @training_type, @trainer_id)";
            SqlCommand cmd = new SqlCommand(query);
            //cmd.Parameters.AddWithValue("@member_id", mem.Id);
            cmd.Parameters.AddWithValue("@full_name", mem.FullName);
            cmd.Parameters.AddWithValue("@phone", mem.Phone);
            cmd.Parameters.AddWithValue("@email", mem.Email);
            cmd.Parameters.AddWithValue("@gender", mem.Gender);
            cmd.Parameters.AddWithValue("@date_of_birth", mem.DateOfBirth.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@join_date", mem.JoinDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@membership_id", mem.Membership);
            cmd.Parameters.AddWithValue("@training_type", mem.TrainingType);
            cmd.Parameters.AddWithValue("@trainer_id", string.IsNullOrEmpty(mem.Trainer) ? (object)DBNull.Value : mem.Trainer);

            return conn.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
        public bool DeleteMember(Loadmember mem, ref string err)
        {
            string deleteSql = "DELETE FROM members WHERE member_id = @member_id";
            using (var cmd = new SqlCommand(deleteSql))
            {
                cmd.Parameters.AddWithValue("@member_id", mem.Id);
                bool deleted = conn.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
                if (!deleted)
                    return false;   // xóa lỗi thì dừng
            }

            // 2) Reset lại identity seed
            ResetIdentity(ref err);

            return string.IsNullOrEmpty(err);
        }
        public bool UpdateMember(Loadmember mem, ref string err)
        {
            string query = @"UPDATE members SET 
                        full_name = @full_name,
                        phone = @phone,
                        email = @email,
                        gender = @gender,
                        date_of_birth = @date_of_birth,
                        join_date = @join_date,
                        membership_id = @membership_id,
                        training_type = @training_type,
                        trainer_id = @trainer_id
                    WHERE member_id = @member_id";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@full_name", mem.FullName);
            cmd.Parameters.AddWithValue("@phone", mem.Phone);
            cmd.Parameters.AddWithValue("@email", mem.Email);
            cmd.Parameters.AddWithValue("@gender", mem.Gender);
            cmd.Parameters.AddWithValue("@date_of_birth", mem.DateOfBirth.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@join_date", mem.JoinDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@membership_id", mem.Membership);
            cmd.Parameters.AddWithValue("@training_type", mem.TrainingType);
            cmd.Parameters.AddWithValue("@trainer_id", string.IsNullOrEmpty(mem.Trainer) ? (object)DBNull.Value : mem.Trainer);
            cmd.Parameters.AddWithValue("@member_id", mem.Id);

            return conn.MyExecuteNonQuery(cmd, CommandType.Text, ref err);
        }
    }
}
