package tn.esprit.bi.cwc.interfaces;

import java.util.Date;
import java.util.List;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Leave;
import tn.esprit.bi.cwc.persistance.Payslip;
import tn.esprit.bi.cwc.persistance.StatLeave;

@Remote
public interface LeaveServicesRemote {
	void saveOrUpdate(Leave leave, String id);

	void deleteLeave(Leave leave);

	Leave findLeaveById(Integer id);

	List<Leave> GetAllLeaves();
	
	List<Leave> GetCurrentLeave();
	
	Long getNbrLeavesInGivenTime(Date from, Date to);
	
	List<Leave> getLeavesInGivenTime(Date from, Date to);
	
	List<Leave> GetAllLeaveByEmployeeId(String id);
	
	Aspnetuser MostAbsentEmployee();
	List<StatLeave> nbrOfCategoryLeave();
	List<String> getDistictEmployeeId();
	int getNbrOfLeavesForEmployeeId(String id);

	int nbrOfCategoryLeave(String c);

	List<StatLeave> getlistCategory();

}
