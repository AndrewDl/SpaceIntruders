using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpaceIntruders.Model
{
    abstract class AbstractEnvironmentObject : INotifyPropertyChanged
    {
        protected ulong id;

        protected int x;
        protected int y;
        protected int width;
        protected int height;
        protected int orientation = 0;

        protected string imageURL = "";
        
        /// <summary>
        /// X - coordinate of the object
        /// </summary>
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
                NotifyPropertyChanged("Margin");
            }
        }

        /// <summary>
        /// Y - coordinate of the object
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
                NotifyPropertyChanged("Margin");
            }
        }

        /// <summary>
        /// Orientation in space of the object; Accepts values
        /// </summary>
        public int Orientation {
            get { return 45; }
            set {
                if ((value < 0) || (value >= 360))
                {
                    throw new ArgumentOutOfRangeException("Orientation should be in diapason 0-360, except 360;");
                }
                orientation = value;
            }
        }

        /// <summary>
        /// Width of the craft.
        /// </summary>
        public int Width { get { return width; } }

        /// <summary>
        /// Height of the craft
        /// </summary>
        public int Height { get { return height; } }

        /// <summary>
        /// Path to the sprite of the object
        /// </summary>
        public string ImageSouce { get { return imageURL; } }

        /// <summary>
        /// Specifies margin from the start of coordinates on the view
        /// </summary>
        public Thickness Margin
        {
            get
            {
                return new Thickness(x, y, 0, 0);
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(PropertyName));
            }
        }

        /// <summary>
        /// Implement this method to destroy object in correct way
        /// </summary>
        abstract public void Destroy();

        /// <summary>
        /// Implement this method to check collision with given environmentalObject
        /// </summary>
        /// <param name="environmentObject"></param>
        /// <returns>true - if it collides; false if it is not</returns>
        public bool CollidesWith(AbstractEnvironmentObject environmentObject)
        {
            Rectangle r = new Rectangle(x, y, width, height);
            Rectangle r2 = new Rectangle(environmentObject.X, environmentObject.Y, environmentObject.Width, environmentObject.Height);
            return r.IntersectsWith(r2);
        }
    }
}
