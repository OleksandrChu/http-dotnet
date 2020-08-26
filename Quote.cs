using System;
using Extentions;
using static web3.DataStorage;

namespace web3
{
    public class Quote
    {
        public string GenerateQuote()
        {
            return $"{who.GetRandomElement()}"
                + $" {how.GetRandomElement()}"
                + $" {does.GetRandomElement()}"
                + $" {what.GetRandomElement()}";
        }
    }

}