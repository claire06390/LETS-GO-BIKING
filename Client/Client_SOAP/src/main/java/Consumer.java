import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.command.ActiveMQQueue;

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
            ActiveMQConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");
            Connection connection = connectionFactory.createConnection();
            connection.start();
            connection.setExceptionListener(this);
            Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);
            Destination destination = session.createQueue("error");

            MessageConsumer consumer = session.createConsumer(destination);
            Message message = consumer.receive();
            TextMessage textMessage = (TextMessage) message;
            String error = textMessage.getText();
            if(error.equals("True")){
                System.out.println("Aucun itinéraire trouvé suite a votre demande");
                consumer.close();
                session.close();
                connection.close();
                return;
            }
            consumer.close();

            destination = session.createQueue("isUtile");
            consumer = session.createConsumer(destination);
            message = consumer.receive();
            textMessage = (TextMessage) message;
            String isUtile = textMessage.getText();
            if(isUtile.equals("False")){
                System.out.println("Pour votre trajet il est plus rapide d'y aller a pieds");
                consumer.close();
                session.close();
                connection.close();
                return;
            }
            consumer.close();

            destination = session.createQueue("instructions");
            consumer = session.createConsumer(destination);
            message = consumer.receive();
            textMessage = (TextMessage) message;
            System.out.println(textMessage.getText());
            System.out.println("Tapez sur une touche afin de découvrir les instructions de votre trajet pas a pas");
            String instruction ="";
            while(instruction!=null){
                System.in.read();
                message = consumer.receive();
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


    public void deleteQueue(){
        ActiveMQConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");
        ActiveMQConnection conn = null;
        try {
            Connection connection = connectionFactory.createConnection();
            connection.start();
            conn = (ActiveMQConnection) connection;
            conn.destroyDestination(new ActiveMQQueue("isUtile"));
            conn.destroyDestination(new ActiveMQQueue("error"));
            conn.destroyDestination(new ActiveMQQueue("instructions"));
            connection.close();
        } catch (JMSException e) {
            System.out.println("Error connecting to the browser please check the URL" + e);
        }
    }



}
