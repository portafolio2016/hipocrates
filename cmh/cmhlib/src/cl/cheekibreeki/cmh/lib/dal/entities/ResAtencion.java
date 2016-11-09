/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
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
@Table(name = "RES_ATENCION")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "ResAtencion.findAll", query = "SELECT r FROM ResAtencion r"),
    @NamedQuery(name = "ResAtencion.findByIdResultadoAtencion", query = "SELECT r FROM ResAtencion r WHERE r.idResultadoAtencion = :idResultadoAtencion"),
    @NamedQuery(name = "ResAtencion.findByAtencionAbierta", query = "SELECT r FROM ResAtencion r WHERE r.atencionAbierta = :atencionAbierta"),
    @NamedQuery(name = "ResAtencion.findByComentario", query = "SELECT r FROM ResAtencion r WHERE r.comentario = :comentario"),
    @NamedQuery(name = "ResAtencion.findByExtArchivo", query = "SELECT r FROM ResAtencion r WHERE r.extArchivo = :extArchivo"),
    @NamedQuery(name = "ResAtencion.findByIdAtencionAgen", query = "SELECT r FROM ResAtencion r WHERE r.idAtencionAgen = :idAtencionAgen"),
//    ,@NamedQuery(name = "ResAtencion.findByIdPersonalMedico", query = "SELECT r FROM ResAtencion r WHERE r.idPersonalMedico = :idPersonalMedico")
    @NamedQuery(name = "ResAtencion.findByExtArchivo", query = "SELECT r FROM ResAtencion r WHERE r.extArchivo = :extArchivo")})
public class ResAtencion implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_RESULTADO_ATENCION")
    private Integer idResultadoAtencion;
    @Column(name = "ATENCION_ABIERTA")
    private Short atencionAbierta;
    @Column(name = "COMENTARIO")
    private String comentario;
    @Lob
    @Column(name = "ARCHIVO_B64")
    private String archivoB64;
    @Column(name = "EXT_ARCHIVO")
    private String extArchivo;
    @JoinColumn(name = "ID_ATENCION_AGEN", referencedColumnName = "ID_ATENCION_AGEN")
    @ManyToOne
    private AtencionAgen idAtencionAgen;
    @JoinColumn(name = "ID_ORDEN_ANALISIS", referencedColumnName = "ID_ORDEN_ANALISIS")
    @ManyToOne
    private OrdenAnalisis idOrdenAnalisis;

    public ResAtencion() {
    }

    public ResAtencion(Integer idResultadoAtencion) {
        this.idResultadoAtencion = idResultadoAtencion;
    }

    public Integer getIdResultadoAtencion() {
        return idResultadoAtencion;
    }

    public void setIdResultadoAtencion(Integer idResultadoAtencion) {
        this.idResultadoAtencion = idResultadoAtencion;
    }

    public Short getAtencionAbierta() {
        return atencionAbierta;
    }

    public void setAtencionAbierta(Short atencionAbierta) {
        this.atencionAbierta = atencionAbierta;
    }

    public String getComentario() {
        return comentario;
    }

    public void setComentario(String comentario) {
        this.comentario = comentario;
    }

    public String getArchivoB64() {
        return archivoB64;
    }

    public void setArchivoB64(String archivoB64) {
        this.archivoB64 = archivoB64;
    }

    public String getExtArchivo() {
        return extArchivo;
    }

    public void setExtArchivo(String extArchivo) {
        this.extArchivo = extArchivo;
    }

    public AtencionAgen getIdAtencionAgen() {
        return idAtencionAgen;
    }

    public void setIdAtencionAgen(AtencionAgen idAtencionAgen) {
        this.idAtencionAgen = idAtencionAgen;
    }

    public OrdenAnalisis getIdOrdenAnalisis() {
        return idOrdenAnalisis;
    }

    public void setIdOrdenAnalisis(OrdenAnalisis idOrdenAnalisis) {
        this.idOrdenAnalisis = idOrdenAnalisis;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idResultadoAtencion != null ? idResultadoAtencion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof ResAtencion)) {
            return false;
        }
        ResAtencion other = (ResAtencion) object;
        if ((this.idResultadoAtencion == null && other.idResultadoAtencion != null) || (this.idResultadoAtencion != null && !this.idResultadoAtencion.equals(other.idResultadoAtencion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.ResAtencion[ idResultadoAtencion=" + idResultadoAtencion + " ]";
    }
    
}
