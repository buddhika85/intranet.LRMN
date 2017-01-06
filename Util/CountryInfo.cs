using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Util
{
    public static class CountryInfo
    {
        public static IEnumerable<Country> GetCountries()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                    .Select(x => new Country
                                    {
                                        CountryCode = new RegionInfo(x.LCID).Name,
                                        CountryName = new RegionInfo(x.LCID).EnglishName
                                    })
                                    .GroupBy(c => c.CountryCode)
                                    .Select(c => c.First())
                                    .OrderBy(x => x.CountryName);
        }
    }

    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
