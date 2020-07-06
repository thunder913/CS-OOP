using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string CallOtherPhone(string phone)
        {
            if (phone.All(x => x >= '0' && x <= '9'))
            {
            return $"Dialing... {phone}";
            }
            return "Invalid number!";
        }


    }
}
