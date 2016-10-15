/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Collection;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "CAJA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Caja.findAll", query = "SELECT c FROM Caja c"),
    @NamedQuery(name = "Caja.findByIdCaja", query = "SELECT c FROM Caja c WHERE c.idCaja = :idCaja"),
    @NamedQuery(name = "Caja.findByFecHoraCierre", query = "SELECT c FROM Caja c WHERE c.fecHoraCierre = :fecHoraCierre"),
    @NamedQuery(name = "Caja.findByFecHoraApertura", query = "SELECT c FROM Caja c WHERE c.fecHoraApertura = :fecHoraApertura")})
public class Caja implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_CAJA")
    private Integer idCaja;
    @Column(name = "FEC_HORA_CIERRE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fecHoraCierre;
    @Column(name = "FEC_HORA_APERTURA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fecHoraApertura;
    @JoinColumn(name = "ID_FUNCIONARIO", referencedColumnName = "ID_FUNCIONARIO")
    @ManyToOne
    private Funcionario idFuncionario;
    @OneToMany(mappedBy = "idCaja")
    private Collection<Pago> pagoCollection;

    public Caja() {
    }

    public Caja(Integer idCaja) {
        this.idCaja = idCaja;
    }

    public Integer getIdCaja() {
        return idCaja;
    }

    public void setIdCaja(Integer idCaja) {
        this.idCaja = idCaja;
    }

    public Date getFecHoraCierre() {
        return fecHoraCierre;
    }

    public void setFecHoraCierre(Date fecHoraCierre) {
        this.fecHoraCierre = fecHoraCierre;
    }

    public Date getFecHoraApertura() {
        return fecHoraApertura;
    }

    public void setFecHoraApertura(Date fecHoraApertura) {
        this.fecHoraApertura = fecHoraApertura;
    }

    public Funcionario getIdFuncionario() {
        return idFuncionario;
    }

    public void setIdFuncionario(Funcionario idFuncionario) {
        this.idFuncionario = idFuncionario;
    }

    @XmlTransient
    public Collection<Pago> getPagoCollection() {
        return pagoCollection;
    }

    public void setPagoCollection(Collection<Pago> pagoCollection) {
        this.pagoCollection = pagoCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idCaja != null ? idCaja.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Caja)) {
            return false;
        }
        Caja other = (Caja) object;
        if ((this.idCaja == null && other.idCaja != null) || (this.idCaja != null && !this.idCaja.equals(other.idCaja))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Caja[ idCaja=" + idCaja + " ]";
    }
    
}
