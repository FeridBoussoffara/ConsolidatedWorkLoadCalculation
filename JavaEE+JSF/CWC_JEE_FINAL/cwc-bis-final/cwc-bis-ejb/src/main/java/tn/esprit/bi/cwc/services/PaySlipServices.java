package tn.esprit.bi.cwc.services;

import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tn.esprit.bi.cwc.interfaces.PaySlipServicesLocal;
import tn.esprit.bi.cwc.interfaces.PaySlipServicesRemote;
import tn.esprit.bi.cwc.persistance.Aspnetuser;
import tn.esprit.bi.cwc.persistance.Payslip;

/**
 * Session Bean implementation class PaySlipServices
 */
@Stateless
public class PaySlipServices implements PaySlipServicesRemote, PaySlipServicesLocal {

	@PersistenceContext
	private EntityManager entityManager;

	@EJB
	private PaySlipServicesLocal paySlipServicesLocal;

	/**
	 * Default constructor.
	 */
	public PaySlipServices() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public void saveOrUpdate(Payslip payslip) {
		entityManager.merge(payslip);

	}

	@Override
	public void deletePaySlip(Payslip payslip) {
		entityManager.remove(entityManager.merge(payslip));

	}

	@Override
	public Payslip findPaySlipById(Integer idPaySlip) {
		return entityManager.find(Payslip.class, idPaySlip);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Payslip> GetAllPaySlip() {
		String jpql = "SELECT p FROM Payslip p";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Payslip> GetAllPaySlipByEmployeeId(String id) {
		String jpql = "SELECT p FROM Payslip p where p.aspnetuser.id=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", id);
		return query.getResultList();
	}

	public Aspnetuser MostPayedEmployee() {
		String jpql = "SELECT pp FROM Payslip pp WHERE pp.grossPay = (SELECT MAX(p.grossPay) FROM Payslip p )";
		Query query = entityManager.createQuery(jpql);
		Payslip p = (Payslip) query.getSingleResult();
		String jpql1 = "SELECT e FROM Aspnetuser e where e.id=:id";
		Query query1 = entityManager.createQuery(jpql1);
		query1.setParameter("id", p.getAspnetuser().getId());
		return (Aspnetuser) query1.getSingleResult();

	}

}
