package tn.esprit.bi.cwc.interfaces;

import javax.ejb.Remote;

@Remote
public interface MailServiceRemote {
	void send(String addresses, String topic, String textMessage);
}
