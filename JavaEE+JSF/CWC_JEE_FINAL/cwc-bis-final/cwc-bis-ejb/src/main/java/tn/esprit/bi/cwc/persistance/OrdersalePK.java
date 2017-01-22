package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the ordersales database table.
 * 
 */
@Embeddable
public class OrdersalePK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	
	private int productId;
 
	private int customerId;

	public OrdersalePK() {
	}
	
	public OrdersalePK(int productId, int customerId) { 
		this.productId = productId;
		this.customerId = customerId;
	}

	public int getProductId() {
		return this.productId;
	}
	public void setProductId(int productId) {
		this.productId = productId;
	}
	public int getCustomerId() {
		return this.customerId;
	}
	public void setCustomerId(int customerId) {
		this.customerId = customerId;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof OrdersalePK)) {
			return false;
		}
		OrdersalePK castOther = (OrdersalePK)other;
		return 
			(this.productId == castOther.productId)
			&& (this.customerId == castOther.customerId);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.productId;
		hash = hash * prime + this.customerId;
		
		return hash;
	}

	@Override
	public String toString() {
		return "OrdersalePK [productId=" + productId + ", customerId=" + customerId + "]";
	}
	
}