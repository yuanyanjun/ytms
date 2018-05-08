using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Account
{
    public interface IAccountServer
    {
        AdminDto Get(long id);
    }
}
