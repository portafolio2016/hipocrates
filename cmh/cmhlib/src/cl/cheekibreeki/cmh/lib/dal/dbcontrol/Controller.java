/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.lib.dal.dbcontrol;
import java.util.List;
import java.util.Map;
import javax.persistence.EntityManager;
import javax.persistence.Query;

/**
 *
 * @author pdelasotta
 */
public class Controller {
    public static boolean upsert(Object obj){
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
    
    public static boolean remove(Class clazz, Integer id){
        EntityManager em = EMFProvider.getEMF().createEntityManager();
        boolean returnVal = false;
        try {
            em.getTransaction().begin();
            Object o = em.find(clazz, id);
            em.remove(o);
            em.getTransaction().commit();
            returnVal = true;
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }finally{
           em.close();
           return returnVal;
        }
    }
    
    public List<? extends Object> findByQuery(String query, Map<String, Object> params){
        EntityManager em = EMFProvider.getEMF().createEntityManager();
        List ret = null;
        try {
            em.getEntityManagerFactory().getCache().evictAll();
            Query q = em.createNamedQuery(query);
            if(params != null){
                for (Map.Entry<String, Object> param : params.entrySet()) {
                    q.setParameter(param.getKey(), param.getValue());//aqui se webea
                }
            }
            ret = q.getResultList();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }finally{
            em.close();
        }
        return ret;
        
    }
}
