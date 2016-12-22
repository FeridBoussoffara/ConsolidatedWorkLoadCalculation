package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the orderpurchases database table.
 * 
 */
@Entity
@Table(name="orderpurchases")
@NamedQuery(name="Orderpurchas.findAll", query="SELECT o FROM Orderpurchas o")
public class Orderpurchas implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private OrderpurchasPK id;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateOrder;

	@Temporal(TemporalType.TIMESTAMP)
	private Date datePurchase;

	private String discriminator;

	private int quantity;

	//bi-directional many-to-one association to Product
	@ManyToOne
	@JoinColumn(name="ProductId")
	private Product product;

	//bi-directional many-to-one association to Provider
	@ManyToOne
	@JoinColumn(name="ProviderId")
	private Provider provider;

	public Orderpurchas() {
	}

	public OrderpurchasPK getId() {
		return this.id;
	}

	public void setId(OrderpurchasPK id) {
		this.id = id;
	}

	public Date getDateOrder() {
		return this.dateOrder;
	}

	public void setDateOrder(Date dateOrder) {
		this.dateOrder = dateOrder;
	}

	public Date getDatePurchase() {
		return this.datePurchase;
	}

	public void setDatePurchase(Date datePurchase) {
		this.datePurchase = datePurchase;
	}

	public String getDiscriminator() {
		return this.discriminator;
	}

	public void setDiscriminator(String discriminator) {
		this.discriminator = discriminator;
	}

	public int getQuantity() {
		return this.quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public Product getProduct() {
		return this.product;
	}

	public void setProduct(Product product) {
		this.product = product;
	}

	public Provider getProvider() {
		return this.provider;
	}

	public void setProvider(Provider provider) {
		this.provider = provider;
	}

}