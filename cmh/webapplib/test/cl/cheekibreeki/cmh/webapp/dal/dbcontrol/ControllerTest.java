/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.dbcontrol;

import cl.cheekibreeki.cmh.webapp.dal.entities.Paciente;
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
     * Test of upsert method, of class Controller.
     */
    @Test
    public void testUpsert() {
        System.out.println("upsert");
        Object obj = this.paciente;
        boolean expResult = true;
        boolean result = Controller.upsert(obj);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        System.out.println("upsert exitoso");
    }

    /**
     * Test of findById method, of class Controller.
     */
    @Test
    public void testFindById() {
        System.out.println("findById");
        Class clazz = Paciente.class;
        Integer id = 1;
        String expResult = "Pablo";
        Object result = Controller.findById(clazz, id);
        Paciente paciente2 = (Paciente)result;
        if(result == null){
            fail("Retorno null");
        }
        if(paciente2.getNombresPaciente().equals(expResult)){
            
        }else{
            System.out.println(paciente2.getNombresPaciente());
            fail("Nombres no calzan");
        }
        
    }



    /**
     * Test of remove method, of class Controller.
     */
    @Test
    public void testRemove() {
        System.out.println("remove");
        Class clazz = null;
        Integer id = null;
        Controller.remove(clazz, id);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of findByQuery method, of class Controller.
     */
    @Test
    public void testFindByQuery() {
        System.out.println("findByQuery");
        String query = "Paciente.findAll";
        Map<String, Object> params = null;
        Controller instance = new Controller();
//        List<? extends Object> expResult = null;
        List<? extends Object> result = instance.findByQuery(query, params);
        if(result.size() > 0){
            System.out.println(result.toString());
        }else{
            fail("findByQuery All no retornó nada");
        }
        String query2 = "Paciente.findByNombresPaciente";
        Map<String, Object> params2 = new HashMap<>();
        params2.put("nombresPaciente", "Pablo");
        Controller instance2 = new Controller();
        List<? extends Object> result2 = instance2.findByQuery(query2, params2);
        if(result2.size() > 0){
            System.out.println(result2.toString());
        }else{
            fail("findByQuery.findByNombresPaciente no retornó nada");
        }
    }

}
