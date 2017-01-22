package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Ordersale;
import tn.esprit.bi.cwc.persistance.Product;

@Local
public interface ProductServicesLocal {

	public Product findProductById(Integer IdProduct);

	public List<Ordersale> getAllOrderSales();
}
