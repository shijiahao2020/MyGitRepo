using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class User
    {
        private int age;
        private string name;

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

        public User(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    class student
    {
        public string name
        {
            get;set;
        }
        public string ID
        {
            get;set;
        }
    }
}
