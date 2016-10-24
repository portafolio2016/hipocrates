/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
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
    @NamedQuery(name = "EstadoAten.findByIdEstadoAten", query = "SELECT e FROM EstadoAten e WHERE e.idEstadoAten = :idEstadoAten"),
    @NamedQuery(name = "EstadoAten.findByNomEstadoAten", query = "SELECT e FROM EstadoAten e WHERE e.nomEstadoAten = :nomEstadoAten")})
public class EstadoAten implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ESTADO_ATEN")
    private Integer idEstadoAten;
    @Column(name = "NOM_ESTADO_ATEN")
    private String nomEstadoAten;
    @OneToMany(mappedBy = "idEstadoAten")
    private Collection<AtencionAgen> atencionAgenCollection;

    public EstadoAten() {
    }

    public EstadoAten(Integer idEstadoAten) {
        this.idEstadoAten = idEstadoAten;
    }

    public Integer getIdEstadoAten() {
        return idEstadoAten;
    }

    public void setIdEstadoAten(Integer idEstadoAten) {
        this.idEstadoAten = idEstadoAten;
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
        hash += (idEstadoAten != null ? idEstadoAten.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EstadoAten)) {
            return false;
        }
        EstadoAten other = (EstadoAten) object;
        if ((this.idEstadoAten == null && other.idEstadoAten != null) || (this.idEstadoAten != null && !this.idEstadoAten.equals(other.idEstadoAten))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.EstadoAten[ idEstadoAten=" + idEstadoAten + " ]";
    }
    
}
