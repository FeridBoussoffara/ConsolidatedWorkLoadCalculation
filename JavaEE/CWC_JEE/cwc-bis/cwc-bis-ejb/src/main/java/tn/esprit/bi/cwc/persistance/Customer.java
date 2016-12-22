package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the customers database table.
 * 
 */
@Entity
@Table(name="customers")
@NamedQuery(name="Customer.findAll", query="SELECT c FROM Customer c")
public class Customer implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int customerId;

	@Lob
	private String adresse;

	@Lob
	private String email;

	@Lob
	private String name;

	@Lob
	private String phoneNumber;

	@Lob
	private String photo;

	@Lob
	private String type;

	//bi-directional many-to-one association to Ordersale
	@OneToMany(mappedBy="customer")
	private List<Ordersale> ordersales;

	public Customer() {
	}

	public int getCustomerId() {
		return this.customerId;
	}

	public void setCustomerId(int customerId) {
		this.customerId = customerId;
	}

	public String getAdresse() {
		return this.adresse;
	}

	public void setAdresse(String adresse) {
		this.adresse = adresse;
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

	public String getPhoto() {
		return this.photo;
	}

	public void setPhoto(String photo) {
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

}