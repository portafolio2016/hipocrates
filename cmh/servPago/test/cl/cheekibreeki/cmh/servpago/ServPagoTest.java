package cl.cheekibreeki.cmh.servpago;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.lib.dal.entities.Banco;
import cl.cheekibreeki.cmh.lib.dal.entities.Bloque;
import cl.cheekibreeki.cmh.lib.dal.entities.CuenBancaria;
import cl.cheekibreeki.cmh.lib.dal.entities.DiaSem;
import cl.cheekibreeki.cmh.lib.dal.entities.Especialidad;
import cl.cheekibreeki.cmh.lib.dal.entities.EstadoAten;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import cl.cheekibreeki.cmh.lib.dal.entities.Pago;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Personal;
import cl.cheekibreeki.cmh.lib.dal.entities.TipoCBancaria;
import java.time.Instant;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
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
    public void testPagarMedicos() throws Exception {
        System.out.println("pagarMedicos");
        init();
        ServPago instance = new ServPago();
        boolean expResult = true;
        boolean result = instance.pagarMedicos();
        assertEquals(expResult, result);
    }
    
    private void init(){
        //Agregar Banco
        Banco banco = new Banco();
        banco.setNombre("Banco Estado");
        Controller.upsert(banco);
        List<? extends Object> aux = Controller.findByQuery("Banco.findAll", new HashMap<>());
        banco = (Banco)aux.get(aux.size()-1);
        //Agregar Tipo Cuenta
        TipoCBancaria  tipocuenta = new TipoCBancaria();
        tipocuenta.setNomCBancaria("Vista");
        Controller.upsert(tipocuenta);
        aux = Controller.findByQuery("TipoCBancaria.findAll", new HashMap<>());
        tipocuenta = (TipoCBancaria)aux.get(aux.size()-1);
        
        
        
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //Agregar Personal
        Personal personal1 = new Personal();
        personal1.setNombres("Tomas");
        personal1.setApellidos("Muniz Quiroz");
        personal1.setEmail("thomasmq@gmail.com");
        personal1.setRut(18766322);
        personal1.setVerificador('1');
        boolean x = Controller.upsert(personal1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Personal.findAll", new HashMap<>());
        personal1 = (Personal)aux.get(aux.size()-1);
        //Agregar Especialidad
        Especialidad especialidad1 = new Especialidad();
        especialidad1.setNomEspecialidad("Medico");
        x = Controller.upsert(especialidad1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Especialidad.findAll", new HashMap<>());
        especialidad1 = (Especialidad)aux.get(aux.size()-1);
        //Agregar PersMedico
        PersMedico persmedico1 = new PersMedico();
        persmedico1.setIdEspecialidad(especialidad1);
        persmedico1.setIdPersonal(personal1);
        x = Controller.upsert(persmedico1);
        assertEquals(true, x);
        aux = Controller.findByQuery("PersMedico.findAll", new HashMap<>());
        persmedico1 = (PersMedico)aux.get(aux.size()-1);
        // Agregar Cuenta
        CuenBancaria cuenta = new CuenBancaria();
        cuenta.setIdPersMedico(persmedico1);
        cuenta.setIdTipoCBancaria(tipocuenta);
        cuenta.setIdBanco(banco);
        cuenta.setNumCBancaria("1234564");
        x = Controller.upsert(cuenta);
        assertEquals(true, x);
        //Agregar Dia
        DiaSem diasem1 =new  DiaSem();
        diasem1.setNombreDia("Lunes");
        x = Controller.upsert(diasem1);
        assertEquals(true, x);
        aux = Controller.findByQuery("DiaSem.findAll", new HashMap<>());
        diasem1 = (DiaSem)aux.get(aux.size()-1);
        //Agregar Bloque
        Bloque bloque1 = new Bloque();
        bloque1.setIdDiaSem(diasem1);
        x = Controller.upsert(bloque1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Bloque.findAll", new HashMap<>());
        bloque1 = (Bloque)aux.get(aux.size()-1);
        //Agrega Paciente
        Paciente paciente1 = new Paciente();
        paciente1.setNombresPaciente("Tomas");
        paciente1.setApellidosPaciente("Muniz Quiroz");
        paciente1.setRut(18766322);
        paciente1.setDigitoVerificador('1');
        paciente1.setHashedPass("holamundo");
        paciente1.setEmailPaciente("tomasmuniz@peladordenaranjas.com");
        x = Controller.upsert(paciente1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Paciente.findAll", new HashMap<>());
        paciente1 = (Paciente)aux.get(aux.size()-1);
        //Agregar EstadoAtencion
        EstadoAten estadoaten1 = new EstadoAten();
        estadoaten1.setNomEstadoAten("Terminado");
        x = Controller.upsert(estadoaten1);
        assertEquals(true, x);
        aux = Controller.findByQuery("EstadoAten.findAll", new HashMap<>());
        estadoaten1 = (EstadoAten)aux.get(aux.size()-1);
        //Agregar Atencion
        AtencionAgen atencion1 = new AtencionAgen();
        Date date = new Date();
        atencion1.setFechor(date);
        atencion1.setIdBloque(bloque1);
        atencion1.setIdPersAtiende(persmedico1);
        atencion1.setIdPaciente(paciente1);
        atencion1.setIdEstadoAten(estadoaten1);
        x = Controller.upsert(atencion1);
        assertEquals(true, x);
        aux = Controller.findByQuery("AtencionAgen.findAll", new HashMap<>());
        atencion1 = (AtencionAgen)aux.get(aux.size()-1);
        //Agregar Pago
        Pago pago1 = new Pago();
        pago1.setFechor(date);
        pago1.setIdAtencionAgen(atencion1);
        pago1.setMontoPago(10000);
        x = Controller.upsert(pago1);
        assertEquals(true, x);
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Agregar Personal
        personal1 = new Personal();
        personal1.setNombres("Fabian");
        personal1.setApellidos("Jaque");
        personal1.setEmail("thomasmq@gmail.com");
        personal1.setRut(18766322);
        personal1.setVerificador('1');
        x = Controller.upsert(personal1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Personal.findAll", new HashMap<>());
        personal1 = (Personal)aux.get(aux.size()-1);
        //Agregar PersMedico
        persmedico1 = new PersMedico();
        persmedico1.setIdEspecialidad(especialidad1);
        persmedico1.setIdPersonal(personal1);
        x = Controller.upsert(persmedico1);
        assertEquals(true, x);
        aux = Controller.findByQuery("PersMedico.findAll", new HashMap<>());
        persmedico1 = (PersMedico)aux.get(aux.size()-1);
        // Agregar Cuenta
        cuenta = new CuenBancaria();
        cuenta.setIdPersMedico(persmedico1);
        cuenta.setIdBanco(banco);
        cuenta.setIdTipoCBancaria(tipocuenta);
        cuenta.setNumCBancaria("54321");
        x = Controller.upsert(cuenta);
        assertEquals(true, x);
        //Agregar Bloque
        bloque1 = new Bloque();
        bloque1.setIdDiaSem(diasem1);
        x = Controller.upsert(bloque1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Bloque.findAll", new HashMap<>());
        bloque1 = (Bloque)aux.get(aux.size()-1);
        //Agregar Atencion
        atencion1 = new AtencionAgen();
        date = new Date();
        atencion1.setFechor(date);
        atencion1.setIdBloque(bloque1);
        atencion1.setIdPersAtiende(persmedico1);
        atencion1.setIdPaciente(paciente1);
        atencion1.setIdEstadoAten(estadoaten1);
        x = Controller.upsert(atencion1);
        assertEquals(true, x);
        aux = Controller.findByQuery("AtencionAgen.findAll", new HashMap<>());
        atencion1 = (AtencionAgen)aux.get(aux.size()-1);
        //Agregar Pago
         pago1 = new Pago();
        pago1.setFechor(date);
        pago1.setIdAtencionAgen(atencion1);
        pago1.setMontoPago(10000);
        x = Controller.upsert(pago1);
        assertEquals(true, x);
        
        ////////////////////////////////////////////////////////////////////////////////////////////
        //Agregar Bloque
        bloque1 = new Bloque();
        bloque1.setIdDiaSem(diasem1);
        x = Controller.upsert(bloque1);
        assertEquals(true, x);
        aux = Controller.findByQuery("Bloque.findAll", new HashMap<>());
        bloque1 = (Bloque)aux.get(aux.size()-1);
        //Agregar Atencion
        atencion1 = new AtencionAgen();
        date = new Date();
        atencion1.setFechor(date);
        atencion1.setIdBloque(bloque1);
        atencion1.setIdPersAtiende(persmedico1);
        atencion1.setIdPaciente(paciente1);
        atencion1.setIdEstadoAten(estadoaten1);
        x = Controller.upsert(atencion1);
        assertEquals(true, x);
        aux = Controller.findByQuery("AtencionAgen.findAll", new HashMap<>());
        atencion1 = (AtencionAgen)aux.get(aux.size()-1);
        //Agregar Pago
        pago1 = new Pago();
        pago1.setFechor(date);
        pago1.setIdAtencionAgen(atencion1);
        pago1.setMontoPago(10000);

        x = Controller.upsert(pago1);
        assertEquals(true, x);
    }
    
}
