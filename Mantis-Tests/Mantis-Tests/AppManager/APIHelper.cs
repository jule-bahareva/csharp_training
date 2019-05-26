﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_Tests
{
    public class APIHelper : HelperBase

    {

  
        public APIHelper(ApplicationManager manager) : base(manager)
        {
     
        }

        public void CreateNewIssue(AccountData account, IssueData issueData, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;


            client.mc_issue_add(account.Name, account.Password, issue);
        }

       
        // TODO public List<ProjectData> GetAllProjects()
      

        //TODO public void AddProject()
        

       //TODO public void RemoveProject()
        

    }
}


