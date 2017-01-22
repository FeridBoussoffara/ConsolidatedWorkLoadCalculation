package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;

import javax.persistence.Entity;

/**
 * Entity implementation class for Entity: Furniture
 *
 */
@Entity

public class Furniture extends Product implements Serializable {

	private static final long serialVersionUID = 1L;
	private float weightFur;
	private String Material;

	public Furniture() {
		super();
	}

	public float getWeightFur() {
		return weightFur;
	}

	public void setWeightFur(float weightFur) {
		this.weightFur = weightFur;
	}

	public String getMaterial() {
		return Material;
	}

	public void setMaterial(String material) {
		Material = material;
	}

}
