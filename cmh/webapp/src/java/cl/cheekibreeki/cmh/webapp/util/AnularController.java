/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import cl.cheekibreeki.cmh.webapp.bl.AccionesPaciente;
import java.util.ArrayList;

/**
 *
 * @author dev
 */
public class AnularController {
    
    public static ArrayList<AtencionAgen> atencionesPaciente(Paciente paciente){
        AccionesPaciente accionesPaciente = new AccionesPaciente();
        return accionesPaciente.obtenerAtencionesPendientes(paciente.getRut());
    }
    
}
