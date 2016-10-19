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
        boolean result = Controller.upsert(paciente);
        return result;
    }
    
     /**
     * Método que entrega los examenes de un paciente
     * @param paciente El paciente a quien pertenecen los examenes
     * @return Un ArrayList con todos los examenes del paciente
     */
    public ArrayList<ResAtencion> obtenerExamenes(Paciente paciente){
        Map<String, Object> params = new HashMap<>();
        params.put("idPaciente", 1);
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
     * Método que devuelve un ArrayList con las prestaciones 
     * @param prestacion La prestacion 
     * @return Si es true el paciente fue registrado
     */
    public ArrayList<AtencionAgen> obtenerAtenciones(Prestacion prestacion){
        Map<String, Object> params = new HashMap<>();
        params.put("nombresPaciente", "Pablo");
        Controller ctr = new Controller();
        List<? extends Object>  atencion = ctr.findByQuery("AtencionAgen.findByIdPaciente", params);
        return (ArrayList<AtencionAgen> )atencion;
    }
    
    public ArrayList<AtencionAgen> obtenerAtencion(Date dia, Prestacion prestacion){
         //TODO: implementar
        return null;
    }
    
    public ArrayList<AtencionAgen> obtenerAtenciones(PersMedico medico){
        //TODO: implementar
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
