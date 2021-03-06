﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BitfinexApi
{
    public class Tickers
    {
        public async Task<decimal> Market(string FirstCrypto, string SecondCrypto, string AskOrBid)
        {
            decimal value = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.bitfinex.com/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"ticker/{FirstCrypto}{SecondCrypto}");
            if (response.IsSuccessStatusCode && AskOrBid == "ask")
            {
                var products = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(products);
                value = (decimal)jObject["ask"];
            }
            else if (response.IsSuccessStatusCode && AskOrBid == "bid")
            {
                var products = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(products);
                value = (decimal)jObject["bid"];
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return value;
        }

    }
}
