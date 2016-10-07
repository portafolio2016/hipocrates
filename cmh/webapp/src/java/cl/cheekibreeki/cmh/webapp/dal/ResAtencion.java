/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal;

import java.io.Serializable;
import java.math.BigDecimal;
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
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
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
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_RESULTADO_ATENCION")
    private BigDecimal idResultadoAtencion;
    @Column(name = "ATENCION_ABIERTA")
    private BigDecimal atencionAbierta;
    @Size(max = 50)
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

    public ResAtencion(BigDecimal idResultadoAtencion) {
        this.idResultadoAtencion = idResultadoAtencion;
    }

    public BigDecimal getIdResultadoAtencion() {
        return idResultadoAtencion;
    }

    public void setIdResultadoAtencion(BigDecimal idResultadoAtencion) {
        this.idResultadoAtencion = idResultadoAtencion;
    }

    public BigDecimal getAtencionAbierta() {
        return atencionAbierta;
    }

    public void setAtencionAbierta(BigDecimal atencionAbierta) {
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
        return "cl.cheekibreeki.cmh.webapp.dal.ResAtencion[ idResultadoAtencion=" + idResultadoAtencion + " ]";
    }
    
}
