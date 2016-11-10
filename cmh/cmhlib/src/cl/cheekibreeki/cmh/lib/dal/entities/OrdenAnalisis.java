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
 * @author palan
 */
@Entity
@Table(name = "ORDEN_ANALISIS")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "OrdenAnalisis.findAll", query = "SELECT o FROM OrdenAnalisis o"),
    @NamedQuery(name = "OrdenAnalisis.findByIdOrdenAnalisis", query = "SELECT o FROM OrdenAnalisis o WHERE o.idOrdenAnalisis = :idOrdenAnalisis"),
    @NamedQuery(name = "OrdenAnalisis.findByFechorEmision", query = "SELECT o FROM OrdenAnalisis o WHERE o.fechorEmision = :fechorEmision"),
    @NamedQuery(name = "OrdenAnalisis.findByFechorRecep", query = "SELECT o FROM OrdenAnalisis o WHERE o.fechorRecep = :fechorRecep")})
public class OrdenAnalisis implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ORDEN_ANALISIS")
    private Integer idOrdenAnalisis;
    @Column(name = "FECHOR_EMISION")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechorEmision;
    @Column(name = "FECHOR_RECEP")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechorRecep;
    @OneToMany(mappedBy = "idOrdenAnalisis")
    private Collection<AtencionAgen> atencionAgenCollection;

    public OrdenAnalisis() {
    }

    public OrdenAnalisis(Integer idOrdenAnalisis) {
        this.idOrdenAnalisis = idOrdenAnalisis;
    }

    public Integer getIdOrdenAnalisis() {
        return idOrdenAnalisis;
    }

    public void setIdOrdenAnalisis(Integer idOrdenAnalisis) {
        this.idOrdenAnalisis = idOrdenAnalisis;
    }

    public Date getFechorEmision() {
        return fechorEmision;
    }

    public void setFechorEmision(Date fechorEmision) {
        this.fechorEmision = fechorEmision;
    }

    public Date getFechorRecep() {
        return fechorRecep;
    }

    public void setFechorRecep(Date fechorRecep) {
        this.fechorRecep = fechorRecep;
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
        return "cl.cheekibreeki.cmh.lib.dal.entities.OrdenAnalisis[ idOrdenAnalisis=" + idOrdenAnalisis + " ]";
    }
    
}
