using Newtonsoft.Json;
using System.Net;

namespace Deck_Of_Cards.Models
{
    public class DeckDAL
    {
        public static DeckModel GetDeckModel()
        {
            //Adjust here
            //setup
            string url = "https://deckofcardsapi.com/api/deck/new/draw/?count=5";
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
    }
}
