<%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>${order == null ? 'Novo Pedido' : 'Editar Pedido'}</title>
</head>
<body>
    <h1>${order == null ? 'Novo Pedido' : 'Editar Pedido'}</h1>
    <form action="order?action=${order == null ? 'insert' : 'update'}" method="post">
        <input type="hidden" name="id" value="${order.id}">
        <label for="purchaseAmount">Valor da Compra:</label>
        <input type="number" step="0.01" name="purchaseAmount" value="${order.purchaseAmount}" required><br>
        <label for="orderDate">Data do Pedido:</label>
        <input type="date" name="orderDate" value="${order.orderDate}" required><br>
        <label for="customerId">ID do Cliente:</label>
        <input type="number" name="customerId" value="${order.customerId}" required><br>
        <label for="salesmanId">ID do Vendedor:</label>
        <input type="number" name="salesmanId" value="${order.salesmanId}" required><br>
        <input type="submit" value="${order == null ? 'Adicionar' : 'Atualizar'}">
    </form>
</body>
</html>
