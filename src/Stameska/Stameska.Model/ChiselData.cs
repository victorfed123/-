using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stameska.Model
{

    public class ChiselData
    {
        /// <summary>
        /// Допстимые значение длины рукояти 
        /// </summary>
        public double MINHL, MAXHL;

        /// <summary>
        /// поле длины рукояти
        /// </summary>
        private double _hangleL;

        /// <summary>
        /// Допстимые значение длины лезвия 
        /// </summary>
        public double MINBL=120, MAXBL=240;

        /// <summary>
        /// поле длины лезвия
        /// </summary>
        private double _bladeL;

        /// <summary>
        /// Допстимые значение высоты лезвия
        /// </summary>
        public double MINBH, MAXBH;

        /// <summary>
        /// поле высоты лезвия
        /// </summary>
        private double _bladeH;

        /// <summary>
        /// Допстимые значение даметра кольца 
        /// </summary>
        public double MINRD, MAXRD;

        /// <summary>
        /// поле диаметра кольца
        /// </summary>
        private double _ringD;

        /// <summary>
        /// Допстимые значение ширины стамески
        /// </summary>
        public double MINC, MAXC;

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
        private void MaxMinChek(double MAX, double MIN, double value)
        {
            
            if (value == 0)
            {
                throw new ArgumentException("Enter the data");
            }
            if ((value > MAX) || (value < MIN))
            {
                throw new ArgumentException("Enabled value range: " + MIN + "-" + MAX + "mm");
            }
            if (MIN >= MAX)
            {
                throw new ArgumentException("Enabled value range: " + MIN + "mm");
            }
        }

/*        private void RangeCheck(double MAX, double MIN, double parameter)
        {
            if (value)
        }*/

        /// <summary>
        /// возвращает или задает длину для Hangle
        /// </summary>
        public double HangleL
        {
            get => _hangleL;
            set
            {
                if (value < 120 || value > 200)
                {
                    throw new ArgumentException("Enter correct count");
                }
                else
                {
                    if (_bladeL == 0)
                    {
                        MINHL = 120;
                        MAXHL = 200;

                    }
                    else
                    {
                        if (MINHL < 120)
                            MINHL = 120;
                        else
                        MINHL = _bladeL / 1.2;
                        MAXHL = _bladeL;
                    }
                    _hangleL = value;
                    MaxMinChek(MAXHL, MINHL, value);
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
                    throw new ArgumentException("Enter correct count");
                }
                else
                {
                    if (_hangleL == 0)
                    {
                        MINBL = 120;
                        MAXBL = 240;

                    }
                    else
                    {
                        if (MAXBL > 240)
                            MAXBL = 240;
                        else
                            MAXBL = 1.2 * _hangleL;
                        MINBL = _hangleL;

                    }
                    _bladeL = value;
                    MaxMinChek(MAXBL, MINBL, value);
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
                    throw new ArgumentException("Enter correct count");
                }
                else
                {
                    if (_chiselW == 0)
                    {
                        MINBH = 10;
                        MAXBH = 20;
                    }
                    else
                    {
                        if (MAXBH > 20)
                            MAXBH = 20;
                        else MAXBH = _chiselW;
                        if (MINBH < 10)
                            MINBH = 10;
                        else MINBH = _chiselW / 2.5;
                    }
                    _bladeH = value;
                    MaxMinChek(MAXBH, MINBH, value);
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
                    throw new ArgumentException("Enter correct count");
                }
                else
                {
                    if (_bladeH == 0)
                    {
                        MINC = 25;
                        MAXC = 40;
                    }
                    else
                    {
                        if (MINC < 25)
                            MINC = 25;
                        else MINC = BladeH;
                        if (MAXC > 40)
                            MAXC = 40;
                        else MAXC = _bladeH*2.5;
                    }    
                    _chiselW = value;
                    MaxMinChek(MAXC, MINC, value);
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
                if (value < 14 || value > 36)
                {
                    throw new ArgumentException("Enter correct count");
                }
                else
                {
                    if ((_bladeH == 0) || (_chiselW == 0))
                    {
                        MINRD = 14;
                        MAXRD = 36;
                    }
                    else
                    {
                        if (MINRD < 14)
                            MINRD = 14;
                        else MINRD = _bladeH * 1.1;
                        if (MAXRD > 36)
                            MAXRD = 36;
                        else MAXRD = 0.9*_chiselW;
                    }
                    _ringD = value;
                    MaxMinChek(MAXRD, MINRD, value);
                }
            }
        }
    }
}
