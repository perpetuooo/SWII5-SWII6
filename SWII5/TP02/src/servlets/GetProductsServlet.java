package servlets;

import java.io.IOException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import db.memDb;

@WebServlet("/GetProductsServlet")
public class GetProductsServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;
    private static memDb productsDb = new memDb();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setAttribute("products", productsDb.getProducts());
        RequestDispatcher rd = request.getRequestDispatcher("/getProduct.jsp");
        
        rd.forward(request, response);
    }
}

//Pedro H Perpétuo & Igor Benites