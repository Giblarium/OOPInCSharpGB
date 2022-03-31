using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    internal class Building
    {
        private static int IDnumerator = 0;

        private int _ID = GetID();
        private int height;
        private int floors;
        private int apartments;
        private int entrance;

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="height">Высота здания. Если 0 или меньше, то меняется на 1.</param>
        /// <param name="floors">Количество этажей. Если 0 или меньше, то меняется на 1.</param>
        /// <param name="apartments">Количество квартир. Если 0 или меньше, то меняется на 1.</param>
        /// <param name="entrance">Количество подъездов. Если 0 или меньше, то меняется на 1.</param>
        public Building(int height, int floors, int apartments, int entrance)
        {
            if (height > 0) Height = height;
            else Height = 1;
            if (floors > 0) Floors = height;
            else Floors = 1;
            if (apartments > 0) Apartments = height;
            else Apartments = 1;
            if (entrance > 0) Entrance = height;
            else Entrance = 1;
        }

        public Building()
        {
        }

        public int ID { get => _ID; set => GetID(); }
        public int Height { get => height; set => height = value; }
        public int Floors { get => floors; set => floors = value; }
        public int Apartments { get => apartments; set => apartments = value; }
        public int Entrance { get => entrance; set => entrance = value; }
        
        /// <summary>
        /// Расчет высоты этажа
        /// </summary>
        /// <returns></returns>
        public float GetHeightFloors() 
        {
            if (floors != 0)
            {
                float heightFloors = (float)height / (float)floors;
                return heightFloors;
            }
            return 0;
        }
        /// <summary>
        /// Расчет квартир в подъезде
        /// </summary>
        /// <returns></returns>
        public int GetApartmentsEntrance()
        {
            if (entrance != 0)
            {
                int apartmentsEntrance = apartments / entrance;
                return apartmentsEntrance;
            }
            return 0;
        }
        /// <summary>
        /// Расчет квартир на этаже
        /// </summary>
        /// <returns></returns>
        public int GetApartmentsFloors()
        {
            if (entrance != 0 || entrance != 0)
            {
                int apartmentsEntrance = GetApartmentsEntrance();
                int apartmentsFloors = apartmentsEntrance / floors;
                return apartmentsFloors;
            }
            return 0;
        }

        /// <summary>
        /// Нумератор
        /// </summary>
        /// <returns></returns>
        private static int GetID()
        {
            return ++IDnumerator;
        }
    }
}


/*
 1. Реализовать класс для описания здания (уникальный номер здания, высота, этажность, количество квартир, подъездов). Поля сделать закрытыми, предусмотреть методы для заполнения полей и получения значений полей для печати. Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества квартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания генерировался программно. Для этого в классе предусмотреть статическое поле, которое бы хранило последний использованный номер здания, и предусмотреть метод, который увеличивал бы значение этого поля.*/