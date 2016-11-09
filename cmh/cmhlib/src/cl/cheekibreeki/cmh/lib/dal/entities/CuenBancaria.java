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
@Table(name = "CUEN_BANCARIA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "CuenBancaria.findAll", query = "SELECT c FROM CuenBancaria c"),
    @NamedQuery(name = "CuenBancaria.findByIdCuenBancaria", query = "SELECT c FROM CuenBancaria c WHERE c.idCuenBancaria = :idCuenBancaria"),
    @NamedQuery(name = "CuenBancaria.findByNumCBancaria", query = "SELECT c FROM CuenBancaria c WHERE c.numCBancaria = :numCBancaria")})
public class CuenBancaria implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "ID_CUEN_BANCARIA")
    private Integer idCuenBancaria;
    @Column(name = "NUM_C_BANCARIA")
    private String numCBancaria;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idCuenBancaria")
    private Collection<Logpagohonorario> logpagohonorarioCollection;
    @JoinColumn(name = "ID_BANCO", referencedColumnName = "ID_BANCO")
    @ManyToOne
    private Banco idBanco;
    @JoinColumn(name = "ID_PERS_MEDICO", referencedColumnName = "ID_PERSONAL_MEDICO")
    @ManyToOne
    private PersMedico idPersMedico;
    @JoinColumn(name = "ID_TIPO_C_BANCARIA", referencedColumnName = "ID_TIPO_C_BANCARIA")
    @ManyToOne
    private TipoCBancaria idTipoCBancaria;

    public CuenBancaria() {
    }

    public CuenBancaria(Integer idCuenBancaria) {
        this.idCuenBancaria = idCuenBancaria;
    }

    public Integer getIdCuenBancaria() {
        return idCuenBancaria;
    }

    public void setIdCuenBancaria(Integer idCuenBancaria) {
        this.idCuenBancaria = idCuenBancaria;
    }

    public String getNumCBancaria() {
        return numCBancaria;
    }

    public void setNumCBancaria(String numCBancaria) {
        this.numCBancaria = numCBancaria;
    }

    @XmlTransient
    public Collection<Logpagohonorario> getLogpagohonorarioCollection() {
        return logpagohonorarioCollection;
    }

    public void setLogpagohonorarioCollection(Collection<Logpagohonorario> logpagohonorarioCollection) {
        this.logpagohonorarioCollection = logpagohonorarioCollection;
    }

    public Banco getIdBanco() {
        return idBanco;
    }

    public void setIdBanco(Banco idBanco) {
        this.idBanco = idBanco;
    }

    public PersMedico getIdPersMedico() {
        return idPersMedico;
    }

    public void setIdPersMedico(PersMedico idPersMedico) {
        this.idPersMedico = idPersMedico;
    }

    public TipoCBancaria getIdTipoCBancaria() {
        return idTipoCBancaria;
    }

    public void setIdTipoCBancaria(TipoCBancaria idTipoCBancaria) {
        this.idTipoCBancaria = idTipoCBancaria;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idCuenBancaria != null ? idCuenBancaria.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof CuenBancaria)) {
            return false;
        }
        CuenBancaria other = (CuenBancaria) object;
        if ((this.idCuenBancaria == null && other.idCuenBancaria != null) || (this.idCuenBancaria != null && !this.idCuenBancaria.equals(other.idCuenBancaria))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "cl.cheekibreeki.cmh.lib.dal.entities.CuenBancaria[ idCuenBancaria=" + idCuenBancaria + " ]";
    }
    
}
