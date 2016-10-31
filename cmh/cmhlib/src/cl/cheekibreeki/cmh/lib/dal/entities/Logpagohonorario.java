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
    @NamedQuery(name = "Logpagohonorario.findByNombre", query = "SELECT l FROM Logpagohonorario l WHERE l.nombre = :nombre"),
    @NamedQuery(name = "Logpagohonorario.findByBanco", query = "SELECT l FROM Logpagohonorario l WHERE l.banco = :banco"),
    @NamedQuery(name = "Logpagohonorario.findByTipocuenta", query = "SELECT l FROM Logpagohonorario l WHERE l.tipocuenta = :tipocuenta"),
    @NamedQuery(name = "Logpagohonorario.findByCuenta", query = "SELECT l FROM Logpagohonorario l WHERE l.cuenta = :cuenta"),
    @NamedQuery(name = "Logpagohonorario.findBySubtotal", query = "SELECT l FROM Logpagohonorario l WHERE l.subtotal = :subtotal"),
    @NamedQuery(name = "Logpagohonorario.findByTotal", query = "SELECT l FROM Logpagohonorario l WHERE l.total = :total"),
    @NamedQuery(name = "Logpagohonorario.findByFechor", query = "SELECT l FROM Logpagohonorario l WHERE l.fechor = :fechor")})
public class Logpagohonorario implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDLOGPAGOHONORARIO")
    private Integer idlogpagohonorario;
    @Column(name = "NOMBRE")
    private String nombre;
    @Column(name = "BANCO")
    private String banco;
    @Column(name = "TIPOCUENTA")
    private String tipocuenta;
    @Column(name = "CUENTA")
    private Integer cuenta;
    @Column(name = "SUBTOTAL")
    private Integer subtotal;
    @Column(name = "TOTAL")
    private Integer total;
    @Column(name = "FECHOR")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechor;

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

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getBanco() {
        return banco;
    }

    public void setBanco(String banco) {
        this.banco = banco;
    }

    public String getTipocuenta() {
        return tipocuenta;
    }

    public void setTipocuenta(String tipocuenta) {
        this.tipocuenta = tipocuenta;
    }

    public Integer getCuenta() {
        return cuenta;
    }

    public void setCuenta(Integer cuenta) {
        this.cuenta = cuenta;
    }

    public Integer getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(Integer subtotal) {
        this.subtotal = subtotal;
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
