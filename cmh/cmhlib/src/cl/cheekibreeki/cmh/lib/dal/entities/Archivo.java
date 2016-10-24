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
@Table(name = "ARCHIVO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Archivo.findAll", query = "SELECT a FROM Archivo a"),
    @NamedQuery(name = "Archivo.findByIdArchivo", query = "SELECT a FROM Archivo a WHERE a.idArchivo = :idArchivo"),
    @NamedQuery(name = "Archivo.findByExtension", query = "SELECT a FROM Archivo a WHERE a.extension = :extension")})
public class Archivo implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ARCHIVO")
    private Integer idArchivo;
    @Basic(optional = false)
    @Lob
    @Column(name = "ARCHIVO_B64")
    private String archivoB64;
    @Basic(optional = false)
    @Column(name = "EXTENSION")
    private String extension;
    @JoinColumn(name = "ID_RESULTADO_ATENCION", referencedColumnName = "ID_RESULTADO_ATENCION")
    @ManyToOne
    private ResAtencion idResultadoAtencion;

    public Archivo() {
    }

    public Archivo(Integer idArchivo) {
        this.idArchivo = idArchivo;
    }

    public Archivo(Integer idArchivo, String archivoB64, String extension) {
        this.idArchivo = idArchivo;
        this.archivoB64 = archivoB64;
        this.extension = extension;
    }

    public Integer getIdArchivo() {
        return idArchivo;
    }

    public void setIdArchivo(Integer idArchivo) {
        this.idArchivo = idArchivo;
    }

    public String getArchivoB64() {
        return archivoB64;
    }

    public void setArchivoB64(String archivoB64) {
        this.archivoB64 = archivoB64;
    }

    public String getExtension() {
        return extension;
    }

    public void setExtension(String extension) {
        this.extension = extension;
    }

    public ResAtencion getIdResultadoAtencion() {
        return idResultadoAtencion;
    }

    public void setIdResultadoAtencion(ResAtencion idResultadoAtencion) {
        this.idResultadoAtencion = idResultadoAtencion;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idArchivo != null ? idArchivo.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Archivo)) {
            return false;
        }
        Archivo other = (Archivo) object;
        if ((this.idArchivo == null && other.idArchivo != null) || (this.idArchivo != null && !this.idArchivo.equals(other.idArchivo))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Archivo[ idArchivo=" + idArchivo + " ]";
    }
    
}
