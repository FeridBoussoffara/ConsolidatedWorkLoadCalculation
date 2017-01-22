package tn.esprit.bi.cwc.utils;

import javax.annotation.PostConstruct;
import javax.ejb.LocalBean;
import javax.ejb.Singleton;
import javax.ejb.Startup;

/**
 * Session Bean implementation class UtilClass
 */
@Singleton
@LocalBean
@Startup
public class UtilClass {

	/**
	 * Default constructor.
	 */
	public UtilClass() {
		// TODO Auto-generated constructor stub
	}

	@PostConstruct
	public void initDB() {

	}
}