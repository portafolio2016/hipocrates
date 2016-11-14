/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.lib.dal.entities.TipoPres;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 *
 * @author dev
 */
public class AgendamientoController {
    
    public static ArrayList<TipoPres> obtenerTipoPres(){
        Map<String, Object> params = new HashMap<String, Object>();
        List<? extends Object> result = Controller.findByQuery("TipoPres.findAll", params);
        ArrayList<TipoPres> tiposPrestacion = new ArrayList<>();
        for(Object obj : result){
            TipoPres tipoPrestacion = (TipoPres)obj;
            tiposPrestacion.add(tipoPrestacion);
        }
        return tiposPrestacion;
    }
    public static ArrayList<Prestacion> obtenerPrestaciones(){
        Map<String, Object> params = new HashMap<String, Object>();
        List<? extends Object> result = Controller.findByQuery("Prestacion.findAll", params);
        ArrayList<Prestacion> prestaciones = new ArrayList<>();
        for(Object obj : result){
            Prestacion prestacion = (Prestacion)obj;
            prestaciones.add(prestacion);
        }
        return prestaciones;
    }
    public static ArrayList<Prestacion> obtenerPrestaciones(int idTipoPrestacion){
        ArrayList<Prestacion> prestaciones = obtenerPrestaciones();
        ArrayList<Prestacion> prestacionesFiltradas = new ArrayList<Prestacion>();
        for(Prestacion prestacion : prestaciones){
            if(prestacion.getIdTipoPrestacion().getIdTipoPrestacion() == idTipoPrestacion){
                prestacionesFiltradas.add(prestacion);
            }
        }
        return prestacionesFiltradas;
    }
}
