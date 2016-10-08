/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.entities;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author pdelasotta
 */
@Entity
@Table(name = "EQUIPO_REQ")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EquipoReq.findAll", query = "SELECT e FROM EquipoReq e"),
    @NamedQuery(name = "EquipoReq.findByIdEquipoReq", query = "SELECT e FROM EquipoReq e WHERE e.idEquipoReq = :idEquipoReq"),
    @NamedQuery(name = "EquipoReq.findByCantidad", query = "SELECT e FROM EquipoReq e WHERE e.cantidad = :cantidad")})
public class EquipoReq implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_EQUIPO_REQ")
    private BigDecimal idEquipoReq;
    @Column(name = "CANTIDAD")
    private BigDecimal cantidad;
    @JoinColumn(name = "ID_PRESTACION", referencedColumnName = "ID_PRESTACION")
    @ManyToOne
    private Prestacion idPrestacion;
    @JoinColumn(name = "ID_TIPO_EQUIPO", referencedColumnName = "ID_TIPO_EQUIPO")
    @ManyToOne
    private TipoEquipo idTipoEquipo;

    public EquipoReq() {
    }

    public EquipoReq(BigDecimal idEquipoReq) {
        this.idEquipoReq = idEquipoReq;
    }

    public BigDecimal getIdEquipoReq() {
        return idEquipoReq;
    }

    public void setIdEquipoReq(BigDecimal idEquipoReq) {
        this.idEquipoReq = idEquipoReq;
    }

    public BigDecimal getCantidad() {
        return cantidad;
    }

    public void setCantidad(BigDecimal cantidad) {
        this.cantidad = cantidad;
    }

    public Prestacion getIdPrestacion() {
        return idPrestacion;
    }

    public void setIdPrestacion(Prestacion idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    public TipoEquipo getIdTipoEquipo() {
        return idTipoEquipo;
    }

    public void setIdTipoEquipo(TipoEquipo idTipoEquipo) {
        this.idTipoEquipo = idTipoEquipo;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idEquipoReq != null ? idEquipoReq.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EquipoReq)) {
            return false;
        }
        EquipoReq other = (EquipoReq) object;
        if ((this.idEquipoReq == null && other.idEquipoReq != null) || (this.idEquipoReq != null && !this.idEquipoReq.equals(other.idEquipoReq))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.entities.EquipoReq[ idEquipoReq=" + idEquipoReq + " ]";
    }
    
}
