package tn.esprit.bi.cwc.persistance;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the historyrows database table.
 * 
 */
@Entity
@Table(name="historyrows")
@NamedQuery(name="Historyrow.findAll", query="SELECT h FROM Historyrow h")
public class Historyrow implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	private String migrationId;

	private String contextKey;

	@Lob
	private byte[] model;

	@Lob
	private String productVersion;

	public Historyrow() {
	}

	public String getMigrationId() {
		return this.migrationId;
	}

	public void setMigrationId(String migrationId) {
		this.migrationId = migrationId;
	}

	public String getContextKey() {
		return this.contextKey;
	}

	public void setContextKey(String contextKey) {
		this.contextKey = contextKey;
	}

	public byte[] getModel() {
		return this.model;
	}

	public void setModel(byte[] model) {
		this.model = model;
	}

	public String getProductVersion() {
		return this.productVersion;
	}

	public void setProductVersion(String productVersion) {
		this.productVersion = productVersion;
	}

}