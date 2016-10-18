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
@Table(name = "TIPO_EQUIPO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "TipoEquipo.findAll", query = "SELECT t FROM TipoEquipo t"),
    @NamedQuery(name = "TipoEquipo.findByIdTipoEquipo", query = "SELECT t FROM TipoEquipo t WHERE t.idTipoEquipo = :idTipoEquipo"),
    @NamedQuery(name = "TipoEquipo.findByNombreTipoEquipo", query = "SELECT t FROM TipoEquipo t WHERE t.nombreTipoEquipo = :nombreTipoEquipo")})
public class TipoEquipo implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_TIPO_EQUIPO")
    private Integer idTipoEquipo;
    @Column(name = "NOMBRE_TIPO_EQUIPO")
    private String nombreTipoEquipo;
    @OneToMany(mappedBy = "idTipoEquipo")
    private Collection<Inventario> inventarioCollection;
    @OneToMany(mappedBy = "idTipoEquipo")
    private Collection<EquipoReq> equipoReqCollection;

    public TipoEquipo() {
    }

    public TipoEquipo(Integer idTipoEquipo) {
        this.idTipoEquipo = idTipoEquipo;
    }

    public Integer getIdTipoEquipo() {
        return idTipoEquipo;
    }

    public void setIdTipoEquipo(Integer idTipoEquipo) {
        this.idTipoEquipo = idTipoEquipo;
    }

    public String getNombreTipoEquipo() {
        return nombreTipoEquipo;
    }

    public void setNombreTipoEquipo(String nombreTipoEquipo) {
        this.nombreTipoEquipo = nombreTipoEquipo;
    }

    @XmlTransient
    public Collection<Inventario> getInventarioCollection() {
        return inventarioCollection;
    }

    public void setInventarioCollection(Collection<Inventario> inventarioCollection) {
        this.inventarioCollection = inventarioCollection;
    }

    @XmlTransient
    public Collection<EquipoReq> getEquipoReqCollection() {
        return equipoReqCollection;
    }

    public void setEquipoReqCollection(Collection<EquipoReq> equipoReqCollection) {
        this.equipoReqCollection = equipoReqCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idTipoEquipo != null ? idTipoEquipo.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TipoEquipo)) {
            return false;
        }
        TipoEquipo other = (TipoEquipo) object;
        if ((this.idTipoEquipo == null && other.idTipoEquipo != null) || (this.idTipoEquipo != null && !this.idTipoEquipo.equals(other.idTipoEquipo))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.TipoEquipo[ idTipoEquipo=" + idTipoEquipo + " ]";
    }
    
}
