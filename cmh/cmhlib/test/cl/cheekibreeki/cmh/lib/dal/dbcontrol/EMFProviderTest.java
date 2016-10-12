/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.dbcontrol;

import javax.persistence.EntityManagerFactory;
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
public class EMFProviderTest {
    
    public EMFProviderTest() {
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
     * Test of getEMF method, of class EMFProvider.
     */
    @Test
    public void testGetEMF() {
        System.out.println("getEMF");
        EntityManagerFactory result = EMFProvider.getEMF();
        if(result == null){
            fail("The test case is a prototype.");
        }else{
            System.out.println("pass");
        }
        
    }
    
}
