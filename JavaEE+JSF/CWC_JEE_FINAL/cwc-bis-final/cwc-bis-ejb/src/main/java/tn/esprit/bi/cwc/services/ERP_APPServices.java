package tn.esprit.bi.cwc.services;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import tn.esprit.bi.cwc.interfaces.ERP_APPServicesLocal;
import tn.esprit.bi.cwc.interfaces.ERP_APPServicesRemote;
import tn.esprit.bi.cwc.persistance.Erpapp;

/**
 * Session Bean implementation class ERP_APPServices
 */
@Stateless
public class ERP_APPServices implements ERP_APPServicesRemote, ERP_APPServicesLocal {

	@PersistenceContext
	EntityManager entityManager;

	public ERP_APPServices() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public void saveOrUpdateApp(Erpapp erpapp) {
		entityManager.merge(erpapp);
	}

}
