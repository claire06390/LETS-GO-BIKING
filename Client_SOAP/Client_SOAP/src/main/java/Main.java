import com.baeldung.soap.ws.client.generated.BikeService;
import com.baeldung.soap.ws.client.generated.IBikeService;

import java.util.Scanner;

public class Main {

    public static final BikeService bikeService = new BikeService();
    public static final IBikeService iBikeService =bikeService.getNewBindingIBikeService();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Entrez votre point de départ :");
        String depart = scanner.nextLine();
        System.out.println("\nEntrez une destination :");
        String destination = scanner.nextLine();
        iBikeService.enqueueItinerary(depart,destination);
        Consumer consumer = new Consumer();
        consumer.run();


    }

}
