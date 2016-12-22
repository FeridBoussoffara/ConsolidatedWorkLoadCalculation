package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the providers database table.
 * 
 */
@Entity
@Table(name="providers")
@NamedQuery(name="Provider.findAll", query="SELECT p FROM Provider p")
public class Provider implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int providerId;

	@Lob
	private String adresse;

	@Lob
	private String email;

	@Lob
	private String logo;

	@Lob
	private String name;

	@Lob
	private String numTel;

	//bi-directional many-to-one association to Orderpurchas
	@OneToMany(mappedBy="provider")
	private List<Orderpurchas> orderpurchases;

	public Provider() {
	}

	public int getProviderId() {
		return this.providerId;
	}

	public void setProviderId(int providerId) {
		this.providerId = providerId;
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

	public String getLogo() {
		return this.logo;
	}

	public void setLogo(String logo) {
		this.logo = logo;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNumTel() {
		return this.numTel;
	}

	public void setNumTel(String numTel) {
		this.numTel = numTel;
	}

	public List<Orderpurchas> getOrderpurchases() {
		return this.orderpurchases;
	}

	public void setOrderpurchases(List<Orderpurchas> orderpurchases) {
		this.orderpurchases = orderpurchases;
	}

	public Orderpurchas addOrderpurchas(Orderpurchas orderpurchas) {
		getOrderpurchases().add(orderpurchas);
		orderpurchas.setProvider(this);

		return orderpurchas;
	}

	public Orderpurchas removeOrderpurchas(Orderpurchas orderpurchas) {
		getOrderpurchases().remove(orderpurchas);
		orderpurchas.setProvider(null);

		return orderpurchas;
	}

}