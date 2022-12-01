import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.Connection;
import javax.jms.DeliveryMode;
import javax.jms.Destination;
import javax.jms.ExceptionListener;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import java.util.Scanner;

public  class Consumer implements Runnable, ExceptionListener {

    public void run() {
        try {
            System.out.println("Nous recherchons un itinéraire pour votre demande veuillez patienter \n");
            ActiveMQConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");
            Connection connection = connectionFactory.createConnection();
            connection.start();
            connection.setExceptionListener(this);
            Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);
            Destination destination = session.createQueue("error");
            MessageConsumer consumer = session.createConsumer(destination);
            Message message = consumer.receive(1000);
            TextMessage textMessage = (TextMessage) message;
            String error = textMessage.getText();
            System.out.println("Received error: " + error);
            if(error.equals("True")){
                System.out.println("Aucun itinéraire trouvé suite a votre demande");
                return;
            }
            consumer.close();

            destination = session.createQueue("isUtile");
            consumer = session.createConsumer(destination);
            message = consumer.receive(1000);
            textMessage = (TextMessage) message;
            String isUtile = textMessage.getText();
            System.out.println("Received isUtile: " + isUtile);
            if(isUtile.equals("False")){
                System.out.println("Pour votre trajet il est plus rapide d'y aller a pieds");
                return;
            }
            consumer.close();

            destination = session.createQueue("instructions");
            consumer = session.createConsumer(destination);
            String instruction ="";
            while(instruction!=null){
                message = consumer.receive(1000);
                textMessage = (TextMessage) message;
                if(textMessage==null)
                    break;
                instruction = textMessage.getText();
                System.out.println(instruction);
            }
            consumer.close();
            session.close();
            connection.close();
        } catch (Exception e) {
            System.out.println("Caught: " + e);
            e.printStackTrace();
        }
    }
    public synchronized void onException(JMSException ex) {
        System.out.println("JMS Exception occured.  Shutting down client.");
    }
}
