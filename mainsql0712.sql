drop database QuanLyPhuKien
use master
go

create database QuanLyPhuKien
go

use QuanLyPhuKien
go

create table NhanVien (
MaNhanVien varchar(10) not null primary key,
HoTenNhanVien nvarchar(30)not null,
GioiTinh nvarchar(5)not null,
NgaySinh date not null,
DiaChi nvarchar(50) not null,
SoDienThoai varchar(11) not null,
MatKhau varchar(15) not null,
PhanQuyen nvarchar(15) not null,
statuss int 
)
go

create table LoaiSanPham (
MaLoaiSanPham varchar(10) not null primary key,
TenLoaiSanPham nvarchar(30) not null,
MoTa nvarchar(200),
)
go

create table SanPham(
MaSanPham varchar(10) not null primary key,
MaLoaiSanPham varchar(10) references LoaiSanPham(MaLoaiSanPham),
TenSanPham nvarchar(50) not null,
SoLuong int not null,
GiaNhap int not null,
GiaBan int not null,
ThoiGianBaoHanh nvarchar(20),
DonVi nvarchar(20) not null,
MoTa nvarchar(200),
)
go

create table HoaDon (
MaHoaDon int not null IDENTITY(1,1) PRIMARY KEY,
MaNhanVien varchar(10) references NhanVien(MaNhanVien),
NgayLap date not null default getdate(),
TongTienHoaDon int,
)
create table ChiTiet_HoaDon (
MaChiTietHoaDon int not null IDENTITY(1,1) PRIMARY KEY ,
MaHoaDon int references HoaDon(MaHoaDon),
MaSanPham varchar(10) references SanPham(MaSanPham),
SoLuong int not null,
TienPhaiTra int,
)
go



insert into NhanVien (MaNhanVien,HoTenNhanVien,GioiTinh,NgaySinh,DiaChi,SoDienThoai,MatKhau,PhanQuyen,statuss) 
values('admin',N'Nguyen Vi Khang',N'Nam','1995-08-17',N'Soc Trang','09394121584','admin','admin',1)
insert into NhanVien (MaNhanVien,HoTenNhanVien,GioiTinh,NgaySinh,DiaChi,SoDienThoai,MatKhau,PhanQuyen,statuss) 
values('nv01',N'sontit',N'Nam','1995-08-17',N'Soc Trang','09121584','123','nhan vien',1)


select * from ChiTiet_HoaDon
select * from HoaDon
select * from NhanVien
select * from SanPham
select * from LoaiSanPham