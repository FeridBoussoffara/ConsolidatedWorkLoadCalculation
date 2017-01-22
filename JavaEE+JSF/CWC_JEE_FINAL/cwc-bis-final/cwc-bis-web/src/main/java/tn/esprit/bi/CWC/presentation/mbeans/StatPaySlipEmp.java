package tn.esprit.bi.CWC.presentation.mbeans;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

import tn.esprit.bi.cwc.interfaces.PaySlipServicesLocal;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Payslip;



@ManagedBean
@ViewScoped
public class StatPaySlipEmp implements Serializable{

	private static final long serialVersionUID = -3538930996818145824L;

	@EJB
	private PaySlipServicesLocal paySlipServicesLocal;

	private List<Payslip> payslips = new ArrayList<>();
	private Aspnetuser mostpayedemployee = new Aspnetuser();

	public List<Payslip> getPayslips() {
		return payslips;
	}

	public void setPayslips(List<Payslip> payslips) {
		this.payslips = payslips;
	}
	
	@PostConstruct
	public void init() {
		
		payslips = paySlipServicesLocal.GetAllPaySlip();
	}
	
	public String MostPayedEmployee(){
		mostpayedemployee = paySlipServicesLocal.MostPayedEmployee();
		
		return "MostPayedEmployee.xhtml";
	}
	
	public String AllPaySlip(){
		payslips = paySlipServicesLocal.GetAllPaySlip();
		return "AllPaySlips.xhtml";
	}

	public Aspnetuser getMostpayedemployee() {
		return mostpayedemployee;
	}

	public void setMostpayedemployee(Aspnetuser mostpayedemployee) {
		this.mostpayedemployee = mostpayedemployee;
	}
 }
