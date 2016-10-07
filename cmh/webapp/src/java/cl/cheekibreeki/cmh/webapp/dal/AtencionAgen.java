/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Collection;
import java.util.Date;
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
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author pdelasotta
 */
@Entity
@Table(name = "ATENCION_AGEN")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "AtencionAgen.findAll", query = "SELECT a FROM AtencionAgen a"),
    @NamedQuery(name = "AtencionAgen.findByIdAtencionAgen", query = "SELECT a FROM AtencionAgen a WHERE a.idAtencionAgen = :idAtencionAgen"),
    @NamedQuery(name = "AtencionAgen.findByFecha", query = "SELECT a FROM AtencionAgen a WHERE a.fecha = :fecha"),
    @NamedQuery(name = "AtencionAgen.findByHora", query = "SELECT a FROM AtencionAgen a WHERE a.hora = :hora"),
    @NamedQuery(name = "AtencionAgen.findByObservaciones", query = "SELECT a FROM AtencionAgen a WHERE a.observaciones = :observaciones")})
public class AtencionAgen implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_ATENCION_AGEN")
    private BigDecimal idAtencionAgen;
    @Column(name = "FECHA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fecha;
    @Column(name = "HORA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date hora;
    @Size(max = 50)
    @Column(name = "OBSERVACIONES")
    private String observaciones;
    @OneToMany(mappedBy = "idAtencionAgendada")
    private Collection<ResAtencion> resAtencionCollection;
    @JoinColumn(name = "ID_ESTADO_ATENCION", referencedColumnName = "ID_ESTADO_ATENCION")
    @ManyToOne
    private EstadoAten idEstadoAtencion;
    @JoinColumn(name = "ID_PACIENTE", referencedColumnName = "ID_PACIENTE")
    @ManyToOne
    private Paciente idPaciente;
    @JoinColumn(name = "ID_PAGO", referencedColumnName = "ID_PAGO")
    @ManyToOne
    private Pago idPago;
    @JoinColumn(name = "ID_PERSONAL_MEDICO", referencedColumnName = "ID_PERSONAL_MEDICO")
    @ManyToOne
    private PersMedico idPersonalMedico;
    @JoinColumn(name = "ID_PRESTACION", referencedColumnName = "ID_PRESTACION")
    @ManyToOne
    private Prestacion idPrestacion;

    public AtencionAgen() {
    }

    public AtencionAgen(BigDecimal idAtencionAgen) {
        this.idAtencionAgen = idAtencionAgen;
    }

    public BigDecimal getIdAtencionAgen() {
        return idAtencionAgen;
    }

    public void setIdAtencionAgen(BigDecimal idAtencionAgen) {
        this.idAtencionAgen = idAtencionAgen;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    public Date getHora() {
        return hora;
    }

    public void setHora(Date hora) {
        this.hora = hora;
    }

    public String getObservaciones() {
        return observaciones;
    }

    public void setObservaciones(String observaciones) {
        this.observaciones = observaciones;
    }

    @XmlTransient
    public Collection<ResAtencion> getResAtencionCollection() {
        return resAtencionCollection;
    }

    public void setResAtencionCollection(Collection<ResAtencion> resAtencionCollection) {
        this.resAtencionCollection = resAtencionCollection;
    }

    public EstadoAten getIdEstadoAtencion() {
        return idEstadoAtencion;
    }

    public void setIdEstadoAtencion(EstadoAten idEstadoAtencion) {
        this.idEstadoAtencion = idEstadoAtencion;
    }

    public Paciente getIdPaciente() {
        return idPaciente;
    }

    public void setIdPaciente(Paciente idPaciente) {
        this.idPaciente = idPaciente;
    }

    public Pago getIdPago() {
        return idPago;
    }

    public void setIdPago(Pago idPago) {
        this.idPago = idPago;
    }

    public PersMedico getIdPersonalMedico() {
        return idPersonalMedico;
    }

    public void setIdPersonalMedico(PersMedico idPersonalMedico) {
        this.idPersonalMedico = idPersonalMedico;
    }

    public Prestacion getIdPrestacion() {
        return idPrestacion;
    }

    public void setIdPrestacion(Prestacion idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idAtencionAgen != null ? idAtencionAgen.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof AtencionAgen)) {
            return false;
        }
        AtencionAgen other = (AtencionAgen) object;
        if ((this.idAtencionAgen == null && other.idAtencionAgen != null) || (this.idAtencionAgen != null && !this.idAtencionAgen.equals(other.idAtencionAgen))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.dal.AtencionAgen[ idAtencionAgen=" + idAtencionAgen + " ]";
    }
    
}
