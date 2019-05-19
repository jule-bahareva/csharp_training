using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_Tests
{
    public class ManagementMenuHelper :HelperBase
    {

        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        //TODO
        //
        public void OpenMainPage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {

                return;
            }


            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }




        public void OpenProjectManagementPage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.21.0/manage_proj_page.php")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.21.0/manage_proj_page.php");
        }

  



    }
}
