using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.sys_user_info;

namespace WindowsFormsApp1
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserLoginId { get; set; }
        public string UserRank { get; set; }
        public string UserEmpType { get; set; }
        public string UserGender { get; set; }
        public string UserTel { get; set; }
        public string UserEmail { get; set; }
        public string UserMessengerId { get; set; }
        public string RemarkDc { get; set; }
        public int IdDept { get; set; }
        public string DeptCd { get; set; }
        public string DeptName { get; set; }
    }

    public class Dept 
    { 
        public int Id { get; set; }
        public string DeptCd { get; set; } 
        public string DeptName { get; set; } 
        public string RemarkDc { get; set; } 
    }

    public class FormManager
    {
        private static IndexForm indexForm;
        private static UserInfoForm userInfoForm;
        private static UserAddForm userAddForm;
        private static UserUpdateForm userUpdateForm;
        private static DeptInfoForm deptInfoForm;
        private static DeptAddForm deptAddForm;
        private static DeptUpdateForm deptUpdateForm;

        // Singleton 인스턴스
        private static FormManager instance;

        // private 생성자: 외부에서 인스턴스를 생성하지 못하도록
        private FormManager() { }

        // Singleton 인스턴스 접근용 프로퍼티
        public static FormManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormManager();
                }
                return instance;
            }
        }

        public IndexForm GetIndexForm()
        {
            if (indexForm == null || indexForm.IsDisposed)
                indexForm = new IndexForm();
            return indexForm;
        }

        public UserInfoForm GetUserInfoForm()
        {
            if (userInfoForm == null || userInfoForm.IsDisposed)
                userInfoForm = new UserInfoForm();
            return userInfoForm;
        }

        public UserAddForm GetUserAddForm()
        {
            if (userAddForm == null || userAddForm.IsDisposed)
                userAddForm = new UserAddForm();

            userAddForm.ResetForm();
            return userAddForm;
        }

        public UserUpdateForm GetUserUpdateForm(User user)
        {
            if (userUpdateForm == null || userUpdateForm.IsDisposed)
                userUpdateForm = new UserUpdateForm(user);
            else if (user != null)
                userUpdateForm.SetData(user);
            return userUpdateForm;
        }

        public DeptInfoForm GetDeptInfoForm()
        {
            if (deptInfoForm == null || deptInfoForm.IsDisposed)
                deptInfoForm = new DeptInfoForm();
            return deptInfoForm;
        }

        public DeptAddForm GetDeptAddForm()
        {
            if (deptAddForm == null || deptAddForm.IsDisposed)
                deptAddForm = new DeptAddForm();

            deptAddForm.ResetForm();

            return deptAddForm;
        }

        public DeptUpdateForm GetDeptUpdateForm(Dept dept)
        {
            if (deptUpdateForm == null || deptUpdateForm.IsDisposed)
                deptUpdateForm = new DeptUpdateForm(dept);
            else if (dept != null)
                deptUpdateForm.SetData(dept);

            return deptUpdateForm;
        }
    }

    //유효성검사
    public static class Validator
    {
        // 비밀번호: 최소 8자리, 영어+숫자 포함
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Za-z])(?=.*\d).{8,}$");
            return regex.IsMatch(password);
        }

        // 이메일: 일반 형식 체크
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            return regex.IsMatch(email);
        }
    }
}
