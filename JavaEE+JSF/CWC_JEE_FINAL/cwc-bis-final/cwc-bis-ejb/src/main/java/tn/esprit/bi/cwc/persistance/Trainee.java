package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import javax.persistence.*;
import java.util.*;

/**
 * Entity implementation class for Entity: Trainee
 *
 */
@Entity
public class Trainee implements Serializable {

	public List<Internship> getInternships() {
		return internships;
	}
	public void setInternships(List<Internship> internships) {
		this.internships = internships;
	}

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private Integer TraineeId;
	@Override
	public String toString() {
		return "Trainee [FirstName=" + FirstName + ", LastName=" + LastName + "]";
	}

	private String Adresse;
	private String CIN;
	private String Email;
	private String FirstName;
	private String LastName;
	private String Photo;
	@ManyToMany(fetch = FetchType.EAGER,mappedBy="trainees",cascade={CascadeType.MERGE,CascadeType.PERSIST}) 
	List<Internship> internships;
	private static final long serialVersionUID = 1L;

	public Trainee() {
		super();
	}   
	public Integer getTraineeId() {
		return this.TraineeId;
	}
	public void addInternship(Internship internship)
	{
		internships.add(internship);
	}
	public void setTraineeId(Integer TraineeId) {
		this.TraineeId = TraineeId;
	}   
	public String getAdresse() {
		return this.Adresse;
	}

	public void setAdresse(String Adresse) {
		this.Adresse = Adresse;
	}   
	public String getCIN() {
		return this.CIN;
	}

	public void setCIN(String CIN) {
		this.CIN = CIN;
	}   
	public String getEmail() {
		return this.Email;
	}

	public void setEmail(String Email) {
		this.Email = Email;
	}   
	public String getFirstName() {
		return this.FirstName;
	}

	public void setFirstName(String FirstName) {
		this.FirstName = FirstName;
	}   
	public String getLastName() {
		return this.LastName;
	}

	public void setLastName(String LastName) {
		this.LastName = LastName;
	}   
	
	
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((CIN == null) ? 0 : CIN.hashCode());
		return result;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Trainee other = (Trainee) obj;
		if (CIN == null) {
			if (other.CIN != null)
				return false;
		} else if (!CIN.equals(other.CIN))
			return false;
		return true;
	}
	public String getPhoto() {
		return this.Photo;
	}

	public void setPhoto(String Photo) {
		this.Photo = Photo;
	}
   
}
