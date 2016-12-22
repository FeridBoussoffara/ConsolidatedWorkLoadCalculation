package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the aspnetusers database table.
 * 
 */
@Entity
@Table(name="aspnetusers")
@NamedQuery(name="Aspnetuser.findAll", query="SELECT a FROM Aspnetuser a")
public class Aspnetuser implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private String id;

	private int accessFailedCount;

	@Lob
	private String adresse;

	@Lob
	private String cin;

	private String discriminator;

	private String email;

	private byte emailConfirmed;

	@Lob
	private String firstName;

	@Temporal(TemporalType.TIMESTAMP)
	private Date hireDate;

	@Lob
	private String lastName;

	private byte lockoutEnabled;

	@Temporal(TemporalType.TIMESTAMP)
	private Date lockoutEndDateUtc;

	@Lob
	private String passwordHash;

	@Lob
	private String phoneNumber;

	private byte phoneNumberConfirmed;

	@Lob
	private String photo;

	@Lob
	private String securityStamp;

	private byte twoFactorEnabled;

	private String type;

	private String userName;

	//bi-directional many-to-one association to Activity
	@OneToMany(mappedBy="aspnetuser")
	private List<Activity> activities;

	//bi-directional many-to-one association to Aspnetuserclaim
	@OneToMany(mappedBy="aspnetuser")
	private List<Aspnetuserclaim> aspnetuserclaims;

	//bi-directional many-to-one association to Aspnetuserlogin
	@OneToMany(mappedBy="aspnetuser")
	private List<Aspnetuserlogin> aspnetuserlogins;

	//bi-directional many-to-many association to Aspnetrole
	@ManyToMany
	@JoinTable(
		name="aspnetuserroles"
		, joinColumns={
			@JoinColumn(name="UserId")
			}
		, inverseJoinColumns={
			@JoinColumn(name="RoleId")
			}
		)
	private List<Aspnetrole> aspnetroles;

	//bi-directional many-to-one association to Project
	@ManyToOne
	@JoinColumn(name="GroupProject_ProjectId")
	private Project project;

	//bi-directional many-to-one association to Assignement
	@OneToMany(mappedBy="aspnetuser")
	private List<Assignement> assignements;

	//bi-directional many-to-one association to Attendance
	@OneToMany(mappedBy="aspnetuser")
	private List<Attendance> attendances;

	//bi-directional many-to-one association to Erpapp
	@OneToMany(mappedBy="aspnetuser")
	private List<Erpapp> erpapps;

	//bi-directional many-to-one association to Leave
	@OneToMany(mappedBy="aspnetuser")
	private List<Leave> leaves;

	//bi-directional many-to-one association to Payslip
	@OneToMany(mappedBy="aspnetuser")
	private List<Payslip> payslips;

	//bi-directional many-to-one association to Project
	@OneToMany(mappedBy="aspnetuser1")
	private List<Project> projects1;

	//bi-directional many-to-one association to Project
	@OneToMany(mappedBy="aspnetuser2")
	private List<Project> projects2;

	//bi-directional many-to-one association to Ratingactivity
	@OneToMany(mappedBy="aspnetuser")
	private List<Ratingactivity> ratingactivities;

	//bi-directional many-to-one association to Rating
	@OneToMany(mappedBy="aspnetuser")
	private List<Rating> ratings;

	//bi-directional many-to-one association to Reward
	@OneToMany(mappedBy="aspnetuser")
	private List<Reward> rewards;

	//bi-directional many-to-one association to Task
	@OneToMany(mappedBy="aspnetuser")
	private List<Task> tasks;

	public Aspnetuser() {
	}

	public String getId() {
		return this.id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public int getAccessFailedCount() {
		return this.accessFailedCount;
	}

	public void setAccessFailedCount(int accessFailedCount) {
		this.accessFailedCount = accessFailedCount;
	}

	public String getAdresse() {
		return this.adresse;
	}

	public void setAdresse(String adresse) {
		this.adresse = adresse;
	}

	public String getCin() {
		return this.cin;
	}

	public void setCin(String cin) {
		this.cin = cin;
	}

	public String getDiscriminator() {
		return this.discriminator;
	}

	public void setDiscriminator(String discriminator) {
		this.discriminator = discriminator;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public byte getEmailConfirmed() {
		return this.emailConfirmed;
	}

	public void setEmailConfirmed(byte emailConfirmed) {
		this.emailConfirmed = emailConfirmed;
	}

	public String getFirstName() {
		return this.firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public Date getHireDate() {
		return this.hireDate;
	}

	public void setHireDate(Date hireDate) {
		this.hireDate = hireDate;
	}

	public String getLastName() {
		return this.lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public byte getLockoutEnabled() {
		return this.lockoutEnabled;
	}

	public void setLockoutEnabled(byte lockoutEnabled) {
		this.lockoutEnabled = lockoutEnabled;
	}

	public Date getLockoutEndDateUtc() {
		return this.lockoutEndDateUtc;
	}

	public void setLockoutEndDateUtc(Date lockoutEndDateUtc) {
		this.lockoutEndDateUtc = lockoutEndDateUtc;
	}

	public String getPasswordHash() {
		return this.passwordHash;
	}

	public void setPasswordHash(String passwordHash) {
		this.passwordHash = passwordHash;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public byte getPhoneNumberConfirmed() {
		return this.phoneNumberConfirmed;
	}

	public void setPhoneNumberConfirmed(byte phoneNumberConfirmed) {
		this.phoneNumberConfirmed = phoneNumberConfirmed;
	}

	public String getPhoto() {
		return this.photo;
	}

	public void setPhoto(String photo) {
		this.photo = photo;
	}

	public String getSecurityStamp() {
		return this.securityStamp;
	}

	public void setSecurityStamp(String securityStamp) {
		this.securityStamp = securityStamp;
	}

	public byte getTwoFactorEnabled() {
		return this.twoFactorEnabled;
	}

	public void setTwoFactorEnabled(byte twoFactorEnabled) {
		this.twoFactorEnabled = twoFactorEnabled;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getUserName() {
		return this.userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public List<Activity> getActivities() {
		return this.activities;
	}

	public void setActivities(List<Activity> activities) {
		this.activities = activities;
	}

	public Activity addActivity(Activity activity) {
		getActivities().add(activity);
		activity.setAspnetuser(this);

		return activity;
	}

	public Activity removeActivity(Activity activity) {
		getActivities().remove(activity);
		activity.setAspnetuser(null);

		return activity;
	}

	public List<Aspnetuserclaim> getAspnetuserclaims() {
		return this.aspnetuserclaims;
	}

	public void setAspnetuserclaims(List<Aspnetuserclaim> aspnetuserclaims) {
		this.aspnetuserclaims = aspnetuserclaims;
	}

	public Aspnetuserclaim addAspnetuserclaim(Aspnetuserclaim aspnetuserclaim) {
		getAspnetuserclaims().add(aspnetuserclaim);
		aspnetuserclaim.setAspnetuser(this);

		return aspnetuserclaim;
	}

	public Aspnetuserclaim removeAspnetuserclaim(Aspnetuserclaim aspnetuserclaim) {
		getAspnetuserclaims().remove(aspnetuserclaim);
		aspnetuserclaim.setAspnetuser(null);

		return aspnetuserclaim;
	}

	public List<Aspnetuserlogin> getAspnetuserlogins() {
		return this.aspnetuserlogins;
	}

	public void setAspnetuserlogins(List<Aspnetuserlogin> aspnetuserlogins) {
		this.aspnetuserlogins = aspnetuserlogins;
	}

	public Aspnetuserlogin addAspnetuserlogin(Aspnetuserlogin aspnetuserlogin) {
		getAspnetuserlogins().add(aspnetuserlogin);
		aspnetuserlogin.setAspnetuser(this);

		return aspnetuserlogin;
	}

	public Aspnetuserlogin removeAspnetuserlogin(Aspnetuserlogin aspnetuserlogin) {
		getAspnetuserlogins().remove(aspnetuserlogin);
		aspnetuserlogin.setAspnetuser(null);

		return aspnetuserlogin;
	}

	public List<Aspnetrole> getAspnetroles() {
		return this.aspnetroles;
	}

	public void setAspnetroles(List<Aspnetrole> aspnetroles) {
		this.aspnetroles = aspnetroles;
	}

	public Project getProject() {
		return this.project;
	}

	public void setProject(Project project) {
		this.project = project;
	}

	public List<Assignement> getAssignements() {
		return this.assignements;
	}

	public void setAssignements(List<Assignement> assignements) {
		this.assignements = assignements;
	}

	public Assignement addAssignement(Assignement assignement) {
		getAssignements().add(assignement);
		assignement.setAspnetuser(this);

		return assignement;
	}

	public Assignement removeAssignement(Assignement assignement) {
		getAssignements().remove(assignement);
		assignement.setAspnetuser(null);

		return assignement;
	}

	public List<Attendance> getAttendances() {
		return this.attendances;
	}

	public void setAttendances(List<Attendance> attendances) {
		this.attendances = attendances;
	}

	public Attendance addAttendance(Attendance attendance) {
		getAttendances().add(attendance);
		attendance.setAspnetuser(this);

		return attendance;
	}

	public Attendance removeAttendance(Attendance attendance) {
		getAttendances().remove(attendance);
		attendance.setAspnetuser(null);

		return attendance;
	}

	public List<Erpapp> getErpapps() {
		return this.erpapps;
	}

	public void setErpapps(List<Erpapp> erpapps) {
		this.erpapps = erpapps;
	}

	public Erpapp addErpapp(Erpapp erpapp) {
		getErpapps().add(erpapp);
		erpapp.setAspnetuser(this);

		return erpapp;
	}

	public Erpapp removeErpapp(Erpapp erpapp) {
		getErpapps().remove(erpapp);
		erpapp.setAspnetuser(null);

		return erpapp;
	}

	public List<Leave> getLeaves() {
		return this.leaves;
	}

	public void setLeaves(List<Leave> leaves) {
		this.leaves = leaves;
	}

	public Leave addLeave(Leave leave) {
		getLeaves().add(leave);
		leave.setAspnetuser(this);

		return leave;
	}

	public Leave removeLeave(Leave leave) {
		getLeaves().remove(leave);
		leave.setAspnetuser(null);

		return leave;
	}

	public List<Payslip> getPayslips() {
		return this.payslips;
	}

	public void setPayslips(List<Payslip> payslips) {
		this.payslips = payslips;
	}

	public Payslip addPayslip(Payslip payslip) {
		getPayslips().add(payslip);
		payslip.setAspnetuser(this);

		return payslip;
	}

	public Payslip removePayslip(Payslip payslip) {
		getPayslips().remove(payslip);
		payslip.setAspnetuser(null);

		return payslip;
	}

	public List<Project> getProjects1() {
		return this.projects1;
	}

	public void setProjects1(List<Project> projects1) {
		this.projects1 = projects1;
	}

	public Project addProjects1(Project projects1) {
		getProjects1().add(projects1);
		projects1.setAspnetuser1(this);

		return projects1;
	}

	public Project removeProjects1(Project projects1) {
		getProjects1().remove(projects1);
		projects1.setAspnetuser1(null);

		return projects1;
	}

	public List<Project> getProjects2() {
		return this.projects2;
	}

	public void setProjects2(List<Project> projects2) {
		this.projects2 = projects2;
	}

	public Project addProjects2(Project projects2) {
		getProjects2().add(projects2);
		projects2.setAspnetuser2(this);

		return projects2;
	}

	public Project removeProjects2(Project projects2) {
		getProjects2().remove(projects2);
		projects2.setAspnetuser2(null);

		return projects2;
	}

	public List<Ratingactivity> getRatingactivities() {
		return this.ratingactivities;
	}

	public void setRatingactivities(List<Ratingactivity> ratingactivities) {
		this.ratingactivities = ratingactivities;
	}

	public Ratingactivity addRatingactivity(Ratingactivity ratingactivity) {
		getRatingactivities().add(ratingactivity);
		ratingactivity.setAspnetuser(this);

		return ratingactivity;
	}

	public Ratingactivity removeRatingactivity(Ratingactivity ratingactivity) {
		getRatingactivities().remove(ratingactivity);
		ratingactivity.setAspnetuser(null);

		return ratingactivity;
	}

	public List<Rating> getRatings() {
		return this.ratings;
	}

	public void setRatings(List<Rating> ratings) {
		this.ratings = ratings;
	}

	public Rating addRating(Rating rating) {
		getRatings().add(rating);
		rating.setAspnetuser(this);

		return rating;
	}

	public Rating removeRating(Rating rating) {
		getRatings().remove(rating);
		rating.setAspnetuser(null);

		return rating;
	}

	public List<Reward> getRewards() {
		return this.rewards;
	}

	public void setRewards(List<Reward> rewards) {
		this.rewards = rewards;
	}

	public Reward addReward(Reward reward) {
		getRewards().add(reward);
		reward.setAspnetuser(this);

		return reward;
	}

	public Reward removeReward(Reward reward) {
		getRewards().remove(reward);
		reward.setAspnetuser(null);

		return reward;
	}

	public List<Task> getTasks() {
		return this.tasks;
	}

	public void setTasks(List<Task> tasks) {
		this.tasks = tasks;
	}

	public Task addTask(Task task) {
		getTasks().add(task);
		task.setAspnetuser(this);

		return task;
	}

	public Task removeTask(Task task) {
		getTasks().remove(task);
		task.setAspnetuser(null);

		return task;
	}

}