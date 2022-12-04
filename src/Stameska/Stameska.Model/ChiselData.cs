using System;

namespace Stameska.Model
{

    public class ChiselData
    {
        /// <summary>
        /// Допстимые значение длины рукояти 
        /// </summary>
        private double _minl = 120, _maxl = 200; 
        
        ///ПРИВАТНЫЕ ПОЛЯ С НИЖНИМИ ПОДЧЕРКИВАНИЯМИ 

        /// <summary>
        /// поле длины рукояти
        /// </summary>
        private double _handleL;

        /// <summary>
        /// Допстимые значение длины лезвия 
        /// </summary>
        private double _minbl=120, _maxbl=240;

        /// <summary>
        /// поле длины лезвия
        /// </summary>
        private double _bladeL;

        /// <summary>
        /// Допстимые значение высоты лезвия
        /// </summary>
        private double _minbh = 10, _maxbh = 20;

        /// <summary>
        /// поле высоты лезвия
        /// </summary>
        private double _bladeH;

        /// <summary>
        /// Допстимые значение даметра кольца 
        /// </summary>
        private double _minrd = 11, _maxrd = 45;

        /// <summary>
        /// поле диаметра кольца
        /// </summary>
        private double _ringD;

        /// <summary>
        /// Допстимые значение ширины стамески
        /// </summary>
        private double _minc = 25, _maxc = 50;

        /// <summary>
        /// поле ширины стамески 
        /// </summary>
        private double _chiselW;

        /// <summary>
        /// обработчик максимального и минимального значения
        /// </summary>
        /// <param name="MAX"></param>
        /// <param name="MIN"></param>
        /// <param name="value"></param>
        private void MaxMinCheсk(double MAX, double MIN, double value)
        {
            if (value == 0)
            {
                throw new ArgumentException("Enter the data");
            }
            if ((value > MAX) || (value < MIN))
            {
                throw new ArgumentException("Enabled value range: " + MIN + "-" + MAX + "mm");
            }
        }

        /// <summary>
        /// возвращает или задает длину для Handle
        /// </summary>
        public double HandleL
        {
            get => _handleL;
            set
            {
                if (value < 120 || value > 200)
                {
                    MaxMinCheсk(_maxl, _minl, value);
                }
                else
                {
                    if (_bladeL == 0)
                    {
                        _minl = 120;
                        _maxl = 200;
                    }
                    else
                    {
                        _maxl = _bladeL;
                        _minl = _bladeL / 1.2;
                        if (_minl < 120)
                        {
                            _minl = 120;
                        }    
                        if (_maxl > 200)
                        {
                            _maxl = 200;
                        }
                    }
                    MaxMinCheсk(_maxl, _minl, value);
                    _handleL = value;
                }
            }
        }

        /// <summary>
        /// возвращает или задает длину для BladeL
        /// </summary>
        public double BladeL
        {
            get => _bladeL;
            set
            {
                if (value < 120 || value > 240)
                {
                    MaxMinCheсk(_maxbl, _minbl, value);
                }
                else
                {
                    if (_handleL == 0)
                    {
                        _minbl = 120;
                        _maxbl = 240;
                    }
                    else
                    {
                        _minbl = _handleL;
                        _maxbl = 1.2 * _handleL;
                        if (_maxbl > 240)
                        {
                            _maxbl = 240;
                        }
                        if (_minbl < 120)
                        {
                            _minbl = 120;
                        }
                    }
                    MaxMinCheсk(_maxbl, _minbl, value);
                    _bladeL = value;
                }
            }
        }

        /// <summary>
        /// возвращает или задает длину для BladeH
        /// </summary>
        public double BladeH
        {
            get => _bladeH;
            set
            {
                if (value < 10 || value > 20)
                {
                    MaxMinCheсk(_maxbh, _minbh, value);
                }
                else
                {
                    if (_chiselW == 0)
                    {
                        _minbh = 10;
                        _maxbh = 20;
                    }
                    else
                    {
                        _minbh = _chiselW / 2.5;
                        _maxbh = _chiselW;


                        if (_maxbh > 20)
                        {
                            _maxbh = 20;
                        }
                        if (_minbh < 10)
                        {
                            _minbh = 10;
                        }
                    }
                    MaxMinCheсk(_maxbh, _minbh, value);
                    _bladeH = value;
                }
            }
        }

        /// <summary>
        /// возвращает или задает длину для RingD
        /// </summary>
        public double RingD
        {
            get => _ringD;
            set
            {
                if (value < 11 || value > 45)
                {
                    MaxMinCheсk(_maxrd, _minrd, value);
                }
                else
                {
                    if ((_bladeH == 0) || (_chiselW == 0))
                    {
                        _minrd = 11;
                        _maxrd = 45;
                    }
                    else
                    {
                        _minrd = _bladeH * 1.1;
                        _maxrd = 0.9 * _chiselW;
                        if (_minrd < 11)
                        {
                            _minrd = 11;
                        }
                        if (_maxrd > 45)
                        {
                            _maxrd = 45;
                        }
                    }
                    MaxMinCheсk(_maxrd, _minrd, value);
                    _ringD = value;
                }

            }
        }

        /// <summary>
        /// возвращает или задает длину для ChiselW
        /// </summary>
        public double ChiselW
        {
            get => _chiselW;
            set
            {
                if (value < 25 || value > 50)
                {
                    MaxMinCheсk(_maxc, _minc, value);
                }
                else
                {
                    if (_bladeH == 0)
                    {
                        _minc = 25;
                        _maxc = 50;
                    }
                    else
                    {
                        _maxc = _bladeH * 2.5;
                        _minc = _bladeH;
                        if (_minc < 25)
                        {
                            _minc = 25;
                        }
                        if (_maxc > 50)
                        {
                            _maxc = 50;
                        }
                    }    
                    MaxMinCheсk(_maxc, _minc, value);
                    _chiselW = value;
                }
            }
        }
    }
}
///RESHARPER СКАЧАТЬ