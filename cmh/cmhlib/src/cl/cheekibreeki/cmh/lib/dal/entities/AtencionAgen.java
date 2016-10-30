/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Collection;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
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
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "ATENCION_AGEN")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "AtencionAgen.findAll", query = "SELECT a FROM AtencionAgen a"),
    @NamedQuery(name = "AtencionAgen.findByIdAtencionAgen", query = "SELECT a FROM AtencionAgen a WHERE a.idAtencionAgen = :idAtencionAgen"),
    @NamedQuery(name = "AtencionAgen.findByObservaciones", query = "SELECT a FROM AtencionAgen a WHERE a.observaciones = :observaciones"),
    @NamedQuery(name = "AtencionAgen.findByFechor", query = "SELECT a FROM AtencionAgen a WHERE a.fechor = :fechor"),
    @NamedQuery(name = "AtencionAgen.findByIdPaciente", query = "SELECT a FROM AtencionAgen a WHERE a.idPaciente = :idPaciente"),
    @NamedQuery(name = "AtencionAgen.findByIdPersonalMedico", query = "SELECT a FROM AtencionAgen a WHERE a.idPersAtiende = :idPersAtiende")})
//falta un named query que obtenga atenciones por medico solicitante
public class AtencionAgen implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ATENCION_AGEN")
    private Integer idAtencionAgen;
    @Column(name = "FECHOR")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechor;
    @Column(name = "OBSERVACIONES")
    private String observaciones;
    @JoinColumn(name = "ID_BLOQUE", referencedColumnName = "ID_BLOQUE")
    @ManyToOne(optional = false)
    private Bloque idBloque;
    @JoinColumn(name = "ID_ESTADO_ATEN", referencedColumnName = "ID_ESTADO_ATEN")
    @ManyToOne
    private EstadoAten idEstadoAten;
    @JoinColumn(name = "ID_PACIENTE", referencedColumnName = "ID_PACIENTE")
    @ManyToOne
    private Paciente idPaciente;
    @JoinColumn(name = "ID_PERS_SOLICITA", referencedColumnName = "ID_PERSONAL_MEDICO")
    @ManyToOne
    private PersMedico idPersSolicita;
    @JoinColumn(name = "ID_PERS_ATIENDE", referencedColumnName = "ID_PERSONAL_MEDICO")
    @ManyToOne(optional = false)
    private PersMedico idPersAtiende;
    @JoinColumn(name = "ID_PRESTACION", referencedColumnName = "ID_PRESTACION")
    @ManyToOne
    private Prestacion idPrestacion;
    @OneToMany(mappedBy = "idAtencionAgen")
    private Collection<ResAtencion> resAtencionCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idAtencionAgen")
    private Collection<Pago> pagoCollection;

    public AtencionAgen() {
    }

    public AtencionAgen(Integer idAtencionAgen) {
        this.idAtencionAgen = idAtencionAgen;
    }

    public Integer getIdAtencionAgen() {
        return idAtencionAgen;
    }

    public void setIdAtencionAgen(Integer idAtencionAgen) {
        this.idAtencionAgen = idAtencionAgen;
    }

    public Date getFechor() {
        return fechor;
    }

    public void setFechor(Date fechor) {
        this.fechor = fechor;
    }

    public String getObservaciones() {
        return observaciones;
    }

    public void setObservaciones(String observaciones) {
        this.observaciones = observaciones;
    }

    public Bloque getIdBloque() {
        return idBloque;
    }

    public void setIdBloque(Bloque idBloque) {
        this.idBloque = idBloque;
    }

    public EstadoAten getIdEstadoAten() {
        return idEstadoAten;
    }

    public void setIdEstadoAten(EstadoAten idEstadoAten) {
        this.idEstadoAten = idEstadoAten;
    }

    public Paciente getIdPaciente() {
        return idPaciente;
    }

    public void setIdPaciente(Paciente idPaciente) {
        this.idPaciente = idPaciente;
    }

    public PersMedico getIdPersSolicita() {
        return idPersSolicita;
    }

    public void setIdPersSolicita(PersMedico idPersSolicita) {
        this.idPersSolicita = idPersSolicita;
    }

    public PersMedico getIdPersAtiende() {
        return idPersAtiende;
    }

    public void setIdPersAtiende(PersMedico idPersAtiende) {
        this.idPersAtiende = idPersAtiende;
    }

    public Prestacion getIdPrestacion() {
        return idPrestacion;
    }

    public void setIdPrestacion(Prestacion idPrestacion) {
        this.idPrestacion = idPrestacion;
    }

    @XmlTransient
    public Collection<ResAtencion> getResAtencionCollection() {
        return resAtencionCollection;
    }

    public void setResAtencionCollection(Collection<ResAtencion> resAtencionCollection) {
        this.resAtencionCollection = resAtencionCollection;
    }

    @XmlTransient
    public Collection<Pago> getPagoCollection() {
        return pagoCollection;
    }

    public void setPagoCollection(Collection<Pago> pagoCollection) {
        this.pagoCollection = pagoCollection;
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
        return "cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen[ idAtencionAgen=" + idAtencionAgen + " ]";
    }
    
}
