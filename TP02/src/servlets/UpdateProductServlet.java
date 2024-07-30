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

@WebServlet("/UpdateProductServlet")
public class UpdateProductServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;
    private static memDb productsDb = new memDb();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        int id = Integer.parseInt(request.getParameter("id"));
        
        Produto product = productsDb.getProducts().stream().filter(p -> p.getId() == id).findFirst().orElse(null);
        request.setAttribute("product", product);
        
        RequestDispatcher rd = request.getRequestDispatcher("/updateProduct.jsp");
        rd.forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        Produto updatedProduct = new Produto();
        
        updatedProduct.setId(Integer.parseInt(request.getParameter("id")));
        updatedProduct.setNome(request.getParameter("name"));
        updatedProduct.setUnidadeCompra(Integer.parseInt(request.getParameter("unitPurchase")));
        updatedProduct.setDescricao(request.getParameter("description"));
        updatedProduct.setQtdPrevistoMes(Double.parseDouble(request.getParameter("qtyExpectedMonth")));
        updatedProduct.setPrecoMaxComprado(Double.parseDouble(request.getParameter("maxPricePurchased")));

        productsDb.updateProduct(updatedProduct);
        response.sendRedirect("GetProductsServlet");
    }
}

//Pedro H Perpétuo & Igor Benites