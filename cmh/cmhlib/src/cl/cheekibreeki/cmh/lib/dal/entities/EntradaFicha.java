/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "ENTRADA_FICHA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EntradaFicha.findAll", query = "SELECT e FROM EntradaFicha e"),
    @NamedQuery(name = "EntradaFicha.findByIdEntradaFicha", query = "SELECT e FROM EntradaFicha e WHERE e.idEntradaFicha = :idEntradaFicha"),
    @NamedQuery(name = "EntradaFicha.findByNombreEntrada", query = "SELECT e FROM EntradaFicha e WHERE e.nombreEntrada = :nombreEntrada"),
    @NamedQuery(name = "EntradaFicha.findByContenidoEntrada", query = "SELECT e FROM EntradaFicha e WHERE e.contenidoEntrada = :contenidoEntrada"),
    @NamedQuery(name = "EntradaFicha.findByFechaEntrada", query = "SELECT e FROM EntradaFicha e WHERE e.fechaEntrada = :fechaEntrada")})
public class EntradaFicha implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ENTRADA_FICHA")
    private Integer idEntradaFicha;
    @Column(name = "NOMBRE_ENTRADA")
    private String nombreEntrada;
    @Column(name = "CONTENIDO_ENTRADA")
    private String contenidoEntrada;
    @Column(name = "FECHA_ENTRADA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaEntrada;
    @JoinColumn(name = "ID_PACIENTE", referencedColumnName = "ID_PACIENTE")
    @ManyToOne
    private Paciente idPaciente;
    @JoinColumn(name = "ID_TIPO_FICHA", referencedColumnName = "ID_TIPO_FICHA")
    @ManyToOne(optional = false)
    private TipoFicha idTipoFicha;

    public EntradaFicha() {
    }

    public EntradaFicha(Integer idEntradaFicha) {
        this.idEntradaFicha = idEntradaFicha;
    }

    public Integer getIdEntradaFicha() {
        return idEntradaFicha;
    }

    public void setIdEntradaFicha(Integer idEntradaFicha) {
        this.idEntradaFicha = idEntradaFicha;
    }

    public String getNombreEntrada() {
        return nombreEntrada;
    }

    public void setNombreEntrada(String nombreEntrada) {
        this.nombreEntrada = nombreEntrada;
    }

    public String getContenidoEntrada() {
        return contenidoEntrada;
    }

    public void setContenidoEntrada(String contenidoEntrada) {
        this.contenidoEntrada = contenidoEntrada;
    }

    public Date getFechaEntrada() {
        return fechaEntrada;
    }

    public void setFechaEntrada(Date fechaEntrada) {
        this.fechaEntrada = fechaEntrada;
    }

    public Paciente getIdPaciente() {
        return idPaciente;
    }

    public void setIdPaciente(Paciente idPaciente) {
        this.idPaciente = idPaciente;
    }

    public TipoFicha getIdTipoFicha() {
        return idTipoFicha;
    }

    public void setIdTipoFicha(TipoFicha idTipoFicha) {
        this.idTipoFicha = idTipoFicha;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idEntradaFicha != null ? idEntradaFicha.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EntradaFicha)) {
            return false;
        }
        EntradaFicha other = (EntradaFicha) object;
        if ((this.idEntradaFicha == null && other.idEntradaFicha != null) || (this.idEntradaFicha != null && !this.idEntradaFicha.equals(other.idEntradaFicha))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.EntradaFicha[ idEntradaFicha=" + idEntradaFicha + " ]";
    }
    
}
