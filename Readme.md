Projet Étudiant API
Ce projet est une API ASP.NET Core qui utilise LINQ pour manipuler et interroger des données d'étudiants provenant de deux sources différentes : JSON et XML. L'API permet de rechercher, trier et filtrer les données, et offre également une fonctionnalité de conversion de données entre les formats JSON et XML.

Prérequis
Pour exécuter ce projet, vous aurez besoin des éléments suivants installés sur votre machine :

.NET 5.0 SDK
Un IDE compatible, tel que Visual Studio Code avec l'extension C# pour Visual Studio Code.
Installation
Pour mettre en place le projet localement, suivez les étapes suivantes :

Clonez le dépôt Git :

git clone https://your-repository-url.git
Naviguez dans le dossier du projet :

cd LinqProject

Restaurez les dépendances du projet :

dotnet restore

Configuration
Aucune configuration supplémentaire n'est nécessaire pour exécuter le projet dans un environnement de développement. Toutes les configurations nécessaires sont déjà incluses dans les fichiers du projet.

Lancement de l'API
Pour lancer l'API, exécutez la commande suivante dans le répertoire du projet :

dotnet run

L'API sera accessible via http://localhost:5130/api/etudiant par défaut.

Utilisation
Voici quelques exemples d'utilisation de l'API via des requêtes HTTP :

Pour rechercher des étudiants par nom, prénom, ou email, utilisez l'URL suivante :

GET http://localhost:5130/api/etudiant/recherche?query=Jean

Pour trier tous les étudiants par nom en ordre alphabétique :

GET http://localhost:5130/api/etudiant/triernom

Pour obtenir une liste des étudiants ayant un âge minimum spécifié :

GET http://localhost:5130/api/etudiant/filtrerparage?ageMinimum=20

Pour convertir les données actuellement stockées au format JSON en XML :

POST http://localhost:5130/api/etudiant/convertjsonToxml




