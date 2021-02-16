using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AIE_38_FileIOsavecontact2
{
    class Contact
    {
        public string name = "";
        public string email = "";
        public string phone = "";

        public Contact()
        {

        }

        public Contact(string name, string email, string phone)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public void Serialise(string filename)
        {
            // TODO: use StreamWriter to write the name, email and phone to file
            // check if directory exists , if not make directory

            var fileInfo = new FileInfo(filename);
            var dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);

            using (StreamWriter sw = File.CreateText(filename))
            {
                if (!string.IsNullOrWhiteSpace(name))  sw.WriteLine($"name {name}");
                if (!string.IsNullOrWhiteSpace(email)) sw.WriteLine($"email {email}");
                if (!string.IsNullOrWhiteSpace(phone)) sw.WriteLine($"phone {phone}");
            }
        }

        public void DeSerialise(string filename)
        {
            using (StreamReader readtext = new StreamReader(filename))
            {
                string line;

                while ((line = readtext.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    string key = words[0];
                    string value = words[1];

                    if (key == "name") { name = value; }
                    if (key == "email") { email = value; }
                    if (key == "phone") { phone = value; }
                }
            }
        }

        public void Print()
        {

            Console.WriteLine($"{name} {email} {phone}");

            //using(StreamReader writeText = File.OpenText(filename))
            //{
            //    string s;
            //    while ((s = writeText.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }

            //    Console.WriteLine("");

            //    // why is this line of code read in the midst of the text being written on console during "while"
            //}
        }
    }
}
