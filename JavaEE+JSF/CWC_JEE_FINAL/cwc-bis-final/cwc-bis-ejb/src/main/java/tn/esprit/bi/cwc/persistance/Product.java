package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Lob;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

/**
 * The persistent class for the products database table.
 * 
 */
@Entity
@Table(name = "products")
@Inheritance(strategy = InheritanceType.SINGLE_TABLE)
@NamedQuery(name = "Product.findAll", query = "SELECT p FROM Product p")
public class Product implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private Integer productId;

	@Temporal(TemporalType.TIMESTAMP)
	private Date addedDate;

	@Lob
	private String name;

	@Lob
	private String photo;

	private float price;

	private Integer quantity;

	private String type;

	@Temporal(TemporalType.TIMESTAMP)
	private Date validityDate;

	// bi-directional many-to-one association to Orderpurchas
	@OneToMany(mappedBy = "product", cascade = CascadeType.MERGE, fetch = FetchType.EAGER)
	private List<Orderpurchas> orderpurchases;

	// bi-directional many-to-one association to Ordersale
	@OneToMany(mappedBy = "product", cascade = CascadeType.MERGE, fetch = FetchType.EAGER)
	private List<Ordersale> ordersales;

	public Product() {
	}

	public Integer getProductId() {
		return this.productId;
	}

	public void setProductId(Integer productId) {
		this.productId = productId;
	}

	public Date getAddedDate() {
		return this.addedDate;
	}

	public void setAddedDate(Date addedDate) {
		this.addedDate = addedDate;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPhoto() {
		return this.photo;
	}

	public void setPhoto(String photo) {
		this.photo = photo;
	}

	public float getPrice() {
		return this.price;
	}

	public void setPrice(float price) {
		this.price = price;
	}

	public Integer getQuantity() {
		return this.quantity;
	}

	public void setQuantity(Integer quantity) {
		this.quantity = quantity;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public Date getValidityDate() {
		return this.validityDate;
	}

	public void setValidityDate(Date validityDate) {
		this.validityDate = validityDate;
	}

	public List<Orderpurchas> getOrderpurchases() {
		return this.orderpurchases;
	}

	public void setOrderpurchases(List<Orderpurchas> orderpurchases) {
		this.orderpurchases = orderpurchases;
	}

	public Orderpurchas addOrderpurchas(Orderpurchas orderpurchas) {
		getOrderpurchases().add(orderpurchas);
		orderpurchas.setProduct(this);

		return orderpurchas;
	}

	public Orderpurchas removeOrderpurchas(Orderpurchas orderpurchas) {
		getOrderpurchases().remove(orderpurchas);
		orderpurchas.setProduct(null);

		return orderpurchas;
	}

	public List<Ordersale> getOrdersales() {
		return this.ordersales;
	}

	public void setOrdersales(List<Ordersale> ordersales) {
		this.ordersales = ordersales;
	}

	public Ordersale addOrdersale(Ordersale ordersale) {
		getOrdersales().add(ordersale);
		ordersale.setProduct(this);

		return ordersale;
	}

	public Ordersale removeOrdersale(Ordersale ordersale) {
		getOrdersales().remove(ordersale);
		ordersale.setProduct(null);

		return ordersale;
	}

	@Override
	public String toString() {
		return "Product [productId=" + productId + ", addedDate=" + addedDate + ", name=" + name + ", photo=" + photo
				+ ", price=" + price + ", quantity=" + quantity + ", type=" + type + ", validityDate=" + validityDate
				+ ", orderpurchases=" + orderpurchases + ", ordersales=" + ordersales + "]";
	}

}