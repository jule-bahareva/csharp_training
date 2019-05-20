﻿using System;
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



        public void OpenProjectManagementPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }


    }
}
