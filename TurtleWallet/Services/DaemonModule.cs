using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using TurtleWallet.Utilities;

namespace TurtleWallet.Services
{
    public class DaemonModule 
    {
        private static  HttpClient client = new HttpClient();
        private static int requestid = 0;

        private static async Task<JObject> SendRpcRequest(string method, string parameters = "{}")
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://us.turtlepool.space:11899/json_rpc");
            string content = $"{{ \"jsonrpc\":\"2.0\", \"method\":\"{method}\", \"params\":{parameters}, \"id\":{requestid++} }}";
            requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JObject.Parse(responseString);
            }
            else
            {
                throw new Exception($"{(int)response.StatusCode} {response.ReasonPhrase}");
            }
        }

        public static async Task<string> CurrentHeight(string ignore = null)
        {
            JObject blockCountObject = await SendRpcRequest("getblockcount");
            return ($"{string.Format(CultureInfo.InvariantCulture, "{0:N0}", (long)blockCountObject["result"]["count"])}");
        }

        public static async Task<string> CurrentHashrate( string ignore = null)
        {
            JObject lastBlockHeaderObject = await SendRpcRequest("getlastblockheader");
            return ($"{HashFormatter.Format((double)lastBlockHeaderObject["result"]["block_header"]["difficulty"] / 30)}/s");
        }

        public static async Task<string> CurrentSupply(string ignore = null)
        {
            JObject lastBlockHeaderObject = await SendRpcRequest("getlastblockheader");
            JObject blockObject = await SendRpcRequest("f_block_json", $"{{ \"hash\":\"{lastBlockHeaderObject["result"]["block_header"]["hash"]}\"}}");
            return ($"{((double)blockObject["result"]["block"]["alreadyGeneratedCoins"] / 100).ToString("n2")} TRTL");
        }

        public static async Task<string> CurrentDifficulty( string ignore = null)
        {
            JObject lastBlockHeaderObject = await SendRpcRequest("getlastblockheader");
            return ($"{string.Format(CultureInfo.InvariantCulture, "{0:N0}", lastBlockHeaderObject["result"]["block_header"]["difficulty"])}");
        }
    }
}