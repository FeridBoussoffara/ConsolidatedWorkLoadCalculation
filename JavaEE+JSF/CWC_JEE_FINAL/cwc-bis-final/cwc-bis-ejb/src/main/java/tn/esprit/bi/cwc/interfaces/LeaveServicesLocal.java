package tn.esprit.bi.cwc.interfaces;

import java.util.Date;
import java.util.List;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Leave;
import tn.esprit.bi.cwc.persistance.Payslip;
import tn.esprit.bi.cwc.persistance.StatLeave;




@Local
public interface LeaveServicesLocal {
	void saveOrUpdate(Leave leave, String id);

	void deleteLeave(Leave leave);

	Leave findLeaveById(Integer id);

	List<Leave> GetAllLeaves();
	
	List<Leave> GetCurrentLeave();
	
    Long getNbrLeavesInGivenTime(Date from, Date to);

	List<Leave> GetAllLeaveByEmployeeId(String id);
	List<Leave> getLeavesInGivenTime(Date from, Date to);
	
	Aspnetuser MostAbsentEmployee();
	List<StatLeave> nbrOfCategoryLeave();
	List<String> getDistictEmployeeId();
	int getNbrOfLeavesForEmployeeId(String id);

	List<StatLeave> getlistCategory();

	int nbrOfCategoryLeave(String c);
	


}
