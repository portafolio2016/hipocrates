/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.servlet;

import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.Paciente;
import cl.cheekibreeki.cmh.webapp.util.LoginController;
import cl.cheekibreeki.cmh.webapp.util.PassHasher;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author dev
 */
public class Actualizar extends HttpServlet {

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
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String method = request.getMethod();
        if ("POST".equals(method)) {//Si metodo POST
            try (PrintWriter out = response.getWriter()) {
                //Capturar input
                //perfilMail
                String nuevoMail = request.getParameter("perfilMail");
                //perfilPassword
                String perfilPassword = request.getParameter("perfilPassword");
                //confirmPassword
                String confirmPassword = request.getParameter("confirmPassword");
                //Si password son diferentes
                if (!perfilPassword.equals(confirmPassword)) {
                    out.println("<script>alert('Passwords no coinciden'); location.href = 'master.jsp?page=editar';</script>");
                    return;
                }
                //Hashear password
                String hashedNewPass = PassHasher.hashToMD5(perfilPassword);
                //Actualizar objeto
                Paciente paciente = LoginController.obtenerPacienteEnSesion(request.getSession());
                paciente.setEmailPaciente(nuevoMail);
                paciente.setHashedPass(hashedNewPass);
                //Persistir paciente
                Controller.upsert(paciente);
                out.println("<script>alert('Perfil actualizado exitosamente'); location.href = 'master.jsp?page=index';</script>");
            }
        } else {//Si metodo GET
            Paciente paciente = LoginController.obtenerPacienteEnSesion(request.getSession());
            //Poner mail como atributo de request
            request.setAttribute("email", paciente.getEmailPaciente());
            System.out.println(paciente.getEmailPaciente());
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
        processRequest(request, response);
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
        processRequest(request, response);
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
