using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;
using FarmGateDev.Models;

namespace FarmGateDev.Controllers
{
    public class HomeController : Controller
    {



        public IActionResult Index(CheckList checkList)
        {          
            return View(checkList);
        }

        [HttpGet]
        public ViewResult EditList()
        {
            checklist = QuestionData();
            return View(checklist);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult EditList()
        {
            if (ModelState.IsValid)
            {
                //const string fromEmail = "bernardo_lugay@dialog.com.au";
                //StringBuilder body = ComposeEmail(checkList);
                ////var body = "<p>Email From:" + checkList.assessor + "</p><p>Message:</p><p>Farm Gate Access form submission</p>";
                //var message = new MailMessage();
                //message.To.Add(new MailAddress("bernardo_lugay@dialog.com.au")); 
                //message.From = new MailAddress(fromEmail); 
                //message.Subject = "Access Checklist - " + checkList.assessor;
                //message.Body = string.Format(body.ToString(), fromEmail, fromEmail, "Test message");
                //message.IsBodyHtml = true;
                //using (var smtp = new SmtpClient())
                //{
                //    var credential = new NetworkCredential
                //    {
                //        UserName = "bernardo_lugay@dialog.com.au",  // replace with valid value
                //        Password = ""  // replace with valid value
                //    };
                //    smtp.Credentials = credential;
                //    smtp.Host = "smtp.office365.com";
                //    //smtp.Host = "smtp-mail.outlook.com";
                //    smtp.Port = 587;
                //    //smtp.Port = 25;
                //    smtp.EnableSsl = true;
                //    smtp.Send(message);
                //    //await smtp.SendMailAsync(message);
                //    //return RedirectToAction("Sent");
                //}

//                return View("Thanks", checkList);
                return View();
            }
            else
            {
                return View();
            }

        }

        private StringBuilder ComposeEmail(CheckList checkList)
        {
            StringBuilder NewBody = new StringBuilder();
            NewBody.Append("<H1> Farm Gate Access: Self - Assessment Checklist");
            NewBody.Append("Road: "+ checkList.road);
            NewBody.Append("Council: " + checkList.council);
            NewBody.Append("Total Length (km): " + checkList.lengthkm);
            NewBody.Append("Date last assessed: " + checkList.accesslastdate);
            NewBody.Append("Assessor: " + checkList.assessor);
            return (NewBody);
        }

        [HttpGet]
        public ViewResult EditQuestions()
        {
            Questions[] questions = QuestionOnlyData();
            return View(questions);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public CheckList QuestionData()
        {

            int QuestionNumber = 4;

            Questions[] questionsblank = new Questions[QuestionNumber];
            for (int i = 0; i < QuestionNumber; i++)
            { questionsblank[i] = new Questions(); }
            questionsblank[0].describe = "What type of access required? <26m, 4.6m, HML, LLS, GHMS>";
            questionsblank[1].describe = "Is there comparable vehicle using this route? <Yes, No>";
            questionsblank[2].describe = "Does the route meet the criteria outline in the Farm Gate Accesss Procedure? <Yes, No> ";
            questionsblank[3].describe = "What is the posted speed limit?";

            questionsblank[0].riskflag = "MH";
            questionsblank[1].riskflag = "LMH";
            questionsblank[2].riskflag = "LM";
            questionsblank[3].riskflag = "NLMH";

            questionsblank[0].residualflag = "MH";
            questionsblank[1].residualflag = "LMH";
            questionsblank[2].residualflag = "LM";
            questionsblank[3].residualflag = "NLMH";

            questionsblank[0].group = "1.0 Suitability";
            questionsblank[1].group = "1.0 Suitability";
            questionsblank[2].group = "2.0 Road environment";
            questionsblank[3].group = "2.0 Road environment";



            //CheckList checklist = new CheckList("", "", 0, default(DateTime), "", new Questions[] { new Questions("Question One", "", "", "", ""), new Questions("Question Two", "", "", "", ""), new Questions("Question Three", "", "", "", ""), new Questions() });
            CheckList checklist = new CheckList("", "", 0, default(DateTime), "", questionsblank);
            return (checklist);
        }

        public Questions[] QuestionOnlyData()
        {
            Questions[] questionsblank = new Questions[4];
            for (int i = 0; i < 4; i++)
            { questionsblank[i] = new Questions(); }
            questionsblank[0].describe = "What type of access required? <26m, 4.6m, HML, LLS, GHMS>";
            questionsblank[1].describe = "Is there comparable vehicle using this route? <Yes, No>";
            questionsblank[2].describe = "Does the route meet the criteria outline in the Farm Gate Accesss Procedure? <Yes, No> ";
            questionsblank[3].describe = "What is the posted speed limit?";
            return (questionsblank);
        }

    }

}
