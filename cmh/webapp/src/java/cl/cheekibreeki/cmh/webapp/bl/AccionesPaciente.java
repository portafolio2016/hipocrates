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
import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author pdelasotta
 */
public class AccionesPaciente {
    public boolean registrarPaciente(Paciente paciente){
        //TODO: implementar
        return false;
    }
    
    public ArrayList<ResAtencion> obtenerExamenes(Paciente paciente){
        //TODO: implementar
        return null;
    }
    
    public ArrayList<AtencionAgen> obtenerAtenciones(Date dia, Prestacion prestacion){
        //TODO: implementar
        return null;
    }
    
    public ArrayList<AtencionAgen> obtenerAtenciones(Date dia, PersMedico medico){
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
