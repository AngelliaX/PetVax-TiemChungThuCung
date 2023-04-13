using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;
using System.Linq;

namespace Models.DataAccessLayer
{
    public class StatisticDAO
    {
        private TiemChungThuCungDbContext context = null;
        public StatisticDAO()
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
