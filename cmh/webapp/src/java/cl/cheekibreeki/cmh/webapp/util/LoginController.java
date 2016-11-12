/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.servlet.http.HttpSession;

/**
 *
 * @author pdelasotta
 */
public class LoginController {
    public static Paciente obtenerPacienteEnSesion(HttpSession session){
        if(null != session){//Si la sesion no es nula
            //Obtener el paciente de la sesion
            Paciente paciente = (Paciente)session.getAttribute("paciente");
            return paciente;
        }else{//Si la sesion es nula
            return null;
        }
    }
    
    public static boolean login(HttpSession session, String email, String passTextoPlano) throws Exception{
        if(null != session){//Si la sesion no es nula
            //Hashear password
            String hashedPass = PassHasher.hashToMD5(passTextoPlano);
            //Obtener paciente DB
            Paciente paciente = getPacientePorEmail(email);
            if(null == paciente){//Paciente db: no existe
                return false;
            }
            if(!hashedPass.equals(paciente.getHashedPass())){//Pass: no coincide
                return false;
            }
            //Asignar variable de sesión
            session.setAttribute("paciente", paciente);
            //login exitoso
            return true;
        }else{//Si la sesion es nula
            return false;
        }
    }
    
    private static Paciente getPacientePorEmail(String email) throws Exception{
        Map<String, Object> params1 = new HashMap<>();
        params1.put("emailPaciente", email);
        List<? extends Object>  pacienteList = Controller.findByQuery("Paciente.findByEmailPaciente", params1);
        if(pacienteList.size() == 0){ // si no hay pacientes
            return null;
        }else if(pacienteList.size() > 1){//Si hay mas de un paciente con el mismo mail
            throw new Exception("Hay dos pacientes con el mismo mail.");
        }else{
            return (Paciente)pacienteList.get(0);
        }
    }
}
