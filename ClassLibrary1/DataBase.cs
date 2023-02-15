using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DataBase
    {
        private List<PersonRecord> PersonList;
        //Methods
        public void AddPerson(PersonRecord pPerson)
        {
            PersonList.Add(pPerson);
        }
        public List<PersonRecord> SearchPerson(string pId)
        {
            List<PersonRecord> PersonListTemp = PersonList.Where(x => x.Id == pId).ToList();
            if (PersonListTemp.Count > 0) return PersonListTemp;
            else return null;
        }
        public List<PersonRecord> RemovePerson(string pId)
        {
            List<PersonRecord> PersonListTemp = PersonList.Where(x => x.Id == pId).ToList();
            if (PersonListTemp.Count > 0)
            {
                foreach (PersonRecord person in PersonListTemp)
                {
                    PersonList.Remove(person);
                }
                return PersonListTemp;
            }
            else return null;
        }
        //Constructor
        public DataBase()
        {
            PersonList = new List<PersonRecord>();
        }
    }
}
