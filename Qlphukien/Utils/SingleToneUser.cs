using Qlphukien.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.utils
{

    // class SingleToneUser lưu thông tin nhân viên hiện tại đang đăng nhập qua biến nv
    // lưu lại để lúc phân quyền dựa vào loại nhân viên nào thì cho chức năng tương ứng
    public class SingleToneUser
    {
        public static NhanVien nv;
    }
}
