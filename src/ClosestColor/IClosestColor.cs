using System.Collections.Generic;

namespace ClosestColor
{
    public interface IClosestColor
    {
        IReadOnlyList<IColor> GetClosestColorInGroup(IReadOnlyList<IColor> colorGroups, IColor color);
    }
}