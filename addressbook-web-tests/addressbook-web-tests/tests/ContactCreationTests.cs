﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;



namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {

        private static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> randomContact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                randomContact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)) 
                {
                    Middlename = GenerateRandomString(20),
                    Nickname = GenerateRandomString(20),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    Home = GenerateRandomString(20),
                    Mobile = GenerateRandomString(20),
                    Work = GenerateRandomString(20),
                    Fax = GenerateRandomString(20),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20),
                    Bday = "1",
                    Bmonth = "May",
                    Byear = "2000",
                    Aday = "2",
                    Amonth = "December",
                    Ayear = "2010",
                });

            }

            return randomContact;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));

        }



        [Test, TestCaseSource("ContactDataFromJsonFile")]

        public void ContactCreationTest( ContactData contact)
        {
           

            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);

          
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);


        }

        [Test]
        public void DBConnectivityTest()
        {
            foreach (ContactData contact in ContactData.GetAll())
            {
                Console.Out.WriteLine(contact.Deprecated );
            }

        }

    }
}
