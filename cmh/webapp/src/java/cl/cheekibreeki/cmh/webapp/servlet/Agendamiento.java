package cl.cheekibreeki.cmh.webapp.servlet;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import cl.cheekibreeki.cmh.lib.dal.dbcontrol.Controller;
import cl.cheekibreeki.cmh.lib.dal.entities.PersMedico;
import cl.cheekibreeki.cmh.lib.dal.entities.Personal;
import cl.cheekibreeki.cmh.lib.dal.entities.Prestacion;
import cl.cheekibreeki.cmh.lib.dal.entities.TipoPres;
import cl.cheekibreeki.cmh.webapp.util.AgendamientoController;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
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
//        try (PrintWriter out = response.getWriter())
            //Obtener todos los tipos de prestacion
            ArrayList<TipoPres> tiposPrestacion = AgendamientoController.obtenerTipoPres();
            request.setAttribute("tiposPrestacion", tiposPrestacion);
            boolean esMismoIdTipoPrestacion = false;
            if(request.getParameter("tipoPrestacion")!= null){
                TipoPres tipoPrestacion = (TipoPres)Controller.findById(TipoPres.class, Integer.parseInt(request.getParameter("tipoPrestacion")));
                request.setAttribute("tipoPrestacion", tipoPrestacion);
                int idTipoPrestacionAnterior = Integer.parseInt(request.getParameter("tipoPrestacion"));
                //si se selecciona un nuevo tipo prestacion
                esMismoIdTipoPrestacion =  idTipoPrestacionAnterior == tipoPrestacion.getIdTipoPrestacion();
            }
            //Obtener prestaciones filtradas
            ArrayList<Prestacion> prestaciones = AgendamientoController.obtenerPrestaciones(request);
            request.setAttribute("prestaciones", prestaciones);
            boolean esMismaPrestacion = false;
            if(request.getParameter("prestacion")!= null && esMismoIdTipoPrestacion){
                Prestacion prestacion = (Prestacion)Controller.findById(Prestacion.class, Integer.parseInt(request.getParameter("prestacion")));    
                request.setAttribute("prestacion", prestacion);
                int idPresatcionAnterior = Integer.parseInt(request.getParameter("prestacion"));
                esMismaPrestacion = idPresatcionAnterior == prestacion.getIdPrestacion();
                ArrayList<Personal> medicos = AgendamientoController.obtenerPersonal(request);
                request.setAttribute("medicos", medicos);
            }else{
                request.setAttribute("medico", null);
            }
            boolean esMismoMedico = false;
            if(request.getParameter("medico")!= null && esMismaPrestacion){
                Personal medico = (Personal)Controller.findById(Personal.class, Integer.parseInt(request.getParameter("medico")));    
                request.setAttribute("medico", medico);
                int idMedicoAnterior = Integer.parseInt(request.getParameter("medico"));
                esMismoMedico = (idMedicoAnterior == medico.getIdPersonal());
            }else{
                request.setAttribute("medico", null);
            }
//        }
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
