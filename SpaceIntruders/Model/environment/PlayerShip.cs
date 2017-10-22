using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace SpaceIntruders.Model 
{
    class PlayerShip : AbstractShip
    {
        private IWeapon weapon = new Blaster();
        
        private string name = "Untitled";
        private int hp = 0;
        
        private PlayerShip()
        {
        }

        /// <summary>
        /// Creates a player ship
        /// </summary>
        /// <param name="image">Path to player ship sprite</param>
        /// <param name="x">initial x position</param>
        /// <param name="y">initial y position</param>
        /// <param name="Name">name of spacecraft</param>
        /// <param name="HP">ammount of hitpoints</param>
        public PlayerShip(string image, int x, int y, string Name, int HP)
        {
            imageURL = image;
            this.x = x;
            this.y = y;
            this.HP = hp;
            this.Name = Name;

            this.width = 32;
            this.height = 32;
            
            Timer fireTimer = new Timer(weapon.FireRate);
            fireTimer.Elapsed += FireTimer_Elapsed;
            fireTimer.Start();
        }

        private void FireTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
        }
                

        /// <summary>
        /// Grants read/write access to hitpoints of the spacecraft
        /// </summary>
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = (value >= 0) ? value : 0;
                NotifyPropertyChanged("HP");
            }
        }

        /// <summary>
        /// Grants access to the name of the spacecraft
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        /*
        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(PropertyName));
            }
        }
        */
        /// <summary>
        /// Moves the ship in specified direction with the step that is specified by .setSpeed(int speed) method
        /// </summary>
        /// <param name="directionX">direction of horizontal movement -1 - left, 1 - right, 0 - no motion</param>
        /// <param name="directionY">direction of vertical movement -1 - left, 1 - right, 0 - no motion</param>
        public void Move(int directionX, int directionY)
        {
            X += directionX * 10;
            Y += directionY * 10;
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
