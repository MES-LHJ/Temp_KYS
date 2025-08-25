using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.sys_user_info;
using WindowsFormsApp1.sys_dept_info;
namespace WindowsFormsApp1.helper
{
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

        public void SetIndexForm(IndexForm form)
        {
            indexForm = form;
        }

        public IndexForm GetIndexForm()
        {
            //if (indexForm == null || indexForm.IsDisposed)
            //    indexForm = new IndexForm();
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

            //userAddForm.ResetForm();
            return userAddForm;
        }

        public UserUpdateForm GetUserUpdateForm(int id)
        {
            if (userUpdateForm == null || userUpdateForm.IsDisposed)
                userUpdateForm = new UserUpdateForm(id);
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

            //deptAddForm.ResetForm();

            return deptAddForm;
        }

        public DeptUpdateForm GetDeptUpdateForm(int id)
        {
            if (deptUpdateForm == null || deptUpdateForm.IsDisposed)
                deptUpdateForm = new DeptUpdateForm(id);

            return deptUpdateForm;
        }
    }
}
