using System.Collections.Generic;

namespace ClosestColor
{
    public interface IClosestColor
    {
        IColor GetClosestColorInGroup(IEnumerable<IColor> colorGroups, IColor color);
    }
}