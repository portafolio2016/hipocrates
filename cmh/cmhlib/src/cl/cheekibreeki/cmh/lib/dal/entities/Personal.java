/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.entities;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
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
@Table(name = "PERSONAL")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Personal.findAll", query = "SELECT p FROM Personal p"),
    @NamedQuery(name = "Personal.findByIdPersonal", query = "SELECT p FROM Personal p WHERE p.idPersonal = :idPersonal"),
    @NamedQuery(name = "Personal.findByNombres", query = "SELECT p FROM Personal p WHERE p.nombres = :nombres"),
    @NamedQuery(name = "Personal.findByApellidos", query = "SELECT p FROM Personal p WHERE p.apellidos = :apellidos"),
    @NamedQuery(name = "Personal.findByRemuneracion", query = "SELECT p FROM Personal p WHERE p.remuneracion = :remuneracion"),
    @NamedQuery(name = "Personal.findByHashedPass", query = "SELECT p FROM Personal p WHERE p.hashedPass = :hashedPass"),
    @NamedQuery(name = "Personal.findByPorcentDescuento", query = "SELECT p FROM Personal p WHERE p.porcentDescuento = :porcentDescuento"),
    @NamedQuery(name = "Personal.findByRut", query = "SELECT p FROM Personal p WHERE p.rut = :rut"),
    @NamedQuery(name = "Personal.findByVerificador", query = "SELECT p FROM Personal p WHERE p.verificador = :verificador"),
    @NamedQuery(name = "Personal.findByEmail", query = "SELECT p FROM Personal p WHERE p.email = :email")})
public class Personal implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_PERSONAL")
    private Integer idPersonal;
    @Column(name = "NOMBRES")
    private String nombres;
    @Column(name = "APELLIDOS")
    private String apellidos;
    @Column(name = "REMUNERACION")
    private Integer remuneracion;
    @Column(name = "HASHED_PASS")
    private String hashedPass;
    @Column(name = "PORCENT_DESCUENTO")
    private Short porcentDescuento;
    @Basic(optional = false)
    @Column(name = "RUT")
    private int rut;
    @Basic(optional = false)
    @Column(name = "VERIFICADOR")
    private Character verificador;
    @Column(name = "EMAIL")
    private String email;
    @OneToMany(mappedBy = "idPersonal")
    private Collection<PersMedico> persMedicoCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idPersonal")
    private Collection<Funcionario> funcionarioCollection;

    public Personal() {
    }

    public Personal(Integer idPersonal) {
        this.idPersonal = idPersonal;
    }

    public Personal(Integer idPersonal, int rut, Character verificador) {
        this.idPersonal = idPersonal;
        this.rut = rut;
        this.verificador = verificador;
    }

    public Integer getIdPersonal() {
        return idPersonal;
    }

    public void setIdPersonal(Integer idPersonal) {
        this.idPersonal = idPersonal;
    }

    public String getNombres() {
        return nombres;
    }

    public void setNombres(String nombres) {
        this.nombres = nombres;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public Integer getRemuneracion() {
        return remuneracion;
    }

    public void setRemuneracion(Integer remuneracion) {
        this.remuneracion = remuneracion;
    }

    public String getHashedPass() {
        return hashedPass;
    }

    public void setHashedPass(String hashedPass) {
        this.hashedPass = hashedPass;
    }

    public Short getPorcentDescuento() {
        return porcentDescuento;
    }

    public void setPorcentDescuento(Short porcentDescuento) {
        this.porcentDescuento = porcentDescuento;
    }

    public int getRut() {
        return rut;
    }

    public void setRut(int rut) {
        this.rut = rut;
    }

    public Character getVerificador() {
        return verificador;
    }

    public void setVerificador(Character verificador) {
        this.verificador = verificador;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @XmlTransient
    public Collection<PersMedico> getPersMedicoCollection() {
        return persMedicoCollection;
    }

    public void setPersMedicoCollection(Collection<PersMedico> persMedicoCollection) {
        this.persMedicoCollection = persMedicoCollection;
    }

    @XmlTransient
    public Collection<Funcionario> getFuncionarioCollection() {
        return funcionarioCollection;
    }

    public void setFuncionarioCollection(Collection<Funcionario> funcionarioCollection) {
        this.funcionarioCollection = funcionarioCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idPersonal != null ? idPersonal.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Personal)) {
            return false;
        }
        Personal other = (Personal) object;
        if ((this.idPersonal == null && other.idPersonal != null) || (this.idPersonal != null && !this.idPersonal.equals(other.idPersonal))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Personal[ idPersonal=" + idPersonal + " ]";
    }
    
}
