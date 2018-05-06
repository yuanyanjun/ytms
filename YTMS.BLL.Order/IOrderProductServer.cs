using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.DAL;
using YTMS.Domain;
using YTMS.Common.Core;
namespace YTMS.BLL.Order
{
    public interface IOrderProductServer
    {

        bool Add(List<OrderProductDto> items);

        bool Add(List<OrderProductDto> items, string orderNo);

        List<OrderProductDto> Get(string orderNo);


    }
}
