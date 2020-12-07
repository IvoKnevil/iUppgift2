﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iUppgift2
{
    class Login
    {
        private int loginCounter = 0;
        private string password = "bästkusten";
        private string inputPassword;

        public bool LogingIn()
        {
                    //loopen som ber användaren mata in sitt inloggningslösen. Räknar antal felaktiga försök. Om användare anger fel lösen tre gången avslutas programmet.
            do
            {
                Console.Write("Vänligen ange ditt lösenord: ");
                inputPassword = Console.ReadLine();
                if (inputPassword == password)
                {
                    Console.Clear();
                    return true;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du har angett fel lösenord ({0}försök)\n", loginCounter + 1);
                    loginCounter++;
                }

            } while (loginCounter < 3);

            Console.Clear();
            Console.WriteLine("Du har gjort för många felaktiga inloggningsförsök. Programmet stängs.");
            return false;

        }
    }
}
