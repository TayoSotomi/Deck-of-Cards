using Newtonsoft.Json;
using System.Net;

namespace Deck_Of_Cards.Models
{
    public class DeckDAL
    {
        public static string id = "1nu9gfwae7uk";

        public static DeckModel GetDeckModel(int amount)
        {
            //Adjust here
            //setup
            string url = $"https://deckofcardsapi.com/api/deck/{id}/draw/?count={amount}";
            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //save the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert it to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Adjust here
            //convert to C#
            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);
            return result;
        }

        public static void ShuffleDeck()
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            //save the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }
    }
}
