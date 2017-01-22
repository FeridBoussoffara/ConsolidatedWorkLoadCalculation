package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;

import javax.persistence.Entity;

/**
 * Entity implementation class for Entity: Vehicule
 *
 */
@Entity

public class Vehicule extends Product implements Serializable {

	private static final long serialVersionUID = 1L;
	private Integer WheelsNbr;
	private Integer Capacity;
	private String VehiculeType;
	private float weightveh;

	public Integer getWheelsNbr() {
		return WheelsNbr;
	}

	public void setWheelsNbr(Integer wheelsNbr) {
		WheelsNbr = wheelsNbr;
	}

	public Integer getCapacity() {
		return Capacity;
	}

	public void setCapacity(Integer capacity) {
		Capacity = capacity;
	}

	public String getVehiculeType() {
		return VehiculeType;
	}

	public void setVehiculeType(String vehiculeType) {
		VehiculeType = vehiculeType;
	}

	public float getWeightveh() {
		return weightveh;
	}

	public void setWeightveh(float weightveh) {
		this.weightveh = weightveh;
	}

	public Vehicule() {
		super();
	}

}
