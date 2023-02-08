//class constructor properties methods (add - search - 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PersonRecord
    {
        //atributes
        private string name;
        private int age;
        private string id;
        private DateTime birth;
        //Properties
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Id { get { return id; } set { id = value; } }
        public DateTime Birth { get { return birth; } set { birth = value; } }
        //Constructor
        public PersonRecord(string name, int age, string id, DateTime birth)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.birth = birth;
        }
        public PersonRecord()
        {
            name = "";
            age = 0;
            id = "";
            birth = DateTime.Now;
        }
    }
}
