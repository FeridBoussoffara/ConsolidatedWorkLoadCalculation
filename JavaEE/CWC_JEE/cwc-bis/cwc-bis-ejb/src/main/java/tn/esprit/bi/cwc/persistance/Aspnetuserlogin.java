package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the aspnetuserlogins database table.
 * 
 */
@Entity
@Table(name="aspnetuserlogins")
@NamedQuery(name="Aspnetuserlogin.findAll", query="SELECT a FROM Aspnetuserlogin a")
public class Aspnetuserlogin implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private AspnetuserloginPK id;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="UserId")
	private Aspnetuser aspnetuser;

	public Aspnetuserlogin() {
	}

	public AspnetuserloginPK getId() {
		return this.id;
	}

	public void setId(AspnetuserloginPK id) {
		this.id = id;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

}