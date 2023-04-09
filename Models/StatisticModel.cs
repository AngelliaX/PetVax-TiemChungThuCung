using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using System.Linq;

namespace Models
{
    public class StatisticModel
    {
        private TiemChungThuCungDbContext context = null;
        public StatisticModel()
        {
            context = new TiemChungThuCungDbContext();
        }

        public List<account> ListAll()
        {
            var list = context.accounts.Select(a => a).ToList();
            return list;
        }
    }
}
