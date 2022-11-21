using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Textileria.Bicola_AtencionCliente
{
    internal class Cliente
    {
        public string nombre;
        public int DNI;
        public int telef;
        public string correo;
        public string direccion;
        public string servicio;
        public double mVenta;
        public double mFinal;
        public int cantidad;

        public Cliente(string nombre, int dNI, int telef, string correo, 
            string direccion, string servicio,int cantida, double mVenta, double mFinal)
        {
            this.nombre = nombre;
            this.DNI = dNI;
            this.telef = telef;
            this.correo = correo;
            this.direccion = direccion;
            this.servicio = servicio;
            this.mVenta = mVenta;
            this.mFinal = mFinal;
            cantidad = cantida;
        }
    }
}
