using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.api;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_dept_info
{
    public partial class DeptChartForm : Form
    {
        private List<DeptUserCnt> chartList;

        // 이벤트 핸들러
        private void InitEvents()
        {
            this.Load += DeptChartForm_Load;
            this.KeyDown += DeptChartForm_KeyDown;
            chart1.MouseMove += Chart1_MouseMove;
        }

        public DeptChartForm()
        {
            InitializeComponent();
            InitEvents();
        }


        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private void DeptChartForm_Load(object sender, EventArgs e)
        {
            DeptChart();
        }

        // 폼 KeyDown 이벤트
        private void DeptChartForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 닫기(ESC)
                case Keys.Escape:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            var hit = chart1.HitTest(pos.X, pos.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var point = hit.Series.Points[hit.PointIndex];
                var label = hit.Series.Name + ": " + point.YValues[0].ToString();
                chart1.Series[hit.Series.Name].ToolTip = label;
                chart1.Cursor = Cursors.Hand;
            }
            else
            {
                chart1.Series.ToList().ForEach(s => s.ToolTip = string.Empty);
                chart1.Cursor = Cursors.Default;
            }
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서별 사원수 차트
        public async Task DeptChart()
        {
            Chart chart = chart1;

            Series series = chart.Series["series"];
            series.Name = "사원수";

            //chartList = DeptRepository.Instance.GetDeptUserCnt();

            var deptList = await ApiDeptRepository.Instance.GetDept(1);
            var userList = await ApiUserRepository.Instance.GetUser(1);

            chartList = deptList.Data
                .Select(d => new DeptUserCnt
                {
                    DeptName = d.DeptName,
                    UserCnt = userList.Data.Count(u => u.IdDept == d.Id)
                })
                .ToList();
            
            if (chartList.Count > 0)
            {
                foreach(var item in chartList)
                {
                    series.Points.AddXY(item.DeptName, item.UserCnt);
                }
            }

            chart.ChartAreas[0].AxisX.Interval = 1;                     // 기본 간격(모든 라벨 표시)
            chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;            // 라벨 자동맞춤 (크기 각도 자동조절)
            chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;    // 라벨 여러 줄로 표시
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;        // 불필요한 격자 제거
            chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;         // X축 스크롤바 활성화 (많은 데이터가 있을 때 스크롤 가능)
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;        // X축 확대/축소(Zoom) 기능 활성화
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;           // 마우스로 X축 구간 선택(커서 기능) 허용
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;  // 드래그해서 특정 영역을 선택 → 확대할 수 있도록 허용

            // 차트 제목 설정
            Title title = new Title("부서별 사원수", Docking.Top, new System.Drawing.Font("Arial", 14), System.Drawing.Color.Black);
            chart.Titles.Add(title);
        }
    }
}
