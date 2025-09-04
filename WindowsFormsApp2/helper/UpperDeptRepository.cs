using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.helper
{
    public class UpperDeptRepository
    {
        private static UpperDeptRepository instance;

        private UpperDeptRepository() { }

        public static UpperDeptRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UpperDeptRepository();
                return instance;
            }
        }

        // 상위 부서 조회
        public List<UpperDept> GetUpperDept()
        {
            var upperDepts = new List<UpperDept>();

            string sql = "SELECT * FROM sys_upperdept_info ORDER BY dept_cd, dept_name";

            var parameters = new List<SqlParameter>();

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
            {
                while (reader.Read())
                {
                    upperDepts.Add(new UpperDept
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                        DeptName = reader.GetString(reader.GetOrdinal("dept_name")),
                        RemarkDc = reader.IsDBNull(reader.GetOrdinal("remark_dc")) ? null : reader.GetString(reader.GetOrdinal("remark_dc"))
                    });
                }
            }

            return upperDepts;
        }

        // id에 해당하는 상위 부서 정보 조회
        public UpperDept GetUpperDeptById(int id)
        {
            UpperDept upperDept = null;

            string sql = "SELECT * FROM sys_upperdept_info WHERE id = @id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            using (SqlDataReader reader = ConnDatabase.Instance.ExecuteReader(sql, parameters))
            {
                if (reader.Read())
                {
                    upperDept = new UpperDept
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        DeptCd = reader.GetString(reader.GetOrdinal("dept_cd")),
                        DeptName = reader.GetString(reader.GetOrdinal("dept_name")),
                        RemarkDc = reader.IsDBNull(reader.GetOrdinal("remark_dc")) ? null : reader.GetString(reader.GetOrdinal("remark_dc"))
                    };
                }
            }

            return upperDept;
        }

        // 상위 부서 추가
        public int AddUpperDept(UpperDept upperDept)
        {
            try
            {
                // 부서코드 중복 체크
                string deptCdCheckSql = "SELECT COUNT(*) FROM sys_upperdept_info WHERE dept_cd = @dept_cd";

                var deptCdParams = new List<SqlParameter>
                {
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = upperDept.DeptCd }
                };

                int deptCdCheckCount = ConnDatabase.Instance.ExecuteNonQuery(deptCdCheckSql, deptCdParams);

                if (deptCdCheckCount > 0)
                {
                    return -1;
                }

                // 부서 추가
                string sql = "INSERT INTO sys_upperdept_info (dept_cd, dept_name, remark_dc) VALUES (@dept_cd, @dept_name, @remark_dc)";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = upperDept.DeptCd },
                    new SqlParameter("@dept_name", SqlDbType.NVarChar) { Value = upperDept.DeptName },
                    new SqlParameter("@remark_dc", SqlDbType.NVarChar) { Value = upperDept.RemarkDc }
                };

                int addCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);

                return addCnt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"InsertUpperDept Error: {ex.Message}");
                return -2;
            }
        }

        // 상위 부서 수정
        public int UpdateUpperDept(UpperDept upperDept)
        {
            try
            {
                // 부서코드 중복 체크
                string deptCdCheckSql = "SELECT COUNT(*) FROM sys_upperdept_info WHERE dept_cd = @dept_cd AND id <> @id";

                var deptCdParams = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = upperDept.Id},
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = upperDept.DeptCd }
                };

                int deptCdCheckCount = ConnDatabase.Instance.ExecuteNonQuery(deptCdCheckSql, deptCdParams);

                if (deptCdCheckCount > 0)
                {
                    return -1;
                }

                // 부서 수정
                string sql = "UPDATE sys_upperdept_info SET dept_cd = @dept_cd, dept_name = @dept_name, remark_dc = @remark_dc WHERE id = @id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = upperDept.Id },
                    new SqlParameter("@dept_cd", SqlDbType.NVarChar) { Value = upperDept.DeptCd },
                    new SqlParameter("@dept_name", SqlDbType.NVarChar) { Value = upperDept.DeptName },
                    new SqlParameter("@remark_dc", SqlDbType.NVarChar) { Value = upperDept.RemarkDc }
                };

                int updateCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return updateCnt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateUpperDept Error: {ex.Message}");
                return -2;
            }
        }

        // 상위 부서 삭제
        public int DeleteUpperDept(int id)
        {
            try
            {
                string sql = "DELETE FROM sys_upperdept_info WHERE id = @id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                int deleteCnt = ConnDatabase.Instance.ExecuteNonQuery(sql, parameters);
                return deleteCnt;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Debug.WriteLine($"DeleteUpperDept Error: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DeleteUpperDept Error: {ex.Message}");
                return -2;
            }
        }
    }
}
