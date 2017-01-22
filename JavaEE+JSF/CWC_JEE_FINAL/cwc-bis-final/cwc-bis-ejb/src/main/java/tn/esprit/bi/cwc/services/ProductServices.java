package tn.esprit.bi.cwc.services;

import java.util.List;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tn.esprit.bi.cwc.interfaces.ProductServicesLocal;
import tn.esprit.bi.cwc.interfaces.ProductServicesRemote;
import tn.esprit.bi.cwc.persistance.Ordersale;
import tn.esprit.bi.cwc.persistance.Product;

/**
 * Session Bean implementation class ProductServices
 */
@Stateless
public class ProductServices implements ProductServicesRemote, ProductServicesLocal {

	@PersistenceContext
	EntityManager entityManager;

	public ProductServices() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public Product findProductById(Integer IdProduct) {
		return entityManager.find(Product.class, IdProduct);
	}

	@Override
	public List<Ordersale> getAllOrderSales() {
		Query query = entityManager.createQuery("Select o From OrderSale o  ");
		return (List<Ordersale>) query.getResultList();

	}

}
