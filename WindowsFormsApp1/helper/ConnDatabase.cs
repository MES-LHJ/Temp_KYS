using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.helper
{
    public class ConnDatabase
    {
        private static ConnDatabase instance;
        private readonly string connectionString = @"Data Source=DESKTOP-3E4KCVF\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";

        private ConnDatabase() { }

        public static ConnDatabase Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnDatabase();
                return instance;
            }
        }

        // 로그인 조회
        public User LoginAct(User user)
        {
            string sql = "SELECT * FROM sys_user_info WHERE user_login_id = @user_login_id and user_pass = @user_pass";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@user_login_id", SqlDbType.NVarChar).Value = user.UserLoginId;
                cmd.Parameters.Add("@user_pass", SqlDbType.NVarChar).Value = user.UserPass;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            UserId = reader.GetString(reader.GetOrdinal("user_id")),
                            UserName = reader.GetString(reader.GetOrdinal("user_name"))
                        };
                    }
                }
            }

            return null;
        }

        // 사원 조회
        public BindingList<User> GetUser()
        {
            var users = new BindingList<User>();

            string sql = "SELECT t1.id, id_dept, dept_cd, dept_name, user_id, user_name, user_login_id, " +
                "user_pass, user_rank, user_emp_type, user_gender, user_tel, user_email, user_messenger_id, t1.remark_dc " +
                "FROM sys_user_info T1 INNER JOIN sys_dept_info T2 ON T1.id_dept = T2.id " +
                "WHERE user_id <> 'master' ORDER BY user_id, user_name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            UserId = reader.GetString(reader.GetOrdinal("user_id")),
                            UserName = reader.GetString(reader.GetOrdinal("user_name")),
                            UserPass = reader.GetString(reader.GetOrdinal("user_pass")),
                            UserLoginId = reader.GetString(reader.GetOrdinal("user_login_id")),
                            UserRank = reader.IsDBNull(reader.GetOrdinal("user_rank")) ? null : reader.GetString(reader.GetOrdinal("user_rank")),
                            UserEmpType = reader.IsDBNull(reader.GetOrdinal("user_emp_type")) ? null : reader.GetString(reader.GetOrdinal("user_emp_type")),
                            UserGender = reader.IsDBNull(reader.GetOrdinal("user_gender")) ? User.Gender.None : (User.Gender)reader.GetInt32(reader.GetOrdinal("user_gender")),
                            UserTel = reader.IsDBNull(reader.GetOrdinal("user_tel")) ? null : reader.GetString(reader.GetOrdinal("user_tel")),
                            UserEmail = reader.IsDBNull(reader.GetOrdinal("user_email")) ? null : reader.GetString(reader.GetOrdinal("user_email")),
                            UserMessengerId = reader.IsDBNull(reader.GetOrdinal("user_messenger_id")) ? null : reader.GetString(reader.GetOrdinal("user_messenger_id")),
                            RemarkDc = reader.IsDBNull(reader.GetOrdinal("remark_dc")) ? null : reader.GetString(reader.GetOrdinal("remark_dc")),
                            IdDept = reader.GetInt32(reader.GetOrdinal("id_dept")),
                            DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                            DeptName = reader.GetString(reader.GetOrdinal("dept_name"))
                        });
                    }
                }
            }

            return users;
        }

        // 사원 추가
        public int AddUser(User user)
        {
            try
            {
                // 사원코드 중복 체크
                string userIdCheckSql = "SELECT COUNT(*) FROM sys_user_info WHERE user_id = @user_id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand checkCmd = new SqlCommand(userIdCheckSql, conn))
                {
                    checkCmd.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user.UserId;
                    conn.Open();

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return -1;
                    }
                    conn.Close();
                }

                // 로그인ID 중복 체크
                string loginIdCheckSql = "SELECT COUNT(*) FROM sys_user_info WHERE user_login_id = @user_login_id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand checkCmd = new SqlCommand(loginIdCheckSql, conn))
                {
                    checkCmd.Parameters.Add("@user_login_id", SqlDbType.NVarChar).Value = user.UserLoginId;
                    conn.Open();

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return -2;
                    }
                    conn.Close();
                }

                string sql = "INSERT INTO sys_user_info (user_id, user_name, user_pass, user_login_id, id_dept, user_rank, user_emp_type, user_gender, user_tel, user_email, user_messenger_id, remark_dc) " +
                    "VALUES (@user_id, @user_name, @user_pass, @user_login_id, @id_dept, @user_rank, @user_emp_type, @user_gender, @user_tel, @user_email, @user_messenger_id, @remark_dc)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user.UserId;
                    cmd.Parameters.Add("@user_name", SqlDbType.NVarChar).Value = user.UserName;
                    cmd.Parameters.Add("@user_pass", SqlDbType.NVarChar).Value = user.UserPass;
                    cmd.Parameters.Add("@user_login_id", SqlDbType.NVarChar).Value = user.UserLoginId;
                    cmd.Parameters.Add("@id_dept", SqlDbType.Int).Value = user.IdDept;
                    cmd.Parameters.Add("@user_rank", SqlDbType.NVarChar).Value = user.UserRank;
                    cmd.Parameters.Add("@user_emp_type", SqlDbType.NVarChar).Value = user.UserEmpType;
                    cmd.Parameters.Add("@user_gender", SqlDbType.Int).Value = user.UserGender;
                    cmd.Parameters.Add("@user_tel", SqlDbType.NVarChar).Value = user.UserTel;
                    cmd.Parameters.Add("@user_email", SqlDbType.NVarChar).Value = user.UserEmail;
                    cmd.Parameters.Add("@user_messenger_id", SqlDbType.NVarChar).Value = user.UserMessengerId;

                    cmd.Parameters.Add("@remark_dc", SqlDbType.NVarChar).Value = user.RemarkDc;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"InsertUser Error: {ex.Message}");
                return -3;
            }
        }

        // 사원 수정
        public int UpdateUser(User user)
        {
            try
            {
                // 사원코드 중복 체크
                string checkSql = "SELECT COUNT(*) FROM sys_user_info WHERE user_id = @user_id AND id <> @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = user.Id;
                    checkCmd.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user.UserId;

                    conn.Open();

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return -1;
                    }
                }

                string sql = "UPDATE sys_user_info SET id_dept = @id_dept, user_id = @user_id, user_name = @user_name, user_rank = @user_rank, " +
                    "user_emp_type = @user_emp_type, user_gender = @user_gender, user_tel = @user_tel, user_email = @user_email, " +
                    "user_messenger_id = @user_messenger_id, remark_dc = @remark_dc WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.Id;
                    cmd.Parameters.Add("@id_dept", SqlDbType.Int).Value = user.IdDept;
                    cmd.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user.UserId;
                    cmd.Parameters.Add("@user_name", SqlDbType.NVarChar).Value = user.UserName;
                    cmd.Parameters.Add("@user_rank", SqlDbType.NVarChar).Value = user.UserRank;
                    cmd.Parameters.Add("@user_emp_type", SqlDbType.NVarChar).Value = user.UserEmpType;
                    cmd.Parameters.Add("@user_gender", SqlDbType.Int).Value = user.UserGender;
                    cmd.Parameters.Add("@user_tel", SqlDbType.NVarChar).Value = user.UserTel;
                    cmd.Parameters.Add("@user_email", SqlDbType.NVarChar).Value = user.UserEmail;
                    cmd.Parameters.Add("@user_messenger_id", SqlDbType.NVarChar).Value = user.UserMessengerId;
                    cmd.Parameters.Add("@remark_dc", SqlDbType.NVarChar).Value = user.RemarkDc;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateUser Error: {ex.Message}");
                return -2;
            }
        }

        // 사원 삭제
        public int DeleteUser(int id)
        {
            try
            {
                string sql = "DELETE FROM sys_user_info WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DeleteDept Error: {ex.Message}");
                return -2;
            }
        }

        // 부서 조회
        public BindingList<Dept> GetDept()
        {
            var depts = new BindingList<Dept>();

            string sql = "SELECT * FROM sys_dept_info ORDER BY dept_cd, dept_name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        depts.Add(new Dept
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                            DeptName = reader.GetString(reader.GetOrdinal("dept_name")),
                            RemarkDc = reader.IsDBNull(reader.GetOrdinal("remark_dc")) ? null : reader.GetString(reader.GetOrdinal("remark_dc"))
                        });
                    }
                }
            }

            return depts;
        }

        // 부서 추가
        public int AddDept(Dept dept)
        {
            try
            {
                // 중복 체크
                string checkSql = "SELECT COUNT(*) FROM sys_dept_info WHERE dept_cd = @dept_cd";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar).Value = dept.DeptCd;
                    conn.Open();

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return -1;
                    }
                    conn.Close();
                }

                string sql = "INSERT INTO sys_dept_info (dept_cd, dept_name, remark_dc) VALUES (@dept_cd, @dept_name, @remark_dc)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar).Value = dept.DeptCd;
                    cmd.Parameters.Add("@dept_name", SqlDbType.NVarChar).Value = dept.DeptName;
                    cmd.Parameters.Add("@remark_dc", SqlDbType.NVarChar).Value = dept.RemarkDc;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"InsertDept Error: {ex.Message}");
                return -2;
            }
        }

        // 부서 수정
        public int UpdateDept(Dept dept)
        {
            try
            {
                // 중복 체크
                string checkSql = "SELECT COUNT(*) FROM sys_dept_info WHERE dept_cd = @dept_cd AND id <> @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = dept.Id;
                    checkCmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar).Value = dept.DeptCd;

                    conn.Open();

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return -1;
                    }
                }

                string sql = "UPDATE sys_dept_info SET dept_cd = @dept_cd, dept_name = @dept_name, remark_dc = @remark_dc WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = dept.Id;
                    cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar).Value = dept.DeptCd;
                    cmd.Parameters.Add("@dept_name", SqlDbType.NVarChar).Value = dept.DeptName;
                    cmd.Parameters.Add("@remark_dc", SqlDbType.NVarChar).Value = dept.RemarkDc;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateDept Error: {ex.Message}");
                return -2;
            }
        }

        // 부서 삭제
        public int DeleteDept(int id)
        {
            try
            {
                string sql = "DELETE FROM sys_dept_info WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Debug.WriteLine($"DeleteDept Error: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DeleteDept Error: {ex.Message}");
                return -2;
            }
        }
    }
}
