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
@Table(name = "BONO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Bono.findAll", query = "SELECT b FROM Bono b"),
    @NamedQuery(name = "Bono.findByIdBono", query = "SELECT b FROM Bono b WHERE b.idBono = :idBono"),
    @NamedQuery(name = "Bono.findByCantBono", query = "SELECT b FROM Bono b WHERE b.cantBono = :cantBono"),
    @NamedQuery(name = "Bono.findByCodAseguradora", query = "SELECT b FROM Bono b WHERE b.codAseguradora = :codAseguradora")})
public class Bono implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_BONO")
    private BigDecimal idBono;
    @Column(name = "CANT_BONO")
    private BigDecimal cantBono;
    @Column(name = "COD_ASEGURADORA")
    private String codAseguradora;
    @JoinColumn(name = "ID_ASEGURADORA", referencedColumnName = "ID_ASEGURADORA")
    @ManyToOne
    private Aseguradora idAseguradora;
    @OneToMany(mappedBy = "idBono")
    private Collection<Pago> pagoCollection;

    public Bono() {
    }

    public Bono(BigDecimal idBono) {
        this.idBono = idBono;
    }

    public BigDecimal getIdBono() {
        return idBono;
    }

    public void setIdBono(BigDecimal idBono) {
        this.idBono = idBono;
    }

    public BigDecimal getCantBono() {
        return cantBono;
    }

    public void setCantBono(BigDecimal cantBono) {
        this.cantBono = cantBono;
    }

    public String getCodAseguradora() {
        return codAseguradora;
    }

    public void setCodAseguradora(String codAseguradora) {
        this.codAseguradora = codAseguradora;
    }

    public Aseguradora getIdAseguradora() {
        return idAseguradora;
    }

    public void setIdAseguradora(Aseguradora idAseguradora) {
        this.idAseguradora = idAseguradora;
    }

    @XmlTransient
    public Collection<Pago> getPagoCollection() {
        return pagoCollection;
    }

    public void setPagoCollection(Collection<Pago> pagoCollection) {
        this.pagoCollection = pagoCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idBono != null ? idBono.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Bono)) {
            return false;
        }
        Bono other = (Bono) object;
        if ((this.idBono == null && other.idBono != null) || (this.idBono != null && !this.idBono.equals(other.idBono))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.entities.Bono[ idBono=" + idBono + " ]";
    }
    
}
