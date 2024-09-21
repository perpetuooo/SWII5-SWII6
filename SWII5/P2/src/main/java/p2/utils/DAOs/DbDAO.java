package p2.utils.DAOs;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DbDAO {
    private static Connection connection;
    public static Connection getConnection() {
        if (connection == null) {
            try {
                String dbUrl = "jdbc:mysql://localhost:3306/sales_db";
                String dbUser = "root";
                String dbPassword = "1234";

                Class.forName("com.mysql.cj.jdbc.Driver");
                connection = DriverManager.getConnection(dbUrl, dbUser, dbPassword);
            } catch (ClassNotFoundException | SQLException e) {
                e.printStackTrace();
            }
        }
        return connection;
    }
}
//Pedro H Perpétuo & Igor Benites