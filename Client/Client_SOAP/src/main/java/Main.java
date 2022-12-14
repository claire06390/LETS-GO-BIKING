import com.baeldung.soap.ws.client.generated.BikeService;
import com.baeldung.soap.ws.client.generated.IBikeService;

import java.util.Scanner;

public class Main {

    public static final BikeService bikeService = new BikeService();
    public static final IBikeService iBikeService =bikeService.getNewBindingIBikeService();

    public static void main(String[] args) {
        Consumer consumer = new Consumer();
        String startAgain = "o";
        while(startAgain.equals("o")){
            consumer.deleteQueue();
            Scanner scanner = new Scanner(System.in);
            System.out.println("Entrez votre point de départ :");
            String begin = scanner.nextLine();
            System.out.println("\nEntrez une destination :");
            String destination = scanner.nextLine();
            System.out.println("Nous recherchons un itinéraire pour votre demande veuillez patienter \n");
            try{
                iBikeService.enqueueItinerary(begin,destination);
            }catch (Exception e){
                System.out.println("Un problème est servenu veuillez verifier votre connexion internet \n Si le problème perdure il est possible que ce soit une erreur interne au serveur délivrant l'itinéraire");
            }
            consumer.run();
            System.out.println("\nVoulez vous chercher un autre itinéraire ? (o/n) ");
            startAgain =scanner.nextLine();
        }
    }
}
