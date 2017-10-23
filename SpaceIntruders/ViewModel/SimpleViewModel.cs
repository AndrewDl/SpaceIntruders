using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceIntruders.Model;
using System.Collections.ObjectModel;
using System.Timers;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace SpaceIntruders.ViewModel
{
    class SimpleViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AbstractEnvironmentObject> environmentObjects;

        /// <summary>
        /// List of objects, currently existing on the CosmoCpace
        /// </summary>
        public ObservableCollection<AbstractEnvironmentObject> EnvironmentObjects { get; set; }

        /// <summary>
        /// Instance that specifies CosmoSpace
        /// </summary>
        public Space CosmoSpace { get; set; }

        private Timer timer = new Timer(10);

        private PlayerShip userShip;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(PropertyName));
            }
        }

        public SimpleViewModel()
        {   
            CosmoSpace = Space.getInstance(480, 800);

            userShip = new PlayerShip("../View/sprites/Battleship.png", CosmoSpace.Width/2, CosmoSpace.Heigth - 42, "UserShip", 10);
            
            //initialize key bindings
            MoveLeft = new Command(moveLeft, canMoveLeft);
            MoveRight = new Command(moveRight, canMoveRight);
            Fire = new Command(fire, canFire);

            environmentObjects = new ObservableCollection<AbstractEnvironmentObject>();

            Asteroid a = new Asteroid() { X = 50, Y = 10 };
            Asteroid a1 = new Asteroid() { X = 322, Y = 10 };
            Asteroid a2 = new Asteroid() { X = 188, Y = 10 };

            environmentObjects.Add(a);
            environmentObjects.Add(a1);
            environmentObjects.Add(a2);
            environmentObjects.Add(userShip);

            EnvironmentObjects = environmentObjects;

            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        /// <summary>
        /// Master-timer. It is possible to add some actions on ticks to make them synchronous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (AbstractEnvironmentObject o in environmentObjects.ToArray())
            {
                foreach (AbstractEnvironmentObject o2 in environmentObjects.ToArray())
                {
                    if (o.Collides(o2))
                    {
                        environmentObjects.Remove(o);
                        environmentObjects.Remove(o2);
                        o.Destroy();
                        o2.Destroy();
                    }
                }

                if ((o.Y < 0) || (o.Y > CosmoSpace.Heigth))
                {
                    _dispatcher.Invoke(new Action(() => {
                        environmentObjects.Remove(o);
                        o.Destroy();
                    }));                    
                }
            }
        }

        Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        //Commands to control user spacecraft
        public ICommand MoveLeft { get; set; }

        public ICommand MoveRight { get; set; }

        public ICommand Fire { get; set; }

        /// <summary>
        /// method moves userShip left
        /// </summary>
        /// <param name="param"></param>
        private void moveLeft(object param)
        {
            userShip.X -= 10;
        }

        /// <summary>
        /// method moves userShip right
        /// </summary>
        /// <param name="param"></param>
        private void moveRight(object param)
        {
            userShip.X += 10;
        }

        /// <summary>
        /// causes user ship to fire
        /// </summary>
        /// <param name="param"></param>
        private void fire(object param)
        {
            //int x = userShip.X;
            //int y = userShip.Y;

            //BlasterCartridge cartridge = new BlasterCartridge(x, y);
            IList<BlasterCartridge> cartridges = userShip.Fire();
            foreach(BlasterCartridge cartridge in cartridges)
            {
                environmentObjects.Add(cartridge);
            }
            
        }

        private bool canMoveLeft(object param)
        {
            return userShip.X > 0;
        }

        private bool canMoveRight(object param)
        {
            return userShip.X+userShip.Width < CosmoSpace.Width;
        }

        private bool canFire(object param)
        {
            return true;
        }

    }

}