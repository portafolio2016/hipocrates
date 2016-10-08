/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author pdelasotta
 */
@Entity
@Table(name = "INVENTARIO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Inventario.findAll", query = "SELECT i FROM Inventario i"),
    @NamedQuery(name = "Inventario.findByIdInventarioEquipo", query = "SELECT i FROM Inventario i WHERE i.idInventarioEquipo = :idInventarioEquipo"),
    @NamedQuery(name = "Inventario.findByCantBodega", query = "SELECT i FROM Inventario i WHERE i.cantBodega = :cantBodega")})
public class Inventario implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_INVENTARIO_EQUIPO")
    private Integer idInventarioEquipo;
    @Column(name = "CANT_BODEGA")
    private Integer cantBodega;
    @JoinColumn(name = "ID_TIPO_EQUIPO", referencedColumnName = "ID_TIPO_EQUIPO")
    @ManyToOne
    private TipoEquipo idTipoEquipo;

    public Inventario() {
    }

    public Inventario(Integer idInventarioEquipo) {
        this.idInventarioEquipo = idInventarioEquipo;
    }

    public Integer getIdInventarioEquipo() {
        return idInventarioEquipo;
    }

    public void setIdInventarioEquipo(Integer idInventarioEquipo) {
        this.idInventarioEquipo = idInventarioEquipo;
    }

    public Integer getCantBodega() {
        return cantBodega;
    }

    public void setCantBodega(Integer cantBodega) {
        this.cantBodega = cantBodega;
    }

    public TipoEquipo getIdTipoEquipo() {
        return idTipoEquipo;
    }

    public void setIdTipoEquipo(TipoEquipo idTipoEquipo) {
        this.idTipoEquipo = idTipoEquipo;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idInventarioEquipo != null ? idInventarioEquipo.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Inventario)) {
            return false;
        }
        Inventario other = (Inventario) object;
        if ((this.idInventarioEquipo == null && other.idInventarioEquipo != null) || (this.idInventarioEquipo != null && !this.idInventarioEquipo.equals(other.idInventarioEquipo))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.dal.entities.Inventario[ idInventarioEquipo=" + idInventarioEquipo + " ]";
    }
    
}
