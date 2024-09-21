package servlets;

import java.io.IOException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import db.memDb;
import model.Produto;

@WebServlet("/AddProductsServlet")
public class AddProductsServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;
    private static memDb productsDb = new memDb();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        RequestDispatcher rd = request.getRequestDispatcher("/newProduct.jsp");
        rd.forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        Produto newProduct = new Produto();
        newProduct.setNome(request.getParameter("name"));
        newProduct.setUnidadeCompra(Integer.parseInt(request.getParameter("unitPurchase")));
        newProduct.setDescricao(request.getParameter("description"));
        newProduct.setQtdPrevistoMes(Double.parseDouble(request.getParameter("qtyExpectedMonth")));
        newProduct.setPrecoMaxComprado(Double.parseDouble(request.getParameter("maxPricePurchased")));

        productsDb.addProduct(newProduct);
        response.sendRedirect("GetProductsServlet");
    }
}

//Pedro H Perpétuo & Igor Benites