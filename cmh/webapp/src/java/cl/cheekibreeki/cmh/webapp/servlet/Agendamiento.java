package cl.cheekibreeki.cmh.webapp.servlet;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.AtencionAgen;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Personal;
import cl.cheekibreeki.cmh.lib.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.lib.dal.entities.TipoPres;
import cl.cheekibreeki.cmh.webapp.bl.AccionesPaciente;
import cl.cheekibreeki.cmh.webapp.bl.HoraDisponible;
import cl.cheekibreeki.cmh.webapp.bl.HorasDisponibles;
import cl.cheekibreeki.cmh.webapp.util.AgendamientoController;
import cl.cheekibreeki.cmh.webapp.util.LoginController;
import cl.cheekibreeki.cmh.webapp.util.Validador;
import java.io.IOException;
import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author dev
 */
public class Agendamiento extends HttpServlet {

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

        AgendamientoController.cargarTodosTiposPrestaciones(request);
        AgendamientoController.cargarPrestaciones(request);
        AgendamientoController.cargarPersonal(request);
        AgendamientoController.cargarHorasLibres(request);
        String paramBtnRegistrar = request.getParameter("hiddenRegistrar");
        boolean btnRegistrarClick = null != paramBtnRegistrar && "registrar".compareTo(paramBtnRegistrar) == 0;
        if (btnRegistrarClick) {
            boolean isLoggedIn = LoginController.obtenerPacienteEnSesion(request.getSession()) != null;
            if (isLoggedIn) {
                AgendamientoController.registrarAtencion(request);
                PrintWriter out = response.getWriter();
                out.println("<script>alert('Atencion agendada exitosamente'); location.href = 'master.jsp?page=index';</script>");
            } else {
                PrintWriter out = response.getWriter();
                out.println("<script>alert('Por favor inicie sesión'); location.href = 'master.jsp?page=login';</script>");
            }
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
