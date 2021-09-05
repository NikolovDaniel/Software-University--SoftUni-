using System;
using System.Collections.Generic;
using System.Text;

namespace diagrama
{


    public class hero
    {
        private string name;


        public string Name
        {
            get { return name; }
            set { name = value; }


        }
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }

        }
        public hero(string name, int level)
        {
            Name = name;
            Level = level;

        }

        public override string ToString()
        {
            return Name + " " + Level;
        }
    }
}



namespace diagrama
{
    public class wizard : hero
    {

        public wizard(string name, int level)
             : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }


    }
}


namespace diagrama
{
    class darkwizard : wizard
    {
        public darkwizard(string name, int level)
               : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}


namespace diagrama
{
    class soulmaster : wizard
    {
        public soulmaster(string name, int level)
               : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}



namespace diagrama
{
    class elf : hero
    {
        public elf(string name, int level)
            : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}



namespace diagrama
{
    class museelf : elf
    {
        public museelf(string name, int level)
               : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}



namespace diagrama
{
    class knight : hero
    {
        public knight(string name, int level)
               : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}



namespace diagrama
{
    class darkknihgt : knight
    {
        public darkknihgt(string name, int level)
               : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}



namespace diagrama
{
    class bladeknight : knight
    {
        public bladeknight(string name, int level)
               : base(name, level)
        {


        }
        public override string ToString()
        {
            return base.Name + " " + Level;
        }
    }
}



namespace diagrama
{
    class Program
    {
        static void Main(string[] args)
        {
            hero h = new hero("ime", 1);
            elf e = new elf("ime", 1);
            museelf m = new museelf("ime", 1);
            knight k = new knight("ime", 1);
            darkknihgt d = new darkknihgt("ime", 1);
            bladeknight b = new bladeknight("ime", 1);
            wizard w = new wizard("ime", 1);
            darkknihgt da = new darkknihgt("ime", 1);
            soulmaster s = new soulmaster("ime", 1);
            Console.WriteLine(h);
            Console.WriteLine(e);
            Console.WriteLine(m);
            Console.WriteLine(k);
            Console.WriteLine(d);
            Console.WriteLine(b);
            Console.WriteLine(w);
            Console.WriteLine(da);
            Console.WriteLine(s);


        }
    }
}

