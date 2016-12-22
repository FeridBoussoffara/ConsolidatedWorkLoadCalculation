package tn.esprit.bi.cwc.services;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateful;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.sun.mail.iap.Response;

import tn.esprit.bi.cwc.interfaces.ActivityServiceLocal;
import tn.esprit.bi.cwc.interfaces.ActivityServiceRemote;
import tn.esprit.bi.cwc.interfaces.MailServiceLocal;
import tn.esprit.bi.cwc.persistance.Activity;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Ratingactivity;
import tn.esprit.bi.cwc.persistance.Task;

@Stateful
public class ActivityService implements ActivityServiceLocal, ActivityServiceRemote {

	@PersistenceContext
	private EntityManager entityManager;

	@EJB
	MailServiceLocal mail;
	public ActivityService() {
		super();
	}

	@Override
	public void addActivity(Activity activity, String idTrainer) {
		Aspnetuser a = entityManager.find(Aspnetuser.class, idTrainer);
		activity.setAspnetuser(a);
		entityManager.merge(activity);
	}

	@Override
	public void UpdateActivity(Activity activity) {
		entityManager.merge(activity);
	}

	@Override
	public Activity FindActivityById(int id) {

		return entityManager.find(Activity.class, id);
	}

	@Override
	public Aspnetuser FindEmployeeById(String id) {
		String jpql = "SELECT e FROM Aspnetuser e where e.id=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", id);
		return (Aspnetuser) query.getSingleResult();
	}

	@Override
	public Task getTask(int id) {

		return entityManager.find(Task.class, id);
	}

	@Override
	public void DeleteActivityById(int id) {
		Activity a = entityManager.find(Activity.class, id);

		entityManager.remove(a);
	}

	@Override
	public void DeleteActivity(Activity activity) {
		Activity a = entityManager.find(Activity.class, activity.getActivityId());

		entityManager.remove(a);

	}

	@Override
	public void SubscribeEmployeeToActivity(String idEmployee, int idActivity) {
		Aspnetuser employee = entityManager.find(Aspnetuser.class, idEmployee);
		Activity activity = entityManager.find(Activity.class, idActivity);
		Ratingactivity ra = new Ratingactivity(0, activity, employee);
		entityManager.merge(ra);
		mail.send(employee.getEmail(), activity.getName(), "Congrats,You have been subscribed in "+activity.getName());
		
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Activity> getActivitiesByEmployee(String idEmployee) {

		String jpql = "SELECT r.activity FROM Ratingactivity r WHERE r.aspnetuser.id=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", idEmployee);

		return query.getResultList();
	}

	@Override
	public void RateActivity(float note, String idEmployee, int idActivity) {
		Aspnetuser employee = entityManager.find(Aspnetuser.class, idEmployee);
		Activity activity = entityManager.find(Activity.class, idActivity);
		Ratingactivity ra = new Ratingactivity(note, activity, employee);
		entityManager.merge(ra);
	}

	@Override
	public double MeanRatingByActivity(int idActivity) {

		String jpql = "SELECT  avg(r.note) FROM Ratingactivity r WHERE r.activity.activityId=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", idActivity);
		if (query.getSingleResult() != null) {
			return (double) query.getSingleResult();
		}
		return 0;
	}

	@SuppressWarnings("unchecked")
	@Override
	public Activity getBestRatedActivity() {
		List<Activity> AllActivities = getAllActivites();
		List<Double> Averages = new ArrayList<>();
		for (Activity a : AllActivities) {
			Averages.add(MeanRatingByActivity(a.getActivityId()));
		}
		Double MaxAverage = Collections.max(Averages);

		String jpql1 = "SELECT  r.activity  FROM Ratingactivity r GROUP BY r.activity having avg(r.note)=:bestRating";
		Query query1 = entityManager.createQuery(jpql1);
		query1.setParameter("bestRating", MaxAverage);
		return (Activity) query1.getSingleResult();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Aspnetuser> getAllEmployees() {
		String jpql = "SELECT r FROM Aspnetuser r ";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Activity> getAllActivites() {
		String jpql = "SELECT r FROM Activity r ";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Aspnetuser> getAllEmployeesPerActivity(int id) {
		String jpql1 = "SELECT  r.aspnetuser  FROM Ratingactivity r WHERE r.activity.activityId=:act";
		Query query1 = entityManager.createQuery(jpql1);
		query1.setParameter("act", id);
		return query1.getResultList();
	}

	
	@Override
	public Integer nbtotalEmployees() {
		Client client;
		WebTarget target;
		@SuppressWarnings("unused")
		String uri ="http://localhost:46441/api/TasksAPI/GetnumbersEmployees";
		client = ClientBuilder.newClient();
		target = client.target(uri);
		javax.ws.rs.core.Response response = target.request().get();
		String result = (String) response.readEntity(String.class);
		//Gson gSon = new GsonBuilder().create();
		//Integer asp = gSon.fromJson(result, Integer.class);
		//System.out.println(result);
		Integer.parseInt(result);
	//	System.out.println("userName " + asp.getHireDate());
		//response.close();
		return Integer.parseInt(result);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Activity> getActivitiesByTrainer(String id) {
		String jpql = "SELECT r FROM Activity r WHERE r.aspnetuser.id=:id ";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", id);
		return query.getResultList();
	}
	
	

}
