package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Activity;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Task;

@Remote
public interface ActivityServiceRemote {
	/******/
	void addActivity(Activity activity, String idTrainer);
	/******/
	void UpdateActivity(Activity activity);
	/******/
	Activity FindActivityById(int id);

	void DeleteActivityById(int id);
	/******/
	void DeleteActivity(Activity activity);

	Aspnetuser FindEmployeeById(String id);

	public Task getTask(int id);
	/*************/
	void SubscribeEmployeeToActivity(String idEmployee, int idActivity);
	/*****/
	List<Activity> getActivitiesByEmployee(String idEmployee);
	/***************/
	void RateActivity(float note, String idEmployee, int idActivity);

	/******/
	double MeanRatingByActivity(int idActivity);
	/******/
	Activity  getBestRatedActivity();
	/******/
	List<Aspnetuser> getAllEmployees();
	/******/
	List<Activity> getAllActivites();
	/*********BONUS***************/
	List <Aspnetuser> getAllEmployeesPerActivity(int id);
	/*************WEB SERVICE*********/
	Integer nbtotalEmployees();
	/*********BONUS***************/
	List<Activity> getActivitiesByTrainer(String id);
	
	

}
