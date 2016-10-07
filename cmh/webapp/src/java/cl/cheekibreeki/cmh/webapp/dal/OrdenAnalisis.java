/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Collection;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author pdelasotta
 */
@Entity
@Table(name = "ORDEN_ANALISIS")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "OrdenAnalisis.findAll", query = "SELECT o FROM OrdenAnalisis o"),
    @NamedQuery(name = "OrdenAnalisis.findByIdOrdenAnalisis", query = "SELECT o FROM OrdenAnalisis o WHERE o.idOrdenAnalisis = :idOrdenAnalisis"),
    @NamedQuery(name = "OrdenAnalisis.findByFechaHoraEmision", query = "SELECT o FROM OrdenAnalisis o WHERE o.fechaHoraEmision = :fechaHoraEmision"),
    @NamedQuery(name = "OrdenAnalisis.findByFechaHoraRecep", query = "SELECT o FROM OrdenAnalisis o WHERE o.fechaHoraRecep = :fechaHoraRecep")})
public class OrdenAnalisis implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_ORDEN_ANALISIS")
    private BigDecimal idOrdenAnalisis;
    @Column(name = "FECHA_HORA_EMISION")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaHoraEmision;
    @Column(name = "FECHA_HORA_RECEP")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaHoraRecep;
    @OneToMany(mappedBy = "idOrdenAnalisis")
    private Collection<ResAtencion> resAtencionCollection;

    public OrdenAnalisis() {
    }

    public OrdenAnalisis(BigDecimal idOrdenAnalisis) {
        this.idOrdenAnalisis = idOrdenAnalisis;
    }

    public BigDecimal getIdOrdenAnalisis() {
        return idOrdenAnalisis;
    }

    public void setIdOrdenAnalisis(BigDecimal idOrdenAnalisis) {
        this.idOrdenAnalisis = idOrdenAnalisis;
    }

    public Date getFechaHoraEmision() {
        return fechaHoraEmision;
    }

    public void setFechaHoraEmision(Date fechaHoraEmision) {
        this.fechaHoraEmision = fechaHoraEmision;
    }

    public Date getFechaHoraRecep() {
        return fechaHoraRecep;
    }

    public void setFechaHoraRecep(Date fechaHoraRecep) {
        this.fechaHoraRecep = fechaHoraRecep;
    }

    @XmlTransient
    public Collection<ResAtencion> getResAtencionCollection() {
        return resAtencionCollection;
    }

    public void setResAtencionCollection(Collection<ResAtencion> resAtencionCollection) {
        this.resAtencionCollection = resAtencionCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idOrdenAnalisis != null ? idOrdenAnalisis.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof OrdenAnalisis)) {
            return false;
        }
        OrdenAnalisis other = (OrdenAnalisis) object;
        if ((this.idOrdenAnalisis == null && other.idOrdenAnalisis != null) || (this.idOrdenAnalisis != null && !this.idOrdenAnalisis.equals(other.idOrdenAnalisis))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.dal.OrdenAnalisis[ idOrdenAnalisis=" + idOrdenAnalisis + " ]";
    }
    
}
