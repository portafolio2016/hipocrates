/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.bl;


import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.EstadoAten;
import cl.cheekibreeki.cmh.lib.dal.entities.*;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.List;

/**
 *
 * @author pdelasotta
 */
public class AccionesPaciente {
     /**
     * Método que registra un paciente
     * @param paciente El paciente que se quiere registrar
     * @return Si es true el paciente fue registrado
     */
    public boolean registrarPaciente(Paciente paciente){
        Map<String, Object> params1 = new HashMap<>();
        params1.put("rut", paciente.getRut());
        List<? extends Object>  pacienteAux = Controller.findByQuery("Paciente.findByRut", params1);
        if(pacienteAux.isEmpty()){
            Object obj = paciente;
            boolean result = Controller.upsert(obj);
            return result;
        }else{
            return false;
        }
    }
    
     /**
     * Método que entrega los examenes de un paciente
     * @param paciente El paciente a quien pertenecen los examenes.
     * @return Un ArrayList con todos los examenes del paciente, si esta vacio no hay examenes asociados.
     */
    public ArrayList<ResAtencion> obtenerExamenes(Paciente paciente){
        Map<String, Object> params = new HashMap<>();
        params.put("idPaciente", paciente);
        List<? extends Object>  atenciones = Controller.findByQuery("AtencionAgen.findByIdPaciente", params);
        ArrayList<ResAtencion> resAtencion = new ArrayList<>();
        for(Object  x : atenciones){
            Map<String, Object> paramsAux = new HashMap<>();
            AtencionAgen atencionAux = (AtencionAgen)x;
            paramsAux.put("idAtencionAgen", atencionAux);
            List<? extends Object>  resultado = Controller.findByQuery("ResAtencion.findByIdAtencionAgen", paramsAux);
            for(Object  y : resultado){
                resAtencion.add((ResAtencion)y);
            }
        }
        return resAtencion;
    }
    
     /**
     * Método que devuelve un ArrayList con las horas libres 
     * @param medico El medico
     * @param dia dia el cual se quiere tomar hora
     * @return El ArrayList contiene tas atenciones de una prestación
     */
    public HorasDisponibles horasDisponibles(PersMedico medico, Date dia) throws Exception{
       HorasDisponibles horas = new HorasDisponibles();
       //Obtener todas las atenciones Vigentes del médico
       Map<String, Object> paramAtencion = new HashMap<>();
       paramAtencion.put("idPersAtiende", medico);
       List<? extends Object>  atencionList = Controller.findByQuery("AtencionAgen.findByIdPersonalMedico", paramAtencion);
       List<AtencionAgen> atencionesVigentes = new ArrayList<>();
       for(Object a : atencionList){
           AtencionAgen atencion = (AtencionAgen)a;
           if(atencion.getIdEstadoAten().getNomEstadoAten().equals("Vigente")){
               Calendar cal1 = Calendar.getInstance();
               Calendar cal2 = Calendar.getInstance();
               cal1.setTime(atencion.getFechor());
               cal2.setTime(dia);
               boolean mismoDia = (cal1.get(Calendar.YEAR) == cal2.get(Calendar.YEAR)
                       && cal1.get(Calendar.DAY_OF_YEAR) == cal2.get(Calendar.DAY_OF_YEAR));
               if(mismoDia){
                atencionesVigentes.add(atencion);    
               }
           }
       }
       //Obtener el horario del medico
       Collection<Horario> horarios = medico.getHorarioCollection();
       //Obtener lista de bloques
       ArrayList<Bloque> bloques = new ArrayList<>();
       for(Horario horario : horarios){
           bloques.add(horario.getIdBloque());
       }
       //Filtrar bloques por dia de la semana
       //No agregar bloques si hay una atencion en el mismo bloque
       DiaSem diaPorBuscar = buscarDiaPorDate(dia);
       ArrayList<Bloque> bloquesFiltrados = new ArrayList<>();
       for(Bloque bloque : bloques){
           if(bloque.getIdDiaSem().getNombreIda().equalsIgnoreCase(diaPorBuscar.getNombreIda())){
               for(AtencionAgen atencion : atencionesVigentes){
                   if(!(atencion.getIdBloque().getIdBloque() == bloque.getIdBloque())){
                       bloquesFiltrados.add(bloque);
                   }
               }
               
           }
       }
       //convertir bloque a hora disponible
       horas = new HorasDisponibles(dia, bloquesFiltrados);
       return horas;
    }
    
    /**
     * Método que concatena los dos parametros
     * @param hora La hora
     * @param minuto La minuto
     * @return Lods dos parametros concatenados
     */
    private int ConcatenarHora(int hora, int minuto){
        int x = hora*100 + minuto;
        return x;
    }
    
    
    /**
     * Método que agenda una atencion
     * @param atencion La atencion a registrar
     * @return Si es true la atencion fue registrada
     */
    public boolean agendarAtencion(AtencionAgen atencion){
        Object obj = atencion;
        boolean result = Controller.upsert(obj);
        return result;
    }
    
    /**
     * Método que retorna las atenciones pendientes
     * @param rut rut del paciente
     * @return Un ArrayList con todas las atenciones que no tengan respuesta, si es null significa que no fue encontrado el paciente o que no existen atenciones pendientes
     */
    public ArrayList<AtencionAgen> obtenerAtencionesPendientes(String rut){
        Map<String, Object> params1 = new HashMap<>();
        params1.put("rut", rut);
        List<? extends Object> pacientes = Controller.findByQuery("Paciente.findByRut", params1);
        if(pacientes.isEmpty()){
            return null;
        }
        Map<String, Object> params2 = new HashMap<>();
        params2.put("idPaciente", pacientes.get(0));
        ArrayList<AtencionAgen> atenciones = (ArrayList<AtencionAgen>)Controller.findByQuery("AtencionAgen.findByIdPaciente", params2);
        for (AtencionAgen x : atenciones) {
            if(!x.getResAtencionCollection().isEmpty()){
                atenciones.remove(x);
            }
        }
        return atenciones;
    }
    
     /** 
     * Método que develve todo el personal medico que realize la prestación
     * @param prestacion La prestacion
     * @return  un ArrayList de personal medico que realiza la prestacion
     */
    public ArrayList<PersMedico> obtenerMedicosPorPrestacion(Prestacion prestacion){
        ArrayList<PersMedico> atenciones = new ArrayList<>();
        Map<String, Object> params1 = new HashMap<>();
        params1.put("idEspecialidad", prestacion.getIdEspecialidad());
        List<? extends Object> atencionesAux = Controller.findByQuery("PersMedico.findByIdEspecialidad", params1);
        if(!atencionesAux.isEmpty()){
            for (Object x : atencionesAux) {
                atenciones.add((PersMedico)x);
            }
        }
        return atenciones;
    }
    
    /**
     * Método que anula una atencion agendada
     * @param atencion atencion agendada
     * @return  Si es true significa que se pudo anular la atencion
     */
    public AtencionAgen anularAtencion(AtencionAgen atencion) throws Exception{
        //Buscar estado actual de la atencion
        EstadoAten estadoAtencion = atencion.getIdEstadoAten();
        //si la atencion está anulada, lanzar excepción
        if(estadoAtencion.getNomEstadoAten().equals("Anulada")){
            throw new Exception("La atención ya está anulada");
        }
        //si la atención no está anulada, buscar estado anulada    
        Map<String, Object> params = new HashMap<>();
        params.put("nomEstadoAten", "Anulada");
        List<? extends Object>  estadoAtenList = Controller.findByQuery("EstadoAten.findByNomEstadoAten", params);
        if(estadoAtenList.size() < 1){
            throw new Exception("No hay estado con nombre Anulada");
        }
        EstadoAten estadoAnulada = (EstadoAten)estadoAtenList.get(0);
        //asignar estado anulada a atencion
        atencion.setIdEstadoAten(estadoAnulada);
        //upsert atencion
        Controller.upsert(atencion);
        //retornar atencion
        return atencion;
    }
    
    private DiaSem buscarDiaPorDate(Date date) throws Exception{
        Calendar cal = Calendar.getInstance();
        int numDia = cal.get(Calendar.DAY_OF_WEEK);
        String nomDiaBuscar = "";
        switch(numDia){
            case 0:
                nomDiaBuscar = "Domingo";
                break;
            case 1:
                nomDiaBuscar = "Lunes";
                break;
            case 2:
                nomDiaBuscar = "Martes";
                break;
            case 3:
                nomDiaBuscar = "Miercoles";
                break;
            case 4:
                nomDiaBuscar = "Jueves";
                break;
            case 5:
                nomDiaBuscar = "Viernes";
                break;
            case 6:
                nomDiaBuscar = "Sábado";
                break;
            default:
                throw new Exception("Dia invalido");
        }
        Map<String, Object> params = new HashMap<>();
        params.put("nombreIda", nomDiaBuscar);
        List<? extends Object>  diaSemList = Controller.findByQuery("DiaSem.findByNombreIda", params);
        if(diaSemList.size() < 1){
            throw new Exception("No hay dia con nombre " + nomDiaBuscar);
        }
        return (DiaSem)diaSemList.get(0);
    }
}
