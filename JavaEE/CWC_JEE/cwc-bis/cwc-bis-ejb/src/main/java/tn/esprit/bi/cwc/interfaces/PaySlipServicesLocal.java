package tn.esprit.bi.cwc.interfaces;

import java.util.List;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Payslip;


@Local
public interface PaySlipServicesLocal {
	void saveOrUpdate(Payslip payslip);

	void deletePaySlip(Payslip payslip);

	Payslip findPaySlipById(Integer idPaySlip);
	
	List<Payslip> GetAllPaySlip();
	
	List<Payslip> GetAllPaySlipByEmployeeId(String id);
	
	Aspnetuser MostPayedEmployee();
}
