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
 * @author dev
 */
@Entity
@Table(name = "PRESTACION")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Prestacion.findAll", query = "SELECT p FROM Prestacion p"),
    @NamedQuery(name = "Prestacion.findByIdPrestacion", query = "SELECT p FROM Prestacion p WHERE p.idPrestacion = :idPrestacion"),
    @NamedQuery(name = "Prestacion.findByNomPrestacion", query = "SELECT p FROM Prestacion p WHERE p.nomPrestacion = :nomPrestacion"),
    @NamedQuery(name = "Prestacion.findByPrecioPrestacion", query = "SELECT p FROM Prestacion p WHERE p.precioPrestacion = :precioPrestacion"),
    @NamedQuery(name = "Prestacion.findByCodigoPrestacion", query = "SELECT p FROM Prestacion p WHERE p.codigoPrestacion = :codigoPrestacion"),
    @NamedQuery(name = "Prestacion.findByActivo", query = "SELECT p FROM Prestacion p WHERE p.activo = :activo")})
public class Prestacion implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_PRESTACION")
    private Integer idPrestacion;
    @Column(name = "NOM_PRESTACION")
    private String nomPrestacion;
    @Column(name = "PRECIO_PRESTACION")
    private Integer precioPrestacion;
    @Column(name = "CODIGO_PRESTACION")
    private String codigoPrestacion;
    @Basic(optional = false)
    @Column(name = "ACTIVO")
    private short activo;
    @OneToMany(mappedBy = "idPrestacion")
    private Collection<EquipoReq> equipoReqCollection;
    @JoinColumn(name = "ID_ESPECIALIDAD", referencedColumnName = "ID_ESPECIALIDAD")
    @ManyToOne
    private Especialidad idEspecialidad;
    @JoinColumn(name = "ID_TIPO_PRESTACION", referencedColumnName = "ID_TIPO_PRESTACION")
    @ManyToOne
    private TipoPres idTipoPrestacion;
    @OneToMany(mappedBy = "idPrestacion")
    private Collection<AtencionAgen> atencionAgenCollection;

    public Prestacion() {
    }

    public Prestacion(Integer idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    public Prestacion(Integer idPrestacion, short activo) {
        this.idPrestacion = idPrestacion;
        this.activo = activo;
    }

    public Integer getIdPrestacion() {
        return idPrestacion;
    }

    public void setIdPrestacion(Integer idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    public String getNomPrestacion() {
        return nomPrestacion;
    }

    public void setNomPrestacion(String nomPrestacion) {
        this.nomPrestacion = nomPrestacion;
    }

    public Integer getPrecioPrestacion() {
        return precioPrestacion;
    }

    public void setPrecioPrestacion(Integer precioPrestacion) {
        this.precioPrestacion = precioPrestacion;
    }

    public String getCodigoPrestacion() {
        return codigoPrestacion;
    }

    public void setCodigoPrestacion(String codigoPrestacion) {
        this.codigoPrestacion = codigoPrestacion;
    }

    public short getActivo() {
        return activo;
    }

    public void setActivo(short activo) {
        this.activo = activo;
    }

    @XmlTransient
    public Collection<EquipoReq> getEquipoReqCollection() {
        return equipoReqCollection;
    }

    public void setEquipoReqCollection(Collection<EquipoReq> equipoReqCollection) {
        this.equipoReqCollection = equipoReqCollection;
    }

    public Especialidad getIdEspecialidad() {
        return idEspecialidad;
    }

    public void setIdEspecialidad(Especialidad idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }

    public TipoPres getIdTipoPrestacion() {
        return idTipoPrestacion;
    }

    public void setIdTipoPrestacion(TipoPres idTipoPrestacion) {
        this.idTipoPrestacion = idTipoPrestacion;
    }

    @XmlTransient
    public Collection<AtencionAgen> getAtencionAgenCollection() {
        return atencionAgenCollection;
    }

    public void setAtencionAgenCollection(Collection<AtencionAgen> atencionAgenCollection) {
        this.atencionAgenCollection = atencionAgenCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idPrestacion != null ? idPrestacion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Prestacion)) {
            return false;
        }
        Prestacion other = (Prestacion) object;
        if ((this.idPrestacion == null && other.idPrestacion != null) || (this.idPrestacion != null && !this.idPrestacion.equals(other.idPrestacion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Prestacion[ idPrestacion=" + idPrestacion + " ]";
    }
    
}
