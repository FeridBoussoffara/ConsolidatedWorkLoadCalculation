package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the erpapps database table.
 * 
 */
@Entity
@Table(name = "erpapps")
@NamedQuery(name = "Erpapp.findAll", query = "SELECT e FROM Erpapp e")
public class Erpapp implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int ERPAppId;

	@Lob
	private String fonder;

	@Lob
	private String logo;

	@Lob
	private String name;

	private TypeApp type;

	// bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name = "Administrator_Id")
	private Aspnetuser aspnetuser;

	public Erpapp() {
	}

	public int getERPAppId() {
		return this.ERPAppId;
	}

	public void setERPAppId(int ERPAppId) {
		this.ERPAppId = ERPAppId;
	}

	public String getFonder() {
		return this.fonder;
	}

	public void setFonder(String fonder) {
		this.fonder = fonder;
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

	public TypeApp getType() {
		return type;
	}

	public void setType(TypeApp type) {
		this.type = type;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

	public enum TypeApp {
		Banking, Agriculture, ComputerServices, Company
	}

	@Override
	public String toString() {
		return "Erpapp [ERPAppId=" + ERPAppId + ", fonder=" + fonder + ", logo=" + logo + ", name=" + name + ", type="
				+ type + ", aspnetuser=" + aspnetuser + "]";
	}
	
}
