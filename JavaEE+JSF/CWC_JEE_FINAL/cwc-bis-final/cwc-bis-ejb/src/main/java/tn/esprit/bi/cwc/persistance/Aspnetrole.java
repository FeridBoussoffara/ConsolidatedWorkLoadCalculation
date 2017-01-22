package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the aspnetroles database table.
 * 
 */
@Entity
@Table(name="aspnetroles")
@NamedQuery(name="Aspnetrole.findAll", query="SELECT a FROM Aspnetrole a")
public class Aspnetrole implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private String id;

	private String name;

	//bi-directional many-to-many association to Aspnetuser
	@ManyToMany(mappedBy="aspnetroles")
	private List<Aspnetuser> aspnetusers;

	public Aspnetrole() {
	}

	public String getId() {
		return this.id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public List<Aspnetuser> getAspnetusers() {
		return this.aspnetusers;
	}

	public void setAspnetusers(List<Aspnetuser> aspnetusers) {
		this.aspnetusers = aspnetusers;
	}

}