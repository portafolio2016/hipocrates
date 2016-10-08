/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.bl;

import cl.cheekibreeki.cmh.webapp.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.webapp.dal.entities.Paciente;
import cl.cheekibreeki.cmh.webapp.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.webapp.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.webapp.dal.entities.ResAtencion;
import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author pdelasotta
 */
public class AccionesPaciente {
    public boolean registrarPaciente(Paciente){
        
    }
    
    public ArrayList<ResAtencion> obtenerExamenes(String rutPaciente){
        
    }
    
    public ArrayList<AtencionAgen> obtenerAtenciones(Date dia, Prestacion prestacion){
        
    }
    
    public ArrayList<AtencionAgen> obtenerAtenciones(PersMedico medico){
        
    }
    
    
}
