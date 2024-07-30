<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
    
<c:url value="/GetProductsServlet" var="LstProducts" />
<c:url value="/AddProductsServlet" var="AddProducts" />
<c:url value="/UpdateProductServlet" var="UpdateProducts" />
<c:url value="/DeleteProductServlet" var="DeleteProduct" />


<!DOCTYPE html>
<html>
<head>
    <title>Novo Produto</title>
</head>
<body>
    <h1>Add</h1>
    <form action="AddProductsServlet" method="post">
    
        <label for="name">Nome:</label><br>
        <input type="text" id="name" name="name" required><br>
        
        <label for="unitPurchase">Unidade de compra:</label><br>
        <input type="number" id="unitPurchase" name="unitPurchase" required><br>
        
        <label for="description">Descrição:</label><br>
        <textarea id="description" name="description" required></textarea><br>
        
        <label for="qtyExpectedMonth">Quantidade Prevista (Mês):</label><br>
        <input type="number" step="0.01" id="qtyExpectedMonth" name="qtyExpectedMonth" required><br>
        
        <label for="maxPricePurchased">Preço Máximo Comprado:</label><br>
        <input type="number" step="0.01" id="maxPricePurchased" name="maxPricePurchased" required><br>
        
        <input type="submit" value="Addicionar">
    </form>
    <a href="index.jsp">Voltar</a>
    
</body>
</html>

<!-- Pedro H Perpétuo & Igor Benites -->