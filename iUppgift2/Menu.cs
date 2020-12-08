using System;
using System.Collections.Generic;
using System.Text;

namespace iUppgift2
{
    class Menu
    {
        private List<string> menuList = new List<string>() { "Lista alla deltagare i gruppen bästkusten", "Få ut 10 generella detaljer om en medlem", "Ta bort en medlem", "Avsluta programmet\n" };
        private int userInput;
        private string userInputDescription;
        private object[] menuChoiceToReturn = new object[2];


        public void ShowMenu()
        {

            for (int i = 0; i < menuList.Count; i++)
            {
                //Loopen som går igenom listen menuList för att sammanställa en meny där varje rad inleds med en siffra och en punkt. 
                Console.WriteLine((i + 1) + ". " + menuList[i]);
            }

        }

        public object[] UserMenuChoice() //metoden tar in användarens menyval (valet=int, valets beskrivning=string) och lägger till dessa två i en array som skickas tillbaka till programmet. 
        {

            Console.Write("Vänligen välj en funktion i menyn: ");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            menuChoiceToReturn[0]= userInput;

            if (userInput > 0 && userInput < 5) //if-else satsen som säkerställer att det finns en sträng att lägga till i listan ifall användaren gör ett val utanför intervallen för listans index.
            {
                userInputDescription=menuList[userInput - 1];
            }
            else
            {
                userInputDescription= $"val nr {userInput} som inte existerar i nuläget.\nFör att du inte ska bli besviken att ditt val inte " +
                    $"ledde till något bra får du tips om en häftig bröllopsfotograf.\n\nBesök ivonazlic.com";
            }

            menuChoiceToReturn[1]=userInputDescription;

            return menuChoiceToReturn;

        }
    }
}
