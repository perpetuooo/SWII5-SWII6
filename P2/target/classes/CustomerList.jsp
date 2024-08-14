<!-- Pedro H Perpétuo & Igor Benites --><%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Lista de Clientes</title>
</head>
<body>
    <h1>Lista de Clientes</h1>
    <a href="customer?action=new">Adicionar Novo Cliente</a>
    <table border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Cidade</th>
                <th>Grade</th>
                <th>ID do Vendedor</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <c:forEach var="customer" items="${listCustomer}">
                <tr>
                    <td>${customer.id}</td>
                    <td>${customer.name}</td>
                    <td>${customer.city}</td>
                    <td>${customer.grade}</td>
                    <td>${customer.salesmanId}</td>
                    <td>
                        <a href="customer?action=edit&id=${customer.id}">Editar</a> |
                        <a href="customer?action=delete&id=${customer.id}" onclick="return confirm('Tem certeza que deseja excluir este cliente?');">Deletar</a>
                    </td>
                </tr>
            </c:forEach>
        </tbody>
    </table>
</body>
</html>
<!-- Pedro H Perpétuo & Igor Benites -->