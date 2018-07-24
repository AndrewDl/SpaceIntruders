using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceIntruders.Model
{
    class Asteroid : AbstractEnvironmentObject
    {

        int shift = 5;
        double directionX = 0;
        double directionY = 1;
        
        Timer t = new Timer(50);

        public Asteroid()
        {
            imageURL = @"..\View\sprites\Asteroid.png";
            width = 64;
            height = 64;

            id = (ulong)(new Random().Next());

            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (directionX >= 1) directionX = -1; else directionX += 0.20;

            int dirX = (int)Math.Round(directionX);
            int dirY = (int)Math.Round(directionY);

            //spin it clockwise
            orientation = orientation+15<360 ? orientation + 15 : 0;

            Move(dirX, dirY);
        }

        public override void Destroy()
        {
            //throw new NotImplementedException();
        }

        public string Name
        {
            get
            {
                return "Asteroid: " + id;
            }
        }

        private void Move(int directionX, int directionY)
        {
            Y += directionY * shift;
            //X += directionX * shift;
        }

        /// <summary>
        /// Spawns asteroid on given x coordinate, Y coordinate depents on the size of asteroid
        /// </summary>
        /// <param name="x">spawn position</param>
        /// <param name="size">asteroid size (width and height both)</param>
        /// <returns></returns>
        public static Asteroid spawn(int x, int size)
        {

            return new Asteroid()
            {
                X = x,
                Y = 0 + size,
                width = size,
                height = size
            };
        }
        
    }
}
