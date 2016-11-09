/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.servpago;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.lib.dal.entities.CuenBancaria;
import cl.cheekibreeki.cmh.lib.dal.entities.Devolucion;
import cl.cheekibreeki.cmh.lib.dal.entities.Especialidad;
import cl.cheekibreeki.cmh.lib.dal.entities.Logpagohonorario;
import cl.cheekibreeki.cmh.lib.dal.entities.Pago;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Personal;
import com.sun.webkit.Timer;
import java.time.Instant;
import java.time.Year;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 *
 * @author pdelasotta
 */
public class ServPago {

    private static final float descuento = 0.4f;

    //Tiene que sacar todas las atenciones realizadas con sus respectivos pagos de el mes (Solo de los medicos) sumarlo y el total restarle un 40%
    public boolean pagarMedicos() throws Exception {
        //Se obtiene una lista con la especialidad "Medico" de la cual solo se saca el primer registro [0]
        Especialidad especialidad = obtenerEspecialidadPorNombre("Medico");
        //Se obtiene una lista con el personal medico con la especialidad "Medico"
        ArrayList<PersMedico> medicos = obtenerPersonalMedicoPorEspecialidad(especialidad);
        try {
            for (PersMedico medico : medicos) {
                pagarMedico(medico);
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return false;
        }

        return true;
    }

    private boolean atencionDeEsteMes(AtencionAgen atencion) {
        Calendar cal1 = Calendar.getInstance();
        Calendar cal2 = Calendar.getInstance();
        cal1.setTime(atencion.getFechor());
        cal2.setTime(new Date());
        int yearAtencion = cal1.get(Calendar.YEAR);
        int yearActual = cal2.get(Calendar.YEAR);
        int monthAtencion = cal1.get(Calendar.MONTH);
        int montActual = cal2.get(Calendar.MONTH);
        boolean sameYear = yearAtencion == yearActual;
        boolean sameMonth = monthAtencion == montActual;
        return sameMonth && sameYear;
    }

    private Especialidad obtenerEspecialidadPorNombre(String nomEspecialidad) throws Exception {
        Map<String, Object> params = new HashMap<>();
        params.put("nomEspecialidad", nomEspecialidad);
        List<? extends Object> especialidadList = Controller.findByQuery("Especialidad.findByNomEspecialidad", params);
        //Levanta una excepción si no existe la especialidad
        if (especialidadList == null || especialidadList.isEmpty()) {
            throw new Exception("No hay especialidades");
        }
        Especialidad especialidad = (Especialidad) especialidadList.get(0);
        return especialidad;
    }

    private ArrayList<PersMedico> obtenerPersonalMedicoPorEspecialidad(Especialidad especialidad) throws Exception {
        Map<String, Object> params = new HashMap<>();
        params.put("idEspecialidad", especialidad);
        List<? extends Object> personalMedicos = Controller.findByQuery("PersMedico.findByIdEspecialidad", params);
        ArrayList<PersMedico> medicos = new ArrayList<>();
        for (Object x : personalMedicos) {
            medicos.add((PersMedico) x);
        }
        if (medicos.size() == 0) {
            throw new Exception("No hay médicos");
        }
        return medicos;
    }

    private boolean pagarMedico(PersMedico medico) throws Exception {
        //Obtener primera cuenta bancaria
        CuenBancaria cuenta = obtenerCuentaMedico(medico);
        //Obtener atenciones de este mes
        ArrayList<AtencionAgen> atencionesDelMes = obtenerAtencionesDelMes(medico);
        //Obtener pagos de atenciones no devueltas
        ArrayList<Pago> pagos = obtenerPagosNoDevueltos(atencionesDelMes);
        int honorarios = calcularHonorarios(medico, pagos);
        if(honorarios == 0){
            throw new Exception("Los honorarios no pueden ser 0");
        }
        try {
            //aqui deberia ir la llamada a la api del banco
            registrarPagoHonorarios(cuenta, honorarios);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    private CuenBancaria obtenerCuentaMedico(PersMedico medico) {
        ArrayList<CuenBancaria> cuentas =  new ArrayList<>(medico.getCuenBancariaCollection());
        CuenBancaria cuenta = cuentas.get(0);
        return cuenta;
    }

    private ArrayList<AtencionAgen> obtenerAtencionesDelMes(PersMedico medico) {
        ArrayList<AtencionAgen> atenciones = new ArrayList<>(medico.getAtencionAgenCollection1());
        ArrayList<AtencionAgen> atencionesDelMes = new ArrayList<>();
        for (AtencionAgen atencion : atenciones) {
            boolean isAtencionDeEsteMes = atencionDeEsteMes(atencion);
            if (isAtencionDeEsteMes) {
                atencionesDelMes.add(atencion);
            }
        }
        return atencionesDelMes;
    }

    private ArrayList<Pago> obtenerPagosNoDevueltos(ArrayList<AtencionAgen> atenciones) {
        ArrayList<Pago> pagosNoDevueltos = new ArrayList<>();
        for (AtencionAgen atencion : atenciones) {
            ArrayList<Pago> pagos = new ArrayList<>(atencion.getPagoCollection());
            for (Pago pago : pagos) {
                if (pagoNoDevuelto(pago)) {
                    pagosNoDevueltos.add(pago);
                }
            }
        }
        return pagosNoDevueltos;
    }

    private boolean pagoNoDevuelto(Pago pago) {
        Devolucion devolucion = pago.getIdDevolucion();
        boolean tieneDevolucion = (devolucion == null);
        return tieneDevolucion;
    }

    private int calcularHonorarios(PersMedico medico, ArrayList<Pago> pagos) {
        int sum = 0;
        for (Pago pago : pagos) {
            sum += pago.getMontoPago();
        }
        int total = sum - (int) (sum * this.descuento / 100);
        return total;
    }

    private void registrarPagoHonorarios(CuenBancaria cuenta, int total) {
        Logpagohonorario logpago = new Logpagohonorario();
        logpago.setFechor(new Date());
        logpago.setIdCuenBancaria(cuenta);
        logpago.setTotal(total);
        Controller.upsert(logpago);
    }
}
