using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity
{
    public class EntityBasvuruFormu
    {
        private int basvuruid;
        private int basdersid;
        private int basogrid;

        public int Basvuruid { get => basvuruid; set => basvuruid = value; }
        public int Basdersid { get => basdersid; set => basdersid = value; }
        public int Basogrid { get => basogrid; set => basogrid = value; }
    }
}
