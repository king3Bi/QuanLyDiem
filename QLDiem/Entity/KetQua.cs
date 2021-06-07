using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiem.Entity
{
    public class KetQua
    {
        public double Diem { get; set; }
        public int MaSV { get; set; }
        public SinhVien SinhVien { get; set; }

        public int MaMH { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
