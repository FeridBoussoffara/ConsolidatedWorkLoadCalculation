package activityMbeans;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;


import tn.esprit.bi.cwc.interfaces.ActivityServiceLocal;
import tn.esprit.bi.cwc.persistance.Activity;


@ManagedBean
@ViewScoped
public class ActivityEmployeBean {
	@EJB
	private ActivityServiceLocal activityServiceLocal;
	private Activity activity = new Activity();
	private Activity Selectedactivity = new Activity();
	private List<Activity> activities = new ArrayList<>();
	private Boolean displayForm2 = false;
	private Boolean displayForm1 = true;
	private float	Rating=0;
	
	
	@PostConstruct
	public void init() {
		activities = activityServiceLocal.getActivitiesByEmployee("22960cac-8237-4cdf-b5a2-b7ae2c5f02ae");
		
	}
	
	public String doRateActivity() {

		
		activityServiceLocal.RateActivity(Rating, "22960cac-8237-4cdf-b5a2-b7ae2c5f02ae", Selectedactivity.getActivityId());
		displayForm1 = true;
		displayForm2 = false;
		activities = activityServiceLocal.getActivitiesByEmployee("22960cac-8237-4cdf-b5a2-b7ae2c5f02ae");
		Rating=0;
		return "";

	}
	
	public String cancel() {
		displayForm1 = true;
		displayForm2 = false;
		Selectedactivity = new Activity();
		return "";
	}
	
	public String rateActivity() {
		displayForm1 = false;
		displayForm2 = true;
		return null;
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
	public Activity getSelectedactivity() {
		return Selectedactivity;
	}
	public void setSelectedactivity(Activity selectedactivity) {
		Selectedactivity = selectedactivity;
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

	public float getRating() {
		return Rating;
	}

	public void setRating(float rating) {
		Rating = rating;
	}
	
}
