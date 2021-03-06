﻿using System;
using System.Threading.Tasks;
using Binance;
using BitfinexApi;
using BitforexAPI;

namespace CryptoValue
{
    class Price
    {
        public async Task<decimal> ValueBinance()
        {
            var api = new BinanceApi();
            var answer = await api.GetExchangeRateAsync(Asset.ETH, Asset.BTC);
            Console.WriteLine($"Binance is {answer}");
            return answer;
        }

        public async Task<decimal> ValueBitfinex(string AskOrBid)
        {
            BitfinexApi.BitfinexAssets assets = new BitfinexApi.BitfinexAssets();
            Tickers bitfinexClient = new Tickers();

            decimal answer = await bitfinexClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitfinex is {AskOrBid} {answer}");
            return answer;
        }

        public async Task<decimal> ValueBitforex(string AskOrBid)
        {
            BitforexAPI.Assets assets = new BitforexAPI.Assets();
            BitforexClient bitforexClient = new BitforexClient();

            decimal answer = await bitforexClient.MarketAsync(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitforex is {AskOrBid} {answer}");
            return answer;
        }

    }
}