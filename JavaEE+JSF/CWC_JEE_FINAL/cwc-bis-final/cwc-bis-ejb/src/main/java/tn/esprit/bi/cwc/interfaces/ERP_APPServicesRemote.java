package tn.esprit.bi.cwc.interfaces;

import javax.ejb.Remote;

import tn.esprit.bi.cwc.persistance.Erpapp;

@Remote
public interface ERP_APPServicesRemote {
	public void saveOrUpdateApp(Erpapp erpapp);
}
