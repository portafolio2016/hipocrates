/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
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
@Table(name = "TURNO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Turno.findAll", query = "SELECT t FROM Turno t"),
    @NamedQuery(name = "Turno.findByIdTurno", query = "SELECT t FROM Turno t WHERE t.idTurno = :idTurno"),
    @NamedQuery(name = "Turno.findByNombreTurno", query = "SELECT t FROM Turno t WHERE t.nombreTurno = :nombreTurno"),
    @NamedQuery(name = "Turno.findByNumhoraIni", query = "SELECT t FROM Turno t WHERE t.numhoraIni = :numhoraIni"),
    @NamedQuery(name = "Turno.findByNumminuIni", query = "SELECT t FROM Turno t WHERE t.numminuIni = :numminuIni"),
    @NamedQuery(name = "Turno.findByNumhoraFin", query = "SELECT t FROM Turno t WHERE t.numhoraFin = :numhoraFin"),
    @NamedQuery(name = "Turno.findByNumminuFin", query = "SELECT t FROM Turno t WHERE t.numminuFin = :numminuFin")})
public class Turno implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_TURNO")
    private Integer idTurno;
    @Column(name = "NOMBRE_TURNO")
    private String nombreTurno;
    @Column(name = "NUMHORA_INI")
    private Short numhoraIni;
    @Column(name = "NUMMINU_INI")
    private Short numminuIni;
    @Column(name = "NUMHORA_FIN")
    private Short numhoraFin;
    @Column(name = "NUMMINU_FIN")
    private Short numminuFin;
    @OneToMany(mappedBy = "idTurno")
    private Collection<PersMedico> persMedicoCollection;

    public Turno() {
    }

    public Turno(Integer idTurno) {
        this.idTurno = idTurno;
    }

    public Integer getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(Integer idTurno) {
        this.idTurno = idTurno;
    }

    public String getNombreTurno() {
        return nombreTurno;
    }

    public void setNombreTurno(String nombreTurno) {
        this.nombreTurno = nombreTurno;
    }

    public Short getNumhoraIni() {
        return numhoraIni;
    }

    public void setNumhoraIni(Short numhoraIni) {
        this.numhoraIni = numhoraIni;
    }

    public Short getNumminuIni() {
        return numminuIni;
    }

    public void setNumminuIni(Short numminuIni) {
        this.numminuIni = numminuIni;
    }

    public Short getNumhoraFin() {
        return numhoraFin;
    }

    public void setNumhoraFin(Short numhoraFin) {
        this.numhoraFin = numhoraFin;
    }

    public Short getNumminuFin() {
        return numminuFin;
    }

    public void setNumminuFin(Short numminuFin) {
        this.numminuFin = numminuFin;
    }

    @XmlTransient
    public Collection<PersMedico> getPersMedicoCollection() {
        return persMedicoCollection;
    }

    public void setPersMedicoCollection(Collection<PersMedico> persMedicoCollection) {
        this.persMedicoCollection = persMedicoCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idTurno != null ? idTurno.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Turno)) {
            return false;
        }
        Turno other = (Turno) object;
        if ((this.idTurno == null && other.idTurno != null) || (this.idTurno != null && !this.idTurno.equals(other.idTurno))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Turno[ idTurno=" + idTurno + " ]";
    }
    
}
