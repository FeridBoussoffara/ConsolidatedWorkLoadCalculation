package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the aspnetuserlogins database table.
 * 
 */
@Embeddable
public class AspnetuserloginPK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	private String loginProvider;

	private String providerKey;

	@Column(insertable=false, updatable=false)
	private String userId;

	public AspnetuserloginPK() {
	}
	public String getLoginProvider() {
		return this.loginProvider;
	}
	public void setLoginProvider(String loginProvider) {
		this.loginProvider = loginProvider;
	}
	public String getProviderKey() {
		return this.providerKey;
	}
	public void setProviderKey(String providerKey) {
		this.providerKey = providerKey;
	}
	public String getUserId() {
		return this.userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof AspnetuserloginPK)) {
			return false;
		}
		AspnetuserloginPK castOther = (AspnetuserloginPK)other;
		return 
			this.loginProvider.equals(castOther.loginProvider)
			&& this.providerKey.equals(castOther.providerKey)
			&& this.userId.equals(castOther.userId);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.loginProvider.hashCode();
		hash = hash * prime + this.providerKey.hashCode();
		hash = hash * prime + this.userId.hashCode();
		
		return hash;
	}
}