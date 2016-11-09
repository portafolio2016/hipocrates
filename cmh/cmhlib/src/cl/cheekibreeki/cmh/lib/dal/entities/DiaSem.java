/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
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
@Table(name = "DIA_SEM")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "DiaSem.findAll", query = "SELECT d FROM DiaSem d"),
    @NamedQuery(name = "DiaSem.findByIdDia", query = "SELECT d FROM DiaSem d WHERE d.idDia = :idDia"),
    @NamedQuery(name = "DiaSem.findByNombreDia", query = "SELECT d FROM DiaSem d WHERE d.nombreDia = :nombreDia")})
public class DiaSem implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_DIA")
    private Integer idDia;
    @Column(name = "NOMBRE_DIA")
    private String nombreDia;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idDiaSem")
    private Collection<Bloque> bloqueCollection;

    public DiaSem() {
    }

    public DiaSem(Integer idDia) {
        this.idDia = idDia;
    }

    public Integer getIdDia() {
        return idDia;
    }

    public void setIdDia(Integer idDia) {
        this.idDia = idDia;
    }

    public String getNombreDia() {
        return nombreDia;
    }

    public void setNombreDia(String nombreDia) {
        this.nombreDia = nombreDia;
    }

    @XmlTransient
    public Collection<Bloque> getBloqueCollection() {
        return bloqueCollection;
    }

    public void setBloqueCollection(Collection<Bloque> bloqueCollection) {
        this.bloqueCollection = bloqueCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idDia != null ? idDia.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof DiaSem)) {
            return false;
        }
        DiaSem other = (DiaSem) object;
        if ((this.idDia == null && other.idDia != null) || (this.idDia != null && !this.idDia.equals(other.idDia))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.DiaSem[ idDia=" + idDia + " ]";
    }
    
}
