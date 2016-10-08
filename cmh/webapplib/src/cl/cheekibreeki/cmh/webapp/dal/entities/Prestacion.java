/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.entities;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Collection;
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
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author pdelasotta
 */
@Entity
@Table(name = "PRESTACION")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Prestacion.findAll", query = "SELECT p FROM Prestacion p"),
    @NamedQuery(name = "Prestacion.findByIdPrestacion", query = "SELECT p FROM Prestacion p WHERE p.idPrestacion = :idPrestacion"),
    @NamedQuery(name = "Prestacion.findByNomPrestacion", query = "SELECT p FROM Prestacion p WHERE p.nomPrestacion = :nomPrestacion"),
    @NamedQuery(name = "Prestacion.findByPrecioPrestacion", query = "SELECT p FROM Prestacion p WHERE p.precioPrestacion = :precioPrestacion"),
    @NamedQuery(name = "Prestacion.findByCodigoPrestacion", query = "SELECT p FROM Prestacion p WHERE p.codigoPrestacion = :codigoPrestacion")})
public class Prestacion implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_PRESTACION")
    private BigDecimal idPrestacion;
    @Column(name = "NOM_PRESTACION")
    private BigDecimal nomPrestacion;
    @Column(name = "PRECIO_PRESTACION")
    private BigDecimal precioPrestacion;
    @Column(name = "CODIGO_PRESTACION")
    private String codigoPrestacion;
    @OneToMany(mappedBy = "idPrestacion")
    private Collection<EquipoReq> equipoReqCollection;
    @JoinColumn(name = "ID_ESPECIALIDAD", referencedColumnName = "ID_ESPECIALIDAD")
    @ManyToOne
    private Especialidad idEspecialidad;
    @JoinColumn(name = "ID_TIPO_PRESTACION", referencedColumnName = "ID_TIPO_PRESTACION")
    @ManyToOne
    private TipoPres idTipoPrestacion;
    @OneToMany(mappedBy = "idPrestacion")
    private Collection<AtencionAgen> atencionAgenCollection;

    public Prestacion() {
    }

    public Prestacion(BigDecimal idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    public BigDecimal getIdPrestacion() {
        return idPrestacion;
    }

    public void setIdPrestacion(BigDecimal idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    public BigDecimal getNomPrestacion() {
        return nomPrestacion;
    }

    public void setNomPrestacion(BigDecimal nomPrestacion) {
        this.nomPrestacion = nomPrestacion;
    }

    public BigDecimal getPrecioPrestacion() {
        return precioPrestacion;
    }

    public void setPrecioPrestacion(BigDecimal precioPrestacion) {
        this.precioPrestacion = precioPrestacion;
    }

    public String getCodigoPrestacion() {
        return codigoPrestacion;
    }

    public void setCodigoPrestacion(String codigoPrestacion) {
        this.codigoPrestacion = codigoPrestacion;
    }

    @XmlTransient
    public Collection<EquipoReq> getEquipoReqCollection() {
        return equipoReqCollection;
    }

    public void setEquipoReqCollection(Collection<EquipoReq> equipoReqCollection) {
        this.equipoReqCollection = equipoReqCollection;
    }

    public Especialidad getIdEspecialidad() {
        return idEspecialidad;
    }

    public void setIdEspecialidad(Especialidad idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }

    public TipoPres getIdTipoPrestacion() {
        return idTipoPrestacion;
    }

    public void setIdTipoPrestacion(TipoPres idTipoPrestacion) {
        this.idTipoPrestacion = idTipoPrestacion;
    }

    @XmlTransient
    public Collection<AtencionAgen> getAtencionAgenCollection() {
        return atencionAgenCollection;
    }

    public void setAtencionAgenCollection(Collection<AtencionAgen> atencionAgenCollection) {
        this.atencionAgenCollection = atencionAgenCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idPrestacion != null ? idPrestacion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Prestacion)) {
            return false;
        }
        Prestacion other = (Prestacion) object;
        if ((this.idPrestacion == null && other.idPrestacion != null) || (this.idPrestacion != null && !this.idPrestacion.equals(other.idPrestacion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.entities.Prestacion[ idPrestacion=" + idPrestacion + " ]";
    }
    
}
