package tn.esprit.bi.CWC.presentation.mbeans;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.model.SelectItem;

import org.primefaces.model.chart.Axis;
import org.primefaces.model.chart.AxisType;
import org.primefaces.model.chart.BarChartModel;
import org.primefaces.model.chart.ChartSeries;

import tn.esprit.bi.cwc.interfaces.EmployeeServicesLocal;
import tn.esprit.bi.cwc.interfaces.InternshipServicesLocal;
import tn.esprit.bi.cwc.interfaces.TraineeServicesLocal;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Internship;

import tn.esprit.bi.cwc.persistance.Trainee;

@ManagedBean
@SessionScoped
public class InternshipBean {
	
	public InternshipServicesLocal getInternshipServicesLocal() {
		return internshipServicesLocal;
	}

	public void setInternshipServicesLocal(InternshipServicesLocal internshipServicesLocal) {
		this.internshipServicesLocal = internshipServicesLocal;
	}

	public TraineeServicesLocal getTraineeServicesLocal() {
		return traineeServicesLocal;
	}

	public void setTraineeServicesLocal(TraineeServicesLocal traineeServicesLocal) {
		this.traineeServicesLocal = traineeServicesLocal;
	}

	private List<Internship> internships= new ArrayList<Internship>();
	private List<Trainee> trainees = new ArrayList<Trainee>();
	
	@EJB
	InternshipServicesLocal internshipServicesLocal;
	@EJB
	TraineeServicesLocal traineeServicesLocal;
	@EJB
	EmployeeServicesLocal employeeServicesLocal;
	public EmployeeServicesLocal getEmployeeServicesLocal() {
		return employeeServicesLocal;
	}

	public void setEmployeeServicesLocal(EmployeeServicesLocal employeeServicesLocal) {
		this.employeeServicesLocal = employeeServicesLocal;
	}

	private Internship selectedInternship;
	private Trainee selectedTrainee;
	public Trainee getSelectedTrainee() {
		return selectedTrainee;
	}

	public void setSelectedTrainee(Trainee selectedTrainee) {
		this.selectedTrainee = selectedTrainee;
	}

	private Internship Internshiptoadd;
	private boolean FormList=true;
	private boolean FormEdit=false;
	private boolean FormDetails=false;
	private boolean FormAdd=false;
	private Trainee t ;
	private Trainee trainetoadd;
	private List<SelectItem> SelectTrainee;
	private int selectedTraineeId=-1;
	private List<Trainee> traineesall = new ArrayList<Trainee>();
	private BarChartModel barchart;
	
	public BarChartModel getBarchart() {
		return barchart;
	}

	public void setBarchart(BarChartModel barchart) {
		this.barchart = barchart;
	}

	public Internship getSelectedInternship() {
		return selectedInternship;
	}

	public void setSelectedInternship(Internship selectedInternship) {
		this.selectedInternship = selectedInternship;
	}

	public Internship getInternshiptoadd() {
		return Internshiptoadd;
	}

	public void setInternshiptoadd(Internship internshiptoadd) {
		Internshiptoadd = internshiptoadd;
	}

	public boolean isFormList() {
		return FormList;
	}

	public void setFormList(boolean formList) {
		FormList = formList;
	}

	public boolean isFormEdit() {
		return FormEdit;
	}

	public void setFormEdit(boolean formEdit) {
		FormEdit = formEdit;
	}

	public boolean isFormDetails() {
		return FormDetails;
	}

	public void setFormDetails(boolean formDetails) {
		FormDetails = formDetails;
	}

	public boolean isFormAdd() {
		return FormAdd;
	}

	public void setFormAdd(boolean formAdd) {
		FormAdd = formAdd;
	}

	public InternshipBean() {
		// TODO Auto-generated constructor stub
	}

	public List<Internship> getInternships() {
		return internships;
	}

	public void setInternships(List<Internship> internships) {
		this.internships = internships;
	}

	public List<Trainee> getTrainees() {
		return trainees;
	}

	public void setTrainees(List<Trainee> trainees) {
		this.trainees = trainees;
	}
	@PostConstruct
	public void init(){
		selectedTrainee= new Trainee();
		selectedInternship = new Internship();
		Internshiptoadd = new Internship();
		trainetoadd= new Trainee();
		Internshiptoadd = new Internship();
		internships=internshipServicesLocal.GetAllInternships();
		trainees=traineeServicesLocal.GetAllTrainees();
		
	
	}
	public String getSaltString() {
        String SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder salt = new StringBuilder();
        Random rnd = new Random();
        while (salt.length() < 18) {
            int index = (int) (rnd.nextFloat() * SALTCHARS.length());
            salt.append(SALTCHARS.charAt(index));
        }
        String saltStr = salt.toString();
        return saltStr;

    }
	public String AddAsEmployee(Trainee t){
		String navigateTo=null;
		Aspnetuser asp= new Aspnetuser();
		asp.setFirstName(t.getFirstName());
		asp.setLastName(t.getLastName());
		asp.setAdresse(t.getAdresse());
		asp.setEmail(t.getEmail());
		asp.setCin(t.getCIN());
		asp.setId(getSaltString());
		asp.setUserName(t.getFirstName()+"@esprit.tn");
		employeeServicesLocal.saveOrUpdate(asp);
		traineeServicesLocal.deleteTrainee(t);
		trainees=traineeServicesLocal.GetAllTrainees();
		return navigateTo;
	}
	
	public String doDeleteInternship(Internship i) {
		String navigateTo=null;
		internshipServicesLocal.deleteInternship(i);
		internships = internshipServicesLocal.GetAllInternships();
		
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		return navigateTo;
}

	public String doEditInternship() {
		String navigateTo = null;
		internshipServicesLocal.update(selectedInternship);
		
		internships=internshipServicesLocal.GetAllInternships();
		setFormList(true);
		setFormEdit(false);

		selectedInternship = new Internship();
		return navigateTo;
	}

	public String selectInternshipeEdit(Internship i) {
		this.selectedInternship =i;
        setFormAdd(false);
		setFormList(false);
		setFormEdit(true);
		return null;
	}

	public String selectInternshipDetails(Internship i) {
		this.selectedInternship = i;
		this.trainees=traineeServicesLocal.GetAllTraineesForThisInternship(i.getInternshipId());
		traineesall=traineeServicesLocal.GetAllTrainees();
		setSelectTrainee(new ArrayList<SelectItem>(traineesall.size()));
		for (Trainee tr  : traineesall) {
			SelectTrainee.add(new SelectItem(tr.getTraineeId(),tr.getFirstName()));
		}
		setFormList(false);
		setFormDetails(true);
		return null;
	}

	public String doAssignTraineeForThisInternship(){
		String navigateTo=null;
		
		
		internshipServicesLocal.save(selectedInternship,selectedTraineeId );
		this.trainees=traineeServicesLocal.GetAllTraineesForThisInternship(selectedInternship.getInternshipId());
		return navigateTo;
	}
	public String ReturnList()  {
		String navigateTo = null;
		init();
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		setFormAdd(false);
		internships=internshipServicesLocal.GetAllInternships();
		navigateTo="InternshipList.xhtml";
		return navigateTo;
	}
	public String ReturnListInternship() {
		String navigateTo = null;
		init();
		setFormList(true);
		setFormEdit(false);
		setFormDetails(false);
		setFormAdd(false);
		
		internships = internshipServicesLocal.GetAllInternships();
		return navigateTo;
	}
	
		public String goToAdd(){
		     selectedTraineeId=-1;
			trainees=traineeServicesLocal.GetAllTrainees();
			setSelectTrainee(new ArrayList<SelectItem>(trainees.size()));
			for (Trainee tr  : trainees) {
				SelectTrainee.add(new SelectItem(tr.getTraineeId(),tr.getFirstName()));
			}
			String navigateTo = null;
				setFormList(false);
				setFormEdit(false);
				setFormDetails(false);
				setFormAdd(true);
				return navigateTo; 
		 }

		public List<SelectItem> getSelectTrainee() {
			return SelectTrainee;
		}

		public void setSelectTrainee(List<SelectItem> selectTrainee) {
			SelectTrainee = selectTrainee;
		}

		public int getSelectedTraineeId() {
			return selectedTraineeId;
		}

		public void setSelectedTraineeId(int selectedTraineeId) {
			this.selectedTraineeId = selectedTraineeId;
		}

		public Trainee getT() {
			return t;
		}

		public void setT(Trainee t) {
			this.t = t;
		}
		
		
		
		public String goToAddTrainee(){
	    	String navigateTo=null;
	    	navigateTo="addTrainee.xhtml";
	    	return navigateTo;
	    }
		public String goToAddInternship(){
			String navigateTo=null;
			navigateTo="addInternship.xhtml";
			Internshiptoadd=new Internship();
			return navigateTo;
		}
		public String doAddInternship(){
			String navigateTo=null;
			
			internshipServicesLocal.save(Internshiptoadd, selectedTraineeId);
			internships=internshipServicesLocal.GetAllInternships();
			setFormAdd(false);
			setFormDetails(false);
			setFormEdit(false);
			setFormList(true);
			navigateTo="InternshipList.xhtml";
			return navigateTo;
		}
		public String doAddTrainee(){
			String navigateTo=null;
			traineeServicesLocal.saveOrUpdate(trainetoadd);
			selectedTraineeId=traineeServicesLocal.getTraineeId(trainetoadd);
			Internshiptoadd= new Internship();
			navigateTo="addInternship.xhtml";
			
			return navigateTo;
		}

		public Trainee getTrainetoadd() {
			return trainetoadd;
		}

		public void setTrainetoadd(Trainee trainetoadd) {
			this.trainetoadd = trainetoadd;
		}
		
		public String doMostRatedInternships(){
			String navigateTo=null;
			internships=internshipServicesLocal.getMostRatedInternships();
			navigateTo="MostRatedInternships.xhtml";
			return navigateTo;
		}
		
		public String doMostActivetrainee(){
			String navigateTo=null;
			internships=traineeServicesLocal.getMostActiveTraineeInternships();
			selectedTrainee=traineeServicesLocal.getMostActiveTrainee();
			navigateTo="MostActiveTrainee.xhtml";
			return navigateTo;
		}

		public List<Trainee> getTraineesall() {
			return traineesall;
		}

		public void setTraineesall(List<Trainee> traineesall) {
			this.traineesall = traineesall;
		}
		
		public String doInternshipOfThisYear(){
			String navigateTo=null;
			internships=internshipServicesLocal.getInternshipsOfThisYear();
			navigateTo="InternshipsThisYear.xhtml";
			return navigateTo;
		}
		public String goToTraineeList(){
			String navigateTo=null;
			trainees=traineeServicesLocal.GetAllTrainees();
			navigateTo="TraineeList.xhtml";
			return navigateTo;
		}
		 public void createBarChart() {
		      
	         
		        barchart = initBarModel();
		        barchart.setTitle("Trainee/Number Of Internships");
		        barchart.setAnimate(true);
		        barchart.setLegendPosition("ne");
		        Axis yAxis = barchart.getAxis(AxisType.Y);
		        yAxis.setMin(0);
		        yAxis.setMax(10);
		    }
		     
		    public BarChartModel initBarModel() {
		        BarChartModel model = new BarChartModel();
		        
		        ChartSeries Traine = new ChartSeries();
		        Traine.setLabel("Trainee");
		        List<Trainee> listtr= new ArrayList<Trainee>();
		        listtr=traineeServicesLocal.GetAllTrainees();
		        for (Trainee trainee : listtr) {
		        	Traine.set(trainee.getFirstName(), trainee.getInternships().size());
			       
				}
		        
		        model.addSeries(Traine);
		        
		        return model;
		    }
		    public String goToBarChart(){
		    	String navigateTo;
		    	createBarChart();
		    	navigateTo="BarChart.xhtml";
		    	return navigateTo;
		    }

	
}
