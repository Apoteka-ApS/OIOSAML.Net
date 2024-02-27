using System.Collections.Generic;
using System.Text;
using System;
using System.Web.Mvc;
using dk.nita.saml20.identity;
using System.Xml.Linq;
using dk.nita.saml20.protocol;
using dk.nita.saml20.Schema.Core;

namespace ApotekaDemo.Controllers
{
    public class PrescriptionController : Controller
    {
        public ActionResult Index()
        {
            var httpContext = System.Web.HttpContext.Current;
            var signonHandler = new Saml20SignonHandler();
            signonHandler.ProcessRequest(httpContext);
            return View("Index");
        }

        public ActionResult IdpLogin()
        {
            var httpContext = System.Web.HttpContext.Current;
            var signonHandler = new Saml20SignonHandler();
            signonHandler.ProcessRequest(httpContext);
            return View("Index");
        }

        public ActionResult NextStep()
        {
            var bootstrapToken = GetBootstrapToken();
            return this.Content(bootstrapToken.ToString(), "text/xml");
        }

        private XElement GetBootstrapToken()
        {
            var samlAttributes = Saml20Identity.Current["urn:liberty:disco:2006-08:DiscoveryEPR"];

            return Parse(samlAttributes);
        }

        private static XElement Parse(List<SamlAttribute> samlAttributes)
        {
            var discoveryEprAttribute = samlAttributes[0];
            var xml = Encoding.UTF8.GetString(Convert.FromBase64String(discoveryEprAttribute.AttributeValue[0]));

            return XDocument.Parse(xml).Root;
        }
    }
}