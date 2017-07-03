namespace MyResume
{
    public sealed class InternetConnectivity
    {
        public static bool IsConnectedToInternet()
        {
            System.Uri Url = new System.Uri("http://www.google.fr");

            System.Net.WebRequest WebReq;
            System.Net.WebResponse Resp;
            WebReq = System.Net.WebRequest.Create(Url);

            try
            {
                Resp = WebReq.GetResponse();
                Resp.Close();
                WebReq = null;
                return true;
            }

            catch
            {
                WebReq = null;
                return false;
            }
        }
    }
}
