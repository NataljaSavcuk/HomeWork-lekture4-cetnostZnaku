using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_lekture4 
{
    public class MyLibrary : IEquatable<MyLibrary> //dik bohu za Google! Neprobiraly jsme to, tak ze jinak bych to nedala!
    {
        public char Znak { get; set; }

        public int Pocet { get; set; }

        public override string ToString()
        {
            return "Symbol " + Znak + "   Pocet: " + Pocet;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            MyLibrary objAsPart = obj as MyLibrary;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            Znak = this.Znak;
            return Pocet;
        }
        public bool Equals(MyLibrary other)
        {
            if (other == null) return false;
            return (this.Znak.Equals(other.Znak));
        }
    }
}
