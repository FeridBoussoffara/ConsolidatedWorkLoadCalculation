package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the assignements database table.
 * 
 */
@Entity
@Table(name="assignements")
@NamedQuery(name="Assignement.findAll", query="SELECT a FROM Assignement a")
public class Assignement implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int assignementId;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateIn;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateOut;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="EmployeeId")
	private Aspnetuser aspnetuser;

	//bi-directional many-to-one association to Project
	@ManyToOne
	@JoinColumn(name="ProjectId")
	private Project project;

	public Assignement() {
	}

	public int getAssignementId() {
		return this.assignementId;
	}

	public void setAssignementId(int assignementId) {
		this.assignementId = assignementId;
	}

	public Date getDateIn() {
		return this.dateIn;
	}

	public void setDateIn(Date dateIn) {
		this.dateIn = dateIn;
	}

	public Date getDateOut() {
		return this.dateOut;
	}

	public void setDateOut(Date dateOut) {
		this.dateOut = dateOut;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

	public Project getProject() {
		return this.project;
	}

	public void setProject(Project project) {
		this.project = project;
	}

}