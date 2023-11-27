using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ClasesBase
{
    public class Cliente:IDataErrorInfo
    {
        private int idCliente; 
        private string clienteDNI;
        private string apellido;
        private string nombre;
        private string telefono;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }


        public string ClienteDNI
        {
            get { return clienteDNI; }
            set { clienteDNI = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "ClienteDNI")
                {
                    if (String.IsNullOrEmpty(ClienteDNI) || ClienteDNI.Length < 8 || ClienteDNI.Length > 8)
                        result = "Debe ingresar un DNI con 8 digitos numericos";

                }
                else if (columnName == "Nombre")
                {
                    if (String.IsNullOrEmpty(Nombre) || Nombre.Length < 3)
                        result = "Debe ingresar el nombre minimo 3 caracteres";
                }
                else if (columnName == "Apellido")
                {
                    if (String.IsNullOrEmpty(Apellido) || Apellido.Length < 3)
                        result = "Debe ingresar un apellido minimo de 3 caracteres";
                }
                else if (columnName == "Telefono")
                {
                    if (String.IsNullOrEmpty(Telefono))
                        result = "Debe ingresar un numero de telefono";
                }
                return result;
            }
        }


    }
}
