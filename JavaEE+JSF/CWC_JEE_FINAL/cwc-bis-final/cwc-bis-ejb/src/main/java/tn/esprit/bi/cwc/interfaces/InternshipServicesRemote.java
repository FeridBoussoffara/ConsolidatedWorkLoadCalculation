package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Internship;




@Remote
public interface InternshipServicesRemote {
	void save(Internship internship, Integer idTrainee);
	
	void update(Internship internship);

	void deleteInternship(Internship internship);

	Internship findInternshipById(Integer id);

	List<Internship> GetAllInternships();
	
	List<Internship> getMostRatedInternships();

	List<Internship> getInternshipsOfThisYear();
}
