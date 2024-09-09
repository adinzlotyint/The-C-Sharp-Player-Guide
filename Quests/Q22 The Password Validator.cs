using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest22
    {
        public static void Quest()
        {
            string password;
            while (true)
            {

                Console.WriteLine("Provide password:");
                password = Console.ReadLine();

                PasswordValidation.Validate(password);
            }


        }
    }
}

public class PasswordValidation
{

    public static void Validate(string pass)
    {
        if (pass.Length > 13)
        {
            Console.WriteLine("Password too long.");
        }
        else if (pass.Length < 6)
        {
            Console.WriteLine("Password too short.");
        }
        else if (pass.ToLower() == pass)
        {
            Console.WriteLine("Password have to contain at least one upper case letter.");
        }
        else if (pass.ToUpper() == pass)
        {
            Console.WriteLine("Password have to contain at least one lower case letter.");
        }
        else if (!pass.Any(char.IsNumber))
        {
            Console.WriteLine("Password must contain at least 1 number.");
        }
        else if (pass.Contains("T") == true)
        {
            Console.WriteLine("Password cannot contain capital letter \"T\".");
        }
        else if (pass.Contains("&") == true)
        {
            Console.WriteLine("Password cannot contain \"&\".");
        }
        else
        {
            Console.WriteLine("Good password.");
        }

    }
}