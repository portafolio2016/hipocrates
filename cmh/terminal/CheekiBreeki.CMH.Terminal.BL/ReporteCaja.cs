using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;
namespace CheekiBreeki.CMH.Terminal.BL
{
    public class ReporteCaja
    {
        #region campos-privados
        private FUNCIONARIO funcionario;
        private List<PAGO> pagos;
        private List<PAGO> devoluciones;
        private int dineroEnBilletesInicial;
        private int dineroEnBilletesFinal;
        private int dineroEnChequesFinal;

        
        
        private DateTime fechorApertura;
        private DateTime fechorCierre;

        #endregion

        #region constructores
        public ReporteCaja(CAJA caja)
        {
            this.Funcionario = caja.FUNCIONARIO;
            this.fechorApertura = caja.FECHOR_APERTURA.Value;
            this.fechorCierre = caja.FECHOR_CIERRE.Value;
            this.pagos = new List<PAGO>();
            this.devoluciones = new List<PAGO>();
            foreach (PAGO pago in caja.PAGO)
            {
                if(pago.DEVOLUCION == null)
                {
                    this.pagos.Add(pago);
                }
                else
                {
                    this.devoluciones.Add(pago);
                }
            }
            this.dineroEnBilletesInicial = caja.CANT_EFECTIVO_INI.Value;
            this.dineroEnBilletesFinal = caja.CANT_EFECTIVO_FIN.Value;
            this.dineroEnChequesFinal = caja.CANT_CHEQUE_FIN.Value;
        }
        #endregion

        #region propiedades
        public DateTime FechorCierre
        {
            get { return fechorCierre; }
            set { fechorCierre = value; }
        }


        public DateTime FechorApertura
        {
            get { return fechorApertura; }
            set { fechorApertura = value; }
        }



        public int DineroEnBilletesFinal
        {
            get { return dineroEnBilletesFinal; }
            set { dineroEnBilletesFinal = value; }
        }



        public int DineroEnBilletesInicial
        {
            get { return dineroEnBilletesInicial; }
            set { dineroEnBilletesInicial = value; }
        }



        public int Diferencia
        {
            get 
            {
                int dineroQueDeberiaHaber = this.TotalVentasSinBono() + this.dineroEnBilletesInicial;
                int dineroQueHay = this.DineroEnBilletesFinal;// +this.DineroEnChequesFinal;
                return dineroQueDeberiaHaber - dineroQueHay;
            }
        }


        public List<PAGO> Devoluciones
        {
            get { return devoluciones; }
            set { devoluciones = value; }
        }


        public List<PAGO> Pagos
        {
            get { return pagos; }
            set { pagos = value; }
        }

        public int TotalDevoluciones()
        {
            int totalDevoluciones = 0;
            foreach (PAGO devolucion in this.Devoluciones)
            {
                totalDevoluciones += devolucion.MONTO_PAGO.Value + devolucion.BONO.CANT_BONO.Value;
            }
            return totalDevoluciones;            
        }


        public int TotalVentasConBono()
        {
            int totalVentas = 0;
            foreach (PAGO pago in this.pagos)
            {
                totalVentas += pago.MONTO_PAGO.Value + ((pago.BONO == null) ? 0 : pago.BONO.CANT_BONO.Value);
            }
            totalVentas -= this.TotalDevoluciones();
            return totalVentas;
        }
        /// <summary>
        /// Retorna el total de ventas sin contar los bonos, es decir
        /// el dinero que debería estar en documentos en la caja
        /// </summary>
        /// <returns>el total del dinero que debería haber en la caja</returns>
        public int TotalVentasSinBono()
        {
            int totalVentasSinBono = 0;
            foreach (PAGO pago in this.pagos)
            {
                totalVentasSinBono += pago.MONTO_PAGO.Value;
            }
            return totalVentasSinBono;
        }

        public FUNCIONARIO Funcionario
        {
            get { return funcionario; }
            set { funcionario = value; }
        }
        public int DineroEnChequesFinal
        {
            get { return dineroEnChequesFinal; }
            set { dineroEnChequesFinal = value; }
        }
        #endregion

        
        
    }
}
