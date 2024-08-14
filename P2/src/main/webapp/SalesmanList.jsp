<%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Lista de Vendedores</title>
</head>
<body>
    <h1>Lista de Vendedores</h1>
    <a href="salesman?action=new">Adicionar Novo Vendedor</a>
    <table border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Cidade</th>
                <th>Comissão</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <c:forEach var="salesman" items="${listSalesman}">
                <tr>
                    <td>${salesman.id}</td>
                    <td>${salesman.name}</td>
                    <td>${salesman.city}</td>
                    <td>${salesman.commission}</td>
                    <td>
                        <a href="salesman?action=edit&id=${salesman.id}">Editar</a>
                        <a href="salesman?action=delete&id=${salesman.id}">Deletar</a>
                    </td>
                </tr>
            </c:forEach>
        </tbody>
    </table>
</body>
</html>
