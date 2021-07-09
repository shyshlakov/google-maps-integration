using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.Location
{
    public interface ILocationHandler<Tin, Tout>
    {
        Tout HandleLocationParts(Tin model);
    }
}
