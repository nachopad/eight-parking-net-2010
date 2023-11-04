using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : INotifyPropertyChanged
    {
        private int idUsuario;
        private string userName;
        private string password;
        private string apellido;
        private string nombre;
        private string rol;

        public Usuario(string userName,string password,string apellido,string nombre,string rol) {
            this.userName = userName;
            this.password = password;
            this.apellido = apellido;
            this.nombre = nombre;
            this.rol = rol;
        }

        public Usuario()
        {
            // TODO: Complete member initialization
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string UserName
        {
            get { return userName; }
            set 
            { 
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return password; }
            set { 
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set { 
                apellido = value;
                NotifyPropertyChanged("Apellido");
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set { 
                nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }

        public string Rol
        {
            get { return rol; }
            set { 
                rol = value;
                NotifyPropertyChanged("Rol");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Usuario other = (Usuario)obj;
            return userName.Equals(other.userName) &&
                password.Equals(other.password) &&
                apellido.Equals(other.apellido) &&
                nombre.Equals(other.nombre) &&
                rol.Equals(other.rol);
        }

        public override int GetHashCode()
        {
            return userName.GetHashCode() +
                password.GetHashCode() +
                apellido.GetHashCode() +
                nombre.GetHashCode() +
                rol.GetHashCode();
        }

    }


}
