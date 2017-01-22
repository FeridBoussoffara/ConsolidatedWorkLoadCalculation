package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the activities database table.
 * 
 */
@Entity
@Table(name="activities")
@NamedQuery(name="Activity.findAll", query="SELECT a FROM Activity a")
public class Activity implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int activityId;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateActivity;

	@Lob
	private String name;

	@Lob
	private String state;

	@Lob
	private String type;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="TrainerId")
	private Aspnetuser aspnetuser;

	//bi-directional many-to-one association to Ratingactivity
	@OneToMany(mappedBy="activity")
	private List<Ratingactivity> ratingactivities;

	public Activity() {
	}

	public int getActivityId() {
		return this.activityId;
	}

	public void setActivityId(int activityId) {
		this.activityId = activityId;
	}

	public Date getDateActivity() {
		return this.dateActivity;
	}

	public void setDateActivity(Date dateActivity) {
		this.dateActivity = dateActivity;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getState() {
		return this.state;
	}

	public void setState(String state) {
		this.state = state;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

	public List<Ratingactivity> getRatingactivities() {
		return this.ratingactivities;
	}

	public void setRatingactivities(List<Ratingactivity> ratingactivities) {
		this.ratingactivities = ratingactivities;
	}

	public Ratingactivity addRatingactivity(Ratingactivity ratingactivity) {
		getRatingactivities().add(ratingactivity);
		ratingactivity.setActivity(this);

		return ratingactivity;
	}

	public Ratingactivity removeRatingactivity(Ratingactivity ratingactivity) {
		getRatingactivities().remove(ratingactivity);
		ratingactivity.setActivity(null);

		return ratingactivity;
	}

}