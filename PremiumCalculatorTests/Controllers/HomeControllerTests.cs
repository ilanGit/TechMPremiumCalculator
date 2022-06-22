using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PremiumCalculator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiumCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Routing;

namespace PremiumCalculator.Controllers.Tests
{

    [TestClass()]
    public class HomeControllerTests
    {
        public bool Is { get; private set; }

        [TestMethod()]
        public void GetPremiumTest()
        {
        
         HomeController hm = new HomeController();
           
            PremiumModel pm = new PremiumModel();
            pm.IName = "Doctor";
            pm.InsuredAmount = 140000;
            pm.Age = 20;
            pm.MPremium =34356;

                        var result  = hm.GetPremium("ilan", "Professional", Convert.ToDateTime("23-03-1990"), 140000) as JsonResult;

            Assert.IsNotNull(result);

        }
    }
}