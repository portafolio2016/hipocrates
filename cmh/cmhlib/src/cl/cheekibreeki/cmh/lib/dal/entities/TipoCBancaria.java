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
@Table(name = "TIPO_C_BANCARIA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "TipoCBancaria.findAll", query = "SELECT t FROM TipoCBancaria t"),
    @NamedQuery(name = "TipoCBancaria.findByIdTipoCBancaria", query = "SELECT t FROM TipoCBancaria t WHERE t.idTipoCBancaria = :idTipoCBancaria"),
    @NamedQuery(name = "TipoCBancaria.findByNomCBancaria", query = "SELECT t FROM TipoCBancaria t WHERE t.nomCBancaria = :nomCBancaria")})
public class TipoCBancaria implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_TIPO_C_BANCARIA")
    private Integer idTipoCBancaria;
    @Column(name = "NOM_C_BANCARIA")
    private String nomCBancaria;
    @OneToMany(mappedBy = "idTipoCBancaria")
    private Collection<CuenBancaria> cuenBancariaCollection;

    public TipoCBancaria() {
    }

    public TipoCBancaria(Integer idTipoCBancaria) {
        this.idTipoCBancaria = idTipoCBancaria;
    }

    public Integer getIdTipoCBancaria() {
        return idTipoCBancaria;
    }

    public void setIdTipoCBancaria(Integer idTipoCBancaria) {
        this.idTipoCBancaria = idTipoCBancaria;
    }

    public String getNomCBancaria() {
        return nomCBancaria;
    }

    public void setNomCBancaria(String nomCBancaria) {
        this.nomCBancaria = nomCBancaria;
    }

    @XmlTransient
    public Collection<CuenBancaria> getCuenBancariaCollection() {
        return cuenBancariaCollection;
    }

    public void setCuenBancariaCollection(Collection<CuenBancaria> cuenBancariaCollection) {
        this.cuenBancariaCollection = cuenBancariaCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idTipoCBancaria != null ? idTipoCBancaria.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TipoCBancaria)) {
            return false;
        }
        TipoCBancaria other = (TipoCBancaria) object;
        if ((this.idTipoCBancaria == null && other.idTipoCBancaria != null) || (this.idTipoCBancaria != null && !this.idTipoCBancaria.equals(other.idTipoCBancaria))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.TipoCBancaria[ idTipoCBancaria=" + idTipoCBancaria + " ]";
    }
    
}
