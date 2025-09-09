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
    public class DeptRepository
    {
        private static DeptRepository instance;

        private DeptRepository() { }

        public static DeptRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new DeptRepository();
                return instance;
            }
        }

        // 부서 조회
        public List<Dept> GetDept()
        {
            var depts = new List<Dept>();

            string sql = "SELECT * FROM sys_dept_info ORDER BY dept_cd, dept_name";

            var parameters = new List<SqlParameter>();

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
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

            return depts;
        }

        // id에 해당하는 부서 정보 조회
        public Dept GetDeptById(int id)
        {
            Dept dept = null;

            string sql = "SELECT * FROM sys_dept_info WHERE id = @id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
            {
                if (reader.Read())
                {
                    dept = new Dept
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                        DeptName = reader.GetString(reader.GetOrdinal("dept_name")),
                        RemarkDc = reader.IsDBNull(reader.GetOrdinal("remark_dc")) ? null : reader.GetString(reader.GetOrdinal("remark_dc"))
                    };
                }
            }

            return dept;
        }

        // 부서 추가
        public int AddDept(Dept dept)
        {
            try
            {
                // 부서코드 중복 체크
                string deptCdCheckSql = "SELECT COUNT(*) FROM sys_dept_info WHERE dept_cd = @dept_cd";

                var deptCdParams = new List<SqlParameter>
                {
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = dept.DeptCd }
                };

                int deptCdCheckCount = ConnDatabase.Instance.ExecuteScalar(deptCdCheckSql, deptCdParams);

                if (deptCdCheckCount > 0)
                {
                    return -1;
                }

                // 부서 추가
                string sql = "INSERT INTO sys_dept_info (dept_cd, dept_name, remark_dc) VALUES (@dept_cd, @dept_name, @remark_dc)";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = dept.DeptCd },
                    new SqlParameter("@dept_name", SqlDbType.NVarChar) { Value = dept.DeptName },
                    new SqlParameter("@remark_dc", SqlDbType.NVarChar) { Value = dept.RemarkDc }
                };

                int addCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);

                return addCnt;
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
                // 부서코드 중복 체크
                string deptCdCheckSql = "SELECT COUNT(*) FROM sys_dept_info WHERE dept_cd = @dept_cd AND id <> @id";

                var deptCdParams = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = dept.Id},
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = dept.DeptCd }
                };

                int deptCdCheckCount = ConnDatabase.Instance.ExecuteScalar(deptCdCheckSql, deptCdParams);

                if (deptCdCheckCount > 0)
                {
                    return -1;
                }

                // 부서 수정
                string sql = "UPDATE sys_dept_info SET dept_cd = @dept_cd, dept_name = @dept_name, remark_dc = @remark_dc WHERE id = @id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = dept.Id },
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = dept.DeptCd },
                    new SqlParameter("@dept_name", SqlDbType.NVarChar) { Value = dept.DeptName },
                    new SqlParameter("@remark_dc", SqlDbType.NVarChar) { Value = dept.RemarkDc }
                };
                
                int updateCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return updateCnt;
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

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                int deleteCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return deleteCnt;
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

        // 부서별 사원수
        public List<DeptUserCnt> GetDeptUserCnt()
        {
            var deptUserCnt = new List<DeptUserCnt>();

            string sql = "SELECT T1.id, dept_name, COUNT(t2.id_dept) as user_cnt " +
                "FROM sys_dept_info T1 LEFT JOIN sys_user_info T2 ON T1.id = T2.id_dept " +
                "GROUP BY T1.id, dept_name ORDER BY dept_name";

            var parameters = new List<SqlParameter>();

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
            {
                while (reader.Read())
                {
                    deptUserCnt.Add(new DeptUserCnt
                    {

                        DeptName = reader.GetString(reader.GetOrdinal("dept_name")),
                        UserCnt = reader.GetInt32(reader.GetOrdinal("user_cnt"))
                    });
                }
            }

            return deptUserCnt;
        }
    }
}
