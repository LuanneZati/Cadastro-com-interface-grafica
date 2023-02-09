using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class GraphicInterface
    {
        private static string path;
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

        public GraphicInterface() 
        {
            path = "C:\\Users\\Luanne\\Documents\\C#\\Arquivo texto\\data.txt";
            delimiterStart = "##### START #####";
            delimiterEnd = "##### END #####";
            tagName = "NAME: ";
            tagAge = "AGE: ";
            tagId = "ID: ";
            tagBirth = "BRITH DATE: ";
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
        public void LoadData(List<PersonRecord> UserList)
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
                        else if (line.Contains(delimiterEnd))
                            UserList.Add(dataReg);
                        else if (line.Contains(tagName))
                            dataReg.Name = line.Replace(tagName, "");
                        else if (line.Contains(tagAge))
                            dataReg.Age = Convert.ToInt32(line.Replace(tagAge, ""));
                        else if (line.Contains(tagId))
                            dataReg.Id = line.Replace(tagId, "");
                        else if (line.Contains(tagBirth))
                            dataReg.Birth = Convert.ToDateTime(line.Replace(tagBirth, ""));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION: " + e.Message);
            }
        }
        //Update text file data
        public static void UploadData(List<PersonRecord> UserList)
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
        public void StartsInterface()
        {
            List<PersonRecord> UserList = new List<PersonRecord>();
            GraphicInterface x = new GraphicInterface();
            LoadData(UserList);
        }
    }
}
