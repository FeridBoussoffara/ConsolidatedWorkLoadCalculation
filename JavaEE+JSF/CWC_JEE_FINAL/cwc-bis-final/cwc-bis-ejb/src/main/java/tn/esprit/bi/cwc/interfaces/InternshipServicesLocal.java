package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Internship;



@Local
public interface InternshipServicesLocal {
	void save(Internship internship, Integer idTrainee);
	
	void update(Internship internship);

	void deleteInternship(Internship internship);

	Internship findInternshipById(Integer id);

	List<Internship> GetAllInternships();
	
    List<Internship> getMostRatedInternships();
    List<Internship> getInternshipsOfThisYear();

}
