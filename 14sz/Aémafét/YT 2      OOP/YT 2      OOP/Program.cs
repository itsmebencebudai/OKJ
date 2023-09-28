using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YT_2______OOP
{
    class Jegyzetlap
    {
        private string szöv;

        public string Szöv { get => szöv; set => szöv = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Jegyzetlap jl = new Jegyzetlap();
            jl.Szöv = "abc";
            Console.WriteLine(jl.Szöv);
            

        }
    }
}
