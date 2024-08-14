package p2.utils.DAOs;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import p2.utils.Models.Customer;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class CustomerDAO {
    private Connection connection;

    public CustomerDAO() {
        connection = DbDAO.getConnection();
    }

    public void addCustomer(Customer customer) {
        String sql = "INSERT INTO customer (CUSTOMER_ID, CUST_NAME, CITY, GRADE, SALESMAN_ID) VALUES (?, ?, ?, ?, ?)";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setInt(1, customer.getId());
            ps.setString(2, customer.getName());
            ps.setString(3, customer.getCity());
            ps.setInt(4, customer.getGrade());
            ps.setInt(5, customer.getSalesmanId());
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public List<Customer> getAllCustomers() {
        List<Customer> customers = new ArrayList<>();
        String sql = "SELECT * FROM customer";
        try {
            Statement stmt = connection.createStatement();
            ResultSet rs = stmt.executeQuery(sql);
            while (rs.next()) {
                Customer customer = new Customer();
                customer.setId(rs.getInt("CUSTOMER_ID"));
                customer.setName(rs.getString("CUST_NAME"));
                customer.setCity(rs.getString("CITY"));
                customer.setGrade(rs.getInt("GRADE"));
                customer.setSalesmanId(rs.getInt("SALESMAN_ID"));
                customers.add(customer);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return customers;
    }

    public void updateCustomer(Customer customer) {
        String sql = "UPDATE customer SET CUST_NAME=?, CITY=?, GRADE=?, SALESMAN_ID=? WHERE CUSTOMER_ID=?";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setString(1, customer.getName());
            ps.setString(2, customer.getCity());
            ps.setInt(3, customer.getGrade());
            ps.setInt(4, customer.getSalesmanId());
            ps.setInt(5, customer.getId());
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void deleteCustomer(int id) {
        String sql = "DELETE FROM customer WHERE CUSTOMER_ID=?";
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