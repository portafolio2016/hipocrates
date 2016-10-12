/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "ESTADO_ATENCION")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EstadoAtencion.findAll", query = "SELECT e FROM EstadoAtencion e"),
    @NamedQuery(name = "EstadoAtencion.findByIdEstadoAtencion", query = "SELECT e FROM EstadoAtencion e WHERE e.idEstadoAtencion = :idEstadoAtencion"),
    @NamedQuery(name = "EstadoAtencion.findByNomEstadoAten", query = "SELECT e FROM EstadoAtencion e WHERE e.nomEstadoAten = :nomEstadoAten")})
public class EstadoAtencion implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ESTADO_ATENCION")
    private BigDecimal idEstadoAtencion;
    @Column(name = "NOM_ESTADO_ATEN")
    private String nomEstadoAten;

    public EstadoAtencion() {
    }

    public EstadoAtencion(BigDecimal idEstadoAtencion) {
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

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idEstadoAtencion != null ? idEstadoAtencion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EstadoAtencion)) {
            return false;
        }
        EstadoAtencion other = (EstadoAtencion) object;
        if ((this.idEstadoAtencion == null && other.idEstadoAtencion != null) || (this.idEstadoAtencion != null && !this.idEstadoAtencion.equals(other.idEstadoAtencion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.EstadoAtencion[ idEstadoAtencion=" + idEstadoAtencion + " ]";
    }
    
}
