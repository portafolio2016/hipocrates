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
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author dev
 */
@Entity
@Table(name = "BLOQUE")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Bloque.findAll", query = "SELECT b FROM Bloque b"),
    @NamedQuery(name = "Bloque.findByIdBloque", query = "SELECT b FROM Bloque b WHERE b.idBloque = :idBloque"),
    @NamedQuery(name = "Bloque.findByNumBloque", query = "SELECT b FROM Bloque b WHERE b.numBloque = :numBloque"),
    @NamedQuery(name = "Bloque.findByNumHoraIni", query = "SELECT b FROM Bloque b WHERE b.numHoraIni = :numHoraIni"),
    @NamedQuery(name = "Bloque.findByNumMinuIni", query = "SELECT b FROM Bloque b WHERE b.numMinuIni = :numMinuIni"),
    @NamedQuery(name = "Bloque.findByNumHoraFin", query = "SELECT b FROM Bloque b WHERE b.numHoraFin = :numHoraFin"),
    @NamedQuery(name = "Bloque.findByNumMinuFin", query = "SELECT b FROM Bloque b WHERE b.numMinuFin = :numMinuFin")})
public class Bloque implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_BLOQUE")
    private Integer idBloque;
    @Basic(optional = false)
    @Column(name = "NUM_BLOQUE")
    private int numBloque;
    @Basic(optional = false)
    @Column(name = "NUM_HORA_INI")
    private short numHoraIni;
    @Basic(optional = false)
    @Column(name = "NUM_MINU_INI")
    private short numMinuIni;
    @Basic(optional = false)
    @Column(name = "NUM_HORA_FIN")
    private short numHoraFin;
    @Basic(optional = false)
    @Column(name = "NUM_MINU_FIN")
    private short numMinuFin;
    @JoinColumn(name = "ID_DIA_SEM", referencedColumnName = "ID_DIA")
    @ManyToOne(optional = false)
    private DiaSem idDiaSem;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idBloque")
    private Collection<AtencionAgen> atencionAgenCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idBloque")
    private Collection<Horario> horarioCollection;

    public Bloque() {
    }

    public Bloque(Integer idBloque) {
        this.idBloque = idBloque;
    }

    public Bloque(Integer idBloque, int numBloque, short numHoraIni, short numMinuIni, short numHoraFin, short numMinuFin) {
        this.idBloque = idBloque;
        this.numBloque = numBloque;
        this.numHoraIni = numHoraIni;
        this.numMinuIni = numMinuIni;
        this.numHoraFin = numHoraFin;
        this.numMinuFin = numMinuFin;
    }

    public Integer getIdBloque() {
        return idBloque;
    }

    public void setIdBloque(Integer idBloque) {
        this.idBloque = idBloque;
    }

    public int getNumBloque() {
        return numBloque;
    }

    public void setNumBloque(int numBloque) {
        this.numBloque = numBloque;
    }

    public short getNumHoraIni() {
        return numHoraIni;
    }

    public void setNumHoraIni(short numHoraIni) {
        this.numHoraIni = numHoraIni;
    }

    public short getNumMinuIni() {
        return numMinuIni;
    }

    public void setNumMinuIni(short numMinuIni) {
        this.numMinuIni = numMinuIni;
    }

    public short getNumHoraFin() {
        return numHoraFin;
    }

    public void setNumHoraFin(short numHoraFin) {
        this.numHoraFin = numHoraFin;
    }

    public short getNumMinuFin() {
        return numMinuFin;
    }

    public void setNumMinuFin(short numMinuFin) {
        this.numMinuFin = numMinuFin;
    }

    public DiaSem getIdDiaSem() {
        return idDiaSem;
    }

    public void setIdDiaSem(DiaSem idDiaSem) {
        this.idDiaSem = idDiaSem;
    }

    @XmlTransient
    public Collection<AtencionAgen> getAtencionAgenCollection() {
        return atencionAgenCollection;
    }

    public void setAtencionAgenCollection(Collection<AtencionAgen> atencionAgenCollection) {
        this.atencionAgenCollection = atencionAgenCollection;
    }

    @XmlTransient
    public Collection<Horario> getHorarioCollection() {
        return horarioCollection;
    }

    public void setHorarioCollection(Collection<Horario> horarioCollection) {
        this.horarioCollection = horarioCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idBloque != null ? idBloque.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Bloque)) {
            return false;
        }
        Bloque other = (Bloque) object;
        if ((this.idBloque == null && other.idBloque != null) || (this.idBloque != null && !this.idBloque.equals(other.idBloque))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.Bloque[ idBloque=" + idBloque + " ]";
    }
    
}
