using System;
using System.Collections.Generic;
using System.Text;

namespace iUppgift2
{
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


        public override string ToString()
        {
            return ($"Namn: {name}\nLängd: {height}\nÅlder: {age}\nHobby: {hobby}\nFavoritmat: {favoriteFood}\nFavoritfärg: {favoriteColor}\nMotivation till programmering: {whyPrograming}\nHemort: {domicile}\nFödelseort: {birthplace}\nSyskon: {numberOfSiblings}\n");
        }
    }
}
