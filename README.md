# OneWayWork
Projet application **.NET MAUI** pour la classe 420-413-MV DÉVELOPPEMENT D'APPLICATIONS POUR ENTREPRISE

## Notre Application
One Way Work vous offre une application qui a pour but de faire les gestions de stages. Étudiant, Stagiaire, Admin et Entrepise seront ravis !

## Aperçu
![](https://github.com/FastGlory/OneWayWork/blob/main/apercuApp/MauiApp12024-05-1107-58-07-ezgif.com-video-to-gif-converter%20(1).gif)

## Les technologies utilisés 

<img src="https://github.com/FastGlory/OneWayWork/blob/main/apercuApp/dotnet-bot-maui-cross-platform-development.png" alt="image" width="10%" height="auto">

| Contexte  | Technologies |
| ------------- | ------------- |
| **Frontend** | .Net maui, XAML |                                       
| **Backend** | C# avec .NET |
| **Base de données** | SQLite et Entity Framework |
| **Architecture de l'application** | MVVM |

## Comment installer et déployer notre application

### Option Visual Studio Code | Mode développeur
> [!IMPORTANT]
> Pour cette option, il est important d'avoir installé `Visual Studio 2022 17.8 ou supérieur` et `.NET Multi-platform App UI workload`
>  Pour plus de détails, il serait interessant de consulter cette page : [.Net Maui Tutoriel](https://dotnet.microsoft.com/en-us/learn/maui/first-app-tutorial/install), de plus il serait important d'activer le ***mode de développeur*** sur votre appareil.

1. Ouvir Git Bash et cloner le chemin du répertoire de ce Github sur votre appareil : 
   ```
   git clone https://github.com/FastGlory/OneWayWork.git
   ```
2. Aller dans le dossier ***ProjetMauiWWO***

3. Cliquer sur le fichier ***ProjetMauiWWO.sln***

4. Sur le haut de la barre de navigation, cliquer sur la fléche verte pour lancer notre application

5. Vous pouvez vous connecter, si ce n'est pas déja fait, vous pouvez vous inscrire.
  
7. Si vous êtes une Entreprise : Code secret => XVC123


> [!WARNING]
> Assurez vous d'avoir ***Windows Machine*** comme moyen de debugger près de la flèche verte.


### Option Executable | Mode utilisateur



## Comment est structuré notre code

Comme décrit plus haut, nous avons utilisé une architecture MVVM. On à séparé nos dossier en "View", "ViewModel" et "Model". Dans le dossier "View" nous avons mis toute nos pages qui vont être visuel, tout ce que l'utilisateur pourra voir. Dans le viewModel, nous avons mis les méthodes pour le CRUD et ce qui sert à relié la base de donné à notre code. De plus, il y a un éléments important qui est le "IDSession", cette éléments est ce qui nous sert pour reconnaitre un compte à un autre. Dans notre dossier Model, nous avoir mis les tables pour leur création dans la base de donné.

Pour ce qui est des images, nous avons tout mis dans le dossier Ressource. Nous n'avont pas importé des outils pour ce qui est d'améliorer le visuels comme des fonts ou des icon, on s'est contenté de ce que .Net maui proposé de base.

*Resssource*

- Dossier images

Model (table pour la base de donné

 >*   Administrateur.cs
   
 >*  Candidature.cs
   
 >* Entreprise.cs
   
 >*  Stage.cs
   
 >*  Stagiaire.cs

*View*
   >* Page de brouillon 
   
   >* Page de Candidature 
   
   >* Page de Connexion et inscription 
   
   >* Page de Stage 
   
   >* Page de création de stage
   
   >* Page d'Accueil pour Admin, Stagaire et Entreprise
   
   >* Page de stagiaire (profile) 
   
   >* Page de brouillon 

*ViewModel*

   >* LocalDataBase.cs
   
   >* idSessionSeriveApp.cs




## Lien externe
[Notre trello](https://trello.com/invite/b/RDL4M1o0/ATTI6310eb61ccd7765e676c0b5163f53407686A2745/onewaywork)


## Collaborateurs
[Juba Redjradj](https://github.com/FastGlory)

[Aya Issa](https://github.com/AyaIssa1)

[Nadine Chargui](https://github.com/Nchargui)
