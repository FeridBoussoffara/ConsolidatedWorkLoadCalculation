package tn.esprit.bi.cwc.interfaces;

import javax.ejb.Local;

@Local
public interface MailServiceLocal {
void send(String addresses, String topic, String textMessage);
}
