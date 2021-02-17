using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AIE_41_FileIOsavecontact_crack2
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

            // Create folder
            var fileInfo = new FileInfo(filename); //
            string dir = fileInfo.Directory.FullName; //this is assigning the full directory name to a variable
            Directory.CreateDirectory(dir); //this is creating the folder (if doesn't exist) according to filepath

            // Write to file using streamwriter

            using (StreamWriter sw = File.CreateText(filename)) // this opens the file
            {
                sw.WriteLine($"name: {name}"); // WriteLine + StreamWriter writes to a file, instead of the console
                sw.WriteLine($"email: {email}");
                sw.WriteLine($"phone: {phone}");
            } // the file is now closed
        }

        public void DeSerialise(string filename)
        {
            // TODO: use StreamReader to write the name, email and phone to file

            // read file
            using (StreamReader sr = File.OpenText(filename))
            {

                name = sr.ReadLine();
                email = sr.ReadLine();
                phone = sr.ReadLine();

                //string s;

                //while ((s = sr.ReadLine()) != null)
                //{
                //    name = sr.ReadLine();
                //    email = sr.ReadLine();
                //    phone = sr.ReadLine();
                //}
            }


            // print to console
        }

        public void Print()
        {
            Console.WriteLine($"{name} {email} {phone}");
        }
    }
}
