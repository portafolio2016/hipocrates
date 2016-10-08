/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.dbcontrol;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author pdelasotta
 */
public class EMFProvider {
    private static EntityManagerFactory emf = null;
    static{
        emf = Persistence.createEntityManagerFactory("webapplibPU");
    }
    
    public static EntityManagerFactory getEMF(){
        return emf;
    }
}
