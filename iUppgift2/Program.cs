using System;
using System.Collections.Generic;

namespace iUppgift2
{
    class Program
    {
        
        public static bool keepPlaying = true;  //använder denna bool så att programmet körs så länge användaren inte valt att avsluta.
        public static List<Student> groupMembers = new List<Student>();  
        public static List<string> namesOfAllMembers = new List<string>();


        static void Main(string[] args)
        {

            Console.WriteLine(Welcome());

            //skapar ett objekt för inloggningsprocessen.
            Login tryToLogin = new Login();

            //om lyckad inloggning körs resten av koden, annars avslutas programmet.
            if (tryToLogin.LogingIn())  
            {
                ProgramLayout();
                groupMembers = CreateStudents(); //kallar metoden som skapar ett objekt för varje student. Lägger till objekten i en lista på medlemmar.

                Menu userMenu = new Menu(); //skapar ett objekt för menyn.

                while (keepPlaying)  
                {
                    userMenu.ShowMenu();  //kallar metoden som visar menyn.
                    MenuActions(userMenu.UserMenuChoice()); //kallar metoden som tar in användarens val. 
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

            Student ivo = new Student("Ivo", 174, 42, "fotografi", "scampi", "svart", "möjlighet att vara kreativ", "Uppsala", "Split", 1);
            Student david = new Student("David", 183, 32, "bjj", "tacos", "blå", "att lösa roblem", "Nörrtälje", "Göteborg", 1);
            Student johan = new Student("Johan", 194, 34, "gaming", "tacos", "blå", "möjlighet för trygg framtid", "Mariefred", "Mariefred", 2);
            Student oscar = new Student("Oscar", 185, 26, "fotboll", "lasagne", "blå", "jobbmöjligheter", "Stockholm", "Stockholm", 1);
            Student sanjin = new Student("Sanjin", 179, 30, "fotboll", "pizza", "blå", "jobbmöjligheter", "Norrköping", "Mostar", 2);
            Student jerry = new Student("Jerry", 181, 19, "gaming", "älggryta", "teal", "jobbmöjligheter", "Djurö", "Köln", 1);
            Student cecillia = new Student("Cecillia", 163, 29, "The Sims", "risotto", "gul", "möjlighet att vara kreativ", "Norrköping", "Norrköping", 1);
            Student elin = new Student("Elin", 170, 31, "hästar", "sushi", "röd", "personlig utveckling", "Knivsta", "Karlskoga", 2);

            List<Student> listOfStudents = new List<Student>() { ivo, david, johan, oscar, sanjin, jerry, cecillia, elin };
            return listOfStudents;

        }


        static void MenuActions(List<object> userMenuChoice)
        {
            
            Console.WriteLine("Du har valt " + userMenuChoice[1] + "\n");
            switch (userMenuChoice[0])
            {

                case 1:
                    printMembersOnSingleLine();
                    clearScreen();
                    break;

                case 2:
                    showAllMembersNames();
                    Console.Write("\nAnge nummer för den personen som du vill veta mera om: ");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine(groupMembers[userInput - 1].describe());
                    clearScreen();
                    break;

                case 3:
                    showAllMembersNames();
                    Console.Write("\nAnge nummer för den personen som du vill ta bort from gruppen: ");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Vill du verkligen ta bort {groupMembers[userInput-1].Name} from grupplistan? (Y/N)");
                    string answer = Console.ReadLine();
                    if (answer == "J" || answer == "j" || answer == "Y" || answer == "y")
                    {
                        groupMembers.RemoveAt(userInput - 1);
                    }

                    Console.Write("Medlemmar kvar: ");
                    printMembersOnSingleLine();
                    clearScreen();
                    break;


                case 4:
                    keepPlaying = false;
                    break;

                default:
                    clearScreen();
                    break;

            }


        }


        static void printMembersOnSingleLine()
        {
            namesOfAllMembers.Clear();
            foreach (var item in groupMembers)
            {
                namesOfAllMembers.Add(item.Name);
            }
            Console.WriteLine(String.Join(", ", namesOfAllMembers) + "\n");

        }

        static void showAllMembersNames()
        {

            for (int i = 0; i < groupMembers.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + groupMembers[i].Name);
            }

        }

        static void clearScreen()
        {
                    Console.WriteLine("Tryck valfritt tangent för att fortsätta.");
                    Console.ReadKey();
                    Console.Clear();

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
                        Console.WriteLine("Du har angett fel lösenord ({0}försök)\n", loginCounter + 1);
                        loginCounter++;
                    }

                } while (loginCounter < 3);

                Console.Clear();
                Console.WriteLine("Du har gjort för många felaktiga inloggningsförsök. Programmet stängs.");
                return false;

            }

        }


        class Menu
        {
            private List<string> menuList = new List<string>() { "Lista alla deltagare i gruppen bästkusten", "Få ut 10 generella detaljer om en medlem", "Ta bort en medlem", "Avsluta programmet\n" };
            private int userInput;
            private string userInputDescription;
            private List<object> menuChoiceToReturn = new List<object>();


            public void ShowMenu()
            {

                for (int i = 0; i < menuList.Count; i++)
                {
                        //Loopen som går igenom listen menuList för att sammanställa en meny där varje rad inleds med en siffra och en punkt. 
                        Console.WriteLine((i +1 )+ ". " + menuList[i]);
                }        

            }

            public List<object> UserMenuChoice()
            {
                menuChoiceToReturn.Clear();
                Console.Write("Vänligen välj en funktion i menyn: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                userInputDescription = menuList[userInput-1];
                menuChoiceToReturn.Add(userInput);
                menuChoiceToReturn.Add(userInputDescription);
                return menuChoiceToReturn;

            }


        }


        class Student
        {
            private string name;
            private int height;
            private int age;
            private string hobby;
            private string favoriteFood;
            private string favoriteColor;
            private string whyPrograming;
            private string domicile;
            private string birthplace;
            private int numberOfSiblings;



            public Student()
            {

            }

            public Student(string name, int height, int age, string hobby, string favoriteFood, string favoriteColor, string whyPrograming, string domicile, string birthplace, int numberOfSiblings)
            {
                this.name = name;
                this.height = height;
                this.age = age;
                this.hobby = hobby;
                this.favoriteFood = favoriteFood;
                this.favoriteColor = favoriteColor;
                this.whyPrograming = whyPrograming;
                this.domicile = domicile;
                this.birthplace = birthplace;
                this.numberOfSiblings = numberOfSiblings;
            }


            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public int Height
            {
                get
                {
                    return height;
                }
                set
                {
                    height = value;
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }

            public string Hobby
            {
                get
                {
                    return hobby;
                }
                set
                {
                    hobby = value;
                }
            }


            public string FavoriteFood
            {
                get
                {
                    return favoriteFood;
                }
                set
                {
                    favoriteFood = value;
                }
            } 


            public string FavoriteColor
            {
                get
                {
                    return favoriteColor;
                }
                set
                {
                    favoriteColor = value;
                }
            }

            public string WhyPrograming
            {
                get
                {
                    return whyPrograming;
                }
                set
                {
                    whyPrograming = value;
                }
            }

            public string Domicile
            {
                get
                {
                    return domicile;
                }
                set
                {
                    domicile = value;
                }
            }

            public string Birthplace
            {
                get
                {
                    return birthplace;
                }
                set
                {
                    birthplace = value;
                }
            }

            public int NumberOfSiblings
            {
                get
                {
                    return numberOfSiblings;
                }
                set
                {
                    numberOfSiblings = value;
                }
            }

 
        public string describe ()
            {
            
            return ($"Namn: {name}\nLängd: {height}\nÅlder: {age}\nHobby: {hobby}\nFavoritmat: {favoriteFood}\nFavoritfärg: {favoriteColor}\nMotivation till programmering: {whyPrograming}\nHemort: {domicile}\nFödelseort: {birthplace}\nSyskon: {numberOfSiblings}\n");

            }


        }
}