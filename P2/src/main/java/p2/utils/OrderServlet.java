package p2.utils;

import java.io.IOException;
import java.sql.Date;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import p2.utils.DAOs.OrderDAO;
import p2.utils.Models.Order;

import javax.servlet.*;
import java.util.List;

@WebServlet("/order")
public class OrderServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private OrderDAO orderDAO;

    @Override
    public void init() {
        orderDAO = new OrderDAO();
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
                insertOrder(request, response);
                break;
            case "delete":
                deleteOrder(request, response);
                break;
            case "edit":
                showEditForm(request, response);
                break;
            case "update":
                updateOrder(request, response);
                break;
            default:
                listOrder(request, response);
                break;
        }
    }

    private void listOrder(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        List<Order> listOrder = orderDAO.getAllOrders();
        request.setAttribute("listOrder", listOrder);
        RequestDispatcher dispatcher = request.getRequestDispatcher("order-list.jsp");
        dispatcher.forward(request, response);
    }

    private void showNewForm(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        RequestDispatcher dispatcher = request.getRequestDispatcher("order-form.jsp");
        dispatcher.forward(request, response);
    }

    private void insertOrder(HttpServletRequest request, HttpServletResponse response) throws IOException {
        double purchaseAmount = Double.parseDouble(request.getParameter("purchaseAmount"));
        Date orderDate = Date.valueOf(request.getParameter("orderDate"));
        int customerId = Integer.parseInt(request.getParameter("customerId"));
        int salesmanId = Integer.parseInt(request.getParameter("salesmanId"));

        Order newOrder = new Order();
        newOrder.setPurchaseAmount(purchaseAmount);
        newOrder.setOrderDate(orderDate);
        newOrder.setCustomerId(customerId);
        newOrder.setSalesmanId(salesmanId);

        orderDAO.addOrder(newOrder);
        response.sendRedirect("order");
    }

    private void showEditForm(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        Order existingOrder = orderDAO.getAllOrders().stream().filter(o -> o.getId() == id).findFirst().orElse(null);
        RequestDispatcher dispatcher = request.getRequestDispatcher("order-form.jsp");
        request.setAttribute("order", existingOrder);
        dispatcher.forward(request, response);
    }

    private void updateOrder(HttpServletRequest request, HttpServletResponse response) throws IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        double purchaseAmount = Double.parseDouble(request.getParameter("purchaseAmount"));
        Date orderDate = Date.valueOf(request.getParameter("orderDate"));
        int customerId = Integer.parseInt(request.getParameter("customerId"));
        int salesmanId = Integer.parseInt(request.getParameter("salesmanId"));

        Order order = new Order();
        order.setId(id);
        order.setPurchaseAmount(purchaseAmount);
        order.setOrderDate(orderDate);
        order.setCustomerId(customerId);
        order.setSalesmanId(salesmanId);

        orderDAO.updateOrder(order);
        response.sendRedirect("order");
    }

    private void deleteOrder(HttpServletRequest request, HttpServletResponse response) throws IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        orderDAO.deleteOrder(id);
        response.sendRedirect("order");
    }
}
