using System.Net.NetworkInformation;

namespace netconstat
{
    public class GetInternetConStatus
    {
        /// <summary>
        /// ping 具体的网址看能否ping通
        /// </summary>
        /// <param name="strNetAdd"></param>
        /// <returns></returns>
        public static bool PingNetAddress(string strNetAdd)
        {
            bool Flage = false;
            Ping ping = new Ping();
            try
            {
                PingReply pr = ping.Send(strNetAdd, 50);
                //if (pr.Status == IPStatus.TimedOut)
                //{
                 //   Flage = false;
                //}
                if (pr.Status == IPStatus.Success)
                {
                    Flage = true;
                }
                else
                {
                    Flage = false;
                }
            }
            catch
            {
                Flage = false;
            }
            return Flage;
        }



    }
}