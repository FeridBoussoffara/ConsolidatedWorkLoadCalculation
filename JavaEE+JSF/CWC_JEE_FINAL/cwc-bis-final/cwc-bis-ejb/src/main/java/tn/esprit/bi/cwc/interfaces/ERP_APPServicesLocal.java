package tn.esprit.bi.cwc.interfaces;

import javax.ejb.Local;

import tn.esprit.bi.cwc.persistance.Erpapp;

@Local
public interface ERP_APPServicesLocal {

	public void saveOrUpdateApp(Erpapp erpapp);
}
