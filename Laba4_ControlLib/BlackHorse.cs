using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Laba4_ControlLib
{
    class BlackHorse : HorseObject
    {
        public BlackHorse()
        {
            this.Image = BitmapFrame.Create(new Uri("D:/ПОИС/СВПП/Laba4_ControlLib/Laba4_ControlLib/black_horse.png", UriKind.RelativeOrAbsolute));
            point = new Point(0, 250);
            name = "Черная";
        }
    }
}
