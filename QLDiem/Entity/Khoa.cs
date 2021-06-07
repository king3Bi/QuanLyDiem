using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiem.Entity
{
    public class Khoa
    {
        public int MaK { get; set; }
        public string TenKhoa { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
