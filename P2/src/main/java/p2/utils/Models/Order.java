package p2.utils.Models;

import java.sql.Date;

public class Order {
    private int id;
    private double purchaseAmount;
    private Date orderDate;
    private int customerId;
    private int salesmanId;

    public Order() {}

    public Order(int id, double purchaseAmount, Date orderDate, int customerId, int salesmanId) {
        this.id = id;
        this.purchaseAmount = purchaseAmount;
        this.orderDate = orderDate;
        this.customerId = customerId;
        this.salesmanId = salesmanId;
    }

    public int getId() { return id; }
    public void setId(int id) { this.id = id; }

    public double getPurchaseAmount() { return purchaseAmount; }
    public void setPurchaseAmount(double purchaseAmount) { this.purchaseAmount = purchaseAmount; }

    public Date getOrderDate() { return orderDate; }
    public void setOrderDate(Date orderDate) { this.orderDate = orderDate; }

    public int getCustomerId() { return customerId; }
    public void setCustomerId(int customerId) { this.customerId = customerId; }

    public int getSalesmanId() { return salesmanId; }
    public void setSalesmanId(int salesmanId) { this.salesmanId = salesmanId; }
}