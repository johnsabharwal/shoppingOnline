using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Enum
{
    public enum EnumOrderStatus
    {
        WaitingForConfirmation = 1,
        Dispatched = 2,
        OutForDelivery = 3,
        Delivered = 4,
    }
}
