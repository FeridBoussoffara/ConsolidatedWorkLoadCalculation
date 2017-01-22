package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;

/**
 * The persistent class for the customers database table.
 * 
 */
@Entity
@Table(name = "customers")
@NamedQuery(name = "Customer.findAll", query = "SELECT c FROM Customer c")
public class Customer implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer customerId;

	/*
	 * @Lob private Address adresse;
	 */

	private String City;
	private String Contry;
	private String State;
	@Lob
	private String email;

	@Lob
	private String name;

	@Lob
	private String phoneNumber;

	@Lob
	private  String photo;

	@Lob
	private String type;

	// bi-directional many-to-one association to Ordersale
	@OneToMany(mappedBy = "customer", cascade = CascadeType.MERGE)
	private List<Ordersale> ordersales;

	public Customer() {
	}

	public Customer(String city, String contry, String state, String email, String name, String phoneNumber,
			 String photo, String type) {

		this.City = city;
		this.Contry = contry;
		this.State = state;
		this.email = email;
		this.name = name;
		this.phoneNumber = phoneNumber;
		this.photo = photo;
		this.type = type;
		this.ordersales = new ArrayList<Ordersale>();
	}

	public void LinkOrdersalesToThisCustomer(List<Ordersale> ordersales) {
		this.ordersales = ordersales;
		for (Ordersale ordersale : ordersales) {
			ordersale.setCustomer(this);
		}
	}

	public Integer getCustomerId() {
		return this.customerId;
	}

	public void setCustomerId(Integer customerId) {
		this.customerId = customerId;
	}

	public String getCity() {
		return City;
	}

	public void setCity(String city) {
		City = city;
	}

	public String getContry() {
		return Contry;
	}

	public void setContry(String contry) {
		Contry = contry;
	}

	public String getState() {
		return State;
	}

	public void setState(String state) {
		State = state;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public  String getPhoto() {
		return this.photo;
	}

	public void setPhoto( String photo) {
		this.photo = photo;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public List<Ordersale> getOrdersales() {
		return this.ordersales;
	}

	public void setOrdersales(List<Ordersale> ordersales) {
		this.ordersales = ordersales;
	}

	public Ordersale addOrdersale(Ordersale ordersale) {
		getOrdersales().add(ordersale);
		ordersale.setCustomer(this);

		return ordersale;
	}

	public Ordersale removeOrdersale(Ordersale ordersale) {
		getOrdersales().remove(ordersale);
		ordersale.setCustomer(null);

		return ordersale;
	}

	@Override
	public String toString() {
		return "Customer [customerId=" + customerId + ", City=" + City + ", Contry=" + Contry + ", State=" + State
				+ ", email=" + email + ", name=" + name + ", phoneNumber=" + phoneNumber + ", photo=" + photo
				+ ", type=" + type + "]";
	}

}