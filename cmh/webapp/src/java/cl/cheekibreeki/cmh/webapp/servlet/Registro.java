/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.servlet;

import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import cl.cheekibreeki.cmh.webapp.bl.AccionesPaciente;
import cl.cheekibreeki.cmh.webapp.util.PassHasher;
import java.io.IOException;
import java.io.PrintWriter;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author dev
 */
public class Registro extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException, ParseException, NoSuchAlgorithmException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            String method = request.getMethod();
            //Si no es post: (implementado porsiaca)
            if(!"POST".equals(method)){
            }else{//Si es post:registro
                //Capturar inputs
                String nombres = request.getParameter("registroNombres");
                String apellidos = request.getParameter("registroApellidos");
                String fecnac = request.getParameter("registrofecnac");
                String email = request.getParameter("registromail");
                String pass = request.getParameter("registropass");
                String rut = request.getParameter("registrorut");
                String dv = request.getParameter("registroDV");
                String sexo = request.getParameter("registroSexo");
                //Parsear fecnac a date
                SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
                Date fecnacDate = format.parse(fecnac);
                //parsear rut a numero
                int rutInt = Integer.parseInt(rut);
                //parsear dv a char
                char dvChar = dv.toCharArray()[0];
                //parsear sexo a char
                char sexoChar = sexo.toCharArray()[0];
                //Hashear pass
                String hashedPass = PassHasher.hashToMD5(pass);
                //Instanciar objeto
                Paciente paciente = new Paciente();
                paciente.setIdPaciente(0);
                paciente.setNombresPaciente(nombres);
                paciente.setApellidosPaciente(apellidos);
                paciente.setRut(rutInt);
                paciente.setDigitoVerificador(dvChar);
                paciente.setSexo(sexoChar);
                paciente.setEmailPaciente(email);
                paciente.setHashedPass(hashedPass);
                paciente.setFecNac(fecnacDate);
                paciente.setActivo((short)1);
                //Llamar método de registro
                AccionesPaciente accionesPaciente = new AccionesPaciente();
                boolean result = accionesPaciente.registrarPaciente(paciente);
                if(result){//Si registro exitoso: mostrar alert e ir a login
                    out.println("<script>alert('Registro exitoso'); location.href = 'master.jsp?page=login';</script>");
                }else{//Si registro no es exitoso: mostrar alert e ir a página de registro
                    out.println("<script>alert('Problemas con el registro'); location.href = 'master.jsp?page=registro';</script>");
                }
                
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            processRequest(request, response);
        } catch (ParseException ex) {
            Logger.getLogger(Registro.class.getName()).log(Level.SEVERE, null, ex);
        } catch (NoSuchAlgorithmException ex) {
            Logger.getLogger(Registro.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            processRequest(request, response);
        } catch (ParseException ex) {
            Logger.getLogger(Registro.class.getName()).log(Level.SEVERE, null, ex);
        } catch (NoSuchAlgorithmException ex) {
            Logger.getLogger(Registro.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
