package cl.cheekibreeki.cmh.servpago;

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
public class ServPagoTest {
    
    public ServPagoTest() {
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
     * Test of pagarMedicos method, of class ServPago.
     */
    @Test
    public void testPagarMedicos() {
        System.out.println("pagarMedicos");
        ServPago instance = new ServPago();
        boolean expResult = false;
        boolean result = instance.pagarMedicos("Oculista");
        assertEquals(expResult, result);
    }
    
}
