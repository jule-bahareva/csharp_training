using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
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

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
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
    }
}

