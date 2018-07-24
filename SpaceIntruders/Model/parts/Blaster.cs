using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceIntruders.Model
{
    class Blaster : IWeapon
    {
        int damage = 10;
        int fireRate = 300;
        
        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public int FireRate
        {
            get
            {
                return fireRate;
            }
        }

        public void Fire()
        {
            throw new NotImplementedException();
        }
    }
}
