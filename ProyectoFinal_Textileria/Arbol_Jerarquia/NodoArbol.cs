using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Textileria
{
    internal class NodoArbol
    {
        public string codigo, nombre, dni, cargo, horario;
        public NodoArbol hijo, hermano;

        public NodoArbol(string codigo, string nombre, string dni, string cargo, string horario)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.dni = dni;
            this.cargo = cargo;
            this.horario = horario;
        }

        public NodoArbol(string nombre, string horario)
        {
            this.nombre = nombre;
            this.horario = horario;
        }
    }
}
