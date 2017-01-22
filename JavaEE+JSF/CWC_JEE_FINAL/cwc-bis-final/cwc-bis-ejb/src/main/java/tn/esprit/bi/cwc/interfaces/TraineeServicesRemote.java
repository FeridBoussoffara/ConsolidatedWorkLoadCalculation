package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Internship;
import tn.esprit.bi.cwc.persistance.RateTrainee;
import tn.esprit.bi.cwc.persistance.Trainee;



@Remote
public interface TraineeServicesRemote {

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
