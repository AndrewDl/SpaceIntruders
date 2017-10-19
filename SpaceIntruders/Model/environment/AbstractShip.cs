using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceIntruders.Model
{
    abstract class AbstractShip : AbstractEnvironmentObject
    {
        event EventHandler Fired;
    }
}
