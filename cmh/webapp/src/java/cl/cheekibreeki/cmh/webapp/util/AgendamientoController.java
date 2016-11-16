/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Especialidad;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.lib.dal.entities.TipoPres;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.servlet.http.HttpServletRequest;

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
    
    public static int tipoPrestacionSeleccionada(HttpServletRequest request){
        if(request.getParameter("tipoPrestacion") != null){
            return Integer.parseInt(request.getParameter("tipoPrestacion"));
        }else{
            return 0;
        }
    }
    
    public static int prestacionSeleccionada(HttpServletRequest request){
        if(request.getParameter("prestacion") != null){
            return Integer.parseInt(request.getParameter("prestacion"));
        }else{
            return 0;
        }
    }
    
    public static ArrayList<Prestacion> obtenerPrestaciones(HttpServletRequest request){
        int idTipoPrestacion = tipoPrestacionSeleccionada(request);
        if(idTipoPrestacion != 0){//si hay tipo de prestación seleccionada
            return obtenerPrestaciones(idTipoPrestacion);
        }else{//si no hay tipo de prestación seleccionada
            return null;
        }
    }
    
    
    
    public static ArrayList<PersMedico> obtenerPersonalMedico(HttpServletRequest request){
        //si no hay prestacion seleccionada
        int idPrestacionSeleccionada = prestacionSeleccionada(request);
        if(idPrestacionSeleccionada == 0){
            return null;
        }
        //Si hay prestacion seleccionada obtener prestacion
        Prestacion prestacion = (Prestacion)Controller.findById(Prestacion.class, idPrestacionSeleccionada);
        //buscar especialidad
        Especialidad especialidad = prestacion.getIdEspecialidad();
        //buscar todos los medicos de la especialidad
        Collection<PersMedico> personalMedicoCollection = especialidad.getPersMedicoCollection();
        if(null == personalMedicoCollection){
            return null;
        }else{
            return new ArrayList<PersMedico>(personalMedicoCollection);
        }
    }
}
