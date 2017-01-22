package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Internship;
import tn.esprit.bi.cwc.persistance.RateTrainee;
import tn.esprit.bi.cwc.persistance.Trainee;



@Local
public interface TraineeServicesLocal {
	void saveOrUpdate(Trainee trainee);

	void deleteTrainee(Trainee trainee);

	Trainee findTraineeById(Integer id);

	List<Trainee> GetAllTrainees();

	List<Trainee> GetAllTraineesForThisInternship(Integer id);

	List<RateTrainee> GetMostRatedTrainee();
	Integer getTraineeId(Trainee t);
	Trainee getMostActiveTrainee();
	List<Internship> getMostActiveTraineeInternships();
	
	

}
