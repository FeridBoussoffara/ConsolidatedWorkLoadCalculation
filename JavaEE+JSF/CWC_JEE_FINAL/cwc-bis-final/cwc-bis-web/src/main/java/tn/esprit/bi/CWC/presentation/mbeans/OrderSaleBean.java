package tn.esprit.bi.CWC.presentation.mbeans;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;

import org.primefaces.context.RequestContext;
import org.primefaces.event.SelectEvent;

import tn.esprit.bi.cwc.interfaces.CustomerServicesRemote;
import tn.esprit.bi.cwc.persistance.Ordersale;

@ManagedBean
@ViewScoped
public class OrderSaleBean {
	// Model
	private Ordersale ordersale;
	private static List<Ordersale>  ordersales;
	

	// Injection dependences
	@EJB
	CustomerServicesRemote customerServicesRemote ;

 
	
	
	private Date Getteddate;

	public void onDateSelect(SelectEvent event) {
		FacesContext facesContext = FacesContext.getCurrentInstance();
		SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
		facesContext.addMessage(null,
				new FacesMessage(FacesMessage.SEVERITY_INFO, "Date Selected", format.format(event.getObject())));
	}

	public void click() {
		RequestContext requestContext = RequestContext.getCurrentInstance();

		requestContext.update("form:display");
		requestContext.execute("PF('dlg').show()");

		SimpleDateFormat dt = new SimpleDateFormat("dd/MM/yyyy");
		dt.format(Getteddate);
		System.out.println("hhhh : " + dt.format(Getteddate));
	}

	public Date getGetteddate() {
		return Getteddate;
	}

	public void setGetteddate(Date getteddate) {
		Getteddate = getteddate;
	}

	public Ordersale getOrdersale() {
		return ordersale;
	}

	public void setOrdersale(Ordersale ordersale) {
		this.ordersale = ordersale;
	}

	public List<Ordersale> getOrdersales() {
		return ordersales;
	}

	public void setOrdersales(List<Ordersale> ordersales) {
		this.ordersales = ordersales;
	}
}
