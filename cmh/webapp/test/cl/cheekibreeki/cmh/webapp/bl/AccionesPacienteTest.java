package cl.cheekibreeki.cmh.webapp.bl;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Archivo;
import cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.lib.dal.entities.EstadoAten;
import cl.cheekibreeki.cmh.lib.dal.entities.OrdenAnalisis;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import cl.cheekibreeki.cmh.lib.dal.entities.Pago;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.lib.dal.entities.ResAtencion;
import java.time.Instant;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author palan
 */
public class AccionesPacienteTest {
    
     Paciente paciente = null;
    
    public AccionesPacienteTest() {
        paciente = new Paciente();
        paciente.setNombresPaciente("Tomas");
        paciente.setApellidosPaciente("Muniz Quiroz");
        paciente.setRut(18766322);
        paciente.setDigitoVerificador('1');
        paciente.setHashedPass("holamundo");
        paciente.setEmailPaciente("tomasmuniz@peladordenaranjas.com");
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of registrarPaciente method, of class AccionesPaciente.
     */
    @Test
    public void testRegistrarPaciente() {
        System.out.println("registrarPaciente");
        AccionesPaciente instance = new AccionesPaciente();
        
        //Prueba 1: Ingresa paciente
        boolean expResult = true;
        boolean result = instance.registrarPaciente(this.paciente);
        assertEquals(expResult, result);
        
        //Prueba 2: Ingresa paciente vacio
        Paciente paciente2 = new Paciente();
        expResult = false;
        result = instance.registrarPaciente(paciente2);
        assertEquals(expResult, result);
        
        //Prueba 3: ingresa el mismo paciente que en el test 1, se ingresa como otro paciente
        expResult = true;
        result = instance.registrarPaciente(this.paciente);
        assertEquals(expResult, result);
        
        // FIN
         System.out.println("registro exitoso");
    }

    /**
     * Test of obtenerExamenes method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerExamenes() {
         System.out.println("obtenerExamenes");
         AccionesPaciente instance = new AccionesPaciente();
 
         AtencionAgen atencion = new AtencionAgen();
         ResAtencion resAtencion = new ResAtencion();
         
         //Prueba 1: Si no hay examenes asociados
         InsertAtencionesYExamenes(atencion, resAtencion, true);
         ArrayList<ResAtencion> result = instance.obtenerExamenes(this.paciente);
         if(result.isEmpty()){
             System.out.println("El paciente no tiene examenes asociados");
         }else{
             fail("Examenes obtenidos");
         }
         
         //Prueba 2: Si hay examenes asociados
         InsertAtencionesYExamenes(atencion, resAtencion, false);
         result = instance.obtenerExamenes(this.paciente);
         if(result.isEmpty()){
             fail("El paciente no tiene examenes asociados");
         }else{
             System.out.println("Examenes obtenidos");
         }
    }
    
    public void InsertAtencionesYExamenes(AtencionAgen atencion,ResAtencion resAtencion, boolean delete){
        Controller ctr = new Controller();
        if(!delete){
            Map<String, Object> params = new HashMap<>();
            params.put("rut", this.paciente.getRut());
            Paciente pacienteAux = (Paciente)ctr.findByQuery("Paciente.findByRut", params).get(0);
            atencion.setFechor(Date.from(Instant.now()));
            atencion.setIdEstadoAten(new EstadoAten());
            atencion.setIdPaciente(pacienteAux);
            atencion.setIdPago(new Pago());
            atencion.setIdPersonalMedico(new PersMedico());
            atencion.setIdPrestacion(new Prestacion());
            atencion.setObservaciones("test");
            Object obj1 = atencion;
            boolean x = Controller.upsert(obj1);
            assertEquals(true, x);
            
            params = new HashMap<>();
            params.put("idPaciente", pacienteAux.getIdPaciente());
            AtencionAgen atencionAux = (AtencionAgen)ctr.findByQuery("AtencionAgen.findByIdPaciente", params).get(0);//error
            resAtencion.setAtencionAbierta((short)0);
            resAtencion.setComentario("test");
            resAtencion.setIdAtencionAgen(atencionAux);
            resAtencion.setIdOrdenAnalisis(new OrdenAnalisis());
            resAtencion.setIdPersonalMedico(new PersMedico());
            resAtencion.setIdResultadoAtencion(0);
            Object obj2 = resAtencion;
            boolean y = Controller.upsert(obj2);   
            assertEquals(true, y);
            
        }else{
            Map<String, Object> params = new HashMap<>();
            params.put("rut", paciente.getRut());
            Paciente pacienteAux = (Paciente)ctr.findByQuery("Paciente.findByRut", params).get(0);
            if(pacienteAux == null)
                return;
            
             params = new HashMap<>();
            params.put("idPaciente", pacienteAux.getIdPaciente());
            AtencionAgen atencionAux = (AtencionAgen)ctr.findByQuery("AtencionAgen.findByIdPaciente", params);
            if(atencionAux == null)
                return;
            else
                Controller.remove(AtencionAgen.class, atencionAux.getIdAtencionAgen());
            
            params = new HashMap<>();
            params.put("idAtencionAgen", atencionAux.getIdAtencionAgen());
            ResAtencion resAtencionAux = (ResAtencion)ctr.findByQuery("ResAtencion.findByIdAtencionAgen", params);
            if(resAtencionAux != null)
                Controller.remove(ResAtencion.class, resAtencionAux.getIdResultadoAtencion());          
        }  
    }

    /**
     * Test of obtenerAtenciones method, of class AccionesPaciente.
     */
    @Test
    public void testHorasDisponibles() {
    }

    /**
     * Test of obtenerAtenciones method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerAtenciones_Date_PersMedico() {
    }

    /**
     * Test of agendarAtencion method, of class AccionesPaciente.
     */
    @Test
    public void testAgendarAtencion() {
    }

    /**
     * Test of obtenerAtencionesPendientes method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerAtencionesPendientes() {
    }

    /**
     * Test of anularAtencion method, of class AccionesPaciente.
     */
    @Test
    public void testAnularAtencion() {
    }
    
}
