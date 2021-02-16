using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AIE_37_FileIOsavecontact
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
                sw.WriteLine(name);
                sw.WriteLine(email);
                sw.WriteLine(phone);
            }
            
        }

        public void DeSerialise(string filename)
        {
            using (StreamReader readtext = new StreamReader(filename))
            {
                name = readtext.ReadLine();
                email = readtext.ReadLine();
                phone = readtext.ReadLine();
            }
        }

        public void Print()
        {
            Console.WriteLine($"{name} {email} {phone}");
        }
    }
}
