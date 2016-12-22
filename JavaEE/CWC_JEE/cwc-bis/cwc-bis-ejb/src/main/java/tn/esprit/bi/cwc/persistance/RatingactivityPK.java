package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the ratingactivities database table.
 * 
 */
@Embeddable
public class RatingactivityPK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	
	private int activityId;

	
	private String employeId;

	public RatingactivityPK() {
	}
	
	public RatingactivityPK(int activityId, String employeId) {
		super();
		this.activityId = activityId;
		this.employeId = employeId;
	}

	public int getActivityId() {
		return this.activityId;
	}
	public void setActivityId(int activityId) {
		this.activityId = activityId;
	}
	public String getEmployeId() {
		return this.employeId;
	}
	public void setEmployeId(String employeId) {
		this.employeId = employeId;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof RatingactivityPK)) {
			return false;
		}
		RatingactivityPK castOther = (RatingactivityPK)other;
		return 
			(this.activityId == castOther.activityId)
			&& this.employeId.equals(castOther.employeId);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.activityId;
		hash = hash * prime + this.employeId.hashCode();
		
		return hash;
	}
}