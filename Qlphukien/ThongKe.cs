using Qlphukien.DAO;
using Qlphukien.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlphukien
{
    public partial class ThongKe : Form
    {
        SanPhamDao spDao = new SanPhamDao();
        NhanVienDao nvDao = new NhanVienDao();
        // list chứa dssp dc thống kê
        List<SPTK> list;
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            List<string> years = spDao.GetYears();

            // thời gian cố định bát đầu và kết thúc
            dateTimePickerFrom.CustomFormat = "dd/MM/yyyy";
            dateTimePickerto.CustomFormat = "dd/MM/yyyy";

            // lấy tg hiển thị cố định
            dateTimePickerFrom.Value = new DateTime(2018, 10, 01);
            dateTimePickerto.Value = DateTime.Now;

            // 
            cboQuy.SelectedIndex = 0;
            cboQuy.Enabled = false;

            // thêm năm cho cboNam
            foreach (string year in years)
                cboNam.Items.Add(year);
            if (cboNam.Items.Count >= 1)
            {
                cboNam.SelectedIndex = cboNam.Items.Count - 1;
            }
            cboNam.Enabled = false;
        }

        // tra cứu
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // tất cả sp đã nhập từ .. đến ...
            string from = dateTimePickerFrom.Value.ToString("yyyy-MM-dd").Split(' ')[0];
            string to = dateTimePickerto.Value.ToString("yyyy-MM-dd").Split(' ')[0];
            list = new List<SPTK>();
            list =  spDao.getAllSPNhap(from,to);       
            // hiển thị ds
            displayListTodgv(dgvsanpham, list);
            // tổng tiền
            lbl_totalmoney.Text = caculateTongtien()+" VNĐ";
        }

         // Pthuc tinh tong tien
        private int caculateTongtien()
        {
            int tongtien = 0;
            foreach(SPTK item in list)
            {
                tongtien += item.tongtien;
            }
            return tongtien;
        }

        // hiển thị ds sp trong dgv
        private void displayListTodgv(DataGridView dgv, List<SPTK> list)
        {
            dgv.Rows.Clear();

            dgv.ColumnCount = 6;

            int i = 0;
            foreach (SPTK item in list)
            {

                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = item.Tensp;
                dgv.Rows[i].Cells[1].Value = item.slnhap;
                dgv.Rows[i].Cells[2].Value = item.dongianhap + " đ";
                dgv.Rows[i].Cells[3].Value = item.tongtien + " đ";
                dgv.Rows[i].Cells[4].Value = nvDao.GetNameNhanVien(item.tennvnhap);
                dgv.Rows[i].Cells[5].Value = item.ngaynhap.Split(' ')[0];           
                i++;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void chkQuy_CheckedChanged(object sender, EventArgs e)
        {
            //mở two DateTimePicker controls: dateTimePickerFrom and dateTimePickerto khi ko chọn quý
            dateTimePickerFrom.Enabled = !chkQuy.Checked;
            dateTimePickerto.Enabled = !chkQuy.Checked;

            // mở chọn quý và năm khi click chọn quý
            cboQuy.Enabled = chkQuy.Checked;
            cboNam.Enabled = chkQuy.Checked;

            if (chkQuy.Checked)
            {
                UpdateData();
            }
            else
            {
                dgvsanpham.Rows.Clear();
            }
        }

        private void UpdateData()
        {
            string fromDate = "";
            string toDate = "";
            string year = cboNam.Text;

            // lấy thoi gian
            switch (cboQuy.SelectedIndex)
            {
                case 0:
                    fromDate = year + "-01-01";
                    toDate = year + "-03-31";
                    break;
                case 1:
                    fromDate = year + "-04-01";
                    toDate = year + "-06-30";
                    break;
                case 2:
                    fromDate = year + "-07-01";
                    toDate = year + "-09-30";
                    break;
                case 3:
                    fromDate = year + "-10-01";
                    toDate = year + "-12-31";
                    break;
            }

            // lấy dữ liệu
            list = spDao.getAllSPNhap(fromDate, toDate); // sai ở hàm getALLSP  
            // hiển thị ds
            displayListTodgv(dgvsanpham, list);
            // tổng tiền
            lbl_totalmoney.Text = caculateTongtien() + " VNĐ";
        }

        // ko chọn quý
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkQuy.Checked)
            {
                return;
            }

            UpdateData();
        }

        // ko chọn quý
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkQuy.Checked)
            {
                return;
            }

            UpdateData();
        }
    }
}
