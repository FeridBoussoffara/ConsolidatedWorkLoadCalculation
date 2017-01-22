package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.*;


/**
 * The persistent class for the payslips database table.
 * 
 */
@Entity
@Table(name="payslips")
public class Payslip implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int paySlipId;

	private float grossPay;

	private float netPay;

	private float prime;
	
	@Temporal(TemporalType.TIMESTAMP)
	private Date DateCreate;

	//bi-directional many-to-one association to Aspnetuser
	@ManyToOne
	@JoinColumn(name="EmployeeId")
	private Aspnetuser aspnetuser;

	public Payslip() {
	}

	public int getPaySlipId() {
		return this.paySlipId;
	}

	public void setPaySlipId(int paySlipId) {
		this.paySlipId = paySlipId;
	}

	public float getGrossPay() {
		return this.grossPay;
	}

	public void setGrossPay(float grossPay) {
		this.grossPay = grossPay;
	}

	public float getNetPay() {
		return this.netPay;
	}

	public void setNetPay(float netPay) {
		this.netPay = netPay;
	}

	public float getPrime() {
		return this.prime;
	}

	public void setPrime(float prime) {
		this.prime = prime;
	}

	public Aspnetuser getAspnetuser() {
		return this.aspnetuser;
	}

	public void setAspnetuser(Aspnetuser aspnetuser) {
		this.aspnetuser = aspnetuser;
	}

	public Date getDateCreate() {
		return DateCreate;
	}

	public void setDateCreate(Date dateCreate) {
		DateCreate = dateCreate;
	}

	public Payslip(float grossPay, float netPay, float prime) {
		super();
		this.grossPay = grossPay;
		this.netPay = netPay;
		this.prime = prime;
		this.aspnetuser = aspnetuser;
	}

	
	public Payslip(int paySlipId, float grossPay, float netPay, float prime, Aspnetuser aspnetuser) {
		super();
		this.paySlipId = paySlipId;
		this.grossPay = grossPay;
		this.netPay = netPay;
		this.prime = prime;
		this.aspnetuser = aspnetuser;
	}

	@Override
	public String toString() {
		return "Payslip [grossPay=" + grossPay + ", netPay=" + netPay + ", prime=" + prime + ", aspnetuser="
				+ aspnetuser + "]";
	}

	
}