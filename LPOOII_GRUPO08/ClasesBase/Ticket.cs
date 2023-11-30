using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        private int ticketNro;
        private DateTime fechaHoraEnt;
        private DateTime fechaHoraSal;
        private string clienteDNI;
        private int tvCodigo;
        private string patente;
        private int sectorCodigo;
        private double duracion;
        private decimal tarifa;
        private decimal total;

        private string clienteApellido;
        private string clienteNombre;
        private string tipoVehiculo;
        private string sector;
        private string zona;

        public int TicketNro
        {
            get { return ticketNro; }
            set { ticketNro = value; }
        }

        public DateTime FechaHoraEnt
        {
            get { return fechaHoraEnt; }
            set { fechaHoraEnt = value; }
        }

        public DateTime FechaHoraSal
        {
            get { return fechaHoraSal; }
            set { fechaHoraSal = value; }
        }

        public string ClienteDNI
        {
            get { return clienteDNI; }
            set { clienteDNI = value; }
        }

        public int TvCodigo
        {
            get { return tvCodigo; }
            set { tvCodigo = value; }
        }

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }

        public int SectorCodigo
        {
            get { return sectorCodigo; }
            set { sectorCodigo = value; }
        }

        public double Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public decimal Tarifa
        {
            get { return tarifa; }
            set { tarifa = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public string ClienteApellido
        {
            get { return clienteApellido + ", " + clienteNombre; }
            set { clienteApellido = value; }
        }

        public string ClienteNombre
        {
            get { return clienteNombre; }
            set { clienteNombre = value; }
        }

        public string TipoVehiculo
        {
            get { return tipoVehiculo; }
            set { tipoVehiculo = value; }
        }

        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        public double CalcularDuracion()
        {
            TimeSpan tiempoTranscurrido = DateTime.Now - FechaHoraEnt;
            double duracionEnHoras = tiempoTranscurrido.TotalHours;
            return Math.Round(duracionEnHoras, 2);
        }

    }
}