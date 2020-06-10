using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Laba4_ControlLib
{
    class WhiteHorse : HorseObject
    {
        public WhiteHorse()
        {
            this.Image = new BitmapImage(new Uri("Assets/rsz_white_horse.png", UriKind.RelativeOrAbsolute));
            point = new Point(0, 10);
            name = "Белая";
        }
    }
}
