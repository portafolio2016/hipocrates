/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.dbcontrol;

import cl.cheekibreeki.cmh.webapp.dal.entities.Paciente;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author pdelasotta
 */
public class ControllerTest {
    Paciente paciente = null;
    public ControllerTest() {
        
        paciente = new Paciente();
        paciente.setNombresPaciente("Pablo");
        paciente.setApellidosPaciente("de la Sotta");
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
     * Test of merge method, of class Controller.
     */
    @Test
    public void testMerge() {
        System.out.println("merge");
        Object obj = this.paciente;
        boolean expResult = true;
        boolean result = Controller.merge(obj);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        System.out.println("merge exitoso");
    }

    /**
     * Test of findById method, of class Controller.
     */
    @Test
    public void testFindById() {
        System.out.println("findById");
        Class clazz = Paciente.class;
        Integer id = 2;
        String expResult = "Pablo";
        Object result = Controller.findById(clazz, id);
        Paciente paciente2 = (Paciente)result;
        assertEquals(expResult, paciente2.getNombresPaciente());
        // TODO review the generated test code and remove the default call to fail.
//        fail("The test case is a prototype.");
    }

}
