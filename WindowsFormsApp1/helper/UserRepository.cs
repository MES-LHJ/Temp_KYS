using DocumentFormat.OpenXml.Office2010.Excel;
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
    public class UserRepository
    {
        private static UserRepository instance;

        private UserRepository() { }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        // 로그인 조회
        public User LoginAct(User user)
        {
            string sql = "SELECT * FROM sys_user_info WHERE user_login_id = @user_login_id and user_pass = @user_pass";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@user_login_id", SqlDbType.NVarChar) { Value = user.UserLoginId },
                new SqlParameter("@user_pass", SqlDbType.NVarChar) { Value = user.UserPass }
            };

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
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

            return null;
        }

        // 사원 조회
        public List<User> GetUser()
        {
            var users = new List<User>();

            string sql = "SELECT t1.id, id_dept, dept_cd, dept_name, user_id, user_name, user_login_id, user_pass, " +
                "user_rank, user_emp_type, user_gender, user_tel, user_email, user_messenger_id, t1.remark_dc, user_image " +
                "FROM sys_user_info T1 INNER JOIN sys_dept_info T2 ON T1.id_dept = T2.id " +
                "WHERE user_id <> 'master' ORDER BY user_id, user_name";

            var parameters = new List<SqlParameter>();

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
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
                        UserImage = reader.IsDBNull(reader.GetOrdinal("user_image")) ? null : reader.GetString(reader.GetOrdinal("user_image")),
                        IdDept = reader.GetInt32(reader.GetOrdinal("id_dept")),
                        DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                        DeptName = reader.GetString(reader.GetOrdinal("dept_name"))
                    });
                }
            }

            return users;
        }

        // id에 해당하는 사원 정보 조회
        public User GetUserById(int id)
        {
            User user = null;

            string sql = "SELECT t1.id, id_dept, dept_cd, dept_name, user_id, user_name, user_rank, user_emp_type, " +
                "user_gender, user_tel, user_email, user_messenger_id, t1.remark_dc, user_image " +
                "FROM sys_user_info T1 INNER JOIN sys_dept_info T2 ON T1.id_dept = T2.id " +
                "WHERE t1.id = @id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        UserId = reader.GetString(reader.GetOrdinal("user_id")),
                        UserName = reader.GetString(reader.GetOrdinal("user_name")),
                        UserRank = reader.IsDBNull(reader.GetOrdinal("user_rank")) ? null : reader.GetString(reader.GetOrdinal("user_rank")),
                        UserEmpType = reader.IsDBNull(reader.GetOrdinal("user_emp_type")) ? null : reader.GetString(reader.GetOrdinal("user_emp_type")),
                        UserGender = reader.IsDBNull(reader.GetOrdinal("user_gender")) ? User.Gender.None : (User.Gender)reader.GetInt32(reader.GetOrdinal("user_gender")),
                        UserTel = reader.IsDBNull(reader.GetOrdinal("user_tel")) ? null : reader.GetString(reader.GetOrdinal("user_tel")),
                        UserEmail = reader.IsDBNull(reader.GetOrdinal("user_email")) ? null : reader.GetString(reader.GetOrdinal("user_email")),
                        UserMessengerId = reader.IsDBNull(reader.GetOrdinal("user_messenger_id")) ? null : reader.GetString(reader.GetOrdinal("user_messenger_id")),
                        RemarkDc = reader.IsDBNull(reader.GetOrdinal("remark_dc")) ? null : reader.GetString(reader.GetOrdinal("remark_dc")),
                        UserImage = reader.IsDBNull(reader.GetOrdinal("user_image")) ? null : reader.GetString(reader.GetOrdinal("user_image")),
                        IdDept = reader.GetInt32(reader.GetOrdinal("id_dept")),
                        DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                        DeptName = reader.GetString(reader.GetOrdinal("dept_name"))
                    };
                }
            }

            return user;
        }

        // 사원 추가
        public int AddUser(User user)
        {
            try
            {
                // 사원코드 중복 체크
                string userIdCheckSql = "SELECT COUNT(*) FROM sys_user_info WHERE user_id = @user_id";

                var userIdParams = new List<SqlParameter>
                {
                    new SqlParameter("@user_id", SqlDbType.NVarChar) { Value = user.UserId }
                };

                int userIdCheckCount = ConnDatabase.Instance.ExecuteScalar(userIdCheckSql, userIdParams);

                if (userIdCheckCount > 0)
                {
                    return -1;
                }

                // 로그인ID 중복 체크
                string loginIdCheckSql = "SELECT COUNT(*) FROM sys_user_info WHERE user_login_id = @user_login_id";

                var loginIdParames = new List<SqlParameter>
                {
                    new SqlParameter("@user_login_id", SqlDbType.NVarChar) { Value = user.UserLoginId }
                };

                int loginIdCheckCount = ConnDatabase.Instance.ExecuteScalar(loginIdCheckSql, loginIdParames);

                if (loginIdCheckCount > 0)
                {
                    return -2;
                }

                // 사원 추가
                string sql = "INSERT INTO sys_user_info (user_id, user_name, user_pass, user_login_id, id_dept, user_rank, user_emp_type, " +
                    "user_gender, user_tel, user_email, user_messenger_id, remark_dc, user_image) " +
                    "VALUES (@user_id, @user_name, @user_pass, @user_login_id, @id_dept, @user_rank, @user_emp_type, " +
                    "@user_gender, @user_tel, @user_email, @user_messenger_id, @remark_dc, @user_image);" +
                    "SELECT CONVERT(INT, SCOPE_IDENTITY());";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@user_id", SqlDbType.NVarChar) { Value = user.UserId },
                    new SqlParameter("@user_name", SqlDbType.NVarChar) { Value = user.UserName },
                    new SqlParameter("@user_pass", SqlDbType.NVarChar) { Value = user.UserPass },
                    new SqlParameter("@user_login_id", SqlDbType.NVarChar) { Value = user.UserLoginId },
                    new SqlParameter("@id_dept", SqlDbType.Int) { Value = user.IdDept },
                    new SqlParameter("@user_rank", SqlDbType.NVarChar) { Value = user.UserRank },
                    new SqlParameter("@user_emp_type", SqlDbType.NVarChar) { Value = user.UserEmpType },
                    new SqlParameter("@user_gender", SqlDbType.Int) { Value = user.UserGender },
                    new SqlParameter("@user_tel", SqlDbType.NVarChar) { Value = user.UserTel },
                    new SqlParameter("@user_email", SqlDbType.NVarChar) { Value = user.UserEmail },
                    new SqlParameter("@user_messenger_id", SqlDbType.NVarChar) { Value = user.UserMessengerId },
                    new SqlParameter("@remark_dc", SqlDbType.NVarChar) { Value = user.RemarkDc },
                    new SqlParameter("@user_image", SqlDbType.NVarChar) { Value = user.UserImage }
                };

                int addCnt = ConnDatabase.Instance.ExecuteScalar(sql, parameters);
                return addCnt;
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
                string userIdCheckSql = "SELECT COUNT(*) FROM sys_user_info WHERE user_id = @user_id AND id <> @id";

                var userIdParams = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = user.Id },
                    new SqlParameter("@user_id", SqlDbType.NVarChar) { Value = user.UserId }
                };

                int userIdCheckCount = ConnDatabase.Instance.ExecuteScalar(userIdCheckSql, userIdParams);

                if (userIdCheckCount > 0)
                {
                    return -1;
                }
                
                // 사원 수정
                string sql = "UPDATE sys_user_info SET id_dept = @id_dept, user_id = @user_id, user_name = @user_name, user_rank = @user_rank, " +
                    "user_emp_type = @user_emp_type, user_gender = @user_gender, user_tel = @user_tel, user_email = @user_email, " +
                    "user_messenger_id = @user_messenger_id, remark_dc = @remark_dc, user_image = @user_image WHERE id = @id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = user.Id },
                    new SqlParameter("@id_dept", SqlDbType.Int) { Value = user.IdDept },
                    new SqlParameter("@user_id", SqlDbType.NVarChar) { Value = user.UserId },
                    new SqlParameter("@user_name", SqlDbType.NVarChar) { Value = user.UserName },
                    new SqlParameter("@user_rank", SqlDbType.NVarChar) { Value = user.UserRank },
                    new SqlParameter("@user_emp_type", SqlDbType.NVarChar) { Value = user.UserEmpType },
                    new SqlParameter("@user_gender", SqlDbType.Int) { Value = user.UserGender },
                    new SqlParameter("@user_tel", SqlDbType.NVarChar) { Value = user.UserTel },
                    new SqlParameter("@user_email", SqlDbType.NVarChar) { Value = user.UserEmail },
                    new SqlParameter("@user_messenger_id", SqlDbType.NVarChar) { Value = user.UserMessengerId },
                    new SqlParameter("@remark_dc", SqlDbType.NVarChar) { Value = user.RemarkDc },
                    new SqlParameter("@user_image", SqlDbType.NVarChar) { Value = user.UserImage }
                };

                int UpdateCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return UpdateCnt;

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

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                int DeleteCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return DeleteCnt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DeleteDept Error: {ex.Message}");
                return -1;
            }
        }

        // 사원 이미지 업데이트
        public int UpdateUserImage(int id, string filePath)
        {
            try
            {
                string sql = "UPDATE sys_user_info SET user_image = @user_image WHERE id = @id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id },
                    new SqlParameter("@user_image", SqlDbType.NVarChar) { Value = filePath }
                };

                int UpdateCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return UpdateCnt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateUser Error: {ex.Message}");
                return -1;
            }
        }
    }
}
