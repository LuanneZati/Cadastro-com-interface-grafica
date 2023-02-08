using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class GraphicInterface
    {
        private static string path = "C:\\Users\\Luanne\\Documents\\C#\\notations\\data.txt";
        private static string delimiterStart;
        private static string delimiterEnd;
        private static string tagName;
        private static string tagAge;
        private static string tagId;
        private static string tagBirth;

        public static string Path { get { return path; } set { path = value; } }
        public static string DelimiterStart { get { return delimiterStart; } set { delimiterStart = value; } }
        public static string DelimiterEnd { get { return delimiterEnd; } set { delimiterEnd = value; } }
        public static string TagId { get { return tagId; } set { tagId = value; } }
        public static string TagAge { get { return tagAge; } set { tagAge = value; } }
        public static string TagName { get { return tagName; } set { tagName = value; } }
        public static string TagBirth { get { return tagBirth; } set { tagBirth= value; } }

        //Get user data, put in list and store in text file
        public void RecordUser(ref List<PersonRecord> UserList)
        {
            PersonRecord UserRecord;
            Console.Clear();

            try
            {
                Console.Write(tagName);
                string auxName = Console.ReadLine();

                Console.Write(tagAge);
                int auxAge = Convert.ToInt32(Console.ReadLine());

                Console.Write(tagId);
                string auxId = Console.ReadLine();

                Console.Write(tagBirth);
                DateTime auxBirth = Convert.ToDateTime(Console.ReadLine());

                UserRecord = new PersonRecord(auxName, auxAge, auxId, auxBirth);

                UserList.Add(UserRecord);
                Console.WriteLine("\nSucess!");
                StoreData(UserList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        //Store data in text file
        public static void StoreData(List<PersonRecord> UserList)
        {
            bool exist = File.Exists(path);
            try
            {
                if (exist == true)
                {
                    string contentFile = "";
                    foreach (PersonRecord item in UserList)
                    {
                        contentFile += delimiterStart + "\n";
                        contentFile += tagName + item.Name + "\n";
                        contentFile += tagId + item.Id + "\n";
                        contentFile += tagAge + item.Age + "\n";
                        contentFile += tagBirth + item.Birth + "\n";
                        contentFile += delimiterEnd + "\n";
                    }
                    File.WriteAllText(path, contentFile);
                }
                else
                {
                    FileStream myFile = File.Create(path);
                    myFile.Close();
                    StoreData(UserList);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }
        //when starting the program every data in text file are load to list
        static void LoadData(List<PersonRecord> UserList)
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] contentFile = File.ReadAllLines(path);
                    PersonRecord dataReg = new PersonRecord();

                    foreach (string line in contentFile)
                    {
                        if (line.Contains(delimiterStart))
                            continue;
                        if (line.Contains(delimiterEnd))
                            UserList.Add(dataReg);
                        if (line.Contains(tagName))
                            dataReg.Name = line.Replace(tagName, "");
                        if (line.Contains(tagAge))
                            dataReg.Age = Convert.ToInt32(line.Replace(tagAge, ""));
                        if (line.Contains(tagId))
                            dataReg.Id = line.Replace(tagId, "");
                        if (line.Contains(tagBirth))
                            dataReg.Birth = Convert.ToDateTime(line.Replace(tagBirth, ""));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION: " + e.Message);
            }
        }
        //Show data that is in text file
        static void ShowData()
        {
            Console.Clear();
            try
            {
                if (File.Exists(path))
                {
                    Console.WriteLine(File.ReadAllText(path));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ReadKey();
        }
        //Update text file data
        static void UploadData(List<PersonRecord> UserList)
        {
            try
            {
                FileStream FS = File.Create(path);
                FS.Close();
                StreamWriter SW = new StreamWriter(path);
                string contentFile = "";
                foreach (PersonRecord item in UserList)
                {
                    contentFile += delimiterStart + "\n";
                    contentFile += tagName + item.Name + "\n";
                    contentFile += tagAge + item.Age + "\n";
                    contentFile += tagId + item.Id + "\n";
                    contentFile += tagBirth + item.Birth + "\n";
                    contentFile += delimiterEnd + "\n";
                }
                SW.WriteLine(contentFile);
                SW.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }
        //Delete user-supplied record
        static void DeleteData(ref List<PersonRecord> UserList)
        {
            int count = 0;
            Console.Clear();
            try
            {
                PersonRecord aux = new PersonRecord();
                Console.Write("Enter the ID you want to delete\n- if you digit \"all\" every records will be deleted\n= ");
                aux.Id = Console.ReadLine();

                if (aux.Id.ToUpper() == "ALL")
                {
                    for (int i = UserList.Count - 1; i >= 0; i--)
                    {
                        UserList.RemoveAt(i);
                    }
                    Console.WriteLine("Every Records have been deleted!");
                    File.Delete(path);
                    UploadData(UserList);
                }
                else
                {
                    for (int i = UserList.Count - 1; i >= 0; i--)
                    {
                        if (UserList[i].Id.ToUpper() == aux.Id.ToUpper())
                        {
                            UserList.RemoveAt(i);
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Record not found!");
                    }
                    else
                    {
                        Console.WriteLine("Deleted!");
                        File.Delete(path);
                        UploadData(UserList);
                        count = 0;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        public void StartsInterface()
        {
            List<PersonRecord> UserList = new List<PersonRecord>();
            GraphicInterface x = new GraphicInterface();
            int option;
            delimiterStart = "##### START #####";
            delimiterEnd = "##### END #####";
            tagName = "NAME: ";
            tagAge = "AGE: ";
            tagId = "ID: ";
            tagBirth = "BRITH DATE: ";
            //Load data's in text file
            LoadData(UserList);

            do
            {
                Console.Clear();
                Console.WriteLine("1- Register User\n2- Fetch records\n3- Delete Records\n4- Exit");
                Console.Write("Your opção: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RecordUser(ref UserList);
                        break;
                    case 2:
                        ShowData();
                        break;
                    case 3:
                        DeleteData(ref UserList);
                        break;
                    case 4:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option..");
                        Console.ReadKey();
                        break;
                }

            } while (option != 4);
        }
    }
}
