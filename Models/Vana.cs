using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Models
{
    internal class Vana
    {
        public string Name { get; set; }
        public string Kategori { get; set; }
        public int AntalDagarGjorda { get; set; }
        public List<DateTime> DagarGjorda { get; set; } = new List<DateTime>();

        public virtual string Motivation()
        {
            return "BRA JOBBAT,FORTSÄTT SÅ.";
        }
        public void MarkeraGjort()
        {
            AntalDagarGjorda++;
            DagarGjorda.Add(DateTime.Today);
        }
    }
}
