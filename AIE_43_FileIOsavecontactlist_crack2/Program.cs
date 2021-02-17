using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_43_FileIOsavecontactlist_crack2
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("bob", "bob@email.com", "12345678"));
            contacts.Add(new Contact("fred", "", ""));
            contacts.Add(new Contact("ted", "", "12345678"));

            // save to file
            SerialiseContactList("contacts.txt", contacts);

            // clear them out
            contacts = new List<Contact>();

            // read from file
            DeSerialiseContactList("contacts.txt", contacts);

            contacts[0].Print();
            contacts[1].Print();
            contacts[2].Print();
        }

        static void SerialiseContactList(string filename, List<Contact> contacts)
        {
            // TODO save all contacts to file.

            //create folder - don't need to this time ???

            var fileInfo = new FileInfo(filename);
            string dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);

            //write file - empty line between each contact

            using (StreamWriter sw = File.CreateText(filename))
            {
                foreach(var contact in contacts)
                {
                    //can only get contact.name as it's introduced through foreach

                    if (!string.IsNullOrEmpty(contact.name))    sw.WriteLine($"name: {contact.name}");
                    if (!string.IsNullOrEmpty(contact.email))   sw.WriteLine($"email: {contact.email}");
                    if (!string.IsNullOrEmpty(contact.phone))   sw.WriteLine($"phone: {contact.phone}");

                    sw.WriteLine("");
                }
                
            }
        }

        static void DeSerialiseContactList(string filename, List<Contact> contacts)
        {
            // TODO load all contacts from file.

            // assign first contact
            Contact contact = new Contact();

            using (StreamReader sr = File.OpenText(filename)) //use stream reader to read file
            {
                string line;

                while((line = sr.ReadLine()) != null) //how do we progress past this point if the line is null?
                {
                    if (string.IsNullOrWhiteSpace(line)) // check if line is empty
                    {
                        contacts.Add(contact); //add new contact to list
                        contact = new Contact(); //access new contact
                    } 
                    else
                    {
                        string[] words = line.Split(" ");
                        string key = words[0];
                        string value = words[1];

                        if (key == "name:") { contact.name = value; } //assign newly created contact's name. etc below.
                        if (key == "email:") { contact.email = value; }
                        if (key == "phone:") { contact.phone = value; }
                    }
                }
            }
        }
    }
}
