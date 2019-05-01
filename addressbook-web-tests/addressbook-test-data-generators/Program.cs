using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            if (dataType == "groups")
            {
       
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)

                    });
                }

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format  = " + format);
                }

                writer.Close();
            }

            else if (dataType == "contacts")
            {
                for (int p = 0; p < count; p++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30))
                    {
                        Middlename = TestBase.GenerateRandomString(20),
                        Nickname = TestBase.GenerateRandomString(20),
                        Title = TestBase.GenerateRandomString(20),
                        Company = TestBase.GenerateRandomString(20),
                        Address = TestBase.GenerateRandomString(20),
                        Home = TestBase.GenerateRandomString(20),
                        Mobile = TestBase.GenerateRandomString(20),
                        Work = TestBase.GenerateRandomString(20),
                        Fax = TestBase.GenerateRandomString(20),
                        Email = TestBase.GenerateRandomString(20),
                        Email2 = TestBase.GenerateRandomString(20),
                        Email3 = TestBase.GenerateRandomString(20),
                        Homepage = TestBase.GenerateRandomString(20),
                        Bday = "1",
                        Bmonth = "May",
                        Byear = "2000",
                        Aday = "2",
                        Amonth = "December",
                        Ayear = "2010",

                    });
                }

                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format = " + format);
                }

                writer.Close();

            }
            else

            {
                System.Console.Out.Write("Unrecognized dataType = " + dataType);
            }

        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                    contact.Firstname, 
                    contact.Lastname, 
                    contact.Middlename,
                    contact.Nickname,
                    contact.Title,
                    contact.Company,
                    contact.Address,
                    contact.Home,
                    contact.Mobile,
                    contact.Work,
                    contact.Fax,
                    contact.Email,
                    contact.Email2,
                    contact.Email3,
                    contact.Homepage,
                    contact.Bday,
                    contact.Bmonth,
                    contact.Byear,
                    contact.Aday,
                    contact.Amonth,
                    contact.Ayear
                    ));
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach ( GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},{1},{2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)

        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));

        }
    }
}
