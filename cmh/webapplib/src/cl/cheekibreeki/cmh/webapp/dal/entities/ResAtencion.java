/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.entities;

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
 * @author pdelasotta
 */
@Entity
@Table(name = "RES_ATENCION")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "ResAtencion.findAll", query = "SELECT r FROM ResAtencion r"),
    @NamedQuery(name = "ResAtencion.findByIdResultadoAtencion", query = "SELECT r FROM ResAtencion r WHERE r.idResultadoAtencion = :idResultadoAtencion"),
    @NamedQuery(name = "ResAtencion.findByAtencionAbierta", query = "SELECT r FROM ResAtencion r WHERE r.atencionAbierta = :atencionAbierta"),
    @NamedQuery(name = "ResAtencion.findByComentario", query = "SELECT r FROM ResAtencion r WHERE r.comentario = :comentario")})
public class ResAtencion implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_RESULTADO_ATENCION")
    private Integer idResultadoAtencion;
    @Column(name = "ATENCION_ABIERTA")
    private Integer atencionAbierta;
    @Column(name = "COMENTARIO")
    private String comentario;
    @JoinColumn(name = "ID_ATENCION_AGENDADA", referencedColumnName = "ID_ATENCION_AGEN")
    @ManyToOne
    private AtencionAgen idAtencionAgendada;
    @JoinColumn(name = "ID_ORDEN_ANALISIS", referencedColumnName = "ID_ORDEN_ANALISIS")
    @ManyToOne
    private OrdenAnalisis idOrdenAnalisis;
    @JoinColumn(name = "ID_PERSONAL_MEDICO", referencedColumnName = "ID_PERSONAL_MEDICO")
    @ManyToOne
    private PersMedico idPersonalMedico;
    @OneToMany(mappedBy = "idResultadoAtencion")
    private Collection<Archivo> archivoCollection;

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

    public Integer getAtencionAbierta() {
        return atencionAbierta;
    }

    public void setAtencionAbierta(Integer atencionAbierta) {
        this.atencionAbierta = atencionAbierta;
    }

    public String getComentario() {
        return comentario;
    }

    public void setComentario(String comentario) {
        this.comentario = comentario;
    }

    public AtencionAgen getIdAtencionAgendada() {
        return idAtencionAgendada;
    }

    public void setIdAtencionAgendada(AtencionAgen idAtencionAgendada) {
        this.idAtencionAgendada = idAtencionAgendada;
    }

    public OrdenAnalisis getIdOrdenAnalisis() {
        return idOrdenAnalisis;
    }

    public void setIdOrdenAnalisis(OrdenAnalisis idOrdenAnalisis) {
        this.idOrdenAnalisis = idOrdenAnalisis;
    }

    public PersMedico getIdPersonalMedico() {
        return idPersonalMedico;
    }

    public void setIdPersonalMedico(PersMedico idPersonalMedico) {
        this.idPersonalMedico = idPersonalMedico;
    }

    @XmlTransient
    public Collection<Archivo> getArchivoCollection() {
        return archivoCollection;
    }

    public void setArchivoCollection(Collection<Archivo> archivoCollection) {
        this.archivoCollection = archivoCollection;
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
        return "cl.cheekibreeki.cmh.webapp.dal.entities.ResAtencion[ idResultadoAtencion=" + idResultadoAtencion + " ]";
    }
    
}
