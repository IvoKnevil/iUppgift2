using System;
using System.Collections.Generic;

namespace iUppgift2
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(welcome());
            Login tryToLogin = new Login();
            if (tryToLogin.LogingIn())
            {
                Console.WriteLine("ok");
            }

        }

        static string welcome()
        {
            return "Välkommen till superprogrammet.";
        }


    }


    class Login
    {
        private int loginCounter = 0;
        private string password = "bästkusten";
        private string inputPassword;

        public bool LogingIn()
        {

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
                    Console.WriteLine("Du har angett fel lösenord ({0}försök). Vänligen försök igen. ", loginCounter + 1);
                    loginCounter++;
                }

            } while (loginCounter < 3);

            Console.Clear();
            Console.WriteLine("Du har gjort för många felaktiga inloggningsförsök. Programmet stängs.");
            return false;

        }



    }





















    /*  

            private string groupName = "bästkusten";
            private List<string> menuList = new List<string>() { $"1. Lista alla deltagare i gruppen bästkusten", "2. Få ut 10 generella detaljer om en medlem", "3. Ta bort en medlem", "4. Avsluta programmet" };
            private int loginCounter = 0;
            private bool inloggad;



            public void showMenu()
            {

                foreach (var item in MenuList)
                {
                    Console.WriteLine(item);
                }
            }

    */






}