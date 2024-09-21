package p2.utils.DAOs;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import p2.utils.Models.Order;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class OrderDAO {
    private Connection connection;

    public OrderDAO() {
        connection = DbDAO.getConnection();
    }

    public void addOrder(Order order) {
        String sql = "INSERT INTO orders (ORD_NO, PURCH_AMT, ORD_DATE, CUSTOMER_ID, SALESMAN_ID) VALUES (?, ?, ?, ?, ?)";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setInt(1, order.getId());
            ps.setDouble(2, order.getPurchaseAmount());
            ps.setDate(3, order.getOrderDate());
            ps.setInt(4, order.getCustomerId());
            ps.setInt(5, order.getSalesmanId());
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public List<Order> getAllOrders() {
        List<Order> orders = new ArrayList<>();
        String sql = "SELECT * FROM orders";
        try {
            Statement stmt = connection.createStatement();
            ResultSet rs = stmt.executeQuery(sql);
            while (rs.next()) {
                Order order = new Order();
                order.setId(rs.getInt("ORD_NO"));
                order.setPurchaseAmount(rs.getDouble("PURCH_AMT"));
                order.setOrderDate(rs.getDate("ORD_DATE"));
                order.setCustomerId(rs.getInt("CUSTOMER_ID"));
                order.setSalesmanId(rs.getInt("SALESMAN_ID"));
                orders.add(order);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return orders;
    }

    public void updateOrder(Order order) {
        String sql = "UPDATE orders SET PURCH_AMT=?, ORD_DATE=?, CUSTOMER_ID=?, SALESMAN_ID=? WHERE ORD_NO=?";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setDouble(1, order.getPurchaseAmount());
            ps.setDate(2, order.getOrderDate());
            ps.setInt(3, order.getCustomerId());
            ps.setInt(4, order.getSalesmanId());
            ps.setInt(5, order.getId());
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void deleteOrder(int id) {
        String sql = "DELETE FROM orders WHERE ORD_NO=?";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
//Pedro H Perpétuo & Igor Benites