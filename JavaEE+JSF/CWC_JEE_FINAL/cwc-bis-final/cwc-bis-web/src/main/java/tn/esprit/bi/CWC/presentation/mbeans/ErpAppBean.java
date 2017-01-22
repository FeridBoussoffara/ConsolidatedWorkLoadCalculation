package tn.esprit.bi.CWC.presentation.mbeans;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import tn.esprit.bi.cwc.interfaces.ERP_APPServicesRemote;
import tn.esprit.bi.cwc.persistance.Erpapp;

@ManagedBean
@SessionScoped
public class ErpAppBean {

	private Erpapp erpapp ;

	@EJB
	private ERP_APPServicesRemote appServicesRemote;

	@PostConstruct
	public void init() {
		erpapp = new Erpapp();
	}

	public String doConfigERP() {
		appServicesRemote.saveOrUpdateApp(erpapp);
		System.out.println(erpapp);
		return "/pages/Admin/Customer/Home?faces-redirect=true";
	}

	public Erpapp getErpapp() {
		return erpapp;
	}

	public void setErpapp(Erpapp erpapp) {
		this.erpapp = erpapp;
	}
}
