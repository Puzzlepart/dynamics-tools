using Microsoft.Xrm.Sdk;
using PuzzlepartDynamicsTools.Helpers;
using PuzzlepartDynamicsTools.Models;
using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace PuzzlepartDynamicsTools
{
    public class GetBrregDetailsForAccountPlugin : IPlugin
    {
        // Hard coded url to Brreg to retrieve company information
        private static string brregApiUrl = "https://data.brreg.no/enhetsregisteret/enhet/";
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                var account = context.InputParameters["Target"] as Entity;
                var accountNumber = account.GetAttributeValue<string>("accountnumber");

                if (!string.IsNullOrEmpty(accountNumber))
                {
                    // Replace international formating in case of copy/paste
                    accountNumber = accountNumber.ToLower().Replace(" ", "").Replace("mva", "").Replace("NO", "");
                    if (accountNumber.Length == 9 && int.TryParse(accountNumber, out int orgNum))
                    {
                        BrregCompanyDTO brregCompany;
                        using (var client = new WebClient())
                        {
                            var stream = client.OpenRead($"{brregApiUrl}{accountNumber}.json");
                            var serializer = new DataContractJsonSerializer(typeof(BrregCompanyDTO));

                            brregCompany = (BrregCompanyDTO)serializer.ReadObject(stream);
                        }

                        context.InputParameters["Target"] = BrregCompanyMapper.MapFromBrregToAccount(brregCompany, account, trace);
                    }
                }
            }
        }
    }
}
