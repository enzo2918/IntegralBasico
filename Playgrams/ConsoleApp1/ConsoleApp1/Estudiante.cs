using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Estudiante
    {
        private string nombre;
        private string carrera;
        private double promedio;

        public string Nombre { get { return nombre; } }
        public string Carrera { get {  return carrera; } }
        public double Promedio { get {  return promedio; } }

        public Estudiante(string nombre, string carrera, double promedio)
        {
            this.nombre = nombre;
            this.carrera = carrera;
            this.promedio = promedio;
        }
        public override string ToString()
        {
            return string.Format("nombre: {0}   carrera: {1}    promedio: {2}", nombre, carrera, promedio);
        }
    }
    internal class IQ
    {
        private string carrera;
        private double iq;

        public IQ (string carrera, double iq)
        {
            this.carrera = carrera;
            this.iq = iq;
        }
        public double Iq { get { return iq; } }
        public string Carrera { get { return carrera; } }
        //public override string ToString()
        //{
        //    return string.Format("IQ {0}", Iq);
        //}
    }
}
