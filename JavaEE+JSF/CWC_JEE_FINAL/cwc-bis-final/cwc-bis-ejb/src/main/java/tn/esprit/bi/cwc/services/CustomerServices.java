package tn.esprit.bi.cwc.services;

import java.util.Date;
import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;

import tn.esprit.bi.cwc.interfaces.CustomerServicesLocal;
import tn.esprit.bi.cwc.interfaces.CustomerServicesRemote;
import tn.esprit.bi.cwc.interfaces.ProductServicesLocal;
import tn.esprit.bi.cwc.persistance.Customer;
import tn.esprit.bi.cwc.persistance.Ordersale;
import tn.esprit.bi.cwc.persistance.Product;

/**
 * Session Bean implementation class CustomerServices
 */
@Stateless
public class CustomerServices implements CustomerServicesRemote, CustomerServicesLocal {

	@PersistenceContext
	private EntityManager entityManager;
	@EJB
	ProductServicesLocal productServicesLocal;

	public CustomerServices() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public void saveOrupdate(Customer customer) {
		entityManager.merge(customer);
	}

	@Override
	public void deleteCustomer(Customer customer) {
		entityManager.remove(entityManager.merge(customer));
	}

	@Override
	public Customer findCustomerById(Integer idCustomer) {
		return entityManager.find(Customer.class, idCustomer);
	}

	@Override
	public List<Customer> GetAllCustomers() {
		Query query = entityManager.createQuery("select c from Customer c");
		List<Customer> customers = query.getResultList();

		return customers;
	}

	@Override
	public void BuyProductOrUpdate(Integer idCustomer, Integer idProduct, Date dateOrder, Date dateSale, int quantity) {
		Product product = productServicesLocal.findProductById(idProduct);
		Customer customer = findCustomerById(idCustomer);
		Ordersale ordersale = new Ordersale(dateOrder, dateSale, quantity, customer, product);
		System.out.println(ordersale.getQuantity());
		entityManager.merge(ordersale);

	}

	@Override
	public Ordersale findOrderSaleById(Integer Id) {
		return entityManager.find(Ordersale.class, Id);
	}

	@Override
	public List<Ordersale> findOrderSaleByCustomer(Customer customer) {
		Query query = entityManager.createQuery("Select o From Ordersale o where o.customer.customerId=:param");
		query.setParameter("param", customer.getCustomerId());
		System.out.println(" cus id : " + customer.getCustomerId());
		List<Ordersale> ordersales = (List<Ordersale>) query.getResultList();

		customer.LinkOrdersalesToThisCustomer(ordersales);

		return ordersales;
	}

	@Override
	public List<Ordersale> findOrderSaleByDate(Date date) {
		Query query = entityManager
				.createQuery("Select o From Ordersale o where o.dateSale=:param1 or o.dateSale=:param2");
		query.setParameter("param1", date);

		return (List<Ordersale>) query.getResultList();
	}

	@Override
	public List<Customer> GetActiveCustomers() {
		Query query = entityManager.createQuery("Select  c from customers where c.type='Active' ");

		return query.getResultList();
	}

	@Override
	public List<Ordersale> UpdateActiveCustomers(Integer months, Integer year) {

		Query query = entityManager.createQuery(
				"Select c from Ordersale c WHERE  MONTH(c.dateSale)=:param and YEAR(c.dateSale)=:param2  GROUP BY c.customer HAVING COUNT(c)>=2 ");
		// " select * from cwcdb.ordersales c where (extract(month from
		// c.DateSale)) =:param group by (c.CustomerId) having count(*)>=2 ");
		query.setParameter("param", months);
		query.setParameter("param2", year);
		List<Customer> customersNotAc = GetAllCustomers();
		for (Customer customer : customersNotAc) {
			customer.setType("Not Active");
			entityManager.merge(customer);
		}
		List<Ordersale> ordersales = (List<Ordersale>) query.getResultList();
		for (Ordersale ordersale : ordersales) {
			System.out.println("eee :" + ordersale.toString());
			ordersale.getCustomer().setType("Active");
			entityManager.merge(ordersale.getCustomer());
		}
		return ordersales;
	}

	@Override
	public List<Product> GetAllProducts() {

		Client client;
		WebTarget target;

		@SuppressWarnings("unused")
		// String uri = "http://localhost:8787/api/ProductApi/MostSoldProduct";
		String uri = "http://localhost:8787/api/ProductApi/ListAllProducts";
		client = ClientBuilder.newClient();
		target = client.target(uri);
		javax.ws.rs.core.Response response = target.request().get();
		String result = (String) response.readEntity(String.class);

		System.out.println("hhh : " + result);
		// Type product = new TypeToken<ArrayList<Product>>(){}.getType();
		/*
		 * Gson gSon = new
		 * GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create(); //
		 * Aspnetuser asp = gSon.fromJson(result, Aspnetuser.class);
		 */
		// System.out.println(result);
		// System.out.println("userName " + asp.getHireDate());
		// response.close();
		// return null;

		Query query = entityManager.createQuery("Select c   from Product c");
		List<Product> products = query.getResultList();
		return products;

	}

	@Override
	public int NbreOrderByCustomer(Customer customer) {
		int count = 0;

		Query query = entityManager.createQuery("Select COUNT(o) From Ordersale o where o.customer.customerId=:param")
				.setParameter("param", customer.getCustomerId());
		System.out.println(" hhh" + query.getSingleResult());
		count = Integer.parseInt(query.getSingleResult().toString());
		return count;

	}

	@Override
	public void UpdateOrder(Ordersale ordersale) {
		entityManager.merge(ordersale);
	}

	@Override
	public List<Ordersale> GetAllOrderSales() {
		Query query = entityManager.createQuery("Select c   from Ordersale c");
		List<Ordersale> ordersales = query.getResultList();
		
		for (Ordersale ordersale : ordersales) {
			System.out.println("eee :" + ordersale.toString());
		}
		return ordersales;
	}

}
