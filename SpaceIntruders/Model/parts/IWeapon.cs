using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceIntruders.Model
{
    interface IWeapon : IDevice
    {
        /// <summary>
        /// Specifies how many damage can deal this weapon
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// Specifies how fast can weapon fire
        /// </summary>
        int FireRate { get; }

        /// <summary>
        /// 
        /// </summary>
        void Fire();

    }
}
