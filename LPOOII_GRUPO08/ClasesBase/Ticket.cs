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
    }
}
