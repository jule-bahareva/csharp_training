using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInfoFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(0);

            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
 
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(0);
            string fromDetails = app.Contacts.GetContactInfoFromDetails(0);

            //verification
 
            Console.Out.Write("Edit Contact Form data:\r\n" + fromForm.AllDetails + "\r\n");
            Console.Out.Write("\r\n\r\n" + "Contact Details Page:\r\n"  + fromDetails + "\r\n");
            Assert.AreEqual(fromForm.AllDetails, fromDetails);
     
 
        }


    }
}