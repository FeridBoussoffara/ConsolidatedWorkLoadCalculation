package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the projects database table.
 * 
 */
@Entity
@Table(name="projects")
@NamedQuery(name="Project.findAll", query="SELECT p FROM Project p")
public class Project implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private int projectId;

	private float budget;

	private int category;

	@Temporal(TemporalType.TIMESTAMP)
	private Date endDate;

	@Lob
	private String name;

	@Temporal(TemporalType.TIMESTAMP)
	private Date startDate;

	@Lob
	private String state;

	private String type;

	private int typeProject;

	//bi-directional many-to-one association to Aspnetuser
	@OneToMany(mappedBy="project")
	private List<Aspnetuser> aspnetusers;

	//bi-directional many-to-one association to Assignement
	@OneToMany(mappedBy="project")
	private List<Assignement> assignements;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="SingleEmployeeId")
	private Aspnetuser aspnetuser1;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="TeamLeaderId")
	private Aspnetuser aspnetuser2;

	//bi-directional many-to-one association to Task
	@OneToMany(mappedBy="project")
	private List<Task> tasks;

	public Project() {
	}

	public int getProjectId() {
		return this.projectId;
	}

	public void setProjectId(int projectId) {
		this.projectId = projectId;
	}

	public float getBudget() {
		return this.budget;
	}

	public void setBudget(float budget) {
		this.budget = budget;
	}

	public int getCategory() {
		return this.category;
	}

	public void setCategory(int category) {
		this.category = category;
	}

	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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

	public int getTypeProject() {
		return this.typeProject;
	}

	public void setTypeProject(int typeProject) {
		this.typeProject = typeProject;
	}

	public List<Aspnetuser> getAspnetusers() {
		return this.aspnetusers;
	}

	public void setAspnetusers(List<Aspnetuser> aspnetusers) {
		this.aspnetusers = aspnetusers;
	}

	public Aspnetuser addAspnetuser(Aspnetuser aspnetuser) {
		getAspnetusers().add(aspnetuser);
		aspnetuser.setProject(this);

		return aspnetuser;
	}

	public Aspnetuser removeAspnetuser(Aspnetuser aspnetuser) {
		getAspnetusers().remove(aspnetuser);
		aspnetuser.setProject(null);

		return aspnetuser;
	}

	public List<Assignement> getAssignements() {
		return this.assignements;
	}

	public void setAssignements(List<Assignement> assignements) {
		this.assignements = assignements;
	}

	public Assignement addAssignement(Assignement assignement) {
		getAssignements().add(assignement);
		assignement.setProject(this);

		return assignement;
	}

	public Assignement removeAssignement(Assignement assignement) {
		getAssignements().remove(assignement);
		assignement.setProject(null);

		return assignement;
	}

	public Aspnetuser getAspnetuser1() {
		return this.aspnetuser1;
	}

	public void setAspnetuser1(Aspnetuser aspnetuser1) {
		this.aspnetuser1 = aspnetuser1;
	}

	public Aspnetuser getAspnetuser2() {
		return this.aspnetuser2;
	}

	public void setAspnetuser2(Aspnetuser aspnetuser2) {
		this.aspnetuser2 = aspnetuser2;
	}

	public List<Task> getTasks() {
		return this.tasks;
	}

	public void setTasks(List<Task> tasks) {
		this.tasks = tasks;
	}

	public Task addTask(Task task) {
		getTasks().add(task);
		task.setProject(this);

		return task;
	}

	public Task removeTask(Task task) {
		getTasks().remove(task);
		task.setProject(null);

		return task;
	}

}