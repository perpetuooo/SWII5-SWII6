package p2.utils;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.*;
import java.util.List;

import p2.utils.DAOs.SalesmanDAO;
import p2.utils.Models.Salesman;


@WebServlet("/salesman")
public class SalesmanServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private SalesmanDAO salesmanDAO;

    @Override
    public void init() {
        salesmanDAO = new SalesmanDAO();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");
        if (action == null) {
            action = "list";
        }

        switch (action) {
            case "new":
                showNewForm(request, response);
                break;
            case "insert":
                insertSalesman(request, response);
                break;
            case "delete":
                deleteSalesman(request, response);
                break;
            case "edit":
                showEditForm(request, response);
                break;
            case "update":
                updateSalesman(request, response);
                break;
            default:
                listSalesman(request, response);
                break;
        }
    }

    private void listSalesman(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        List<Salesman> listSalesman = salesmanDAO.getAllSalesmen();
        request.setAttribute("listSalesman", listSalesman);
        RequestDispatcher dispatcher = request.getRequestDispatcher("salesman-list.jsp");
        dispatcher.forward(request, response);
    }

    private void showNewForm(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        RequestDispatcher dispatcher = request.getRequestDispatcher("salesman-form.jsp");
        dispatcher.forward(request, response);
    }

    private void insertSalesman(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String name = request.getParameter("name");
        String city = request.getParameter("city");
        double commission = Double.parseDouble(request.getParameter("commission"));

        Salesman newSalesman = new Salesman();
        newSalesman.setName(name);
        newSalesman.setCity(city);
        newSalesman.setCommission(commission);

        salesmanDAO.addSalesman(newSalesman);
        response.sendRedirect("salesman");
    }

    private void showEditForm(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        Salesman existingSalesman = salesmanDAO.getAllSalesmen().stream().filter(s -> s.getId() == id).findFirst().orElse(null);
        RequestDispatcher dispatcher = request.getRequestDispatcher("salesman-form.jsp");
        request.setAttribute("salesman", existingSalesman);
        dispatcher.forward(request, response);
    }

    private void updateSalesman(HttpServletRequest request, HttpServletResponse response) throws IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        String name = request.getParameter("name");
        String city = request.getParameter("city");
        double commission = Double.parseDouble(request.getParameter("commission"));

        Salesman salesman = new Salesman();
        salesman.setId(id);
        salesman.setName(name);
        salesman.setCity(city);
        salesman.setCommission(commission);

        salesmanDAO.updateSalesman(salesman);
        response.sendRedirect("salesman");
    }

    private void deleteSalesman(HttpServletRequest request, HttpServletResponse response) throws IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        salesmanDAO.deleteSalesman(id);
        response.sendRedirect("salesman");
    }}
//Pedro H Perpétuo & Igor Benites