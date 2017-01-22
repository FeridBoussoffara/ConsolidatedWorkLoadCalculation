package tn.esprit.bi.cwc.services;

import java.time.DayOfWeek;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tn.esprit.bi.cwc.interfaces.InternshipServicesLocal;
import tn.esprit.bi.cwc.interfaces.TraineeServicesLocal;
import tn.esprit.bi.cwc.interfaces.TraineeServicesRemote;
import tn.esprit.bi.cwc.persistance.Internship;
import tn.esprit.bi.cwc.persistance.RateTrainee;
import tn.esprit.bi.cwc.persistance.Trainee;

/**
 * Session Bean implementation class TraineeServices
 */
@Stateless
public class TraineeServices implements TraineeServicesRemote, TraineeServicesLocal {

	@PersistenceContext
	private EntityManager entityManager;

	@EJB
	private TraineeServicesLocal traineeServicesLocal;
	@EJB
	private InternshipServicesLocal internshipServicesLocal;
    /**
     * Default constructor. 
     */
    public TraineeServices() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public void saveOrUpdate(Trainee trainee) {
		entityManager.merge(trainee);
		
		
	}

	@Override
	public void deleteTrainee(Trainee trainee) {
		Trainee t = entityManager.find(Trainee.class, trainee.getTraineeId());

		entityManager.remove(t);
		
	}

	@Override
	public Trainee findTraineeById(Integer id) {
		return entityManager.find(Trainee.class, id);	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Trainee> GetAllTrainees() {
		String jpql = "SELECT t from Trainee t";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}

	@Override
	public List<Trainee> GetAllTraineesForThisInternship(Integer id) {
	  Internship i= internshipServicesLocal.findInternshipById(id);
	  
		return i.getTrainees();
	}

	@Override
	public List<RateTrainee> GetMostRatedTrainee() {
	/*	String sql="select  trainees_TraineeId,sum(Rate)    from cwcdb_final.internship t   inner join cwcdb_final.trainee_internship it on  t.InternshipId   = it.internships_InternshipId   group by (trainees_TraineeId)";

		Query query = entityManager.createNativeQuery(sql);
		
	
		List<RateTrainee> idTrs = new ArrayList<RateTrainee>(); 
		Trainee trainee = new Trainee();
	  
		 
		 for (RateTrainee rateTrainee : idTrs) {
		 trainee=findTraineeById(rateTrainee.getIdTrainer());
			//rateTrainee.setNameTraine(trainee.getFirstName()+" "+trainee.getLastName());
		
		
			 
		}
		return idTrs;
		*/
		return null;
	}
	@Override
	public Integer getTraineeId(Trainee t){
		String jpql = "SELECT t.TraineeId from Trainee t where t.CIN=:c";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("c", t.getCIN());
		return (Integer) query.getSingleResult();
	}

	@Override
	public List<Internship> getMostActiveTraineeInternships(){
		int max,id;
		max=0;
		id=0;
		List<Trainee> trainees= new ArrayList<Trainee>();
		trainees=traineeServicesLocal.GetAllTrainees();
		for (Trainee t : trainees) {
			if(t.getInternships().size()>max){
				max=t.getInternships().size();
				id=t.getTraineeId();
			}
			
		}
		Trainee trainee = traineeServicesLocal.findTraineeById(id);
		return trainee.getInternships();
	}
	
	@Override
	public Trainee getMostActiveTrainee(){
		int max,id;
		max=0;
		id=0;
		List<Trainee> trainees= new ArrayList<Trainee>();
		trainees=traineeServicesLocal.GetAllTrainees();
		for (Trainee t : trainees) {
			if(t.getInternships().size()>max){
				max=t.getInternships().size();
				id=t.getTraineeId();
			}
			
		}
		Trainee trainee = traineeServicesLocal.findTraineeById(id);
		return trainee;
	}


     
	
	
}
