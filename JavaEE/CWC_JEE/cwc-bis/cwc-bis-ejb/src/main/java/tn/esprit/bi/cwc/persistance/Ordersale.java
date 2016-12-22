package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ordersales database table.
 * 
 */
@Entity
@Table(name="ordersales")
@NamedQuery(name="Ordersale.findAll", query="SELECT o FROM Ordersale o")
public class Ordersale implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private OrdersalePK id;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateOrder;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateSale;

	private int quantity;

	//bi-directional many-to-one association to Customer
	@ManyToOne
	@JoinColumn(name="CustomerId")
	private Customer customer;

	//bi-directional many-to-one association to Product
	@ManyToOne
	@JoinColumn(name="ProductId")
	private Product product;

	public Ordersale() {
	}

	public OrdersalePK getId() {
		return this.id;
	}

	public void setId(OrdersalePK id) {
		this.id = id;
	}

	public Date getDateOrder() {
		return this.dateOrder;
	}

	public void setDateOrder(Date dateOrder) {
		this.dateOrder = dateOrder;
	}

	public Date getDateSale() {
		return this.dateSale;
	}

	public void setDateSale(Date dateSale) {
		this.dateSale = dateSale;
	}

	public int getQuantity() {
		return this.quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public Customer getCustomer() {
		return this.customer;
	}

	public void setCustomer(Customer customer) {
		this.customer = customer;
	}

	public Product getProduct() {
		return this.product;
	}

	public void setProduct(Product product) {
		this.product = product;
	}

}