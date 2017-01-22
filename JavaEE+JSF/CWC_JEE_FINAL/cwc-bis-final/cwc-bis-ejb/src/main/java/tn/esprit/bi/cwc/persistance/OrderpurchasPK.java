package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the orderpurchases database table.
 * 
 */
@Embeddable
public class OrderpurchasPK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	@Column(insertable=false, updatable=false)
	private int productId;

	@Column(insertable=false, updatable=false)
	private int providerId;

	public OrderpurchasPK() {
	}
	public int getProductId() {
		return this.productId;
	}
	public void setProductId(int productId) {
		this.productId = productId;
	}
	public int getProviderId() {
		return this.providerId;
	}
	public void setProviderId(int providerId) {
		this.providerId = providerId;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof OrderpurchasPK)) {
			return false;
		}
		OrderpurchasPK castOther = (OrderpurchasPK)other;
		return 
			(this.productId == castOther.productId)
			&& (this.providerId == castOther.providerId);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.productId;
		hash = hash * prime + this.providerId;
		
		return hash;
	}
}