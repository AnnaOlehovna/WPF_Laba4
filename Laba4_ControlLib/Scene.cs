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

        // Запущена ли игра.
        public bool IsBusy { get; set; }

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
                    blackHorse.Update();
                    brownHorse.Update();
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

    }
}
