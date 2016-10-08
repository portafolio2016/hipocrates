/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.entities;

import java.io.Serializable;
import java.math.BigDecimal;
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
@Table(name = "ARCHIVO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Archivo.findAll", query = "SELECT a FROM Archivo a"),
    @NamedQuery(name = "Archivo.findByIdArchivo", query = "SELECT a FROM Archivo a WHERE a.idArchivo = :idArchivo"),
    @NamedQuery(name = "Archivo.findByFileUri", query = "SELECT a FROM Archivo a WHERE a.fileUri = :fileUri")})
public class Archivo implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ARCHIVO")
    private BigDecimal idArchivo;
    @Column(name = "FILE_URI")
    private String fileUri;
    @JoinColumn(name = "ID_RESULTADO_ATENCION", referencedColumnName = "ID_RESULTADO_ATENCION")
    @ManyToOne
    private ResAtencion idResultadoAtencion;

    public Archivo() {
    }

    public Archivo(BigDecimal idArchivo) {
        this.idArchivo = idArchivo;
    }

    public BigDecimal getIdArchivo() {
        return idArchivo;
    }

    public void setIdArchivo(BigDecimal idArchivo) {
        this.idArchivo = idArchivo;
    }

    public String getFileUri() {
        return fileUri;
    }

    public void setFileUri(String fileUri) {
        this.fileUri = fileUri;
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
        return "cl.cheekibreeki.cmh.webapp.entities.Archivo[ idArchivo=" + idArchivo + " ]";
    }
    
}
