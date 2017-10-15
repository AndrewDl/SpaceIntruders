using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceIntruders.Model
{
    class Space
    {
        private int width = 480;
        private int height = 640;

        public Space(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Width of space can't be < 0");
                width = value;
            }
        }

        public int Heigth
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Heigth of space can't be < 0");
                height = value;
            }
        }
    }
}
