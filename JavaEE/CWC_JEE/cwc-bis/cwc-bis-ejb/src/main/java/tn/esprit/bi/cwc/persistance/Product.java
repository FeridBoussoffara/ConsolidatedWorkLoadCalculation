package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the products database table.
 * 
 */
@Entity
@Table(name="products")
@NamedQuery(name="Product.findAll", query="SELECT p FROM Product p")
public class Product implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int productId;

	@Temporal(TemporalType.TIMESTAMP)
	private Date addedDate;

	@Lob
	private String brand;

	private int capacity;

	private int category;

	@Lob
	private String material;

	@Lob
	private String name;

	@Lob
	private String photo;

	private float price;

	private int quantity;

	@Lob
	private String technology;

	private String type;

	@Temporal(TemporalType.TIMESTAMP)
	private Date validityDate;

	@Lob
	private String vehiculeType;

	@Lob
	private String version;

	private float weightElec;

	private float weightFur;

	private float weightveh;

	private int wheelsNbr;

	//bi-directional many-to-one association to Orderpurchas
	@OneToMany(mappedBy="product")
	private List<Orderpurchas> orderpurchases;

	//bi-directional many-to-one association to Ordersale
	@OneToMany(mappedBy="product")
	private List<Ordersale> ordersales;

	public Product() {
	}

	public int getProductId() {
		return this.productId;
	}

	public void setProductId(int productId) {
		this.productId = productId;
	}

	public Date getAddedDate() {
		return this.addedDate;
	}

	public void setAddedDate(Date addedDate) {
		this.addedDate = addedDate;
	}

	public String getBrand() {
		return this.brand;
	}

	public void setBrand(String brand) {
		this.brand = brand;
	}

	public int getCapacity() {
		return this.capacity;
	}

	public void setCapacity(int capacity) {
		this.capacity = capacity;
	}

	public int getCategory() {
		return this.category;
	}

	public void setCategory(int category) {
		this.category = category;
	}

	public String getMaterial() {
		return this.material;
	}

	public void setMaterial(String material) {
		this.material = material;
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

	public int getQuantity() {
		return this.quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public String getTechnology() {
		return this.technology;
	}

	public void setTechnology(String technology) {
		this.technology = technology;
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

	public String getVehiculeType() {
		return this.vehiculeType;
	}

	public void setVehiculeType(String vehiculeType) {
		this.vehiculeType = vehiculeType;
	}

	public String getVersion() {
		return this.version;
	}

	public void setVersion(String version) {
		this.version = version;
	}

	public float getWeightElec() {
		return this.weightElec;
	}

	public void setWeightElec(float weightElec) {
		this.weightElec = weightElec;
	}

	public float getWeightFur() {
		return this.weightFur;
	}

	public void setWeightFur(float weightFur) {
		this.weightFur = weightFur;
	}

	public float getWeightveh() {
		return this.weightveh;
	}

	public void setWeightveh(float weightveh) {
		this.weightveh = weightveh;
	}

	public int getWheelsNbr() {
		return this.wheelsNbr;
	}

	public void setWheelsNbr(int wheelsNbr) {
		this.wheelsNbr = wheelsNbr;
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

}