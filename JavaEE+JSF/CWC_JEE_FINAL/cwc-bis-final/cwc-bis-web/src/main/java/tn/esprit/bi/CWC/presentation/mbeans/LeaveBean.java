package tn.esprit.bi.CWC.presentation.mbeans;


import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.function.Predicate;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.model.SelectItem;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.Response;

import org.apache.poi.ss.usermodel.Workbook;
import org.primefaces.model.chart.Axis;
import org.primefaces.model.chart.AxisType;
import org.primefaces.model.chart.BarChartModel;
import org.primefaces.model.chart.ChartSeries;
import org.primefaces.model.chart.PieChartModel;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import tn.esprit.bi.cwc.interfaces.EmployeeServicesLocal;
import tn.esprit.bi.cwc.interfaces.LeaveServicesLocal;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Leave;
import tn.esprit.bi.cwc.persistance.LeaveJsonArray;
import tn.esprit.bi.cwc.persistance.Project;
import tn.esprit.bi.cwc.persistance.StatLeave;
import tn.esprit.bi.cwc.persistance.Trainee;







@ManagedBean
@SessionScoped
public class LeaveBean {
	
	private List<Leave> leaves = new ArrayList<Leave>();
	private List<Aspnetuser> employees = new ArrayList<>();
	private PieChartModel pie;
	private BarChartModel barchart;
	private List<SelectItem> SelectEmployee;
	private int selectedEmployeeId=-1;
	

	public BarChartModel getBarchart() {
		return barchart;
	}

	public void setBarchart(BarChartModel barchart) {
		this.barchart = barchart;
	}

	@EJB
	private LeaveServicesLocal leaveServicesLocal;
	@EJB
	private EmployeeServicesLocal employeeServicesLocal;
    public EmployeeServicesLocal getEmployeeServicesLocal() {
		return employeeServicesLocal;
	}

	public void setEmployeeServicesLocal(EmployeeServicesLocal employeeServicesLocal) {
		this.employeeServicesLocal = employeeServicesLocal;
	}

	private Leave leavetoadd;
    private Aspnetuser selectedEmployee = new Aspnetuser();
	private Leave selectedLeave;
	public String userId="0d3adc06-7eb0-4ab8-9cd0-71d93b98d395";
	private Aspnetuser usedemployee = new Aspnetuser();
    private Date from = new Date();
    private Date to= new Date();
	private boolean formList=true;

	private boolean formEdit=false;

	private boolean formDetails=false;
	private boolean formAdd=false;
	List<StatLeave> listst= new ArrayList<StatLeave>();
	String emailselected;
	
	

	public String getEmailselected() {
		return emailselected;
	}

	public void setEmailselected(String emailselected) {
		this.emailselected = emailselected;
	}

	public List<StatLeave> getListst() {
		return listst;
	}

	public void setListst(List<StatLeave> listst) {
		this.listst = listst;
	}

	public LeaveServicesLocal getLeaveServicesLocal() {
		return leaveServicesLocal;
	}

	public void setLeaveServicesLocal(LeaveServicesLocal leaveServicesLocal) {
		this.leaveServicesLocal = leaveServicesLocal;
	}

	public List<Leave> getLeaves() {
		return leaves;
	}

	public void setLeaves(List<Leave> leaves) {
		this.leaves = leaves;
	}

	@PostConstruct
	public void init(){
		selectedLeave = new Leave();
		leavetoadd = new Leave();
		leaves=leaveServicesLocal.GetAllLeaves();
		emailselected= new String();
		
	}
	public int getSelectedEmployeeId() {
		return selectedEmployeeId;
	}

	public void setSelectedEmployeeId(int selectedEmployeeId) {
		this.selectedEmployeeId = selectedEmployeeId;
	}
	

	public Leave getSelectedLeave() {
		return selectedLeave;
	}

	public void setSelectedLeave(Leave selectedLeave) {
		this.selectedLeave = selectedLeave;
	}
	public String doAdd() {
		
		String navigateTo = null;
		leavetoadd.setState((byte) 0);
		System.out.println(selectedEmployeeId);
		String email =SelectEmployee.get(selectedEmployeeId).getLabel();
		Aspnetuser asp= employeeServicesLocal.FindEmployeeByEmail(email);
		leaveServicesLocal.saveOrUpdate(leavetoadd,asp.getId());
		leaves = leaveServicesLocal.GetAllLeaves();
		
		
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		setFormAdd(false);
		return navigateTo;
	}

	public String doDelete(Leave l) {
		String navigateTo = null;
		leaveServicesLocal.deleteLeave(l);
		leaves = leaveServicesLocal.GetAllLeaves();
		return navigateTo;
	}
	
	public String doDeleteEmpLeave(Leave l) {
		String navigateTo=null;
		leaveServicesLocal.deleteLeave(l);
		leaves = leaveServicesLocal.GetAllLeaves();
		leaves=leaveServicesLocal.GetAllLeaves();
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		return navigateTo;
	}

	public String doEdit() {
		String navigateTo = null;
		leaveServicesLocal.saveOrUpdate(selectedLeave,userId);

	leaves = leaveServicesLocal.GetAllLeaves();
		setFormList(true);
		setFormEdit(false);

		selectedLeave = new Leave();
		return navigateTo;
	}

	public String doEditLeaveEmp() {
		String navigateTo = null;
		
		leaveServicesLocal.saveOrUpdate(selectedLeave,selectedLeave.getAspnetuser().getId());
		
		//leaves = leaveServicesLocal.GetAllLeaveByEmployeeId(selectedLeave.getAspnetuser().getId());
		leaves=leaveServicesLocal.GetAllLeaves();
		setFormList(true);
		setFormEdit(false);

		selectedLeave = new Leave();
		return navigateTo;
	}

	public String selectLeaveEdit(Leave l) {
		this.selectedLeave = l;

		setFormList(false);
		setFormEdit(true);
		return null;
	}

	public String selectLeaveDetails(Leave l) {
		this.selectedLeave = l;
		setFormList(false);
		setFormDetails(true);
		return null;
	}

	public String ReturnList()  {
		String navigateTo = null;
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		setFormAdd(false);
		return navigateTo;
	}
	
	public String ReturnListEmpLeave(String id) {
		String navigateTo = null;
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		setFormAdd(false);
		
		leaves = leaveServicesLocal.GetAllLeaveByEmployeeId(id);
		return navigateTo;
	}
	public String ReturnListLeave() {
		String navigateTo = null;
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		setFormDetails(false);
		
		leaves = leaveServicesLocal.GetAllLeaves();
		navigateTo="LeaveEmployee.xhtml";
		return navigateTo;
	}
	
	public String ListLeaveByEmployee(Aspnetuser a) {
		this.leaves = leaveServicesLocal.GetAllLeaveByEmployeeId(a.getId());
		this.setUsedemployee(a);
		return "LeaveEmployee.xhtml";
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

	public boolean isFormDetails() {
		return formDetails;
	}

	public void setFormDetails(boolean formDetails) {
		this.formDetails = formDetails;
	}

	public Aspnetuser getUsedemployee() {
		return usedemployee;
	}

	public void setUsedemployee(Aspnetuser usedemployee) {
		this.usedemployee = usedemployee;
	}

	public List<Aspnetuser> getEmployees() {
		return employees;
	}

	public void setEmployees(List<Aspnetuser> employees) {
		this.employees = employees;
	}

	public boolean isFormAdd() {
		return formAdd;
	}

	public void setFormAdd(boolean formAdd) {
		this.formAdd = formAdd;
	}

	public Leave getLeavetoadd() {
		return leavetoadd;
	}

	public void setLeavetoadd(Leave leavetoadd) {
		this.leavetoadd = leavetoadd;
	}
	 public String goToAdd(){
		 String navigateTo = null;
		 employees=employeeServicesLocal.GetAllEmployee();
			setSelectEmployee(new ArrayList<SelectItem>(employees.size()));
			int i=0;
			for (Aspnetuser asp  : employees) {
				
				SelectEmployee.add(new SelectItem(i,asp.getEmail()));
				i++;
				System.out.println(i+"----");
			}
			setFormList(false);
			setFormEdit(false);
			setFormDetails(false);
			setFormAdd(true);
			return navigateTo; 
	 }
	 public String DoCurrentLeaves()
	 {
		 String navigateTo=null;
		 leaves=leaveServicesLocal.GetCurrentLeave();
		 navigateTo="CurrentLeaves.xhtml";
		 return navigateTo;
	 }

	public Date getFrom() {
		return from;
	}

	public void setFrom(Date from) {
		this.from = from;
	}

	public Date getTo() {
		return to;
	}

	public void setTo(Date to) {
		this.to = to;
	}
    public String DoGivenLeavesInTime()
    {
    	String navigateTo=null;
    	leaves=leaveServicesLocal.getLeavesInGivenTime(from, to);
    	System.out.println(from+"   "+to);
    	navigateTo="LeavesInGivenTime.xhtml";
    	return navigateTo;
    }
    
    public String DoMostAbsentEmployee(){
    	String navigateTo=null;
    	int nbr=0;
    	int max=0;
    	String id="";
    	List<String> empid = new ArrayList<String>();
    	empid=leaveServicesLocal.getDistictEmployeeId();
    	for (String ide : empid) {
			if(leaveServicesLocal.getNbrOfLeavesForEmployeeId(ide)>max)
			{
				max=leaveServicesLocal.getNbrOfLeavesForEmployeeId(ide);
				id=ide;
			}
		}
    	
    	selectedEmployee=employeeServicesLocal.FindEmployeeById(id);
    	leaves=selectedEmployee.getLeaves();
    	navigateTo="MostAbsentEmployee.xhtml";
    	return navigateTo;
    }
    
    public String StatPerCategory(){
    	String navigateTo=null;
    	
    	
    	listst=leaveServicesLocal.nbrOfCategoryLeave();
    	
    	return navigateTo;
    }

	public Aspnetuser getSelectedEmployee() {
		return selectedEmployee;
	}

	public void setSelectedEmployee(Aspnetuser selectedEmployee) {
		this.selectedEmployee = selectedEmployee;
	}
	
	public String LeaveForEmployee(){
		selectedEmployee=employeeServicesLocal.FindEmployeeByEmail(emailselected);
		
		String navigateTo=null;
		Client client;
		WebTarget target;
		String uri = "http://localhost:46441/api/WebAPIProject/LeavesEmployee/"+selectedEmployee.getId();
		client = ClientBuilder.newClient();
		target = client.target(uri);
		Response response = target.request().get();
		String result = (String) response.readEntity(String.class);
		Gson gSon = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
		List<LeaveJsonArray> listl = gSon.fromJson(result, new TypeToken<List<LeaveJsonArray>>(){}.getType());
     
        leaves= new ArrayList<Leave>();
		System.out.println(result);
		
		System.out.println(listl);
		System.out.println("qqqqqqqqqqq"+leaves);
		for (LeaveJsonArray l : listl) {
			Leave leave= new Leave();
			leave.setAspnetuser(employeeServicesLocal.FindEmployeeById(l.getEmployeeId()));
			leave.setCategory(l.getCategory());
			leave.setEndDate(l.getEndDate());
			leave.setLeaveId(l.getLeaveId());
			leave.setStartDate(l.getStartDate());
			if(l.isState())
			leave.setState((byte) 1);
			else{leave.setState((byte) 0);}
			leaves.add(leave);
		}
		
		response.close();
		navigateTo="LeavesForThisEmployee.xhtml";
		return navigateTo;
		
	}
	
	@SuppressWarnings("unused")
	private void createpie() {
        pie = new PieChartModel();
         List<StatLeave> listst = new ArrayList<StatLeave>();
         listst=leaveServicesLocal.getlistCategory();
         for (StatLeave statLeave : listst) {
			pie.set(statLeave.getName(), statLeave.getValue());
		}
        
        pie.setTitle("Leaves/Category");
        pie.setLegendPosition("e");
        pie.setFill(true);
        pie.setShowDataLabels(true);
        pie.setDiameter(150);
        }
	public String gotoChart(){
		String navigateTo=null;
		createpie();
		navigateTo="Chart.xhtml";
		return navigateTo;
	}

	public PieChartModel getPie() {
		return pie;
	}

	public void setPie(PieChartModel pie) {
		this.pie = pie;
	}

	public List<SelectItem> getSelectEmployee() {
		return SelectEmployee;
	}

	public void setSelectEmployee(List<SelectItem> selectEmployee) {
		SelectEmployee = selectEmployee;
	}

	
	
	
}
