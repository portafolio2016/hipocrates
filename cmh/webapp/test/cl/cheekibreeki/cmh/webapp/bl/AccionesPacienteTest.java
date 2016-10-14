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
    
    public AccionesPacienteTest() {
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
        Paciente paciente = null;
        AccionesPaciente instance = new AccionesPaciente();
        boolean expResult = false;
        boolean result = instance.registrarPaciente(paciente);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of obtenerExamenes method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerExamenes() {
        System.out.println("obtenerExamenes");
        Paciente paciente = null;
        AccionesPaciente instance = new AccionesPaciente();
        ArrayList<ResAtencion> expResult = null;
        ArrayList<ResAtencion> result = instance.obtenerExamenes(paciente);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of obtenerAtenciones method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerAtenciones_Date_Prestacion() {
        System.out.println("obtenerAtenciones");
        Date dia = null;
        Prestacion prestacion = null;
        AccionesPaciente instance = new AccionesPaciente();
        ArrayList<AtencionAgen> expResult = null;
        ArrayList<AtencionAgen> result = instance.obtenerAtenciones(dia, prestacion);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of obtenerAtenciones method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerAtenciones_Date_PersMedico() {
        System.out.println("obtenerAtenciones");
        Date dia = null;
        PersMedico medico = null;
        AccionesPaciente instance = new AccionesPaciente();
        ArrayList<AtencionAgen> expResult = null;
        ArrayList<AtencionAgen> result = instance.obtenerAtenciones(dia, medico);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of agendarAtencion method, of class AccionesPaciente.
     */
    @Test
    public void testAgendarAtencion() {
        System.out.println("agendarAtencion");
        AtencionAgen atencion = null;
        AccionesPaciente instance = new AccionesPaciente();
        boolean expResult = false;
        boolean result = instance.agendarAtencion(atencion);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of obtenerAtencionesPendientes method, of class AccionesPaciente.
     */
    @Test
    public void testObtenerAtencionesPendientes() {
        System.out.println("obtenerAtencionesPendientes");
        String rut = "";
        AccionesPaciente instance = new AccionesPaciente();
        ArrayList<AtencionAgen> expResult = null;
        ArrayList<AtencionAgen> result = instance.obtenerAtencionesPendientes(rut);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of anularAtencion method, of class AccionesPaciente.
     */
    @Test
    public void testAnularAtencion() {
        System.out.println("anularAtencion");
        AtencionAgen atencion = null;
        AccionesPaciente instance = new AccionesPaciente();
        boolean expResult = false;
        boolean result = instance.anularAtencion(atencion);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
    
}
