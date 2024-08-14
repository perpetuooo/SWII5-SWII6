<%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Lista de Pedidos</title>
</head>
<body>
    <h1>Lista de Pedidos</h1>
    <a href="order?action=new">Adicionar Novo Pedido</a>
    <table border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Valor da Compra</th>
                <th>Data do Pedido</th>
                <th>ID do Cliente</th>
                <th>ID do Vendedor</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <c:forEach var="order" items="${listOrder}">
                <tr>
                    <td>${order.id}</td>
                    <td>${order.purchaseAmount}</td>
                    <td>${order.orderDate}</td>
                    <td>${order.customerId}</td>
                    <td>${order.salesmanId}</td>
                    <td>
                        <a href="order?action=edit&id=${order.id}">Editar</a> |
                        <a href="order?action=delete&id=${order.id}" onclick="return confirm('Tem certeza que deseja excluir este pedido?');">Deletar</a>
                    </td>
                </tr>
            </c:forEach>
        </tbody>
    </table>
</body>
</html>
