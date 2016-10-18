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
@Table(name = "TIPO_PRES")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "TipoPres.findAll", query = "SELECT t FROM TipoPres t"),
    @NamedQuery(name = "TipoPres.findByIdTipoPrestacion", query = "SELECT t FROM TipoPres t WHERE t.idTipoPrestacion = :idTipoPrestacion"),
    @NamedQuery(name = "TipoPres.findByNomTipoPrest", query = "SELECT t FROM TipoPres t WHERE t.nomTipoPrest = :nomTipoPrest")})
public class TipoPres implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_TIPO_PRESTACION")
    private Integer idTipoPrestacion;
    @Column(name = "NOM_TIPO_PREST")
    private String nomTipoPrest;
    @OneToMany(mappedBy = "idTipoPrestacion")
    private Collection<Prestacion> prestacionCollection;

    public TipoPres() {
    }

    public TipoPres(Integer idTipoPrestacion) {
        this.idTipoPrestacion = idTipoPrestacion;
    }

    public Integer getIdTipoPrestacion() {
        return idTipoPrestacion;
    }

    public void setIdTipoPrestacion(Integer idTipoPrestacion) {
        this.idTipoPrestacion = idTipoPrestacion;
    }

    public String getNomTipoPrest() {
        return nomTipoPrest;
    }

    public void setNomTipoPrest(String nomTipoPrest) {
        this.nomTipoPrest = nomTipoPrest;
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
        hash += (idTipoPrestacion != null ? idTipoPrestacion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TipoPres)) {
            return false;
        }
        TipoPres other = (TipoPres) object;
        if ((this.idTipoPrestacion == null && other.idTipoPrestacion != null) || (this.idTipoPrestacion != null && !this.idTipoPrestacion.equals(other.idTipoPrestacion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.TipoPres[ idTipoPrestacion=" + idTipoPrestacion + " ]";
    }
    
}
