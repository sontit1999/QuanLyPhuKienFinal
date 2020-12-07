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
    public partial class MenuForm : Form
    {
        NhanVien nv;
        public MenuForm()
        {
            InitializeComponent();
        }

        // Kiểm tra quyền 
        public MenuForm(NhanVien nhanvien)
        {
            InitializeComponent();

            this.nv = nhanvien;
            // check để chon chưc năng tương ứng cho từng tk
            if (nv.Role.Equals("admin")) // quyền admin
            {
               // ko ql loại và qlsp
                btnLoaiSP.Enabled = false;
                btnSanPham.Enabled = false;
            }
            else
            {
                // ko qlnv
                btnNhanVien.Enabled = false; // quyền nv
            }
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (nv != null)
            {
                lblChaomung.Text = "Chào mừng " + nv.TenNv + " đến với hệ thống quản lý phụ kiện <3";
            }
           
        }

        // nút quan ly nv
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            QLNhanVien qLnhanvien = new QLNhanVien();
            qLnhanvien.Show();
        }

        
        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            QLLoaiSanPham qLloaiSP = new QLLoaiSanPham();
            qLloaiSP.Show();
        }

        
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            QLSanPham qLSanPham = new QLSanPham(null);
            qLSanPham.Show();
        }

        
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            
            QuanLyHoaDon qliHoadon = new QuanLyHoaDon();
            qliHoadon.Show();
        }


        private void btnThongke_Click(object sender, EventArgs e)
        {
            
            ThongKe thongke = new ThongKe();
            thongke.Show();     
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            this.Hide();
            this.Close();
            dangnhap.Show();
        }
    }
}
