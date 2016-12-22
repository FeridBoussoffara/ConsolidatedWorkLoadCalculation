package activityMbeans;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.model.SelectItem;

import org.primefaces.event.SelectEvent;

import tn.esprit.bi.cwc.interfaces.ActivityServiceLocal;
import tn.esprit.bi.cwc.persistance.Activity;
import tn.esprit.bi.cwc.persistance.Aspnetuser;

@ManagedBean
@ViewScoped
public class ActivityBean {
	@EJB
	private ActivityServiceLocal activityServiceLocal;
	private Activity activity = new Activity();
	private Activity Selectedactivity = new Activity();
	private List<Activity> activities = new ArrayList<>();
	private List<Aspnetuser> employees = new ArrayList<>();
	private Boolean displayForm2 = false;
	private Boolean displayForm1 = true;
	private Boolean displayForm3=false;
	private Boolean displayForm4=false;

	private List<SelectItem> SelectTrainer;
	private List<SelectItem> filter;
	private String selectedTrainerId = "-1";
	private Integer TotalEmployees=0;
	@PostConstruct
	public void init() {
		activities = activityServiceLocal.getAllActivites();
		List<Aspnetuser> Trainers = activityServiceLocal.getAllEmployees();
		SelectTrainer = new ArrayList<SelectItem>(Trainers.size());
		for (Aspnetuser employee : Trainers) {
			SelectTrainer.add(new SelectItem(employee.getId(), employee.getFirstName() + "," + employee.getLastName()));
		}
		filter = new ArrayList<SelectItem>(Trainers.size()+1);
		filter.add(new SelectItem("", "Select"));
		for (Aspnetuser employee : Trainers) {
			filter.add(new SelectItem(employee.getFirstName() + "," + employee.getLastName(), employee.getFirstName() + "," + employee.getLastName()));
		}
		
	}

	public String doAddActivity() {

		Selectedactivity.setDateActivity(new Date(2015 - 12 - 1));
		activityServiceLocal.addActivity(Selectedactivity, selectedTrainerId);
		displayForm1 = true;
		displayForm2 = false;
		activities = activityServiceLocal.getAllActivites();
		return null;

	}
	public String checkEmployees() {
		displayForm1 = false;
		displayForm4 = true;
		employees=activityServiceLocal.getAllEmployeesPerActivity(Selectedactivity.getActivityId());
		//TotalEmployees=activityServiceLocal.nbtotalEmployees();
		return null;
	}

	public String selectActivity() {
		displayForm1 = false;
		displayForm2 = true;
		return null;
	}
	public String SubscribeEmployeeActivity() {
		displayForm1 = false;
		displayForm3 = true;
		return null;
	}
	
	public String doSubscribeEmployeeActivity() {

	
		
		activityServiceLocal.SubscribeEmployeeToActivity(selectedTrainerId, Selectedactivity.getActivityId());
		//Aspnetuser mail= activityServiceLocal.FindEmployeeById(selectedTrainerId);
		displayForm1 = true;
		displayForm3 = false;
		activities = activityServiceLocal.getAllActivites();
		return "";

	}

	public String doDeleteActivity() {
		activityServiceLocal.DeleteActivity(Selectedactivity);
		activities = activityServiceLocal.getAllActivites();
		return cancel();
	}

	public String cancel() {
		displayForm1 = true;
		displayForm2 = false;
		Selectedactivity = new Activity();
		return null;
	}
	public String cancel2() {
		displayForm1 = true;
		displayForm3 = false;
		Selectedactivity = new Activity();
		return null;
	}
	
	public String back() {
		displayForm1 = true;
		displayForm4 = false;
		Selectedactivity = new Activity();
		return null;
	}
	
	public void onRowSelect(SelectEvent event) {
	
		displayForm1 = false;
		displayForm2 = true;
	}

	public double GetMeanRating(int id) {
		return activityServiceLocal.MeanRatingByActivity(id);
	}
	
	public Activity GetBestActivity() {
		return activityServiceLocal.getBestRatedActivity();
	}

	public ActivityServiceLocal getActivityServiceLocal() {
		return activityServiceLocal;
	}

	public void setActivityServiceLocal(ActivityServiceLocal activityServiceLocal) {
		this.activityServiceLocal = activityServiceLocal;
	}

	public Activity getActivity() {
		return activity;
	}

	public void setActivity(Activity activity) {
		this.activity = activity;
	}

	public List<Activity> getActivities() {
		return activities;
	}

	public void setActivities(List<Activity> activities) {
		this.activities = activities;
	}

	public Boolean getDisplayForm2() {
		return displayForm2;
	}

	public void setDisplayForm2(Boolean displayForm2) {
		this.displayForm2 = displayForm2;
	}

	public Boolean getDisplayForm1() {
		return displayForm1;
	}

	public void setDisplayForm1(Boolean displayForm1) {
		this.displayForm1 = displayForm1;
	}

	public Activity getSelectedactivity() {
		return Selectedactivity;
	}

	public void setSelectedactivity(Activity selectedactivity) {
		Selectedactivity = selectedactivity;
	}

	public List<SelectItem> getSelectTrainer() {
		return SelectTrainer;
	}

	public void setSelectTrainer(List<SelectItem> selectTrainer) {
		SelectTrainer = selectTrainer;
	}

	public String getSelectedTrainerId() {
		return selectedTrainerId;
	}

	public void setSelectedTrainerId(String selectedTrainerId) {
		this.selectedTrainerId = selectedTrainerId;
	}

	public Boolean getDisplayForm3() {
		return displayForm3;
	}

	public void setDisplayForm3(Boolean displayForm3) {
		this.displayForm3 = displayForm3;
	}

	public Boolean getDisplayForm4() {
		return displayForm4;
	}

	public void setDisplayForm4(Boolean displayForm4) {
		this.displayForm4 = displayForm4;
	}

	public List<Aspnetuser> getEmployees() {
		return employees;
	}

	public void setEmployees(List<Aspnetuser> employees) {
		this.employees = employees;
	}

	public Integer getTotalEmployees() {
		return TotalEmployees;
	}

	public void setTotalEmployees(Integer totalEmployees) {
		TotalEmployees = totalEmployees;
	}

	public List<SelectItem> getFilter() {
		return filter;
	}

	public void setFilter(List<SelectItem> filter) {
		this.filter = filter;
	}
	
	

}
