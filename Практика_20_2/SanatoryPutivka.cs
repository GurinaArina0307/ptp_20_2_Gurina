using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Практика_20
{
    public class SanatoryPutivka : TravelPackage // санаторная путевка (наслед)
    {
        private string disease { get; set; }     // заболевание

        public SanatoryPutivka(string nameTravel, int duration, 
            int price, bool excursions, string disease)
            : base(nameTravel, duration, price, excursions) 
        {
            this.disease = disease;
        }

        public string Disease
        {
            get { return disease; }
            set
            {
                string error = Validation.ValidateString(value, "");
                if (!string.IsNullOrEmpty(error))
                    throw new ArgumentException(error);
                disease = value;
            }
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Заболевание: {disease}");
        }

    }
}
