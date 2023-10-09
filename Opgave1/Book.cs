using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }


        public bool IsValid()
        {
            return IsTitleValid() && IsPriceValid();
        }

        public bool IsIDValid()
        {
            return ID >= 0;
        }

        public bool IsTitleValid()
        {
            return !string.IsNullOrEmpty(Title) && Title.Length > 3;
        }

        public bool IsPriceValid()
        {
            return Price > 0 && Price <= 1200;
        }


        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Title)}={Title}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
