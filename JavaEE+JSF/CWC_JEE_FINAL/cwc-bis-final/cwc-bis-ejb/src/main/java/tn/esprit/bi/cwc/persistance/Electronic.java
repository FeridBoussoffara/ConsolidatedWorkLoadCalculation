package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;
import tn.esprit.bi.cwc.persistance.Product;

/**
 * Entity implementation class for Entity: Electronic
 *
 */
@Entity

public class Electronic extends Product implements Serializable {

	
	private static final long serialVersionUID = 1L;
	private String Brand ;
	private float weightElec ;
	public Electronic() {
		super();
	}
	public String getBrand() {
		return Brand;
	}
	public void setBrand(String brand) {
		Brand = brand;
	}
	public float getWeightElec() {
		return weightElec;
	}
	public void setWeightElec(float weightElec) {
		this.weightElec = weightElec;
	}
   
}
