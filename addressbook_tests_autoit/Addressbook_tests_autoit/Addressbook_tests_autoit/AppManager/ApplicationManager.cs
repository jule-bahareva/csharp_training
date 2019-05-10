using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace Addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        private GroupHelper groupHelper;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"D:\csharp-training\AddressbookProg\AddressBook.exe","",aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActive(WINTITLE);
            aux.WinWaitActive(WINTITLE);

            groupHelper = new GroupHelper(this);  
        }

        public void Stop()
        {
            aux.ControlClick( WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
    }
}
