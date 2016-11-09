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
    public HorasDisponibles horasDisponiblesMedico(PersMedico medico, Date dia) throws Exception{
       //Obtener todas las atenciones Vigentes del médico
       ArrayList<AtencionAgen> atencionesVigentes = buscarAtencionMedicoPorEstado(medico, "Vigente");
       //Obtener todas las atenciones para el día
       ArrayList<AtencionAgen> atencionesFiltradasPorDia = filtrarAtencionPorDia(atencionesVigentes, dia);
       //Obtener los bloques del medico para el día solicitado
       ArrayList<Bloque> bloquesDia = getBloquesMedico(medico, dia);
       //Remover bloques que tengan una atencion agendada
       ArrayList<Bloque> bloquesLibres = removerBloquesAgendados(bloquesDia, atencionesVigentes);
       //convertir bloque a hora disponible
       HorasDisponibles horas = new HorasDisponibles(dia, bloquesLibres);
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
    public boolean agendarAtencion(AtencionAgen atencion) throws Exception{
        //Revisar si el bloque de la atención está en las horas disponibles del médico
        //obtener médico
//        PersMedico medico = atencion.getIdPersAtiende();
        PersMedico medico = (PersMedico)Controller.findById(PersMedico.class, atencion.getIdPersAtiende().getIdPersonalMedico());
        //Obtener día
        Date date = atencion.getFechor();
        HorasDisponibles horasDisponibles = this.horasDisponiblesMedico(medico, date);
        //Si medico no tiene horas disponibles, excepcion
        if (horasDisponibles.getHoras().size() < 1){
            throw new Exception("El médico no tiene horas disponibles");
        }
        //si está en las horas disponibles, entonces ingresar
        if(horasDisponibles.bloqueDisponible(atencion.getIdBloque())){
            return Controller.upsert(atencion);    
        }else{//de lo contrario levantar excepción
            throw new Exception("Hora ocupada.");
        }
    }
    
    /**
     * Método que retorna las atenciones pendientes
     * @param rut rut del paciente
     * @return Un ArrayList con todas las atenciones que no tengan respuesta, si es null significa que no fue encontrado el paciente o que no existen atenciones pendientes
     */
    public ArrayList<AtencionAgen> obtenerAtencionesPendientes(int rut) throws Exception{
        Map<String, Object> params = new HashMap<>();
        params.put("rut", rut);
        List<? extends Object> pacienteList = Controller.findByQuery("Paciente.findByRut", params);
        if(null == pacienteList){
            throw new Exception("Paciente no existe");
        }
        Paciente paciente = (Paciente)pacienteList.get(0);
        Collection<AtencionAgen> atenciones = paciente.getAtencionAgenCollection();
        ArrayList<AtencionAgen> atencionesPendientes = new ArrayList<>();
        if(atenciones.isEmpty()) {
            return atencionesPendientes;
        }
        for(AtencionAgen atencion: atenciones){
            if(atencionTieneEstado(atencion, "Vigente") && atencionEsFutura(atencion)){
                atencionesPendientes.add(atencion);
            }
        }
        return atencionesPendientes;
    }
    
    private boolean atencionTieneEstado(AtencionAgen atencion, String nombreEstado){
        boolean result = false;
        result = atencion.getIdEstadoAten().getNomEstadoAten().equalsIgnoreCase(nombreEstado);
        return result;
    }
    
    private boolean atencionEsFutura(AtencionAgen atencion){
        Date fechaAtencion = atencion.getFechor();
        Date fechaHoy = new Date();
        return(fechaAtencion.after(fechaHoy));
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
    
    public DiaSem buscarDiaPorDate(Date date) throws Exception{
        Calendar cal = Calendar.getInstance();
        int numDia = cal.get(Calendar.DAY_OF_WEEK);
        String nomDiaBuscar = "";
        switch(numDia){
            case 1:
                nomDiaBuscar = "Domingo";
                break;
            case 2:
                nomDiaBuscar = "Lunes";
                break;
            case 3:
                nomDiaBuscar = "Martes";
                break;
            case 4:
                nomDiaBuscar = "Miercoles";
                break;
            case 5:
                nomDiaBuscar = "Jueves";
                break;
            case 6:
                nomDiaBuscar = "Viernes";
                break;
            case 7:
                nomDiaBuscar = "Sábado";
                break;
            default:
                throw new Exception("Dia invalido");
        }
        Map<String, Object> params = new HashMap<>();
        params.put("nombreDia", nomDiaBuscar);
        List<? extends Object>  diaSemList = Controller.findByQuery("DiaSem.findByNombreDia", params);
        if(diaSemList.size() < 1){
            throw new Exception("No hay dia con nombre " + nomDiaBuscar);
        }
        return (DiaSem)diaSemList.get(0);
    }
    
    private ArrayList<AtencionAgen> buscarAtencionMedicoPorEstado(PersMedico medico, String nombreEstado){
        Collection<AtencionAgen> atencionList = medico.getAtencionAgenCollection1();
        ArrayList<AtencionAgen> atencionesFiltradas = new ArrayList<>();
        for(AtencionAgen atencion : atencionList){
            if(atencion.getIdEstadoAten().getNomEstadoAten().equalsIgnoreCase(nombreEstado)){
                atencionesFiltradas.add(atencion);
            }
        }
        return atencionesFiltradas;
    }
    
    private ArrayList<AtencionAgen> filtrarAtencionPorDia(Collection<AtencionAgen> atenciones, Date dia){
        ArrayList<AtencionAgen> atencionesFiltradas = new ArrayList<>();
        for(AtencionAgen atencion : atenciones){
            Calendar cal1 = Calendar.getInstance();
            Calendar cal2 = Calendar.getInstance();
            cal1.setTime(atencion.getFechor());
            cal2.setTime(dia);
            boolean mismoDia = (cal1.get(Calendar.YEAR) == cal2.get(Calendar.YEAR)
                    && cal1.get(Calendar.DAY_OF_YEAR) == cal2.get(Calendar.DAY_OF_YEAR));
            if(mismoDia){
             atencionesFiltradas.add(atencion);    
            }
       }
       return atencionesFiltradas;
    }
    
    private ArrayList<Bloque> getBloquesMedico(PersMedico medico, Date date) throws Exception{
        ArrayList<Bloque> bloquesFiltrados = new ArrayList<>();
        Collection<Horario> horarios = medico.getHorarioCollection();
        DiaSem dia = buscarDiaPorDate(date);
        for(Horario horario : horarios){
            if(horario.getIdBloque().getIdDiaSem().getIdDia() == dia.getIdDia()){
                bloquesFiltrados.add(horario.getIdBloque());
            }
        }
        return bloquesFiltrados;
    }
    
    private ArrayList<Bloque> removerBloquesAgendados(ArrayList<Bloque> bloques, ArrayList<AtencionAgen> atenciones){
        ArrayList<Bloque> result = new ArrayList<>();
        outer:
        for(Bloque bloque : bloques){
            if(isBloqueInAtenciones(bloque, atenciones)){
                
            }else{
                result.add(bloque);
            }
        }
        return result;
    }
    
    private boolean isBloqueInAtenciones(Bloque bloque, ArrayList<AtencionAgen> atenciones){
        boolean result = false;
        for(AtencionAgen atencion : atenciones){
            if(bloque.getIdBloque() == atencion.getIdBloque().getIdBloque()){
                result = true;
            }
        }
        return result;
    }
}
