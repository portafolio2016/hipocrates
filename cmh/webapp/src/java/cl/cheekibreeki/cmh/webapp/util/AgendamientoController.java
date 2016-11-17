/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.*;
import cl.cheekibreeki.cmh.webapp.bl.AccionesPaciente;
import cl.cheekibreeki.cmh.webapp.bl.HorasDisponibles;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
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
        for (Object obj : result) {
            TipoPres tipoPrestacion = (TipoPres) obj;
            tiposPrestacion.add(tipoPrestacion);
        }
        request.setAttribute("tiposPrestacion", tiposPrestacion);
        if (request.getParameter(nomParam) != null) {
            request.setAttribute(nomParam, Integer.parseInt(request.getParameter(nomParam)));
        }
    }

    private static ArrayList<Prestacion> obtenerPrestaciones() {
        Map<String, Object> params = new HashMap<String, Object>();
        List<? extends Object> result = Controller.findByQuery("Prestacion.findAll", params);
        ArrayList<Prestacion> prestaciones = new ArrayList<>();
        for (Object obj : result) {
            Prestacion prestacion = (Prestacion) obj;
            prestaciones.add(prestacion);
        }
        return prestaciones;
    }

    private static ArrayList<Prestacion> obtenerPrestaciones(int idTipoPrestacion) {
        ArrayList<Prestacion> prestaciones = obtenerPrestaciones();
        ArrayList<Prestacion> prestacionesFiltradas = new ArrayList<Prestacion>();
        for (Prestacion prestacion : prestaciones) {
            if (prestacion.getIdTipoPrestacion().getIdTipoPrestacion() == idTipoPrestacion) {
                prestacionesFiltradas.add(prestacion);
            }
        }
        return prestacionesFiltradas;
    }

    public static void cargarPrestaciones(HttpServletRequest request) {
        //si no se ha escogido tipo prestacion
        if (request.getAttribute("tipoPrestacion") == null) {
            return;
        }
        //si ya se ha escogido un tipo de prestacion
        //parseamos el parámetro
        int idTipoPrestacion = (int) (request.getAttribute("tipoPrestacion"));
        //obtener prestaciones filtradas
        ArrayList<Prestacion> prestaciones = obtenerPrestaciones(idTipoPrestacion);
        request.setAttribute("prestaciones", prestaciones);
        if (request.getParameter("prestacion") != null) {
            request.setAttribute("prestacion", Integer.parseInt(request.getParameter("prestacion")));
        }

    }

    public static void cargarPersonal(HttpServletRequest request) {
        //aborto si no hay prestacion fija
        if (request.getAttribute("prestacion") == null) {
            return;
        }
        //obtengo prestacion seleccionada
        int idPrestacionSeleccionada = Integer.parseInt(request.getParameter("prestacion"));
        Prestacion prestacion = (Prestacion) Controller.findById(Prestacion.class, idPrestacionSeleccionada);
        //buscar especialidad
        Especialidad especialidad = prestacion.getIdEspecialidad();
        //buscar todos los medicos de la especialidad
        Collection<PersMedico> personalMedicoCollection = especialidad.getPersMedicoCollection();
        ArrayList<Personal> personalList = new ArrayList<>();
        for (PersMedico persMedico : personalMedicoCollection) {
            personalList.add(persMedico.getIdPersonal());
        }
        //agregarlo como atributo al request.
        request.setAttribute("medicos", personalList);
        if (request.getParameter("medico") != null) {
            request.setAttribute("medico", Integer.parseInt(request.getParameter("medico")));
        }
    }

    public static void cargarHorasLibres(HttpServletRequest request) {
        if (request.getParameter("fecha") == null) {
            return;
        }
        String fecString = request.getParameter("fecha");
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
        try {
            Date fecha = format.parse(fecString);
            //valido la fecha
            boolean fechaValida = Validador.fechaFutura(fecha);
            if (fechaValida) {
                Calendar cal = Calendar.getInstance();
                cal.setTime(fecha);
                int year = cal.get(Calendar.YEAR);
                int month = cal.get(Calendar.MONTH);
                int day = cal.get(Calendar.DAY_OF_MONTH);
                request.setAttribute("fecha", year + "-" + (month + 1) + "-" + day);
                //Obtener las horas libres del médico
                AccionesPaciente accionesPaciente = new AccionesPaciente();
                int idPersonal = (int) request.getAttribute("medico");
                Personal personal = (Personal) Controller.findById(Personal.class, idPersonal);
                Collection<PersMedico> personalMedicoCollection = personal.getPersMedicoCollection();
                PersMedico medico = null;
                for (PersMedico persMedico : personalMedicoCollection) {
                    medico = persMedico;
                }
                HorasDisponibles horasDisponibles = accionesPaciente.horasDisponiblesMedico(medico, fecha);
                request.setAttribute("horas", horasDisponibles);
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public static void registrarAtencion(HttpServletRequest request) throws Exception {
        AtencionAgen atencion = new AtencionAgen();
        Paciente paciente = LoginController.obtenerPacienteEnSesion(request.getSession());
        Calendar calendar = Calendar.getInstance();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        Date fechor = sdf.parse((String)request.getAttribute("fecha"));
        atencion.setFechor(fechor);
        int idBloque = Integer.parseInt((String)request.getAttribute("hora"));
        Bloque bloque = (Bloque)Controller.findById(Bloque.class, idBloque);
        atencion.setIdBloque(bloque);
        
        Map<String, Object> paramsEstadoAten = new HashMap<String, Object>();
        paramsEstadoAten.put("nomEstadoAten", "Vigente");
        List<? extends Object> resultEstado = Controller.findByQuery("EstadoAten.findByNomEstadoAten", paramsEstadoAten);
        EstadoAten estadoAten = (EstadoAten)resultEstado.get(0);
        atencion.setIdEstadoAten(estadoAten);
        
        Personal personal = (Personal)Controller.findById(Personal.class, Integer.parseInt((String)request.getAttribute("medico")));
        Collection<PersMedico> personalMedicoCollection = personal.getPersMedicoCollection();
        for(PersMedico persMedico: personalMedicoCollection){
            atencion.setIdPersAtiende(persMedico);
        }
        
        Prestacion prestacion = (Prestacion)Controller.findById(Prestacion.class, Integer.parseInt((String)request.getAttribute("prestacion")));

        atencion.setIdPrestacion(prestacion);
        atencion.setIdPaciente(paciente);

        AccionesPaciente accionesPaciente = new AccionesPaciente();
        accionesPaciente.agendarAtencion(atencion);
    }
}
