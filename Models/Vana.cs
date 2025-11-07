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
        public int Level { get; set; } = 1;
        public List<DateTime> DagarGjorda { get; set; } = new List<DateTime>();
        public int XP => AntalDagarGjorda % 10;
        public List<int> XPList => Enumerable.Range(1, XP).ToList();
        public virtual string Motivation()
        {
            if (XP == 0) return $"DING. Du levlade precis upp till {Level}.";
            return "BRA JOBBAT,FORTSÄTT SÅ.";
        }

        public void MarkeraGjort()
        {
            AntalDagarGjorda++;
            DagarGjorda.Add(DateTime.Today);

            if (AntalDagarGjorda % 10 == 0)
            {
                Level++;
            }
        }
    }
}
