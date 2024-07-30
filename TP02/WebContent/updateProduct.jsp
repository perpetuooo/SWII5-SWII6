<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
    
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
        
<c:url value="/GetProductsServlet" var="LstProducts" />
<c:url value="/AddProductsServlet" var="AddProducts" />
<c:url value="/UpdateProductServlet" var="UpdateProducts" />

<!DOCTYPE html>
<html>
<head>
    <title>Atualizar Produtos</title>
</head>
<body>
    <h1>Atualizar</h1>
    <form action="UpdateProductServlet" method="post">
        <input type="text" name="id" value="${product.id}">
        
        <label for="name">Nome:</label><br>
        <input type="text" id="name" name="name" value="${product.nome}" required><br>
        
        <label for="unitPurchase">Unidade de compra:</label><br>
        <input type="number" id="unitPurchase" name="unitPurchase" value="${product.unidadeCompra}" required><br>
        
        <label for="description">Descrição:</label><br>
        <textarea id="description" name="description" required>${product.descricao}</textarea><br>
        
        <label for="qtyExpectedMonth">Quantidade Prevista (Mês):</label><br>
        <input type="number" step="0.01" id="qtyExpectedMonth" name="qtyExpectedMonth" value="${product.qtdPrevistoMes}" required><br>
        
        <label for="maxPricePurchased">Preço Máximo Comprado:</label><br>
        <input type="number" step="0.01" id="maxPricePurchased" name="maxPricePurchased" value="${product.precoMaxComprado}" required><br>
        
        <input type="submit" value="Update Product">
    </form>
    <a href="index.jsp">Voltar</a>
</body>
</html>

<!-- Pedro H Perpétuo & Igor Benites -->