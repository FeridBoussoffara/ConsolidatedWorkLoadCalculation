package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Activity;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Task;

@Local
public interface ActivityServiceLocal {
	void addActivity(Activity activity, String idTrainer);

	void UpdateActivity(Activity activity);

	Activity FindActivityById(int id);

	void DeleteActivityById(int id);

	void DeleteActivity(Activity activity);

	Aspnetuser FindEmployeeById(String id);

	public Task getTask(int id);

	void SubscribeEmployeeToActivity(String idEmployee, int idActivity);

	List<Activity> getActivitiesByEmployee(String idEmployee);

	void RateActivity(float note, String idEmployee, int idActivity);

	double MeanRatingByActivity(int idActivity);

	Activity  getBestRatedActivity();
	
	List<Aspnetuser> getAllEmployees();
	
	List<Activity> getAllActivites();
	
	List <Aspnetuser> getAllEmployeesPerActivity(int id);
	
	Integer nbtotalEmployees();
	
	List<Activity> getActivitiesByTrainer(String id);

}
