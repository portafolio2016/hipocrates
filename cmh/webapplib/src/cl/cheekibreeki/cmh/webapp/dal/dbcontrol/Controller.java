/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.dal.dbcontrol;

import javax.persistence.EntityManager;

/**
 *
 * @author pdelasotta
 */
public class Controller {
    public static boolean merge(Object obj){
        boolean success = false;
        EntityManager em = EMFProvider.getEMF().createEntityManager();
        try {
            em.getTransaction().begin();
            em.merge(obj);
            em.getTransaction().commit();
            success = true;
        } catch (Exception e) {
            em.getTransaction().rollback();
        }finally{
           em.close();
           return success;
        }
    }
    
    public static Object findById(Class clazz, Integer id){
        EntityManager em = EMFProvider.getEMF().createEntityManager();
        Object obj = null;
        try {
            obj = em.find(clazz, id);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }finally{
           em.close();
           return obj;
        }
    }
    
}
