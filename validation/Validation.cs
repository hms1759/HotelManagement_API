using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.validation
{
    public class Validation
    {
        public static string IsPhoneNumber = "^[0]{1}[0-9]{10}$";
        public static string IsPhoneNumberAlt = "^[+234]{4}[0-9]{10}$";

        public static string IsEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
    }
}
