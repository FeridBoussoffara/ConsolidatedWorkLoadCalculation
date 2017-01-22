package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Ordersale;
import tn.esprit.bi.cwc.persistance.Product;

@Remote
public interface ProductServicesRemote {
	public Product findProductById(Integer IdProduct);

	public List<Ordersale> getAllOrderSales();

}
