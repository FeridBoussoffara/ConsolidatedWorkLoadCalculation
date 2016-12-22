package tn.esprit.bi.cwc.services;

import java.util.logging.Level;
import java.util.logging.Logger;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

import tn.esprit.bi.cwc.interfaces.MailServiceLocal;
import tn.esprit.bi.cwc.interfaces.MailServiceRemote;

@Stateless
public class MailService implements MailServiceRemote, MailServiceLocal  {
	@Resource(name = "java:jboss/mail/Default")
	private Session session;
	
	public MailService() {
		// TODO Auto-generated constructor stub
	}
	@Override
	public void send(String addresses, String topic, String textMessage) {
		try {

			Message message = new MimeMessage(session);
			message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(addresses));
			message.setSubject(topic);
			message.setText(textMessage);

			Transport.send(message);

		} catch (MessagingException e) {
			Logger.getLogger(MailService.class.getName()).log(Level.WARNING, "Cannot send mail", e);
		}
	}

}
