/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.bl;

import cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.lib.dal.entities.ResAtencion;
import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Personal;
import cl.cheekibreeki.cmh.lib.dal.entities.Turno;
import java.util.ArrayList;
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
        Controller ctr = new Controller();
        Map<String, Object> params1 = new HashMap<>();
        params1.put("rut", paciente.getRut());
        List<? extends Object>  pacienteAux = ctr.findByQuery("Paciente.findByRut", params1);
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
        Controller ctr = new Controller();
        List<? extends Object>  atenciones = ctr.findByQuery("AtencionAgen.findByIdPaciente", params);
        ArrayList<ResAtencion> resAtencion = new ArrayList<>();
        for(Object  x : atenciones){
            Map<String, Object> paramsAux = new HashMap<>();
            AtencionAgen atencionAux = (AtencionAgen)x;
            paramsAux.put("idAtencionAgen", atencionAux);
            List<? extends Object>  resultado = ctr.findByQuery("ResAtencion.findByIdAtencionAgen", paramsAux);
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
    public HorasDisponibles HorasDisponibles(PersMedico medico, Date dia){
        HorasDisponibles horas = new HorasDisponibles();
        Turno turno =  (Turno)Controller.findById(PersMedico.class, medico.getIdTurno().getIdTurno());
        Map<String, Object> params = new HashMap<>();
        params.put("idPersonalMedico", medico.getIdPersonalMedico());
        Controller ctr = new Controller();
        List<? extends Object> atenciones = ctr.findByQuery("AtencionAgen.findByIdPersonalMedico", params);
        int turnos = (ConcatenarHora( turno.getNumhoraIni(), turno.getNumminuIni() )  - ConcatenarHora( turno.getNumhoraFin(), turno.getNumminuFin() ) )/30;
        
        for (int i = 0; i < turnos; i++) {
            boolean noDispo = true;
            ArrayList<AtencionAgen> atenAgen = (ArrayList<AtencionAgen>)atenciones;
            for (int j = 0; j < atenciones.size(); j++) {
                if ( ConcatenarHora( turno.getNumhoraIni(), turno.getNumminuIni() ) + turnos*30 == ConcatenarHora(atenAgen.get(j).getFechor().getHours(), atenAgen.get(j).getFechor().getMinutes()) )
                {
                    noDispo = false;
                }
            }
            if(noDispo)
                horas.getHoras().add(ConcatenarHora( turno.getNumhoraIni(), turno.getNumminuIni() ) + turnos*30);
        }
        
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
        Controller ctr = new Controller();
        List<? extends Object> pacientes = ctr.findByQuery("Paciente.findByRut", params1);
        if(pacientes.isEmpty()){
            return null;
        }
        Map<String, Object> params2 = new HashMap<>();
        params2.put("idPaciente", pacientes.get(0));
        ArrayList<AtencionAgen> atenciones = (ArrayList<AtencionAgen>)ctr.findByQuery("AtencionAgen.findByIdPaciente", params2);
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
        Controller ctr = new Controller();
        ArrayList<PersMedico> atenciones = new ArrayList<>();
        Map<String, Object> params1 = new HashMap<>();
        params1.put("idEspecialidad", prestacion.getIdEspecialidad());
        List<? extends Object> atencionesAux = ctr.findByQuery("PersMedico.findByIdEspecialidad", params1);
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
    public boolean anularAtencion(AtencionAgen atencion){
        //TODO: implementar
        return false;
    }
}
