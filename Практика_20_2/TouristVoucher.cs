using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_20
{
    public class TouristVoucher : TravelPackage  // туристическая путевка (наслед)
    {
        private string categoryRoute { get; set; }   // категория маршрута
        private bool spravka { get; set; }           // необходимость справки от врача


        public TouristVoucher(string nameTravel, int duration, int price, bool excursions,
            string categoryRoute, bool spravka)
            : base(nameTravel, duration, price, excursions)
        {
            this.categoryRoute = categoryRoute;
            this.spravka = spravka;
        }

        public string CategoryRoute
        {
            get { return categoryRoute; }
            set
            {
                string error = Validation.ValidateString(value, "");
                if (!string.IsNullOrEmpty(error))
                    throw new ArgumentException(error);
                categoryRoute = value;
            }
        }

        public bool Spravka
        {
            get { return spravka; }
            set { spravka = value; }
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Категория маршрута: {categoryRoute}");
            Console.WriteLine($"Нужна справка от врача: {(spravka ? "Да" : "Нет")}");
        }

    }
}
