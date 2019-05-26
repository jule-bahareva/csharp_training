using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Mantis_Tests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public ProjectManagementHelper Projects { get; set; }
        public ManagementMenuHelper Menu { get; set; }
        public LoginHelper Auth { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal<ApplicationManager> app= new ThreadLocal<ApplicationManager>();

        private ApplicationManager()

        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-2.21.0";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Projects = new ProjectManagementHelper(this);
            Menu = new ManagementMenuHelper(this, baseURL);
            Auth = new LoginHelper(this);
            Admin = new AdminHelper(this,baseURL);
            API = new APIHelper(this);

        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static  ApplicationManager GetInstance ()
        {
            if (! app.IsValueCreated)
            {

                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.21.0/login_page.php";
                app.Value = newInstance;

            }

            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }


    }
}
