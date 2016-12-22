package tn.esprit.bi.cwc.services;

import java.io.IOException;
import java.net.MalformedURLException;
import java.util.List;

import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.xml.bind.JAXBException;

import tn.esprit.bi.cwc.interfaces.EmployeeServicesLocal;
import tn.esprit.bi.cwc.interfaces.EmployeeServicesRemote;
import tn.esprit.bi.cwc.persistance.Aspnetuser;

/**
 * Session Bean implementation class EmployeeServices
 */
@Stateless
public class EmployeeServices implements EmployeeServicesRemote, EmployeeServicesLocal {

	@PersistenceContext
	private EntityManager entityManager;

	@EJB
	private EmployeeServicesLocal employeeServicesLocal;

	public EmployeeServices() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public Aspnetuser CheckLogin(String username, String password)
			throws MalformedURLException, JAXBException, IOException {
		Client client;
		WebTarget target;
		@SuppressWarnings("unused")
		String uri = "http://localhost:8732/api/EmployeeWeb/Login/?Email=master@grand.com&password=Tunisia22%C2%B2";
		client = ClientBuilder.newClient();
		target = client
				.target("http://localhost:8732/api/EmployeeWeb/Login/?Email=master@grand.com&password=Tunisia22%C2%B2")
				.queryParam("cnt", "10").queryParam("Email", "master@grand.com")
				.queryParam("password", "Tunisia22%C2%B2");
		Response response = target.request(MediaType.APPLICATION_JSON).get();
		String result = (String) response.readEntity(String.class);
		// Aspnetuser jobj = new Gson().fromJson(result, Aspnetuser.class);
		// Aspnetuser a = jobj.fromJson(res)
		// String a = jobj.getFirstName();
		System.out.println(result);
		response.close();
		return null;
	}

	public Aspnetuser FindEmployeeByEmail(String email) {
		String jpql = "SELECT e FROM Aspnetuser e where e.email=:email";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("email", email);
		return (Aspnetuser) query.getSingleResult();
	}

	public Aspnetuser FindEmployeeById(String id) {
		String jpql = "SELECT e FROM Aspnetuser e where e.id=:id";
		Query query = entityManager.createQuery(jpql);
		query.setParameter("id", id);
		return (Aspnetuser) query.getSingleResult();
	}

	@SuppressWarnings("unchecked")
	public List<Aspnetuser> GetAllEmployee() {
		String jpql = "SELECT e FROM Aspnetuser e";
		Query query = entityManager.createQuery(jpql);
		return query.getResultList();
	}
}
