/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.bl;

import cl.cheekibreeki.cmh.lib.dal.entities.Bloque;
import java.util.Date;

/**
 *
 * @author dev
 */
public class HoraDisponible {
    private Date date;
    private int horaIni;
    private int horaFin;
    private int minuIni;
    private int minuFin;

    public HoraDisponible() {
    }

    public HoraDisponible(Date date, Bloque bloque) {
        this.horaIni = bloque.getNumHoraIni();
        this.horaFin = bloque.getNumHoraFin();
        this.minuIni = bloque.getNumMinuIni();
        this.minuFin = bloque.getNumMinuFin();
    }

    
    
    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public int getHoraIni() {
        return horaIni;
    }

    public void setHoraIni(int horaIni) {
        this.horaIni = horaIni;
    }

    public int getHoraFin() {
        return horaFin;
    }

    public void setHoraFin(int horaFin) {
        this.horaFin = horaFin;
    }

    public int getMinuIni() {
        return minuIni;
    }

    public void setMinuIni(int minuIni) {
        this.minuIni = minuIni;
    }

    public int getMinuFin() {
        return minuFin;
    }

    public void setMinuFin(int minuFin) {
        this.minuFin = minuFin;
    }
    
}
