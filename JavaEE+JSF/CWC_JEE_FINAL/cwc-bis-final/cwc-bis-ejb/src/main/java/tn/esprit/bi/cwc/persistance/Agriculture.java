package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.*;
import tn.esprit.bi.cwc.persistance.Product;

/**
 * Entity implementation class for Entity: Agriculture
 *
 */
@Entity

public class Agriculture extends Product implements Serializable {

	
	private static final long serialVersionUID = 1L;
	private String Category;
	private Date  ValidityDate ;
	public Agriculture() {
		super();
	}
	public String getCategory() {
		return Category;
	}
	public void setCategory(String category) {
		Category = category;
	}
	public Date getValidityDate() {
		return ValidityDate;
	}
	public void setValidityDate(Date validityDate) {
		ValidityDate = validityDate;
	}
   
}
