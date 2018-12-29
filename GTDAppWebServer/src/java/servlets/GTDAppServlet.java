/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlets;

import com.google.gson.Gson;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import model.Item;

/**
 * @author paprika0712
 */
@WebServlet(name = "GTDAppServlet", urlPatterns = {"/GTDAppServlet"})
public class GTDAppServlet extends HttpServlet {

    private List<Item> getByContainer(){
        
        List<Item> items = new ArrayList();
        
        Item item1 = new Item();
        item1.setDescription("Go to the shop and buy some stuff");
        item1.setTitle("Shopping");
        items.add(item1);
        
        Item item2 = new Item();
        item2.setDescription("Print the book you always wanted");
        item2.setTitle("Go to printer");
        items.add(item2);
        
        Item item3 = new Item();
        item3.setDescription("Watch all episodes of scrubs");
        item3.setTitle("ScrubberWeekend");
        items.add(item3);
        
        Item item4 = new Item();
        item4.setDescription("Seriously!");
        item4.setTitle("Do nothing");
        items.add(item4);
        
        return items;
    }
    
    /**
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException 
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("application/json");
        response.setCharacterEncoding("UTF-8");
        
        List<Item> items = this.getByContainer();
        Gson gson = new Gson();
        String json = gson.toJson(items);

        response.getWriter().write(json);
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
