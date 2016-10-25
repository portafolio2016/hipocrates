/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "PAGO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Pago.findAll", query = "SELECT p FROM Pago p"),
    @NamedQuery(name = "Pago.findByIdPago", query = "SELECT p FROM Pago p WHERE p.idPago = :idPago"),
    @NamedQuery(name = "Pago.findByFechor", query = "SELECT p FROM Pago p WHERE p.fechor = :fechor"),
    @NamedQuery(name = "Pago.findByMontoPago", query = "SELECT p FROM Pago p WHERE p.montoPago = :montoPago")})
public class Pago implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_PAGO")
    private Integer idPago;
    @Column(name = "FECHOR")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechor;
    @Column(name = "MONTO_PAGO")
    private Integer montoPago;
    @JoinColumn(name = "ID_ATENCION_AGEN", referencedColumnName = "ID_ATENCION_AGEN")
    @ManyToOne(optional = false)
    private AtencionAgen idAtencionAgen;
    @JoinColumn(name = "ID_BONO", referencedColumnName = "ID_BONO")
    @ManyToOne
    private Bono idBono;
    @JoinColumn(name = "ID_CAJA", referencedColumnName = "ID_CAJA")
    @ManyToOne
    private Caja idCaja;
    @JoinColumn(name = "ID_DEVOLUCION", referencedColumnName = "ID_DEVOLUCION")
    @ManyToOne
    private Devolucion idDevolucion;

    public Pago() {
    }

    public Pago(Integer idPago) {
        this.idPago = idPago;
    }

    public Integer getIdPago() {
        return idPago;
    }

    public void setIdPago(Integer idPago) {
        this.idPago = idPago;
    }

    public Date getFechor() {
        return fechor;
    }

    public void setFechor(Date fechor) {
        this.fechor = fechor;
    }

    public Integer getMontoPago() {
        return montoPago;
    }

    public void setMontoPago(Integer montoPago) {
        this.montoPago = montoPago;
    }

    public AtencionAgen getIdAtencionAgen() {
        return idAtencionAgen;
    }

    public void setIdAtencionAgen(AtencionAgen idAtencionAgen) {
        this.idAtencionAgen = idAtencionAgen;
    }

    public Bono getIdBono() {
        return idBono;
    }

    public void setIdBono(Bono idBono) {
        this.idBono = idBono;
    }

    public Caja getIdCaja() {
        return idCaja;
    }

    public void setIdCaja(Caja idCaja) {
        this.idCaja = idCaja;
    }

    public Devolucion getIdDevolucion() {
        return idDevolucion;
    }

    public void setIdDevolucion(Devolucion idDevolucion) {
        this.idDevolucion = idDevolucion;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idPago != null ? idPago.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Pago)) {
            return false;
        }
        Pago other = (Pago) object;
        if ((this.idPago == null && other.idPago != null) || (this.idPago != null && !this.idPago.equals(other.idPago))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Pago[ idPago=" + idPago + " ]";
    }
    
}
