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
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author pdelasotta
 */
@Entity
@Table(name = "PERS_MEDICO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "PersMedico.findAll", query = "SELECT p FROM PersMedico p"),
    @NamedQuery(name = "PersMedico.findByIdPersonalMedico", query = "SELECT p FROM PersMedico p WHERE p.idPersonalMedico = :idPersonalMedico")})
public class PersMedico implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_PERSONAL_MEDICO")
    private BigDecimal idPersonalMedico;
    @OneToMany(mappedBy = "idPersonalMedico")
    private Collection<ResAtencion> resAtencionCollection;
    @JoinColumn(name = "ID_ESPECIALIDAD", referencedColumnName = "ID_ESPECIALIDAD")
    @ManyToOne
    private Especialidad idEspecialidad;
    @JoinColumn(name = "ID_PERSONAL", referencedColumnName = "ID_PERSONAL")
    @ManyToOne
    private Personal idPersonal;
    @JoinColumn(name = "ID_TURNO", referencedColumnName = "ID_TURNO")
    @ManyToOne
    private Turno idTurno;
    @OneToMany(mappedBy = "idPersonalMedico")
    private Collection<AtencionAgen> atencionAgenCollection;

    public PersMedico() {
    }

    public PersMedico(BigDecimal idPersonalMedico) {
        this.idPersonalMedico = idPersonalMedico;
    }

    public BigDecimal getIdPersonalMedico() {
        return idPersonalMedico;
    }

    public void setIdPersonalMedico(BigDecimal idPersonalMedico) {
        this.idPersonalMedico = idPersonalMedico;
    }

    @XmlTransient
    public Collection<ResAtencion> getResAtencionCollection() {
        return resAtencionCollection;
    }

    public void setResAtencionCollection(Collection<ResAtencion> resAtencionCollection) {
        this.resAtencionCollection = resAtencionCollection;
    }

    public Especialidad getIdEspecialidad() {
        return idEspecialidad;
    }

    public void setIdEspecialidad(Especialidad idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }

    public Personal getIdPersonal() {
        return idPersonal;
    }

    public void setIdPersonal(Personal idPersonal) {
        this.idPersonal = idPersonal;
    }

    public Turno getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(Turno idTurno) {
        this.idTurno = idTurno;
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
        hash += (idPersonalMedico != null ? idPersonalMedico.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof PersMedico)) {
            return false;
        }
        PersMedico other = (PersMedico) object;
        if ((this.idPersonalMedico == null && other.idPersonalMedico != null) || (this.idPersonalMedico != null && !this.idPersonalMedico.equals(other.idPersonalMedico))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.webapp.dal.PersMedico[ idPersonalMedico=" + idPersonalMedico + " ]";
    }
    
}
