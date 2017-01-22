package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.*;

/**
 * Entity implementation class for Entity: Internship
 *
 */
@Entity

public class Internship implements Serializable {

	   
	@Override
	public String toString() {
		return "Internship [InternshipId=" + InternshipId + ", Poste=" + Poste + ", Type=" + Type + "]";
	}

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private Integer InternshipId;
	private Date StartDate;
	private Date EndDate;
	private String Poste;
	private String Type;
	private Integer Rate;
	private String Status;
	@ManyToMany(fetch = FetchType.EAGER , cascade={CascadeType.MERGE,CascadeType.PERSIST})
	private List<Trainee> trainees= new ArrayList<Trainee>();
	
	public List<Trainee> getTrainees() {
		return trainees;
	}
	public void setTrainees(List<Trainee> trainees) {
		this.trainees = trainees;
	}
	public void addTrainee(Trainee trainee)
	{
		trainee.addInternship(this);
		trainees.add(trainee);
	}
	  public void removeTrainee(Trainee trainee) {
	        trainees.remove(trainee);
	        trainee.internships.remove(this);
	    }
	 
	    public void remove() {
	        for(Trainee trainee : new ArrayList<>(trainees)) {
	            removeTrainee(trainee);
	        }
	    }
	
	private static final long serialVersionUID = 1L;

	public Internship() {
		super();
	}   
	public Integer getInternshipId() {
		return this.InternshipId;
	}

	public void setInternshipId(Integer InternshipId) {
		this.InternshipId = InternshipId;
	}   
	public Date getStartDate() {
		return this.StartDate;
	}

	public void setStartDate(Date StartDate) {
		this.StartDate = StartDate;
	}   
	public Date getEndDate() {
		return this.EndDate;
	}

	public void setEndDate(Date EndDate) {
		this.EndDate = EndDate;
	}   
	public String getPoste() {
		return this.Poste;
	}

	public void setPoste(String Poste) {
		this.Poste = Poste;
	}   
	public String getType() {
		return this.Type;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((Poste == null) ? 0 : Poste.hashCode());
		result = prime * result + ((StartDate == null) ? 0 : StartDate.hashCode());
		result = prime * result + ((Type == null) ? 0 : Type.hashCode());
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
		Internship other = (Internship) obj;
		if (Poste == null) {
			if (other.Poste != null)
				return false;
		} else if (!Poste.equals(other.Poste))
			return false;
		if (StartDate == null) {
			if (other.StartDate != null)
				return false;
		} else if (!StartDate.equals(other.StartDate))
			return false;
		if (Type == null) {
			if (other.Type != null)
				return false;
		} else if (!Type.equals(other.Type))
			return false;
		return true;
	}
	public void setType(String Type) {
		this.Type = Type;
	}   
	public Integer getRate() {
		return this.Rate;
	}

	public void setRate(Integer Rate) {
		this.Rate = Rate;
	}   
	public String getStatus() {
		return this.Status;
	}

	public void setStatus(String Status) {
		this.Status = Status;
	}
   
}
