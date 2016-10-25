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
 * @author dev
 */
@Entity
@Table(name = "TIPO_FICHA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "TipoFicha.findAll", query = "SELECT t FROM TipoFicha t"),
    @NamedQuery(name = "TipoFicha.findByIdTipoFicha", query = "SELECT t FROM TipoFicha t WHERE t.idTipoFicha = :idTipoFicha"),
    @NamedQuery(name = "TipoFicha.findByNomTipoFicha", query = "SELECT t FROM TipoFicha t WHERE t.nomTipoFicha = :nomTipoFicha")})
public class TipoFicha implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_TIPO_FICHA")
    private Integer idTipoFicha;
    @Column(name = "NOM_TIPO_FICHA")
    private String nomTipoFicha;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idTipoFicha")
    private Collection<EntradaFicha> entradaFichaCollection;

    public TipoFicha() {
    }

    public TipoFicha(Integer idTipoFicha) {
        this.idTipoFicha = idTipoFicha;
    }

    public Integer getIdTipoFicha() {
        return idTipoFicha;
    }

    public void setIdTipoFicha(Integer idTipoFicha) {
        this.idTipoFicha = idTipoFicha;
    }

    public String getNomTipoFicha() {
        return nomTipoFicha;
    }

    public void setNomTipoFicha(String nomTipoFicha) {
        this.nomTipoFicha = nomTipoFicha;
    }

    @XmlTransient
    public Collection<EntradaFicha> getEntradaFichaCollection() {
        return entradaFichaCollection;
    }

    public void setEntradaFichaCollection(Collection<EntradaFicha> entradaFichaCollection) {
        this.entradaFichaCollection = entradaFichaCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idTipoFicha != null ? idTipoFicha.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TipoFicha)) {
            return false;
        }
        TipoFicha other = (TipoFicha) object;
        if ((this.idTipoFicha == null && other.idTipoFicha != null) || (this.idTipoFicha != null && !this.idTipoFicha.equals(other.idTipoFicha))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.TipoFicha[ idTipoFicha=" + idTipoFicha + " ]";
    }
    
}
