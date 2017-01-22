package tn.esprit.bi.cwc.persistance;

import java.util.Date;



public class LeaveJsonArray {
    private int $id;
	
    private int LeaveId;

	
	public int getLeaveId() {
		return LeaveId;
	}


	public void setLeaveId(int leaveId) {
		LeaveId = leaveId;
	}


	private String Category;

	
	private Date EndDate;

	
	private Date StartDate;

	
	@Override
	public String toString() {
		return "LeaveJsonArray [$id=" + $id + ", leaveId=" + LeaveId + ", Category=" + Category + ", EndDate=" + EndDate
				+ ", StartDate=" + StartDate + ", State=" + State + ", EmployeeId=" + EmployeeId + "]";
	}


	public int get$id() {
		return $id;
	}


	public void set$id(int $id) {
		this.$id = $id;
	}



	public String getCategory() {
		return Category;
	}


	public void setCategory(String category) {
		Category = category;
	}


	public Date getEndDate() {
		return EndDate;
	}


	public void setEndDate(Date endDate) {
		EndDate = endDate;
	}


	public Date getStartDate() {
		return StartDate;
	}


	public void setStartDate(Date startDate) {
		StartDate = startDate;
	}


	


	public boolean isState() {
		return State;
	}


	public void setState(boolean state) {
		State = state;
	}


	public String getEmployeeId() {
		return EmployeeId;
	}


	public void setEmployeeId(String employeeId) {
		EmployeeId = employeeId;
	}


	private boolean State;

	
	private String EmployeeId;
	
	
}
