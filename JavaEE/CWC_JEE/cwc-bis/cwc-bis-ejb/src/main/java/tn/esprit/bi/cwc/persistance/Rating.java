package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ratings database table.
 * 
 */
@Entity
@Table(name="ratings")
@NamedQuery(name="Rating.findAll", query="SELECT r FROM Rating r")
public class Rating implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int ratingId;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateRating;

	private float number;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="TeamLeaderId")
	private Aspnetuser aspnetuser;

	public Rating() {
	}

	public int getRatingId() {
		return this.ratingId;
	}

	public void setRatingId(int ratingId) {
		this.ratingId = ratingId;
	}

	public Date getDateRating() {
		return this.dateRating;
	}

	public void setDateRating(Date dateRating) {
		this.dateRating = dateRating;
	}

	public float getNumber() {
		return this.number;
	}

	public void setNumber(float number) {
		this.number = number;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

}