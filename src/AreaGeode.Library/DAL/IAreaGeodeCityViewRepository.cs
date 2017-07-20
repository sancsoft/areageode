using System.Collections.Generic;
using AreaGeode.Library.Models;

namespace AreaGeode.Library.DAL
{
    public interface IAreaGeodeCityViewRepository
    {
        IEnumerable<AreaGeodeCityView> FindByAreaCode(int areaCode);
        IEnumerable<AreaGeodeCityView> FindByCity(string cityName, string stateAbbr = "");
    }
}
