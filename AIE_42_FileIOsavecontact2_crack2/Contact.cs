using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIE_42_FileIOsavecontact2_crack2
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

            //create folder
            var fileInfo = new FileInfo(filename);
            string dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);

            //write text
            using (StreamWriter sw = File.CreateText(filename))
            {
                if (!string.IsNullOrWhiteSpace(name)) { sw.WriteLine($"name: {name}"); }
                if (!string.IsNullOrWhiteSpace(email)) { sw.WriteLine($"email: {email}"); }
                if (!string.IsNullOrWhiteSpace(phone)) { sw.WriteLine($"phone: {phone}"); }
            }
            
        }

        public void DeSerialise(string filename)
        {
            // TODO: use StreamReader to write the name, email and phone to file

            using (StreamReader sr = File.OpenText(filename))
            {

                string s;
                //string s = sr.ReadLine();
                //while (s != null)

                //why do we need a string ?
                //we need the string as streamreaderwill will read the line, assign it to the string variable, and then see if the string != null)
                // we need a variable to test against null

                while ((s = sr.ReadLine()) != null) 
                 //while ((string s = sr.ReadLine()) != null) - why can't you create string here?
                {
                    if (s.Contains("name")) { name = s; }
                    if (s.Contains("email")) { email = s; }
                    if (s.Contains("phone")) { phone = s; }

                    //string[] words = s.Split(" ");
                    //string key = words[0];
                    //string value = words[1];

                    //if (key == "name:") { name = value; }
                    //if (key == "email:") { email = value; }
                    //if (key == "phone:") { phone = value; }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"{name} {email} {phone}");
        }
    }
}
