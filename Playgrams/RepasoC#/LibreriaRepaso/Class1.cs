using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRepaso
{
    internal class Class1
    {
        class Class2
        {
            public Class2() 
            {
                ipo2 = "a";
            }
            //no ves c# que esto no tiene sentido?
            public void Potato() { }
            private void Potato2() 
            {
                ipo3 = DateTime.Now;
                var aa = ipo3;
            }

            public string _opi = "";

            public string ipo;

            public string ipo2 { get; set; }
            public string ipo4 { get { return ipo; } set { } }

            private DateTime _ipo3;
            public DateTime ipo3
            {
                get { return _ipo3; }
                set { _ipo3 = value; }
            }
            public DateTime GetIpo3()
            {
                return _ipo3;
            }
            public void SetIpo3(DateTime value)
            {
                _ipo3 = value;
            }

        }
        public void Main()
        { 
            Class2 a = new Class2();
            Class2 b = new Class2();
            //a.opi = "deded";
            //b.ipo = "adada";
            //var param = a.opi;
            //param = "a";
            //pipa(a);

            Acertijito(ref a,ref b);

            a = new Class2();

            Fafafaf();
        }
        Class2 pipa (Class2 parametroCualquiera) 
        {
            parametroCualquiera = new Class2();
            //parametroCualquiera.opi = "afafa";

            return parametroCualquiera;
        }

        void Acertijito(ref Class2 a, ref Class2 b)
        {
           // b.opi = a.opi;
            a.ipo2 = b.ipo;
        }

        void Fafafaf()
        {
            int? num = 1;
            num = null;

            int num2 = 0;
            if (num.HasValue)
                num2 = num.Value;
            else
                num2 = 0;

            var num3 = num.HasValue ? num.Value : 0;

            string cad = "";
            cad = null;

            var cl = new Class2();
            cl = null;

            int fecha = 1;
            Mfahf(fecha);
        }

        private void Mfahf(int fecha)
        {

            int a = 1;

        }
    }
}
