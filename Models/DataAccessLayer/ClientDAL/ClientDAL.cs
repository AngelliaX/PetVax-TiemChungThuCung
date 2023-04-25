using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer.ClientDAL
{
    public class ClientDAL
    {
        TiemChungThuCungDbContext db = null;
        public ClientDAL() 
        {
            db = new TiemChungThuCungDbContext();
        }
        public List<client> GetAllListClient() 
        {
            List<client> list = db.clients.Select(m => m).ToList();
            return list;
        }
        public bool CheckIfClientIsExist(string Username)
        {
            if(db.clients.Count(m => m.username == Username) > 0) return true;
            else return false;
        }

    }
}
