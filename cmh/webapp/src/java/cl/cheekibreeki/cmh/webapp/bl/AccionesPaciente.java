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
         Object obj = paciente;
         boolean result = Controller.upsert(obj);
         return result;
    }
    
     /**
     * Método que entrega los examenes de un paciente
     * @param paciente El paciente a quien pertenecen los examenes.
     * @return Un ArrayList con todos los examenes del paciente, si esta vacio no hay examenes asociados.
     */
    public ArrayList<ResAtencion> obtenerExamenes(Paciente paciente){
        Map<String, Object> params = new HashMap<>();
        params.put("idPaciente", paciente.getIdPaciente());
        Controller ctr = new Controller();
        List<? extends Object>  atencion = ctr.findByQuery("AtencionAgen.findByIdPaciente", params);
        ArrayList<ResAtencion> resAtencion = new ArrayList<>();
        for(Object  x : atencion){
            Map<String, Object> paramsAux = new HashMap<>();
            AtencionAgen atencionAux = (AtencionAgen)x;
            paramsAux.put("idAtencionAgen", atencionAux.getIdAtencionAgen());
            List<? extends Object>  resultado = ctr.findByQuery("ResAtencion.findByIdAtencionAgen", paramsAux);
            for(Object  y : resultado){
                resAtencion.add((ResAtencion)y);
            }
        }
        return resAtencion;
    }
    
     /**
     * Método que devuelve un ArrayList con las horas libres 
     * @param prestacion Prestacion de la cual se quiere saber las horas disponibles
     * @param dia Dia de la atencion que se quiere tomar
     * @return El ArrayList contiene tas atenciones de una prestación
     */
    public ArrayList<AtencionAgen> obtenerHorasLibresParaPrestacion(Prestacion prestacion, Date dia){
        //TODO: implementar
        return null;
    }
    
     /**
     * Método que devuelve un ArrayList con las horas libres 
     * @param medico El medico
     * @param dia dia el cual se quiere tomar hora
     * @return El ArrayList contiene tas atenciones de una prestación
     */
    public HorasDisponibles obtenerHorasLibresPorMedico(PersMedico medico, Date dia){
       HorasDisponibles horas = new HorasDisponibles();
        Turno turno =  (Turno)Controller.findById(PersMedico.class, medico.getIdTurno().getIdTurno());
        Map<String, Object> params = new HashMap<>();
        params.put("idPersonalMedico", medico.getIdPersonalMedico());
        Controller ctr = new Controller();
        List<? extends Object> atenciones = ctr.findByQuery("AtencionAgen.findByIdPersonalMedico", params);
        int turnos = ((turno.getNumhoraIni()*100)+turno.getNumminuIni()) - ((turno.getNumhoraFin()*100)+turno.getNumminuFin())/30;
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
    
    private int ConcatenarHora(int hora, int minuto){
        int x = hora*100 + minuto;
        return x;
    }
    
    public ArrayList<HorasDisponibles> obtenerHorasLibresPorDia(ArrayList<AtencionAgen> atenciones, Date dia){
        //TODO todo
       return null;
    }
    
    public boolean agendarAtencion(AtencionAgen atencion){
        //TODO: implementar
        return false;
    }
    
    public ArrayList<AtencionAgen> obtenerAtencionesPendientes(String rut){
        //TODO: implementar
        return null;
    }
    
    public boolean anularAtencion(AtencionAgen atencion){
        //TODO: implementar
        return false;
    }
}
