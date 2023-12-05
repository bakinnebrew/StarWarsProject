using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using StarWarsProject.Controllers;
using StarWarsProject;
using System.Net;
using System.Text.Json.Nodes;


namespace StarWarsProject
{
    public class StarshipService : IStarshipService
    {

        public string GetStarships(string manufacturer)
        {
            var apiKey = GetApiKey();

            var response = GetStarshipList(manufacturer, apiKey);

            return response;
        }

        public string GetStarshipList(string manufacturer, string apiKey)
        {
            var url = "https://swapi.dev/api/starships/";

            var starShipList = new List<Starship>();

            while (url != null)
            {
                try
                {
                    var client = new RestClient(url);

                    var restRequest = new RestRequest(url, Method.Get);
                    restRequest.AddHeader("Content-Type", "application/json");
                    restRequest.AddHeader("Accept", "*/*");
                    restRequest.AddHeader("Authorization", $"API_KEY {apiKey}");

                    var response = client.Execute(restRequest);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //_logger.LogError("There was a problem retrieving all starships");
                        //alert todo
                        break;
                    }

                    var result = JsonConvert.DeserializeObject<StarshipResponse>(response.Content);

                    if (result.results != null)
                    {
                        foreach (var starship in result.results)
                        {
                            if (starship.manufacturer == manufacturer || manufacturer == "All")
                            {
                                starShipList.Add(starship);
                            }
                        }
                    }

                    url = result.Next;
                }

                catch (Exception)
                {
                    //alert todo
                    //_logger.LogError($"Error calling Star War API: {ex.Message}");
                }
            }

            //convert to JSON string
            var starShipListJsonString = JsonConvert.SerializeObject(starShipList);

            return starShipListJsonString;


        }
        public string GetApiKey()
        {
            //method to simulate getting an actual api key to be used in the request
            string apiKey = Guid.NewGuid().ToString("N");

            return apiKey;
        }






    }
}
