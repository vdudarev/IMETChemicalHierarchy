﻿using System;

namespace ChemicalHierarchy
{
    /// <summary>
    /// количественное содержание элемента в веществе (растворе, смеси)
    /// может задаваться в диапазоне [Min, Max]
    /// </summary>
    public class ChemicalQuantity: IComparable<ChemicalQuantity>, IComparable
    {
        /// <summary>
        /// минимальное содержание элемента в веществе
        /// </summary>
        public double Min { get; }
        /// <summary>
        /// максимальное содержание элемента в веществе
        /// </summary>
        public double Max { get; }

        public ChemicalQuantity(double min, double max) {
            if (min > max || min<=0) throw new ApplicationException("Quantity: min > max || min <= 0");
            Min = min;
            Max = max;
        }
        public ChemicalQuantity(double quantity) : this(quantity, quantity)
        { }
        public ChemicalQuantity(int quantity) : this((double)quantity)
        { }


        public string ToHtmlString {
            get {
                return Min == Max
                    ? (Max == 1 ? "" : "<sub>" + Max + "</sub>")
                    : "<sub>" + Min + "-" + Max + "</sub>";
            }
        }

        public override string ToString() {
            return Min == Max
                ? Max.ToString()
                : Min.ToString() + "-" + Max.ToString();
        }

        #region реализация интерфейсов IComparable<Quantity> и IComparable
        public int CompareTo(ChemicalQuantity other)
        {
            if (other == null) return 1;
            int retVal = Min.CompareTo(other.Min);
            if (retVal != 0)
                return retVal;
            retVal = Max.CompareTo(other.Max);
            return retVal;
        }

        public int CompareTo(object obj)
        {
            return (this as IComparable<ChemicalQuantity>).CompareTo(obj as ChemicalQuantity);
        }
        #endregion
    }
}
