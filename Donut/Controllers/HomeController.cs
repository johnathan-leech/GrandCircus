using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Donut.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://grandcircusco.github.io/demo-apis/donuts.json");
            request.UserAgent = "AgentInfo";
            //UserAgent makes it so that it is taking from the user only ---? Clarify this
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string output = reader.ReadToEnd();
                JObject JParser = JObject.Parse(output);
                ViewBag.ResultKey = JParser["results"];
            }
            return View();
        }

        public ActionResult DonutDetails(int id)
        {
            HttpWebRequest request = WebRequest.CreateHttp(@"https://grandcircusco.github.io/demo-apis/donuts/" + id + ".json");
            request.UserAgent = "AgentInfo";
            //UserAgent makes it so that it is taking from the user only ---? Clarify this
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string output = reader.ReadToEnd();
                JObject JParser = JObject.Parse(output);
                ViewBag.ResultKey = JParser;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}