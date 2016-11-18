/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import javax.mail.internet.InternetAddress;

/**
 *
 * @author dev
 */
public class Validador {

    /**
     * *
     * Retorna si el rut es válido o no
     *
     * @param rut
     * @return
     */
    public static boolean validarRut(String rut) {
        boolean resultado = false;
        try {
            rut = rut.toUpperCase();
            rut = rut.replace(".", "");
            rut = rut.replace("-", "");
            int rutAux = Integer.parseInt(rut.substring(0, rut.length() - 1));
            char dv = rut.charAt(rut.length() - 1);
            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10) {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char) (s != 0 ? s + 47 : 75)) {
                resultado = true;
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return resultado;
    }

    /**
     * *
     * Retorna si el rut es válido o no
     *
     * @param rut
     * @param digitoVerificador
     * @return
     */
    public static boolean validarRut(String rut, char digitoVerificador) {
        boolean resultado = false;
        try {
            rut = rut + digitoVerificador;
            rut = rut.toUpperCase();
            rut = rut.replace(".", "");
            rut = rut.replace("-", "");
            int rutAux = Integer.parseInt(rut.substring(0, rut.length() - 1));
            char dv = rut.charAt(rut.length() - 1);
            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10) {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char) (s != 0 ? s + 47 : 75)) {
                resultado = true;
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return resultado;
    }

    public static boolean validarMail(String email) {
        boolean result = true;
        try {
            InternetAddress emailAddr = new InternetAddress(email);
            emailAddr.validate();
        } catch (Exception ex) {
            result = false;
        }
        return result;
    }

    public static boolean emailUnico(String email) throws Exception {
        Paciente paciente = LoginController.getPacientePorEmail(email);
        boolean emailEsUnico = null == paciente;
        return emailEsUnico;
    }


    /**
     * *
     *
     * @param fecha fecha a evaluar
     * @return Si es hoy, futura o no
     */
    public static boolean fechaFutura(Date fecha) {
        Date hoy = new Date();
        Calendar calendarParam = Calendar.getInstance();
        Calendar calendarHoy = Calendar.getInstance();
        calendarParam.setTime(fecha);
        calendarHoy.setTime(hoy);
        
        if(calendarHoy.get(Calendar.YEAR)< calendarParam.get(Calendar.YEAR)){
            return true;
        }else if(calendarHoy.get(Calendar.YEAR) == calendarParam.get(Calendar.YEAR)){
            if(calendarHoy.get(Calendar.DAY_OF_YEAR) < calendarParam.get(Calendar.DAY_OF_YEAR)){
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }
    
    public static boolean mismoDia(Date fecha) {
        Date hoy = new Date();
        Calendar calendarParam = Calendar.getInstance();
        Calendar calendarHoy = Calendar.getInstance();
        calendarParam.setTime(fecha);
        calendarHoy.setTime(hoy);
        
        return ((calendarHoy.get(Calendar.YEAR) == calendarParam.get(Calendar.YEAR) 
                && (calendarHoy.get(Calendar.DAY_OF_YEAR) == calendarParam.get(Calendar.DAY_OF_YEAR))));
    }
    
    

    /**
     * *
     * Retorna si es rut único en la base de datos o no
     *
     * @param rut
     * @return si el rut es único o no
     */
    public static boolean rutUnico(int rut) {
        Map<String, Object> params1 = new HashMap<>();
        params1.put("rut", rut);
        List<? extends Object> pacienteAux = Controller.findByQuery("Paciente.findByRut", params1);
        return pacienteAux.isEmpty();
    }

}
