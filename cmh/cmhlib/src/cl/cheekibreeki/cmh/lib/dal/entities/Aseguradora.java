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
 * @author dev
 */
@Entity
@Table(name = "ASEGURADORA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Aseguradora.findAll", query = "SELECT a FROM Aseguradora a"),
    @NamedQuery(name = "Aseguradora.findByIdAseguradora", query = "SELECT a FROM Aseguradora a WHERE a.idAseguradora = :idAseguradora"),
    @NamedQuery(name = "Aseguradora.findByNomAseguradora", query = "SELECT a FROM Aseguradora a WHERE a.nomAseguradora = :nomAseguradora")})
public class Aseguradora implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ASEGURADORA")
    private Integer idAseguradora;
    @Column(name = "NOM_ASEGURADORA")
    private String nomAseguradora;
    @OneToMany(mappedBy = "idAseguradora")
    private Collection<Bono> bonoCollection;

    public Aseguradora() {
    }

    public Aseguradora(Integer idAseguradora) {
        this.idAseguradora = idAseguradora;
    }

    public Integer getIdAseguradora() {
        return idAseguradora;
    }

    public void setIdAseguradora(Integer idAseguradora) {
        this.idAseguradora = idAseguradora;
    }

    public String getNomAseguradora() {
        return nomAseguradora;
    }

    public void setNomAseguradora(String nomAseguradora) {
        this.nomAseguradora = nomAseguradora;
    }

    @XmlTransient
    public Collection<Bono> getBonoCollection() {
        return bonoCollection;
    }

    public void setBonoCollection(Collection<Bono> bonoCollection) {
        this.bonoCollection = bonoCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idAseguradora != null ? idAseguradora.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Aseguradora)) {
            return false;
        }
        Aseguradora other = (Aseguradora) object;
        if ((this.idAseguradora == null && other.idAseguradora != null) || (this.idAseguradora != null && !this.idAseguradora.equals(other.idAseguradora))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Aseguradora[ idAseguradora=" + idAseguradora + " ]";
    }
    
}
