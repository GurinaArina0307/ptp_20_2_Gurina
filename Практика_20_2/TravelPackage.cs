using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;

namespace Практика_20
{
    public abstract class TravelPackage //путевка(базовый класс)
    {
        protected string nameTravel;// Название путевки
        protected int duration;     // продолжительность
        protected int price;          // стоимость
        protected bool excursions;    // наличие экскурсий

        public static List<TravelPackage> AllVouchers = new List<TravelPackage>();

        public string NameTravel
        {
            get { return nameTravel; }
            set
            {
                string error = Validation.ValidateString(value, "Название");
                if (!string.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                nameTravel = value;
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                string error = Validation.ValidateInt(value, "Продолжительность") + Validation.ValidateDuration(value);
                if (!string.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                duration = value;
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                string error = Validation.ValidateInt(value, "Стоимость");
                if (!string.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                price = value;
            }
        }
        public bool Excursions
        {
            get { return excursions; }
            set { excursions = value; }
        }

        public TravelPackage(string nameTravel, int duration, 
            int price, bool excursions)
        {
            this.nameTravel = nameTravel;
            this.duration = duration;
            this.price = price;
            this.excursions = excursions;
            AllVouchers.Add(this);
        }
        public virtual void Info()
        {
            //Console.WriteLine($"Название: {nameTravel}");
            //Console.WriteLine($"Продолжительность: {duration} дней");
            //Console.WriteLine($"Стоимость: {price}");
            //Console.WriteLine($"Экскурсии: {(excursions ? "Да" : "Нет")}");
        }

    }

    

    
}
