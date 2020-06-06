using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Laba4_ControlLib
{
    class HorseObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Поля.
        private Rect _objectRect;
        private double _xState;
        private string _speed;
        private BitmapSource _image;

        private Counter counter;
        private Random random = new Random();
        protected Point point = new Point(0, 10);
        protected string name = "Анонимная лошадь";

        // Положение и размер.
        public Rect ObjectRect
        {
            get { return this._objectRect; }
            set
            {
                if (value.Equals(this._objectRect))
                {
                    return;
                }

                this._objectRect = value;
                this.OnPropertyChanged("ObjectRect");
            }
        }

        // Картинка.
        public BitmapSource Image
        {
            get { return this._image; }
            set
            {
                if (Equals(value, this._image))
                {
                    return;
                }

                this._image = value;
                this.OnPropertyChanged("Image");
            }
        }

        public double XState
        {
            get { return this._xState; }
            protected set
            {
                if (value == this._xState)
                {
                    return;
                }

                this._xState = value;
                this.OnPropertyChanged("XState");
            }
        }

        public string Speed
        {
            get { return this._speed; }
            protected set
            {
                if (value == this._speed)
                {
                    return;
                }

                this._speed = value;
                this.OnPropertyChanged("Speed");
            }
        }



        public void Init()
        {
            // Задаем положение по умолчанию.
            Rect rect = this.ObjectRect;
            rect.Location = point;
            this.ObjectRect = rect;
            // Счетчик отсчитывает координату х.
            this.counter = new Counter { Start = -200, Step = random.NextDouble() *3, End = 1280 };
        }

        // Переопределенный метод выполняет обновление состояния объекта.
        public void Update()
        {
            Rect rect = this.ObjectRect;
            // Округляем координату чтобы положение было кратно одному пикселу.
            rect.X = Math.Round(this.counter.Value);
            this.ObjectRect = rect;
            this.XState = this.ObjectRect.Location.X;
            this.Speed = string.Format("Скорость лошади {0}: {1:F}", name, counter.Step);
            counter.Step = random.NextDouble() * 3;
        }

    }
}
