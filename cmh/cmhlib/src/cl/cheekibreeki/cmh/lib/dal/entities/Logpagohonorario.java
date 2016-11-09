/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
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
@Table(name = "LOGPAGOHONORARIO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Logpagohonorario.findAll", query = "SELECT l FROM Logpagohonorario l"),
    @NamedQuery(name = "Logpagohonorario.findByIdlogpagohonorario", query = "SELECT l FROM Logpagohonorario l WHERE l.idlogpagohonorario = :idlogpagohonorario"),
    @NamedQuery(name = "Logpagohonorario.findByTotal", query = "SELECT l FROM Logpagohonorario l WHERE l.total = :total"),
    @NamedQuery(name = "Logpagohonorario.findByFechor", query = "SELECT l FROM Logpagohonorario l WHERE l.fechor = :fechor")})
public class Logpagohonorario implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDLOGPAGOHONORARIO")
    private Integer idlogpagohonorario;
    @Column(name = "TOTAL")
    private Integer total;
    @Column(name = "FECHOR")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechor;
    @JoinColumn(name = "ID_CUEN_BANCARIA", referencedColumnName = "ID_CUEN_BANCARIA")
    @ManyToOne(optional = false)
    private CuenBancaria idCuenBancaria;

    public Logpagohonorario() {
    }

    public Logpagohonorario(Integer idlogpagohonorario) {
        this.idlogpagohonorario = idlogpagohonorario;
    }

    public Integer getIdlogpagohonorario() {
        return idlogpagohonorario;
    }

    public void setIdlogpagohonorario(Integer idlogpagohonorario) {
        this.idlogpagohonorario = idlogpagohonorario;
    }

    public Integer getTotal() {
        return total;
    }

    public void setTotal(Integer total) {
        this.total = total;
    }

    public Date getFechor() {
        return fechor;
    }

    public void setFechor(Date fechor) {
        this.fechor = fechor;
    }

    public CuenBancaria getIdCuenBancaria() {
        return idCuenBancaria;
    }

    public void setIdCuenBancaria(CuenBancaria idCuenBancaria) {
        this.idCuenBancaria = idCuenBancaria;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idlogpagohonorario != null ? idlogpagohonorario.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Logpagohonorario)) {
            return false;
        }
        Logpagohonorario other = (Logpagohonorario) object;
        if ((this.idlogpagohonorario == null && other.idlogpagohonorario != null) || (this.idlogpagohonorario != null && !this.idlogpagohonorario.equals(other.idlogpagohonorario))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Logpagohonorario[ idlogpagohonorario=" + idlogpagohonorario + " ]";
    }
    
}
