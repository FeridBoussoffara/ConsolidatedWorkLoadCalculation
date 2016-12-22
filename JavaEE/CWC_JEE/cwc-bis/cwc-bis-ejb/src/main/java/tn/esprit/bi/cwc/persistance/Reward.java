package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the rewards database table.
 * 
 */
@Entity
@Table(name="rewards")
@NamedQuery(name="Reward.findAll", query="SELECT r FROM Reward r")
public class Reward implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int rewardId;

	@Temporal(TemporalType.TIMESTAMP)
	private Date dateReward;

	@Lob
	private String rewardType;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="EmployeeId")
	private Aspnetuser aspnetuser;

	public Reward() {
	}

	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		this.rewardId = rewardId;
	}

	public Date getDateReward() {
		return this.dateReward;
	}

	public void setDateReward(Date dateReward) {
		this.dateReward = dateReward;
	}

	public String getRewardType() {
		return this.rewardType;
	}

	public void setRewardType(String rewardType) {
		this.rewardType = rewardType;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

}