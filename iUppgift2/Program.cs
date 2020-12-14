using System;
using System.Collections.Generic;

namespace iUppgift2
{
    class Program
    {

        static private bool keepPlaying = true;  // booleanen så att programmet körs så länge användaren inte valt att avsluta.
        static private List<Student> groupMembers = new List<Student>();
        static private List<string> namesOfAllMembers = new List<string>();


        static void Main(string[] args)
        {

            RunProgram();

        }


        static void RunProgram()
        {

            Console.WriteLine(Welcome());

            //om lyckad inloggning körs resten av koden, annars avslutas programmet.
            if (Login.LogingIn())
            {
                ProgramLayout();
                groupMembers = CreateStudents(); //kallar metoden som skapar ett objekt för varje student. Lägger till objekten i en lista på medlemmar.


                while (keepPlaying)
                {
                    Menu.ShowMenu();  //kallar metoden som visar menyn.
                    ProgramActions(Menu.UserMenuChoice()); //kallar metoden som tar in användarens val, samt skickar det till en ny metod som utför det som användaren valt att göra.
                }

                Console.WriteLine("See ya!");
            }

        }


        static string Welcome()
        {
            return "Välkommen till superprogrammet. \n";
        }

        static void ProgramLayout()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.Title = "Bästkusten";
        }

        static List<Student> CreateStudents()
        {

            groupMembers.Add(new Student("Ivo", 174, 42, "fotografi", "scampi", "svart", "möjlighet att vara kreativ", "Uppsala", "Split", 1));
            groupMembers.Add(new Student("David", 183, 32, "bjj", "tacos", "blå", "att lösa roblem", "Nörrtälje", "Göteborg", 1));
            groupMembers.Add(new Student("Johan", 194, 34, "gaming", "tacos", "blå", "möjlighet för trygg framtid", "Mariefred", "Mariefred", 2));
            groupMembers.Add(new Student("Oscar", 185, 26, "fotboll", "lasagne", "blå", "jobbmöjligheter", "Stockholm", "Stockholm", 1));
            groupMembers.Add(new Student("Sanjin", 179, 30, "fotboll", "pizza", "blå", "jobbmöjligheter", "Norrköping", "Mostar", 2));
            groupMembers.Add(new Student("Jerry", 181, 19, "gaming", "älggryta", "teal", "jobbmöjligheter", "Djurö", "Köln", 1));
            groupMembers.Add(new Student("Cecillia", 163, 29, "The Sims", "risotto", "gul", "möjlighet att vara kreativ", "Norrköping", "Norrköping", 1));
            groupMembers.Add(new Student("Elin", 170, 31, "hästar", "sushi", "röd", "personlig utveckling", "Knivsta", "Karlskoga", 2));
            groupMembers.Add(new Student("Mostafa", 174, 33, "träning", "oxfile", "svart", "Tycker om att koda och lösa problem", "Stockholm", "Stockholm", 4));

            return groupMembers;
        }


        static void ProgramActions(object[] userMenuChoice)
        {

            Console.WriteLine($"Du har valt {userMenuChoice[1]}\n");
            switch (userMenuChoice[0])
            {
                //om användaren valt 1 kallar metoden som printar en lista på medlemars namn, separerat med , tecke. 
                case 1:
                    PrintMembersOnSingleLine();
                    ClearScreen();
                    break;

                case 2:
                    ShowAllMembersNames(); //kallar metoden för att presentera en meny på gruppens medlemmar.

                    Console.Write("\nAnge nummer för den personen som du vill veta mera om: ");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (userInput > 0 && userInput < groupMembers.Count) //Kollar om användaren angett ett nummer som inte är utanför menyintervallen
                    {
                        Console.WriteLine(groupMembers[userInput - 1]);  //kallar metoden ToString under klassen student.
                    }
                    else
                    {
                        Console.WriteLine(Menu.ReturnErrorMsg(userInput));
                    }

                    ClearScreen();
                    break;

                case 3:
                    ShowAllMembersNames();

                    RemoveMemberFromGroup();  //kallar metoden för att ev ta bort en gruppmedlem.
                    Console.Clear();

                    Console.Write("Medlemmar kvar: ");
                    PrintMembersOnSingleLine();

                    ClearScreen();
                    break;

                case 4:
                    keepPlaying = false;  //för att avsluta programmet
                    break;

                default:
                    ClearScreen();
                    break;

            }

        }


        static void PrintMembersOnSingleLine()
        {
            //skapar en lista med namn på medlemar för att (innan metoden avslutas) kunna få ut dessa på en rad, separarede med , tecke via en string.join kommando.
            namesOfAllMembers.Clear();

            foreach (var item in groupMembers)
            {
                namesOfAllMembers.Add(item.Name);
            }

            Console.WriteLine(String.Join(", ", namesOfAllMembers) + "\n");

        }

        static void ShowAllMembersNames() //Metod som presenterar gruppmedlemar på en menyliknande lista. 
        {

            for (int i = 0; i < groupMembers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {groupMembers[i].Name}");
            }

        }

        static void RemoveMemberFromGroup() //Metod för att eventuellt ta bort en gruppmedlem.
        {
            Console.Write("\nAnge nummer för den personen som du vill ta bort from gruppen: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (userInput > 0 && userInput < groupMembers.Count)
            {
                Console.Write($"Vill du verkligen ta bort {groupMembers[userInput - 1].Name} from grupplistan? (y/n)");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y" || answer.ToLower() == "j")
                {
                    groupMembers.RemoveAt(userInput - 1);
                }

            }
            else
            {
                Console.WriteLine(Menu.ReturnErrorMsg(userInput));
                ClearScreen();
            }
        }

        static void ClearScreen()
        {
            Console.WriteLine("Tryck valfritt tangent för att fortsätta.");
            Console.ReadKey();
            Console.Clear();

        } 

    }


}