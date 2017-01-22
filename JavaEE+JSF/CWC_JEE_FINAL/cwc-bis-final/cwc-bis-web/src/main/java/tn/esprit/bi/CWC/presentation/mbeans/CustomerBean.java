package tn.esprit.bi.CWC.presentation.mbeans;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

import org.primefaces.model.UploadedFile;

import tn.esprit.bi.cwc.interfaces.CustomerServicesRemote;
import tn.esprit.bi.cwc.persistance.Customer;
import tn.esprit.bi.cwc.persistance.Ordersale;
import tn.esprit.bi.cwc.persistance.Product;

@ManagedBean
@SessionScoped
public class CustomerBean {

	// Models
	private Customer customer = new Customer();
	private Customer customerSelected;
	private Product product = new Product();
	private List<Customer> customers = new ArrayList<>();
	private UploadedFile uploadedFile;
	private Ordersale ordersale;
	private Ordersale ordersaleSelected;
	private List<Ordersale> ordersales;
	private List<Ordersale> AllOrdersales;
	private List<Product> products;

	private Boolean formList = true;
	private Boolean formEdit = false;
	private Boolean formDetails = false;
	private Boolean formProduct = false;
	private Boolean formBuyProduct = false;
	private Boolean formEditOrder = false;
	private Boolean formAllOrder = false;
	private Boolean formOrdersCustomer = false;

	private Boolean value;
	private OrderSaleBean orderSaleBean;
	private int yearDate;
	private int monthSelected;
	private int yearSelected;
	private int countOrderSelectedCust;

	public int getMonthSelected() {
		return monthSelected;
	}

	public void setMonthSelected(int monthSelected) {
		this.monthSelected = monthSelected;
	}

	public int getYearSelected() {
		return yearSelected;
	}

	public void setYearSelected(int yearSelected) {
		this.yearSelected = yearSelected;
	}

	public Ordersale getOrdersale() {
		return ordersale;
	}

	public void setOrdersale(Ordersale ordersale) {
		this.ordersale = ordersale;
	}

	public List<Ordersale> getOrdersales() {
		return ordersales;
	}

	public void setOrdersales(List<Ordersale> ordersales) {
		this.ordersales = ordersales;
	}

	// Injection Dependances
	@EJB
	private CustomerServicesRemote customerServicesRemote;

	// Recall
	@PostConstruct
	public void init() {

		customerSelected = new Customer();
		ordersale = new Ordersale();
		product = new Product();
		yearDate = Calendar.getInstance().get(Calendar.YEAR);
		System.out.println(" year : " + yearDate);
		customers = customerServicesRemote.GetAllCustomers();
	}

	public String doAddOrSaveCustomer() {
		customer.setType("Not Active");

		customer.setPhoto(uploadedFile.getFileName());

		byte[] bytes = uploadedFile.getContents();
		OutputStream out;
		try {
			out = new FileOutputStream(
					System.getProperty("jboss.home.dir") + "/imagesContent/" + uploadedFile.getFileName());
			out.write(bytes);
			out.flush();
			out.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		customerServicesRemote.saveOrupdate(customer);
		return "/pages/Admin/Customer/Home?faces-redirect=true";

	}

	public InputStream getImage(String filename) throws FileNotFoundException {
		return new FileInputStream(new File("http://localhost:18080/img/", filename));
	}

	public String selectEditCustomer(Customer customer) {
		this.customerSelected = customer;
		formEdit = true;
		formList = false;
		formDetails = false;
		return null;

	}

	public String selectListProduct(Customer customer) {
		// this.customerSelected = customer;
		products = customerServicesRemote.GetAllProducts();
		formProduct = true;
		formEdit = false;
		formList = false;
		formDetails = false;

		return null;

	}

	public String selectDetailsCustomer(Customer customer) throws Exception {

		System.out.println("heello from dfetails :" + customer);
		this.customerSelected = customer;
		// uploadedFile.write(customer.getPhoto());
		formDetails = true;
		formEdit = false;
		formList = false;
		return null;

	}

	public void addMessage() {

		String summary = value ? "Checked" : "Unchecked";
		if (value == true) {
			System.out.println(" yes now");

		} else {
			System.out.println("not now");
		}
		FacesContext.getCurrentInstance().addMessage(null, new FacesMessage(summary));
	}

	public String doBuyProduct(Customer customer, Product product) {
		if (value == true) {
			ordersale.setDateSale(new Date());
		} else {
			ordersale.setDateSale(null);
		}
		customerServicesRemote.BuyProductOrUpdate(customer.getCustomerId(), product.getProductId(),
				ordersale.getDateOrder(), ordersale.getDateSale(), ordersale.getQuantity());

		return "/pages/Admin/Customer/OrderSale?faces-redirect=true";
	}

	public String EditOrderSale(Ordersale ordersaleSe) {
		if (value == true) {
			ordersaleSe.setDateSale(new Date());
		} else {
			ordersaleSe.setDateSale(null);
		}
		customerServicesRemote.UpdateOrder(ordersaleSe);
		formBuyProduct = false;
		return "/pages/Admin/Customer/OrderSale?faces-redirect=true";
	}

	public String selectBuyProduct(Customer customer, Product product) {
		this.customerSelected = customer;
		this.product = product;

		formDetails = false;
		formEdit = false;
		formList = false;
		formBuyProduct = true;

		System.out.println("customer : " + customer + "\n , product :" + product);
		return null;

	}

	public String showODCustomer(Customer customer) {
		this.customerSelected = customer;
		formOrdersCustomer = true;
		formAllOrder = false;
		ordersales = customerServicesRemote.findOrderSaleByCustomer(customer);
		countOrderSelectedCust = (customerServicesRemote.NbreOrderByCustomer(customer));
		for (Ordersale ordersale : ordersales) {
			System.out.println(ordersale.toString());
		}
		return "/pages/Admin/Customer/OrderSale?faces-redirect=true";

	}

	public String showAllOrders() {

		AllOrdersales = customerServicesRemote.GetAllOrderSales();
		formOrdersCustomer = false;
		formAllOrder = true;

		return "/pages/Admin/Customer/OrderSale?faces-redirect=true";

	}

	public String selectEditOrder(Ordersale ordersale) {
		ordersaleSelected = ordersale;
		formAllOrder = false;
		formBuyProduct = true;
		return null;
	}

	public String doUpdateActiveCustomer() {
		List<Ordersale> ordersales = customerServicesRemote.UpdateActiveCustomers(monthSelected, yearSelected);
		customers = customerServicesRemote.GetAllCustomers();
		return "/pages/Admin/Customer/Home?faces-redirect=true";

	}

	public String goHome() {
		customerSelected = new Customer();
		customers = customerServicesRemote.GetAllCustomers();
		formDetails = false;
		formEdit = false;
		formProduct = false;
		formBuyProduct = false;
		formList = true;

		return null;
	}

	public String doAddOrSaveCustomerEdit() {

		customerSelected.setPhoto(uploadedFile.getFileName());

		customerServicesRemote.saveOrupdate(customerSelected);

		return "/pages/Admin/Customer/Home?faces-redirect=true";

	}

	public String doDeleteCustomer(Customer customer) {
		customerServicesRemote.deleteCustomer(customer);
		customers = customerServicesRemote.GetAllCustomers();
		return "/pages/Admin/Customer/Home?faces-redirect=true";

	}

	public List<Customer> doGetAllCustomers() {
		return customerServicesRemote.GetAllCustomers();
	}

	public Customer getCustomer() {
		return customer;
	}

	public void setCustomer(Customer customer) {
		this.customer = customer;
	}

	public UploadedFile getUploadedFile() {
		return uploadedFile;
	}

	public void setUploadedFile(UploadedFile uploadedFile) {
		this.uploadedFile = uploadedFile;
	}

	public List<Customer> getCustomers() {
		return customers;
	}

	public void setCustomers(List<Customer> customers) {
		this.customers = customers;
	}

	public Boolean getFormEdit() {
		return formEdit;
	}

	public void setFormEdit(Boolean formEdit) {
		this.formEdit = formEdit;
	}

	public Boolean getFormList() {
		return formList;
	}

	public void setFormList(Boolean formList) {
		this.formList = formList;
	}

	public Customer getCustomerSelected() {
		return customerSelected;
	}

	public void setCustomerSelected(Customer customerSelected) {
		this.customerSelected = customerSelected;
	}

	public Boolean getFormDetails() {
		return formDetails;
	}

	public void setFormDetails(Boolean formDetails) {
		this.formDetails = formDetails;
	}

	public OrderSaleBean getOrderSaleBean() {
		return orderSaleBean;
	}

	public void setOrderSaleBean(OrderSaleBean orderSaleBean) {
		this.orderSaleBean = orderSaleBean;
	}

	public Boolean getFormProduct() {
		return formProduct;
	}

	public void setFormProduct(Boolean formProduct) {
		this.formProduct = formProduct;
	}

	public List<Product> getProducts() {
		return products;
	}

	public void setProducts(List<Product> products) {
		this.products = products;
	}

	public Product getProduct() {
		return product;
	}

	public void setProduct(Product product) {
		this.product = product;
	}

	public Boolean getFormBuyProduct() {
		return formBuyProduct;
	}

	public void setFormBuyProduct(Boolean formBuyProduct) {
		this.formBuyProduct = formBuyProduct;
	}

	public Boolean getValue() {
		return value;
	}

	public void setValue(Boolean value) {
		this.value = value;
	}

	public int getYearDate() {
		return yearDate;
	}

	public void setYearDate(int yearDate) {
		this.yearDate = yearDate;
	}

	public int getCountOrderSelectedCust() {
		return countOrderSelectedCust;
	}

	public void setCountOrderSelectedCust(int countOrderSelectedCust) {
		this.countOrderSelectedCust = countOrderSelectedCust;
	}

	public Boolean getFormEditOrder() {
		return formEditOrder;
	}

	public void setFormEditOrder(Boolean formEditOrder) {
		this.formEditOrder = formEditOrder;
	}

	public Boolean getformAllOrder() {
		return formAllOrder;
	}

	public void setformAllOrder(Boolean formAllOrder) {
		this.formAllOrder = formAllOrder;
	}

	public Ordersale getOrdersaleSelected() {
		return ordersaleSelected;
	}

	public void setOrdersaleSelected(Ordersale ordersaleSelected) {
		this.ordersaleSelected = ordersaleSelected;
	}

	public Boolean getFormOrdersCustomer() {
		return formOrdersCustomer;
	}

	public void setFormOrdersCustomer(Boolean formOrdersCustomer) {
		this.formOrdersCustomer = formOrdersCustomer;
	}

	public List<Ordersale> getAllOrdersales() {
		return AllOrdersales;
	}

	public void setAllOrdersales(List<Ordersale> allOrdersales) {
		AllOrdersales = allOrdersales;
	}

	// View
	// Binding LE

}
