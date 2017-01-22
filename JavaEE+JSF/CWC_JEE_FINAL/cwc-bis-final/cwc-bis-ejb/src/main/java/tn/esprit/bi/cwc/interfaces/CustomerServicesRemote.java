package tn.esprit.bi.cwc.interfaces;

import java.util.Date;
import java.util.List;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Customer;
import tn.esprit.bi.cwc.persistance.Ordersale;
import tn.esprit.bi.cwc.persistance.Product;

@Remote
public interface CustomerServicesRemote {
	public void saveOrupdate(Customer customer);

	public void deleteCustomer(Customer customer);

	public Customer findCustomerById(Integer idCustomer);

	public List<Customer> GetAllCustomers();

	// ------------------ Part of Services---------------------
	public void BuyProductOrUpdate(Integer idCustomer, Integer idProduct, Date dateOrder, Date dateSale, int quantity);

	public List<Ordersale> GetAllOrderSales();

	public Ordersale findOrderSaleById(Integer Id);

	public List<Ordersale> findOrderSaleByCustomer(Customer customer);

	public List<Ordersale> findOrderSaleByDate(Date date);

	public List<Customer> GetActiveCustomers();

	public List<Ordersale> UpdateActiveCustomers(Integer months, Integer year);

	public void UpdateOrder(Ordersale ordersale);

	public List<Product> GetAllProducts();

	public int NbreOrderByCustomer(Customer customer);
}
