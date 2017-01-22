package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import tn.esprit.bi.cwc.persistance.Product;

/**
 * Entity implementation class for Entity: Software
 *
 */
@Entity

public class Software extends Product implements Serializable {

	
	private static final long serialVersionUID = 1L;
	private String Version ;
	private String Technology ;
	public Software() {
		super();
	}
	public String getVersion() {
		return Version;
	}
	public void setVersion(String version) {
		Version = version;
	}
	public String getTechnology() {
		return Technology;
	}
	public void setTechnology(String technology) {
		Technology = technology;
	}
	
   
}
