using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceIntruders.Model
{
    class BlasterCartridge : AbstractEnvironmentObject
    {
        Timer t = new Timer();

        private int speed = 10;
        
        private BlasterCartridge() { }
        
        public BlasterCartridge(int x, int y)
        {
            id = (ulong)(new Random().Next());

            this.x = x;
            this.y = y;
            width = 8;
            height = 16;
            imageURL = "../View/sprites/CartridgeRed.png";

            t.Elapsed += move;
            t.Interval = 10;
            t.Start(); 
        }

        private void move(object sender, ElapsedEventArgs e)
        {
            Y -= speed;
        }

        public override void Destroy()
        {
            t.Dispose();
        }

        public override bool Collides(AbstractEnvironmentObject environmentObject)
        {
            throw new NotImplementedException();
        }

        public int ID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }
        }

        public string Name
        {
            get
            {
                return "Cartridge: " + id; 
            }
        }

    }
}
