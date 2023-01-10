# Projet : LET’S GO BIKING!

Consignes de lancement :

-Ce projet utilise les API JC Decaux et graphhopper, il faut donc être connecté à internet pour le lancer.

-Ce projet comporte un proxy/cache en c# qu'il faut lancer à la racine du projet avec la commande suivante :

start Serveur\ProxyCache\routing_serveurSOAP\bin\Debug\routing_serveurSOAP

-Ce projet comporte un serveur en c# qu'il faut lancer à la racine du projet avec la commande suivante :

start Serveur\RoutingServeur\RoutingServeur\bin\Debug\RoutingServeur

-Le partage de l'itinéraire entre le client et le serveur se fait via Activemq, vous avez donc besoin d'activemq installé et de le lancer grâce à la commande suivante à exécuter dans le dossier /bin d'activemq :

activemq start

-Une fois tout ces éléments lancés, vous n'avez plus qu'à lancer le client et demander un itinéraire qui
vous sera donné instructions par instructions dans la console.

-Ce projet comporte un client en java, pour le lancer il faut le compiler puis lancer le main qui se trouve dans la classe :

Client\Client_SOAP\src\main\java\Main.java

Merci pour votre temps et bonne journée :)
