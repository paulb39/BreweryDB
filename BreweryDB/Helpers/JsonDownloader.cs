using BreweryDB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Helpers
{
    public static class JsonDownloader
    {
        public static Func<HttpClient> HttpClientFactory { get; set; } = new Func<HttpClient>(() => new HttpClient());
        public static readonly string BaseBeerRatingURL = @"http://www.beernumbeer.com/BeerScoreWebService.asmx/GetBeerPackageJson?app=575&qs={0}";

        public static async Task<T> DownloadSerializedJsonDataAsync<T>(string url) where T : new()
        {
            using (var httpClient = HttpClientFactory())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonData = string.Empty;
                try
                {
                    jsonData = await httpClient.GetStringAsync(url);
                }
                catch (Exception)
                {
                    return default(T);
                }
                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : default(T);
            }
        }

        public static async Task<string> DownloadBeerRating(string beerName, string breweryName)
        {
            var url = Uri.EscapeUriString(string.Format(BaseBeerRatingURL, beerName + " " + breweryName));
            var uri = new Uri(url);

            BeerNumBeer parsedResponse = new BeerNumBeer();

            var AvgRating = "N/A";
            bool isFound = false;
            int tryCount = 0;

            do
            {
                try
                {
                    var response = await HttpClientFactory().GetAsync(uri);
                    var json = await response.Content.ReadAsStringAsync();
                    parsedResponse = JsonConvert.DeserializeObject<BeerNumBeer>(json);
                }
                catch (Exception e)
                {
                    isFound = true;
                    break;
                }

                // If they are equal, return rating, otherwise try a different search
                if ((parsedResponse.BeerDetails.BeerCommon.BeerName.Equals(beerName, StringComparison.OrdinalIgnoreCase)) &&
                    (parsedResponse.BeerDetails.BeerCommon.Brewery.Equals(breweryName, StringComparison.OrdinalIgnoreCase)))
                {
                    var result = parsedResponse.BeerNumbeer.Average.ToString();
                    AvgRating = (result == "0") ? "N/A" : result + "/100";
                    isFound = true;
                }
                else
                {
                    url = Uri.EscapeUriString(string.Format(BaseBeerRatingURL, beerName));
                    uri = new Uri(url);
                    if (tryCount == 1)
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        tryCount++;
                    }
                }

            } while (!isFound);

            return AvgRating;
        }
    }
}
