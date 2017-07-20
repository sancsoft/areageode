using System.Collections.Generic;
using AreaGeode.Library.Models;

namespace AreaGeode.Library.DAL
{
    public interface IAreaGeodeViewRepository
    {
        AreaGeodeView Find(int areaCode);
        IEnumerable<AreaGeodeView> FindByState(string stateAbbr);
    }
}
