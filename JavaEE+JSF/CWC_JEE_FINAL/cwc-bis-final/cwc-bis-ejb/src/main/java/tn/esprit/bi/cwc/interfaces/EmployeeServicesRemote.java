package tn.esprit.bi.cwc.interfaces;

import java.io.IOException;
import java.net.MalformedURLException;
import java.util.List;

import javax.ejb.Remote;
import javax.xml.bind.JAXBException;

import tn.esprit.bi.cwc.persistance.Aspnetuser;

@Remote
public interface EmployeeServicesRemote {
	Aspnetuser CheckLogin(String username, String password) throws MalformedURLException, JAXBException, IOException;

	Aspnetuser FindEmployeeByEmail(String email);

	Aspnetuser FindEmployeeById(String id);

	List<Aspnetuser> GetAllEmployee();
	void saveOrUpdate(Aspnetuser asp);
}
