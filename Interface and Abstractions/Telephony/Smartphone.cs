using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string CallOtherPhone(string phone)
        {

            if (phone.All(x => x >= '0' && x <= '9'))
            {
                return $"Calling... {phone}";
            }
            return "Invalid number!";
        }

        public string SurfTheWeb(string website)
        {
            if (!website.All(x=>x<'0' || x>'9'))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {website}!";
        }
    }
}
