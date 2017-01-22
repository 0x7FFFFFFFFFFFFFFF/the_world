using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController: Controller
    {
        private IMailService _mailservice;
        private IConfigurationRoot _config;

        public AppController(IMailService service, IConfigurationRoot config)
        {
            _mailservice = service;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel m)
        {
            _mailservice.SendMail(m.Email, _config["MailSettings:ToAddress"], "Subject Test", m.Message);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
