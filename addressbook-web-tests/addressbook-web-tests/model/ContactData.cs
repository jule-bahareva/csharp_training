using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{

    [Table (Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;


        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        [Column (Name="firstname" )]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }


        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "id"),PrimaryKey, Identity]
        public string Id { get; set; }



        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(Home) + Cleanup(Mobile) + Cleanup(Work)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Cleanup(Email) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    allDetails = Firstname + " " + Lastname;

                    if (Middlename != "")
                    {
                        allDetails = Firstname + " " + Middlename + " " +  Lastname;
                    }

                    if (Nickname != "")
                    {
                        allDetails = allDetails + "\r\n" + Nickname; 
                    }

                    if (Title != "")
                    {
                        allDetails = allDetails + "\r\n" + Title;
                    }

                    if (Company != "")
                    {
                        allDetails = allDetails + "\r\n" + Company;
                    }

                    if (Address != "")
                    {
                        allDetails = allDetails + "\r\n" + Address;
                    }

                    if (Home != "" || Mobile != "" || Work != "" || Fax != "")
                    {
                        allDetails = allDetails + "\r\n";
                    }

                    if (Home != "")
                    {
                        allDetails = allDetails + "\r\nH:" +" " + Home;
                    }

                    if (Mobile != "")
                    {
                        allDetails = allDetails + "\r\nM:" + " " + Mobile;
                    }

                    if (Work != "")
                    {
                        allDetails = allDetails + "\r\nW:" + " " + Work;
                    }

                    if (Fax != "")
                    {
                        allDetails = allDetails + "\r\nF:" + " " + Fax;
                    }

                    if (Email != "" || Email2 != "" || Email3 != "" || Homepage != "")
                    {
                        allDetails = allDetails + "\r\n";
                    }

                    if (Email != "")
                    {
                        allDetails = allDetails + "\r\n" + Email;
                    }

                    if (Email2 != "")
                    {
                        allDetails = allDetails + "\r\n" + Email2;
                    }

                    if (Email3 != "")
                    {
                        allDetails = allDetails + "\r\n" + Email3;
                    }
                    if (Homepage != "")
                    {
                        allDetails = allDetails + "\r\n" + "Homepage:" +"\r\n" + Homepage;
                    }

                    if (Byear != "" || Ayear != "" )
                    {
                        allDetails = allDetails + "\r\n";
                    }

                    if (Byear != "")
                    {
                        allDetails = allDetails + "\r\n" + "Birthday" + " " + Bday+ "." + " " + Bmonth + " " + Byear;
                    }
                    if (Ayear != "")
                    {
                        allDetails = allDetails + "\r\n" + "Anniversary" + " " + Aday + "." + " " + Amonth + " " + Ayear;
                    }
    

                    return allDetails;
                }

            }
            set
            {
                allDetails = value;
            }
        }

        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";

            }
            return Regex.Replace(phone,"[ -()]", "") + "\r\n";

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Firstname);
            }
            return Firstname.CompareTo(other.Lastname);
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }


        public override string ToString()
        {
            return Firstname + Lastname;
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}

