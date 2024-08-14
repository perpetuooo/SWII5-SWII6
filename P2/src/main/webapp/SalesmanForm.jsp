<%@ page contentType="text/html;charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Formulário de Vendedor</title>
</head>
<body>
    <h1>${salesman == null ? 'Novo Vendedor' : 'Editar Vendedor'}</h1>
    <form action="salesman?action=${salesman == null ? 'insert' : 'update'}" method="post">
        <input type="hidden" name="id" value="${salesman.id}">
        <label for="name">Nome:</label>
        <input type="text" name="name" value="${salesman.name}" required><br>
        <label for="city">Cidade:</label>
        <input type="text" name="city" value="${salesman.city}" required><br>
        <label for="commission">Comissão:</label>
        <input type="text" name="commission" value="${salesman.commission}" required><br>
        <input type="submit" value="${salesman == null ? 'Adicionar' : 'Atualizar'}">
    </form>
</body>
</html>
