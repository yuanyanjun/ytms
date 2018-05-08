using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Order
{
    public class RoomCheckOutSettlesDto: YTMS.Domain.T_Room_Checkout_Settles
    {

      
        public decimal ThirdFeeCompute
        {
            get
            {
                return TotalAmount * ThirdPercent;
            }
        }

        public decimal ActualAmountCompute
        {
            get
            {
                return TotalAmount - ThirdFee - WastageAmount;
            }
        }
    }
}
