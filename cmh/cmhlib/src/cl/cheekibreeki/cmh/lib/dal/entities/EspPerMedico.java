/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "ESP_PER_MEDICO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EspPerMedico.findAll", query = "SELECT e FROM EspPerMedico e"),
    @NamedQuery(name = "EspPerMedico.findByIdEspPersMed", query = "SELECT e FROM EspPerMedico e WHERE e.idEspPersMed = :idEspPersMed"),
    @NamedQuery(name = "EspPerMedico.findByIdEspecialidad", query = "SELECT e FROM EspPerMedico e WHERE e.idEspecialidad = :idEspecialidad"),
    @NamedQuery(name = "EspPerMedico.findByIdPersonalMedico", query = "SELECT e FROM EspPerMedico e WHERE e.idPersonalMedico = :idPersonalMedico")})
public class EspPerMedico implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID_ESP_PERS_MED")
    private BigDecimal idEspPersMed;
    @Column(name = "ID_ESPECIALIDAD")
    private BigDecimal idEspecialidad;
    @Column(name = "ID_PERSONAL_MEDICO")
    private BigDecimal idPersonalMedico;

    public EspPerMedico() {
    }

    public EspPerMedico(BigDecimal idEspPersMed) {
        this.idEspPersMed = idEspPersMed;
    }

    public BigDecimal getIdEspPersMed() {
        return idEspPersMed;
    }

    public void setIdEspPersMed(BigDecimal idEspPersMed) {
        this.idEspPersMed = idEspPersMed;
    }

    public BigDecimal getIdEspecialidad() {
        return idEspecialidad;
    }

    public void setIdEspecialidad(BigDecimal idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }

    public BigDecimal getIdPersonalMedico() {
        return idPersonalMedico;
    }

    public void setIdPersonalMedico(BigDecimal idPersonalMedico) {
        this.idPersonalMedico = idPersonalMedico;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idEspPersMed != null ? idEspPersMed.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EspPerMedico)) {
            return false;
        }
        EspPerMedico other = (EspPerMedico) object;
        if ((this.idEspPersMed == null && other.idEspPersMed != null) || (this.idEspPersMed != null && !this.idEspPersMed.equals(other.idEspPersMed))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.EspPerMedico[ idEspPersMed=" + idEspPersMed + " ]";
    }
    
}
