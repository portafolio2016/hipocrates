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
@Table(name = "ESTADO_ATEN")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EstadoAten.findAll", query = "SELECT e FROM EstadoAten e"),
    @NamedQuery(name = "EstadoAten.findByIdEstadoAtencion", query = "SELECT e FROM EstadoAten e WHERE e.idEstadoAtencion = :idEstadoAtencion"),
    @NamedQuery(name = "EstadoAten.findByNomEstadoAten", query = "SELECT e FROM EstadoAten e WHERE e.nomEstadoAten = :nomEstadoAten")})
public class EstadoAten implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ESTADO_ATENCION")
    private BigDecimal idEstadoAtencion;
    @Column(name = "NOM_ESTADO_ATEN")
    private String nomEstadoAten;
    @OneToMany(mappedBy = "idEstadoAtencion")
    private Collection<AtencionAgen> atencionAgenCollection;

    public EstadoAten() {
    }

    public EstadoAten(BigDecimal idEstadoAtencion) {
        this.idEstadoAtencion = idEstadoAtencion;
    }

    public BigDecimal getIdEstadoAtencion() {
        return idEstadoAtencion;
    }

    public void setIdEstadoAtencion(BigDecimal idEstadoAtencion) {
        this.idEstadoAtencion = idEstadoAtencion;
    }

    public String getNomEstadoAten() {
        return nomEstadoAten;
    }

    public void setNomEstadoAten(String nomEstadoAten) {
        this.nomEstadoAten = nomEstadoAten;
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
        hash += (idEstadoAtencion != null ? idEstadoAtencion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EstadoAten)) {
            return false;
        }
        EstadoAten other = (EstadoAten) object;
        if ((this.idEstadoAtencion == null && other.idEstadoAtencion != null) || (this.idEstadoAtencion != null && !this.idEstadoAtencion.equals(other.idEstadoAtencion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.entities.EstadoAten[ idEstadoAtencion=" + idEstadoAtencion + " ]";
    }
    
}
