using Microsoft.Xrm.Sdk;
using PuzzlepartDynamicsTools.Models;

namespace PuzzlepartDynamicsTools.Helpers
{
    public class BrregCompanyMapper
    {
        public static Entity MapFromBrregToAccount(BrregCompanyDTO company, Entity account, ITracingService trace)
        {
            if (string.IsNullOrWhiteSpace(account.GetAttributeValue<string>("name")))
            {
                account.Attributes.AddOrUpdate("name", company.navn);
            }
            if (company.forretningsadresse != null)
            {
                account.Attributes.AddOrUpdate("address1_line1", company.forretningsadresse.adresse);
                account.Attributes.AddOrUpdate("address1_city", company.forretningsadresse.kommune);
                account.Attributes.AddOrUpdate("address1_postalcode", company.forretningsadresse.postnummer);
                account.Attributes.AddOrUpdate("address1_country", company.forretningsadresse.land);
            }
            trace.Trace("past address1");
            if (company.postadresse != null)
            {
                account.Attributes.AddOrUpdate("address2_line1", company.postadresse.adresse);
                account.Attributes.AddOrUpdate("address2_city", company.postadresse.kommune);
                account.Attributes.AddOrUpdate("address2_postalcode", company.postadresse.postnummer);
                account.Attributes.AddOrUpdate("address2_country", company.postadresse.land);
            }

            return account;
        }
    }
}
