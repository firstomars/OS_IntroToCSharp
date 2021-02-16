using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_39_FileIOsavecontactlist
{
    class Program
    {
        //Contact contact;
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            {
                //List<Contact> contacts = new List<Contact>();
                contacts.Add(new Contact("bob", "bob@email.com", "12345678"));
                contacts.Add(new Contact("fred", "fred@email.com", "12345678"));
                contacts.Add(new Contact("ted", "ted@email.com", "12345678"));

                // save to file
                SerialiseContactList("contacts.txt", contacts);

                // clear them out
                contacts = new List<Contact>();

                // read from file
                DeSerialiseContactList("contacts.txt", contacts);

            }

            static void SerialiseContactList(string filename, List<Contact> contacts)
            {
                // TODO save all contacts to file.
                var fileInfo = new FileInfo(filename);
                var dir = fileInfo.Directory.FullName;
                Directory.CreateDirectory(dir);

                using (StreamWriter sw = File.CreateText(filename))
                {   
                    
                    for (int i = 0; i <=2; i++)
                    {
                        sw.WriteLine($"name: {contacts[i].name}");
                        sw.WriteLine($"email: {contacts[i].email}");
                        sw.WriteLine($"phone: {contacts[i].phone}");

                        sw.WriteLine(" ");
                    }
                }
            }

            static void DeSerialiseContactList(string filename, List<Contact> contacts)
            {
                Contact contact = new Contact();
                
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s;

                    while ((s = sr.ReadLine()) != null)
                    {
                        // if empty line create new contact
                        if (string.IsNullOrWhiteSpace(s))
                        {
                            contacts.Add(contact);
                            contact = new Contact();
                        }

                        else
                        {
                            string[] words = s.Split(" ");
                            string key = words[0];
                            string value = words[1];

                            if(key == "name:")          { contact.name = value; }
                            if(key == "email:")         { contact.email = value; }
                            if(key == "phone:")         { contact.phone = value; }
                        }
                    }
                }
            }

            foreach (var c in contacts)
            {
                c.Print();
            }

            
            
        }
    }
}
