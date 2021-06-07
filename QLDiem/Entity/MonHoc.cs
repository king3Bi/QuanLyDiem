using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiem.Entity
{
    public class MonHoc
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTinChi { get; set; }

        public virtual IList<KetQua> KetQuas { get; set; }
    }
}
