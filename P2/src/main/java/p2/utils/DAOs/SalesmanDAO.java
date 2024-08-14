package p2.utils.DAOs;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import p2.utils.Models.Salesman;

public class SalesmanDAO {

	private Connection connection;

    public SalesmanDAO() {
        String dbUrl = "jdbc:mysql://localhost:3306/sales_db";
        String dbUser = "root";
        String dbPassword = "1234";

        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            connection = DriverManager.getConnection(dbUrl, dbUser, dbPassword);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void addSalesman(Salesman salesman) {
        String sql = "INSERT INTO salesman (SALESMAN_ID, NAME, CITY, COMMISSION) VALUES (?, ?, ?, ?)";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setInt(1, salesman.getId());
            ps.setString(2, salesman.getName());
            ps.setString(3, salesman.getCity());
            ps.setDouble(4, salesman.getCommission());
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public List<Salesman> getAllSalesmen() {
        List<Salesman> salesmen = new ArrayList<>();
        String sql = "SELECT * FROM salesman";
        try {
            Statement stmt = connection.createStatement();
            ResultSet rs = stmt.executeQuery(sql);
            while (rs.next()) {
                Salesman salesman = new Salesman();
                salesman.setId(rs.getInt("SALESMAN_ID"));
                salesman.setName(rs.getString("NAME"));
                salesman.setCity(rs.getString("CITY"));
                salesman.setCommission(rs.getDouble("COMMISSION"));
                salesmen.add(salesman);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return salesmen;
    }

    public void updateSalesman(Salesman salesman) {
        String sql = "UPDATE salesman SET NAME=?, CITY=?, COMMISSION=? WHERE SALESMAN_ID=?";
        try {
            PreparedStatement ps = connection.prepareStatement(sql);
            ps.setString(1, salesman.getName());
            ps.setString(2, salesman.getCity());
            ps.setDouble(3, salesman.getCommission());
            ps.setInt(4, salesman.getId());
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void deleteSalesman(int id) {
        String sql = "DELETE FROM salesman WHERE SALESMAN_ID=?";
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
