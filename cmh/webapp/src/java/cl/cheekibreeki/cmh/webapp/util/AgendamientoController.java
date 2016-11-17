/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.*;
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
    public static void cargarTodosTiposPrestaciones(HttpServletRequest request) {
        String nomParam = "tipoPrestacion";
        Map<String, Object> params = new HashMap<String, Object>();
        List<? extends Object> result = Controller.findByQuery("TipoPres.findAll", params);
        ArrayList<TipoPres> tiposPrestacion = new ArrayList<>();
        for(Object obj : result){
            TipoPres tipoPrestacion = (TipoPres)obj;
            tiposPrestacion.add(tipoPrestacion);
        }
        request.setAttribute("tiposPrestacion", tiposPrestacion);
        if(request.getParameter(nomParam) != null){
            request.setAttribute(nomParam, Integer.parseInt(request.getParameter(nomParam)));
        }
    }
    
    private static ArrayList<Prestacion> obtenerPrestaciones(){
        Map<String, Object> params = new HashMap<String, Object>();
        List<? extends Object> result = Controller.findByQuery("Prestacion.findAll", params);
        ArrayList<Prestacion> prestaciones = new ArrayList<>();
        for(Object obj : result){
            Prestacion prestacion = (Prestacion)obj;
            prestaciones.add(prestacion);
        }
        return prestaciones;
    }
    private static ArrayList<Prestacion> obtenerPrestaciones(int idTipoPrestacion){
        ArrayList<Prestacion> prestaciones = obtenerPrestaciones();
        ArrayList<Prestacion> prestacionesFiltradas = new ArrayList<Prestacion>();
        for(Prestacion prestacion : prestaciones){
            if(prestacion.getIdTipoPrestacion().getIdTipoPrestacion() == idTipoPrestacion){
                prestacionesFiltradas.add(prestacion);
            }
        }
        return prestacionesFiltradas;
    }
//    
//    public static int tipoPrestacionSeleccionada(HttpServletRequest request){
//        if(request.getParameter("tipoPrestacion") != null){
//            return Integer.parseInt(request.getParameter("tipoPrestacion"));
//        }else{
//            return 0;
//        }
//    }
//    
//    public static int prestacionSeleccionada(HttpServletRequest request){
//        if(request.getParameter("prestacion") != null){
//            return Integer.parseInt(request.getParameter("prestacion"));
//        }else{
//            return 0;
//        }
//    }
//    
//    public static ArrayList<Prestacion> obtenerPrestaciones(HttpServletRequest request){
//        int idTipoPrestacion = tipoPrestacionSeleccionada(request);
//        if(idTipoPrestacion != 0){//si hay tipo de prestación seleccionada
//            return obtenerPrestaciones(idTipoPrestacion);
//        }else{//si no hay tipo de prestación seleccionada
//            return null;
//        }
//    }
//    
//    
//    
//    public static ArrayList<Personal> obtenerPersonal(HttpServletRequest request){
//        //si no hay prestacion seleccionada
//        int idPrestacionSeleccionada = prestacionSeleccionada(request);
//        if(idPrestacionSeleccionada == 0){
//            return null;
//        }
//        //Si hay prestacion seleccionada obtener prestacion
//        Prestacion prestacion = (Prestacion)Controller.findById(Prestacion.class, idPrestacionSeleccionada);
//        //buscar especialidad
//        Especialidad especialidad = prestacion.getIdEspecialidad();
//        //buscar todos los medicos de la especialidad
//        Collection<PersMedico> personalMedicoCollection = especialidad.getPersMedicoCollection();
//        ArrayList<Personal> personalList = new ArrayList<>();
//        for(PersMedico persMedico : personalMedicoCollection){
//            personalList.add(persMedico.getIdPersonal());
//        }
//        if(null == personalMedicoCollection){
//            return null;
//        }else{
//            return personalList;
//        }
//    }

    public static void cargarPrestaciones(HttpServletRequest request) {
        //si no se ha escogido tipo prestacion
        if(request.getAttribute("tipoPrestacion") == null){
            return;
        }
        //si ya se ha escogido un tipo de prestacion
        //parseamos el parámetro
        int idTipoPrestacion = (int)(request.getAttribute("tipoPrestacion"));
        //obtener prestaciones filtradas
        ArrayList<Prestacion> prestaciones = obtenerPrestaciones(idTipoPrestacion);
        request.setAttribute("prestaciones", prestaciones);
        if(request.getParameter("prestacion") != null){
            request.setAttribute("prestacion", Integer.parseInt(request.getParameter("prestacion")));
        }
        
    }
    
    public static void cargarPersonal(HttpServletRequest request){
        //aborto si no hay prestacion fija
        if(request.getAttribute("prestacion") == null){
            return;
        }
        //obtengo prestacion seleccionada
        int idPrestacionSeleccionada = Integer.parseInt(request.getParameter("prestacion"));
        Prestacion prestacion = (Prestacion)Controller.findById(Prestacion.class, idPrestacionSeleccionada);
        //buscar especialidad
        Especialidad especialidad = prestacion.getIdEspecialidad();
        //buscar todos los medicos de la especialidad
        Collection<PersMedico> personalMedicoCollection = especialidad.getPersMedicoCollection();
        ArrayList<Personal> personalList = new ArrayList<>();
        for(PersMedico persMedico : personalMedicoCollection){
            personalList.add(persMedico.getIdPersonal());
        }
        //agregarlo como atributo al request.
        request.setAttribute("medicos", personalList);
        if(request.getParameter("medico") != null){
            request.setAttribute("medico", Integer.parseInt(request.getParameter("medico")));
        }
    }
    public static void cargarHorasLibres(HttpServletRequest request){
        
    }
}
