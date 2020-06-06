using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba4_ControlLib
{
    class Scene : INotifyPropertyChanged
    {

        // таймер, выполняет периодически метод в другом потоке
        private Timer _t;

        public WhiteHorse whiteHorse { get; set; }
        public BlackHorse blackHorse { get; set; }
        public BrownHorse brownHorse { get; set; }

        private string _whitePosition;
        private string _blackPosition;
        private string _brownPosition;
        private int position;

        // Запущена ли игра.
        public bool IsBusy { get; set; }

        public string WhitePosition
        {
            get { return this._whitePosition; }
            protected set
            {
                if (value == this._whitePosition)
                {
                    return;
                }

                this._whitePosition = value;
                this.OnPropertyChanged("WhitePosition");
            }
        }

        public string BlackPosition
        {
            get { return this._blackPosition; }
            protected set
            {
                if (value == this._blackPosition)
                {
                    return;
                }

                this._blackPosition = value;
                this.OnPropertyChanged("BlackPosition");
            }
        }

        public string BrownPosition
        {
            get { return this._brownPosition; }
            protected set
            {
                if (value == this._brownPosition)
                {
                    return;
                }

                this._brownPosition = value;
                this.OnPropertyChanged("BrownPosition");
            }
        }



        // Сброс игры.
        public void Init()
        {
            this.whiteHorse.Init();
            this.blackHorse.Init();
            this.brownHorse.Init();
        }

        public void Start()
        {
            // Если игра уже запущена, то ничего выходим из метода.
            if (this.IsBusy)
            {
                return;
            }

            // Главный таймер, создает поток и выполняет в нем метод обновления состояния сцены.
            this._t = new Timer
                (
                // Лямбда выражение.
                state =>
                {
                    whiteHorse.Update();
                    calculateWhitePosition(whiteHorse);

                    blackHorse.Update();
                    calculateBlackPosition(blackHorse);

                    brownHorse.Update();
                    calculateBrownPosition(brownHorse);
                },
                null,
                // Задержка.
                0,
                // Период.
                10);
            // Устанавливаем IsBusy в true.
            this.IsBusy = true;
        }

        // Пауза
        public void Pause()
        {
            if (this.IsBusy)
            {
                this._t.Dispose();
                this.IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void calculateWhitePosition(WhiteHorse horseObject)
        {
            if (horseObject.XState > blackHorse.XState && horseObject.XState > brownHorse.XState)
            {
                position = 1;
            }
            else if (horseObject.XState > blackHorse.XState || horseObject.XState > brownHorse.XState)
            {
                position = 2;
            }
            else
            {
                position = 3;
            }
            WhitePosition = string.Format("Позиция белой лошади: {0}", position);
        }

        public void calculateBrownPosition(BrownHorse horseObject)
        {           
            if (horseObject.XState > blackHorse.XState && horseObject.XState > whiteHorse.XState)
            {
                position = 1;
            }
            else if (horseObject.XState > blackHorse.XState || horseObject.XState > whiteHorse.XState)
            {
                position = 2;
            }
            else
            {
                position = 3;
            }
            BrownPosition = string.Format("Позиция коричневой лошади: {0}", position);
        }

        public void calculateBlackPosition(BlackHorse horseObject)
        {
            if (horseObject.XState > brownHorse.XState && horseObject.XState > whiteHorse.XState)
            {
                position = 1;
            }
            else if (horseObject.XState > brownHorse.XState || horseObject.XState > whiteHorse.XState)
            {
                position = 2;
            }
            else
            {
                position = 3;
            }
            BlackPosition = string.Format("Позиция черной лошади: {0}", position);

        }

    }
}
