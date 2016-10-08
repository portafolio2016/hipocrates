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
@Table(name = "ESPECIALIDAD")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Especialidad.findAll", query = "SELECT e FROM Especialidad e"),
    @NamedQuery(name = "Especialidad.findByIdEspecialidad", query = "SELECT e FROM Especialidad e WHERE e.idEspecialidad = :idEspecialidad"),
    @NamedQuery(name = "Especialidad.findByNomEspecialidad", query = "SELECT e FROM Especialidad e WHERE e.nomEspecialidad = :nomEspecialidad")})
public class Especialidad implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ESPECIALIDAD")
    private BigDecimal idEspecialidad;
    @Column(name = "NOM_ESPECIALIDAD")
    private String nomEspecialidad;
    @OneToMany(mappedBy = "idEspecialidad")
    private Collection<PersMedico> persMedicoCollection;
    @OneToMany(mappedBy = "idEspecialidad")
    private Collection<Prestacion> prestacionCollection;

    public Especialidad() {
    }

    public Especialidad(BigDecimal idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }

    public BigDecimal getIdEspecialidad() {
        return idEspecialidad;
    }

    public void setIdEspecialidad(BigDecimal idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }

    public String getNomEspecialidad() {
        return nomEspecialidad;
    }

    public void setNomEspecialidad(String nomEspecialidad) {
        this.nomEspecialidad = nomEspecialidad;
    }

    @XmlTransient
    public Collection<PersMedico> getPersMedicoCollection() {
        return persMedicoCollection;
    }

    public void setPersMedicoCollection(Collection<PersMedico> persMedicoCollection) {
        this.persMedicoCollection = persMedicoCollection;
    }

    @XmlTransient
    public Collection<Prestacion> getPrestacionCollection() {
        return prestacionCollection;
    }

    public void setPrestacionCollection(Collection<Prestacion> prestacionCollection) {
        this.prestacionCollection = prestacionCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idEspecialidad != null ? idEspecialidad.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Especialidad)) {
            return false;
        }
        Especialidad other = (Especialidad) object;
        if ((this.idEspecialidad == null && other.idEspecialidad != null) || (this.idEspecialidad != null && !this.idEspecialidad.equals(other.idEspecialidad))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.entities.Especialidad[ idEspecialidad=" + idEspecialidad + " ]";
    }
    
}
