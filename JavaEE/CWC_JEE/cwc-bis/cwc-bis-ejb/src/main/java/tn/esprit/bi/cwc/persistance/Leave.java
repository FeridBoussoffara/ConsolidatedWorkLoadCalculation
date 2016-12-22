package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the leaves database table.
 * 
 */
@Entity
@Table(name="leaves")
@NamedQuery(name="Leave.findAll", query="SELECT l FROM Leave l")
public class Leave implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int leaveId;

	@Lob
	private String category;

	@Temporal(TemporalType.TIMESTAMP)
	private Date endDate;

	@Temporal(TemporalType.TIMESTAMP)
	private Date startDate;

	private byte state;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="EmployeeId")
	private Aspnetuser aspnetuser;

	public Leave() {
	}

	public int getLeaveId() {
		return this.leaveId;
	}

	public void setLeaveId(int leaveId) {
		this.leaveId = leaveId;
	}

	public String getCategory() {
		return this.category;
	}

	public void setCategory(String category) {
		this.category = category;
	}

	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public byte getState() {
		return this.state;
	}

	public void setState(byte state) {
		this.state = state;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

}