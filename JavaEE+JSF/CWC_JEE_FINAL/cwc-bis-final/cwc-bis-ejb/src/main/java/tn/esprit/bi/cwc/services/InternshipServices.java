package tn.esprit.bi.cwc.services;


import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tn.esprit.bi.cwc.interfaces.InternshipServicesLocal;
import tn.esprit.bi.cwc.interfaces.InternshipServicesRemote;
import tn.esprit.bi.cwc.interfaces.TraineeServicesLocal;
import tn.esprit.bi.cwc.persistance.Internship;
import tn.esprit.bi.cwc.persistance.Trainee;

/**
 * Session Bean implementation class InternshipServices
 */
@Stateless
public class InternshipServices implements InternshipServicesRemote, InternshipServicesLocal {

	@PersistenceContext
	private EntityManager entityManager;

	@EJB
	private InternshipServicesLocal internshipServicesLocal;
	@EJB
	private TraineeServicesLocal traineeServicesLocal;
    /**
     * Default constructor. 
     */
    public InternshipServices() {
        super();
    }


	@Override
	public void save(Internship internship, Integer idTrainee) {
		Trainee e = traineeServicesLocal.findTraineeById(idTrainee);
	    System.out.println(e);
		
		
	   internship.addTrainee(e);
		
			  if(internship.getStartDate().before(new Date()) && internship.getEndDate().after(new Date()))
			  {
				  internship.setStatus("In progress");
			  }
			  else if(internship.getStartDate().after(new Date()))
			  {
				  internship.setStatus("Not Started");
			  }
			  else if(internship.getEndDate().before(new Date()))
			  {
				  internship.setStatus("Finished");
			  }
			  
		entityManager.merge(internship);
		
	}

	@Override
	public void deleteInternship(Internship internship) {
   
		Internship i= entityManager.find(Internship.class, internship.getInternshipId());
		System.out.println(i);
	    i.remove();
		entityManager.remove(i);
		
	}

	@Override
	public Internship findInternshipById(Integer id) {
		return entityManager.find(Internship.class,id);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Internship> GetAllInternships() {
		String jpql = "SELECT i FROM Internship i";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Internship> getMostRatedInternships() {
		String jpql = "SELECT i FROM Internship i Order By i.Rate desc"; 
		Query query = entityManager.createQuery(jpql);
		return query.setMaxResults(3).getResultList();
	}


	@Override
	public void update(Internship internship) {
		entityManager.merge(internship);
		
	}


	@SuppressWarnings("unchecked")
	@Override
	public List<Internship> getInternshipsOfThisYear() {
		String jpql = "SELECT i FROM Internship i where year(i.EndDate)>=year(:sysdate)"; 
		Query query = entityManager.createQuery(jpql);
		query.setParameter("sysdate", new Date());
		return query.getResultList();
	}


	

}
