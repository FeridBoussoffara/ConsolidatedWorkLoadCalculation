package tn.esprit.bi.cwc.persistance;

public class RateTrainee {

	private Integer idTrainer;
	//private String NameTraine;
	private Integer Rate;

	public RateTrainee(Integer idTrainer, Integer rate) {
		super();
		this.idTrainer = idTrainer;
		Rate = rate;
	}

	public Integer getIdTrainer() {
		return idTrainer;
	}

	 

	@Override
	public String toString() {
		return "RateTrainee [idTrainer=" + idTrainer + ", Rate=" + Rate + "]";
	}

	public void setIdTrainer(Integer idTrainer) {
		this.idTrainer = idTrainer;
	}

	public Integer getRate() {
		return Rate;
	}

	public void setRate(Integer rate) {
		Rate = rate;
	}

	 

}
