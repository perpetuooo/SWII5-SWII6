<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
    
<c:url value="/GetProductsServlet" var="LstProducts" />
<c:url value="/AddProductsServlet" var="AddProducts" />
<c:url value="/UpdateProductServlet" var="UpdateProducts" />
<c:url value="/DeleteProductServlet" var="DeleteProduct" />


<!DOCTYPE html>
<html>
<head>
    <title>Listar Produtos</title>
</head>
<body>
    <h1>Listar</h1>
    <table border="1">
        <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Unidade de compra</th>
            <th>Descrição</th>
            <th>Quantidade Prevista (Mês)</th>
            <th>Preço Máximo Comprado</th>
            <th>Opções</th>
        </tr>
        <c:forEach var="product" items="${products}">
            <tr>
                <td>${product.id}</td>
                <td>${product.nome}</td>
                <td>${product.unidadeCompra}</td>
                <td>${product.descricao}</td>
                <td>${product.qtdPrevistoMes}</td>
                <td>${product.precoMaxComprado}</td>
                <td>
                    <a href="UpdateProductServlet?id=${product.id}">Editar</a> |
                    <a href="DeleteProductServlet?id=${product.id}">Apagar</a>
                </td>
            </tr>
        </c:forEach>
    </table>
    <a href="index.jsp">Voltar</a>
</body>
</html>

<!-- Pedro H Perpétuo & Igor Benites -->