using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using SearchFight.Models;
using SearchFight.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            string BingKey = ConfigurationSettings.AppSettings["BingKey"];
            string GoogleKey = ConfigurationSettings.AppSettings["GoogleKey"];

            if (args.Length == 0)
            {
                Console.WriteLine("You must write one programming language name at least");
                Console.ReadKey();
            }
            else
            {
                int aux = 0;
                bool Connected = false;
                long?[] totals = new long?[args.Length];
                SearchResultsModel TotalWinner = new SearchResultsModel();
                SearchResultsModel GoogleWinner = new SearchResultsModel();
                SearchResultsModel BingWinner = new SearchResultsModel();
                WebSearchClient clientB = new WebSearchClient(new ApiKeyServiceClientCredentials(BingKey));
                List<SearchResultsModel> searches = new List<SearchResultsModel>();


                foreach (string word in args)
                {
                    SearchResultsModel search = new SearchResultsModel();
                    word.Replace("\"", "");
                    long GoogleResults = GoogleResult(GoogleKey, word);
                    long? BingResults = BingResult(clientB, word);

                    if (GoogleResults != 0 || BingResults != 0)
                    {
                        Connected = true;
                    }

                    if (Connected)
                    {
                        Console.WriteLine("{0}: Google: {1} Bing: {2}", word, GoogleResults, BingResults);
                    }
                    search.word = word;
                    search.GoogleResults = GoogleResults;
                    search.BingResults = BingResults;

                    searches.Add(search);
                }

                if (Connected)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (GoogleWinner.GoogleResults < searches[i].GoogleResults)
                        {
                            GoogleWinner = searches[i];
                        }

                        if (BingWinner.BingResults < searches[i].BingResults || BingWinner.BingResults == null)
                        {
                            BingWinner = searches[i];
                        }
                    }

                    Console.WriteLine("Google winner: {0}", GoogleWinner.word);
                    Console.WriteLine("Bing winner: {0}", BingWinner.word);

                    for (int i = 0; i < searches.Count; i++)
                    {
                        totals[i] += searches[i].GoogleResults + searches[i].BingResults;
                        if (aux < totals[i])
                        {
                            aux = i;
                        }
                    }

                    Console.WriteLine("Total winner: {0}", searches[aux].word);
                }
                else
                {
                    Console.WriteLine("There is not internet connection");
                }
            }
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }

        public static long? BingResult(WebSearchClient client, string word)
        {
            try
            {
                var webData = client.Web.SearchAsync(query: word).Result;
                return webData.WebPages.TotalEstimatedMatches;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static long GoogleResult(string key, string word)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.GetAsync("https://www.googleapis.com/customsearch/v1?key=" + key + "&cx=017576662512468239146:omuauf_lfve&q=" + word);
                var aux = response.Result.Content.ReadAsStringAsync();
                DTOBingResult json = JsonConvert.DeserializeObject<DTOBingResult>(aux.Result);
                return Convert.ToInt64(json.searchInformation.totalResults);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
