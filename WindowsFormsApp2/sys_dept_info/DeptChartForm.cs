using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.helper;

namespace WindowsFormsApp2.sys_dept_info
{
    public partial class DeptChartForm : XtraForm
    {
        private List<User> userList = new List<User>();

        // 이벤트 핸들러
        private void InitEvent()
        {
            this.Load += DeptChartForm_Load;
        }

        public DeptChartForm()
        {
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private void DeptChartForm_Load(object sender, EventArgs e)
        {
            ChartSetData();
        }

        // ------------
        // 메서드 정의
        // ------------

        // Chart Set
        private void ChartSetData()
        {
            userList = UserRepository.Instance.GetUser();

            // 하위부서 추출
            var lowerDeptInfo = userList
                .OrderBy(u => u.IdDept)
                .Select(u => new { u.IdDept, u.DeptCd, u.DeptName })
                .Distinct()
                .ToList();

            // 상위부서 추출
            var upperDeptInfo = userList
                .OrderBy(u => u.IdUpperDept)
                .Select(u => new { u.IdUpperDept, u.UpperDeptCd, u.UpperDeptName })
                .Distinct()
                .ToList();

            chartControl1.Series.Clear();

            // Series 생성
            foreach (var dept in lowerDeptInfo)
            {
                string lowerName = $"{dept.DeptName} ({dept.DeptCd})";
                var series = new Series(lowerName, ViewType.StackedBar);

                foreach (var upper in upperDeptInfo)
                {
                    string upperName = $"{upper.UpperDeptName} ({upper.UpperDeptCd})";
                    int count = userList.Count(u => u.IdDept == dept.IdDept && u.IdUpperDept == upper.IdUpperDept);
                    series.Points.Add(new SeriesPoint(upperName, count));
                }
                
                chartControl1.Series.Add(series);
            }
            
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new ChartTitle() { Text = "부서별 사원수" });
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
        }
    }
}