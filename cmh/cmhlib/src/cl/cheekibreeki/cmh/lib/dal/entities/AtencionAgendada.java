/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
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
@Table(name = "ATENCION_AGENDADA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "AtencionAgendada.findAll", query = "SELECT a FROM AtencionAgendada a"),
    @NamedQuery(name = "AtencionAgendada.findByIdAtencionAgendada", query = "SELECT a FROM AtencionAgendada a WHERE a.idAtencionAgendada = :idAtencionAgendada"),
    @NamedQuery(name = "AtencionAgendada.findByFecha", query = "SELECT a FROM AtencionAgendada a WHERE a.fecha = :fecha"),
    @NamedQuery(name = "AtencionAgendada.findByHora", query = "SELECT a FROM AtencionAgendada a WHERE a.hora = :hora"),
    @NamedQuery(name = "AtencionAgendada.findByObservaciones", query = "SELECT a FROM AtencionAgendada a WHERE a.observaciones = :observaciones"),
    @NamedQuery(name = "AtencionAgendada.findByIdPaciente", query = "SELECT a FROM AtencionAgendada a WHERE a.idPaciente = :idPaciente"),
    @NamedQuery(name = "AtencionAgendada.findByIdPersonalMedico", query = "SELECT a FROM AtencionAgendada a WHERE a.idPersonalMedico = :idPersonalMedico"),
    @NamedQuery(name = "AtencionAgendada.findByIdPago", query = "SELECT a FROM AtencionAgendada a WHERE a.idPago = :idPago"),
    @NamedQuery(name = "AtencionAgendada.findByIdPrestacion", query = "SELECT a FROM AtencionAgendada a WHERE a.idPrestacion = :idPrestacion"),
    @NamedQuery(name = "AtencionAgendada.findByIdEstadoAtencion", query = "SELECT a FROM AtencionAgendada a WHERE a.idEstadoAtencion = :idEstadoAtencion")})
public class AtencionAgendada implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ATENCION_AGENDADA")
    private BigDecimal idAtencionAgendada;
    @Column(name = "FECHA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fecha;
    @Column(name = "HORA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date hora;
    @Column(name = "OBSERVACIONES")
    private String observaciones;
    @Column(name = "ID_PACIENTE")
    private BigDecimal idPaciente;
    @Column(name = "ID_PERSONAL_MEDICO")
    private BigDecimal idPersonalMedico;
    @Column(name = "ID_PAGO")
    private BigDecimal idPago;
    @Column(name = "ID_PRESTACION")
    private BigDecimal idPrestacion;
    @Column(name = "ID_ESTADO_ATENCION")
    private BigDecimal idEstadoAtencion;

    public AtencionAgendada() {
    }

    public AtencionAgendada(BigDecimal idAtencionAgendada) {
        this.idAtencionAgendada = idAtencionAgendada;
    }

    public BigDecimal getIdAtencionAgendada() {
        return idAtencionAgendada;
    }

    public void setIdAtencionAgendada(BigDecimal idAtencionAgendada) {
        this.idAtencionAgendada = idAtencionAgendada;
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

    public BigDecimal getIdPaciente() {
        return idPaciente;
    }

    public void setIdPaciente(BigDecimal idPaciente) {
        this.idPaciente = idPaciente;
    }

    public BigDecimal getIdPersonalMedico() {
        return idPersonalMedico;
    }

    public void setIdPersonalMedico(BigDecimal idPersonalMedico) {
        this.idPersonalMedico = idPersonalMedico;
    }

    public BigDecimal getIdPago() {
        return idPago;
    }

    public void setIdPago(BigDecimal idPago) {
        this.idPago = idPago;
    }

    public BigDecimal getIdPrestacion() {
        return idPrestacion;
    }

    public void setIdPrestacion(BigDecimal idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    public BigDecimal getIdEstadoAtencion() {
        return idEstadoAtencion;
    }

    public void setIdEstadoAtencion(BigDecimal idEstadoAtencion) {
        this.idEstadoAtencion = idEstadoAtencion;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idAtencionAgendada != null ? idAtencionAgendada.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof AtencionAgendada)) {
            return false;
        }
        AtencionAgendada other = (AtencionAgendada) object;
        if ((this.idAtencionAgendada == null && other.idAtencionAgendada != null) || (this.idAtencionAgendada != null && !this.idAtencionAgendada.equals(other.idAtencionAgendada))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgendada[ idAtencionAgendada=" + idAtencionAgendada + " ]";
    }
    
}
