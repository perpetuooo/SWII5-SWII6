package db;

import java.util.*;

import model.Produto;

public class memDb {

    private static List<Produto> listProducts = new ArrayList<>();
    private static int idIncrement = 1;

    public List<Produto> getProducts() {
        return listProducts;
    }
    
    public void addProduct(Produto product) {
        product.setId(idIncrement++);
        listProducts.add(product);
    }

    public void updateProduct(Produto product) {
        for (Produto existingProduct : listProducts) {
            if (existingProduct.getId() == product.getId()) {
                existingProduct.setNome(product.getNome());
                existingProduct.setDescricao(product.getDescricao());
                existingProduct.setPrecoMaxComprado(product.getPrecoMaxComprado());
                existingProduct.setQtdPrevistoMes(product.getQtdPrevistoMes());
                existingProduct.setUnidadeCompra(product.getUnidadeCompra());
                break;
            }
        }
    }

    public void deleteProduct(int id) {
        listProducts.removeIf(p -> p.getId() == id);
    }
}

//Pedro H Perpétuo & Igor Benites