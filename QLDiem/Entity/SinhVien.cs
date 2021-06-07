using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiem.Entity
{
    public class SinhVien
    {
        public int MaSV { get; set; }
        public string HoVaTen { get; set; }
        public string Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public int MaK { get; set; }

        public virtual IList<KetQua> KetQuas { get; set; }
        public virtual Khoa Khoa { get; set; }
    }
}
