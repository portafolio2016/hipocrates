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
@Table(name = "ASEGURADORA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Aseguradora.findAll", query = "SELECT a FROM Aseguradora a"),
    @NamedQuery(name = "Aseguradora.findByIdAseguradora", query = "SELECT a FROM Aseguradora a WHERE a.idAseguradora = :idAseguradora"),
    @NamedQuery(name = "Aseguradora.findByNomAseguradora", query = "SELECT a FROM Aseguradora a WHERE a.nomAseguradora = :nomAseguradora")})
public class Aseguradora implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ASEGURADORA")
    private BigDecimal idAseguradora;
    @Column(name = "NOM_ASEGURADORA")
    private String nomAseguradora;
    @OneToMany(mappedBy = "idAseguradora")
    private Collection<Bono> bonoCollection;

    public Aseguradora() {
    }

    public Aseguradora(BigDecimal idAseguradora) {
        this.idAseguradora = idAseguradora;
    }

    public BigDecimal getIdAseguradora() {
        return idAseguradora;
    }

    public void setIdAseguradora(BigDecimal idAseguradora) {
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
        return "cl.cheekibreeki.cmh.webapp.entities.Aseguradora[ idAseguradora=" + idAseguradora + " ]";
    }
    
}
