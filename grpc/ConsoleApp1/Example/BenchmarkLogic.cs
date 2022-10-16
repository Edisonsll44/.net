using System.IO;
using System.Net;

namespace Example
{
    public class BenchmarkLogic
    {
        public string RestRequest1()
        {
            var url = "http://api.ipapi.com/api/103.129.97.63?access_key=ba22e041405f597bf03914c669f00a4a";
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebResponse Response = WebRequestObject.GetResponse();
            Stream WebStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(WebStream);
            string webcontent = Reader.ReadToEnd();
            return null;

        }
        public string WebRequest()
        {
            var url = "http://api.ipapi.com/api/103.129.97.63?access_key=ba22e041405f597bf03914c669f00a4a";
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebResponse Response = WebRequestObject.GetResponse();
            Stream WebStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(WebStream);
            string webcontent = Reader.ReadToEnd();
            return null;
        }
    }
}
