package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the ratingactivities database table.
 * 
 */
@Entity
@Table(name="ratingactivities")
@NamedQuery(name="Ratingactivity.findAll", query="SELECT r FROM Ratingactivity r")
public class Ratingactivity implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private RatingactivityPK id;

	private float note;

	//bi-directional many-to-one association to Activity
	@ManyToOne
	@JoinColumn(name="ActivityId",referencedColumnName = "activityId", insertable = false, updatable = false)
	private Activity activity;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="EmployeId", referencedColumnName = "id", insertable = false, updatable = false)
	private Aspnetuser aspnetuser;

	public Ratingactivity() {
	}

	
	public Ratingactivity(float note, Activity activity, Aspnetuser aspnetuser) {
		super();
		this.id=new RatingactivityPK(activity.getActivityId(), aspnetuser.getId());
		this.note = note;
		this.activity = activity;
		this.aspnetuser = aspnetuser;
	}


	public RatingactivityPK getId() {
		return this.id;
	}

	public void setId(RatingactivityPK id) {
		this.id = id;
	}

	public float getNote() {
		return this.note;
	}

	public void setNote(float note) {
		this.note = note;
	}

	public Activity getActivity() {
		return this.activity;
	}

	public void setActivity(Activity activity) {
		this.activity = activity;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

}