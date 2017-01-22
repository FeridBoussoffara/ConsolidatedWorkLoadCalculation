package tn.esprit.bi.cwc.services;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tn.esprit.bi.cwc.interfaces.EmployeeServicesLocal;
import tn.esprit.bi.cwc.interfaces.LeaveServicesLocal;
import tn.esprit.bi.cwc.interfaces.LeaveServicesRemote;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Leave;
import tn.esprit.bi.cwc.persistance.Payslip;
import tn.esprit.bi.cwc.persistance.StatLeave;

/**
 * Session Bean implementation class LeaveServices
 */
@Stateless
public class LeaveServices implements LeaveServicesRemote, LeaveServicesLocal {
 

	@PersistenceContext
	private EntityManager entityManager;

	@EJB
	private LeaveServicesLocal leaveServicesLocal;
	@EJB
	private EmployeeServicesLocal employeeServicesLocal;
    /**
     * Default constructor. 
     */
    public LeaveServices() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public void saveOrUpdate(Leave leave, String id) {
		Aspnetuser a = entityManager.find(Aspnetuser.class, id);
		leave.setAspnetuser(a);
		entityManager.merge(leave);
		
	}

	@Override
	public void deleteLeave(Leave leave) {
		Leave l = entityManager.find(Leave.class, leave.getLeaveId());
		entityManager.remove(l);
		// TODO Auto-generated method stub
		
	}

	@Override
	public Leave findLeaveById(Integer id) {
		return entityManager.find(Leave.class, id);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Leave> GetAllLeaves() {
		String jpql = "SELECT l FROM Leave l";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Leave> GetCurrentLeave() {
		String jpql = "SELECT l FROM Leave l where l.endDate>:a";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("a", new Date());
		return query.getResultList();
		
	}

	@Override
	public Long getNbrLeavesInGivenTime(Date from, Date to) {
		String jpql = "SELECT count(l.leaveId) from Leave l where (l.startDate>=:a and l.endDate<=:b)";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("a",from);
		query.setParameter("b", to);
		return (Long) query.getSingleResult();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Leave> getLeavesInGivenTime(Date from, Date to) {
		String jpql = "SELECT l from Leave l where (l.startDate>=:a and l.endDate<=:b)";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("a",from);
		query.setParameter("b", to);
		return  query.getResultList();
		
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Leave> GetAllLeaveByEmployeeId(String id) {
		String jpql = "SELECT l FROM Leave l where l.aspnetuser.id=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", id);
		return query.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public Aspnetuser MostAbsentEmployee() {
		String jpql = "SELECT l FROM Leave l Group By l.aspnetuser.id Order By count(l.aspnetuser.id) ";
		Query query = entityManager.createQuery(jpql);
	
		
		
				Leave leave= (Leave)query.getSingleResult();
				return employeeServicesLocal.FindEmployeeById(leave.getAspnetuser().getId());
	}
    
	
	@SuppressWarnings("unchecked")
	@Override
	public List<StatLeave> nbrOfCategoryLeave() {
		String jpql = "SELECT l.category,count(l) FROM Leave l Group by l.category";
		Query query = entityManager.createQuery(jpql);
		
		return query.getResultList();
	}
	@Override
	public List<String> getDistictEmployeeId(){
		String jpql = "SELECT distinct l.aspnetuser.id FROM Leave l";
		Query query = entityManager.createQuery(jpql);
		
		return query.getResultList();
	}
	@Override
	public int getNbrOfLeavesForEmployeeId(String id){
		String jpql = "SELECT count(l.leaveId) FROM Leave l where l.aspnetuser.id=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", id);
		return  (int)(long) query.getSingleResult();
	}
	@SuppressWarnings("unchecked")
	@Override
	public int nbrOfCategoryLeave(String c) {
		
	    String jpql = "SELECT  count(l) FROM Leave l where l.category=:c";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("c", c);
	    return (int)(long) query.getSingleResult();
	    
	}
	@Override
	public List<StatLeave> getlistCategory(){
		List<StatLeave> listst = new ArrayList<StatLeave>();
		
		String jpql = "SELECT distinct l.category FROM Leave l";
		Query query = entityManager.createQuery(jpql);
	    @SuppressWarnings("unchecked")
		List<String> ls= query.getResultList();
	    for (String s : ls) {
	    	StatLeave st = new StatLeave();
	    	st.setName(s);
	    	st.setValue(nbrOfCategoryLeave(s));
	    	listst.add(st);
		}
	    return listst;

	}
}


