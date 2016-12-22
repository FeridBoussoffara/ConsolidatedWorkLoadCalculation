package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the erpapps database table.
 * 
 */
@Entity
@Table(name="erpapps")
@NamedQuery(name="Erpapp.findAll", query="SELECT e FROM Erpapp e")
public class Erpapp implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int ERPAppId;

	@Lob
	private String fonder;

	@Lob
	private String logo;

	@Lob
	private String name;

	private int type;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="Administrator_Id")
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

	public int getType() {
		return this.type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

}