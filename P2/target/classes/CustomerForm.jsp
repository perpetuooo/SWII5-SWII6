<%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>${customer == null ? 'Novo Cliente' : 'Editar Cliente'}</title>
</head>
<body>
    <h1>${customer == null ? 'Novo Cliente' : 'Editar Cliente'}</h1>
    <form action="customer?action=${customer == null ? 'insert' : 'update'}" method="post">
        <input type="hidden" name="id" value="${customer.id}">
        <label for="name">Nome:</label>
        <input type="text" name="name" value="${customer.name}" required><br>
        <label for="city">Cidade:</label>
        <input type="text" name="city" value="${customer.city}" required><br>
        <label for="grade">Grade:</label>
        <input type="number" name="grade" value="${customer.grade}" required><br>
        <label for="salesmanId">ID do Vendedor:</label>
        <input type="number" name="salesmanId" value="${customer.salesmanId}" required><br>
        <input type="submit" value="${customer == null ? 'Adicionar' : 'Atualizar'}">
    </form>
</body>
</html>
<!-- Pedro H Perpétuo & Igor Benites -->