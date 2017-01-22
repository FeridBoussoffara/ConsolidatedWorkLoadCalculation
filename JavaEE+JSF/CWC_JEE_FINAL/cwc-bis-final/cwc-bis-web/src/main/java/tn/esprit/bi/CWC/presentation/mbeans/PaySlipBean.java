package tn.esprit.bi.CWC.presentation.mbeans;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.model.DataModel;

import tn.esprit.bi.cwc.interfaces.EmployeeServicesLocal;
import tn.esprit.bi.cwc.interfaces.PaySlipServicesLocal;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Payslip;



@ManagedBean
@SessionScoped
public class PaySlipBean implements Serializable {

	private static final long serialVersionUID = 1L;

	private List<Payslip> payslips = new ArrayList<>();
	private List<Payslip> payslipsemp = new ArrayList<>();
	private List<Aspnetuser> employees = new ArrayList<>();
	private Aspnetuser usedemployee = new Aspnetuser();

	private DataModel<Payslip> dataModel;
	private Payslip selectedpayslip;
	private boolean formDetails = false;
	private boolean formList = true;
	private boolean formEdit = false;

	@EJB
	private PaySlipServicesLocal paySlipServicesLocal;

	@EJB
	private EmployeeServicesLocal employeeServicesLocal;

	@PostConstruct
	public void init() {
		
		selectedpayslip = new Payslip();
		payslips = paySlipServicesLocal.GetAllPaySlip();
		employees = employeeServicesLocal.GetAllEmployee();
	}

	public List<Payslip> getPayslips() {
		return payslips;
	}

	public void setPayslips(List<Payslip> payslips) {
		this.payslips = payslips;
	}

	public Payslip getSelectedpayslip() {
		return selectedpayslip;
	}

	public void setSelectedpayslip(Payslip selectedpayslip) {
		this.selectedpayslip = selectedpayslip;
	}

	public DataModel<Payslip> getDataModel() {
		return dataModel;
	}

	public void setDataModel(DataModel<Payslip> dataModel) {
		this.dataModel = dataModel;
	}

	public boolean isFormDetails() {
		return formDetails;
	}

	public void setFormDetails(boolean formDetails) {
		this.formDetails = formDetails;
	}

	public boolean isFormList() {
		return formList;
	}

	public void setFormList(boolean formList) {
		this.formList = formList;
	}

	public boolean isFormEdit() {
		return formEdit;
	}

	public void setFormEdit(boolean formEdit) {
		this.formEdit = formEdit;
	}

	public List<Aspnetuser> getEmployees() {
		return employees;
	}

	public void setEmployees(List<Aspnetuser> employees) {
		this.employees = employees;
	}

	public List<Payslip> getPayslipsemp() {
		return payslipsemp;
	}

	public void setPayslipsemp(List<Payslip> payslipsemp) {
		this.payslipsemp = payslipsemp;
	}
	
	public Aspnetuser getUsedemployee() {
		return usedemployee;
	}

	public void setUsedemployee(Aspnetuser usedemployee) {
		this.usedemployee = usedemployee;
	}
	////////////////////////////////////

	public String doAdd(Payslip p) {
		String navigateTo = null;
		paySlipServicesLocal.deletePaySlip(p);
		payslips = paySlipServicesLocal.GetAllPaySlip();
		return navigateTo;
	}

	public String doDelete(Payslip p) {
		String navigateTo = null;
		paySlipServicesLocal.deletePaySlip(p);
		payslips = paySlipServicesLocal.GetAllPaySlip();
		return navigateTo;
	}
	
	public String doDeleteEmpPaySlip(Payslip p) {
		String navigateTo = null;
		String id = p.getAspnetuser().getId();
		paySlipServicesLocal.deletePaySlip(p);
		payslips = paySlipServicesLocal.GetAllPaySlipByEmployeeId(id);
		return navigateTo;
	}

	public String doEdit() {
		String navigateTo = null;
		paySlipServicesLocal.saveOrUpdate(selectedpayslip);

		payslips = paySlipServicesLocal.GetAllPaySlip();
		formList = true;
		formEdit = false;

		selectedpayslip = new Payslip();
		return navigateTo;
	}

	public String doEditPaySLipEmp() {
		String navigateTo = null;
		paySlipServicesLocal.saveOrUpdate(selectedpayslip);
		
		payslips = paySlipServicesLocal.GetAllPaySlipByEmployeeId(selectedpayslip.getAspnetuser().getId());
		
		formList = true;
		formEdit = false;

		selectedpayslip = new Payslip();
		return navigateTo;
	}

	public String selectPaySlipEdit(Payslip p) {
		this.selectedpayslip = p;

		formList = false;
		formEdit = true;
		return null;
	}

	public String selectPaySlipDetails(Payslip p) {
		this.selectedpayslip = p;
		formList = false;
		formDetails = true;
		return null;
	}

	public String ReturnList()  {
		String navigateTo = null;
		formList = true;
		formEdit = false;
		formDetails = false;
		return navigateTo;
	}
	
	public String ReturnListEmpPay(String id) {
		String navigateTo = null;
		formList = true;
		formEdit = false;
		formDetails = false;
		
		payslips = paySlipServicesLocal.GetAllPaySlipByEmployeeId(id);
		return navigateTo;
	}
	
	public String ListPaySlipByEmployee(Aspnetuser a) {
		this.payslips = paySlipServicesLocal.GetAllPaySlipByEmployeeId(a.getId());
		this.usedemployee = a;
		return "PayslipEmployee.xhtml";
	}
	
	public String ListEmployees(){
		employees = employeeServicesLocal.GetAllEmployee();
		return "home.xhtml";
	}

}
