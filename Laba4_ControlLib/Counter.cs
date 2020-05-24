using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4_ControlLib
{
    class Counter
    {
        // инициализирует счетчик поумолчанию
        public Counter()
        {
            this.Step =1;
            this.End = double.MaxValue;
        }

        // Поле, переменная...
        private double _value;

        // Начальное значение.
        public double Start { get; set; }
        // Шаг изменения.
        public double Step { get; set; }
        // Конечное значение, после которого сброс.
        public double End { get; set; }

        // Текущее значение счетчика
        public double Value
        {
            get
            {
                // Берем текщее значение.
                double d = this._value;
                // Наращиваем счетчик.
                this._value += this.Step;
                // Если счетчик переполнен - сбрасываем.
                if (d >= this.End)
                {
                    d = this._value = this.Start;
                }
                // Возвращаем значение.
                return d;
            }
            set
            {
                this._value = value;
            }
        }
    }
}
