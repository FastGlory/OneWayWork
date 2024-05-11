# Revue de Code (Code Review)

> ![](https://oroinc.com/orocrm/wp-content/uploads/sites/8/2017/09/code-review-best-practices.png)`

***

### Objectif 

La revue de code est un processus essentiel dans le développement. Elle joue un rôle important dans l'amélioration de la qualité du code.
Il s'agit d'une analyse méthodique du code par des pairs ou des développeurs expérimentés afin de repérer les éventuelles erreurs, d'améliorer les 
performances et assurer le respect des normes de programmation.

Il est important de réviser le code pour diverses raisons. En premier lieu, elle permet de repérer les bogues et les erreurs de codage qui auraient pu être négligées lors du développement. En sollicitant l'avis de plusieurs paires d'yeux sur le code, cela augmente les chances de repérer des erreurs qui auraient pu être négligées et de résoudre les problèmes avant qu'ils ne parviennent à l'utilisateur final.

> Par la suite, la révision du code joue le rôle d'une plateforme de partage de savoir. Quand les développeurs étudient le code de chaque personne, ils sont informés des diverses méthodes de codage et techniques. Cela favorise la contribution d'une culture d'apprentissage et d'amélioration constante au sein de l'équipe technique.

> Le code est également révisé afin de respecter les normes de codage et les meilleures pratiques. Il est possible que plusieurs équipes aient leurs propres directives et conventions de codage. La modification du code permet d'assurer le respect de ces normes de manière cohérente tout au long du projet.

> Enfin, il est important de réviser le code afin de créer un code de qualité qui soit stable, lisible et compréhensible. Elle offre la possibilité de repérer les éventuelles erreurs et bogues, d'améliorer les performances et de s'assurer du respect des normes de codage.

## Éléments à considérer lors de la revue de code

* Respect des normes du codage de l'équipe.
* Le code est clair et facile à lire.
* Performance du code.
* Protection contre les tests (si nécessaire).
* Considérations la sécurité.
* Conserver la flexibilité et la durabilité du code.

## Processus de Revue de Code

À chaque transition de branche, nous avons l'obligation de vérifier le code de chaque membre afin d'évaluer son état et son rendu. Cela nous permettra de suivre son avancement et, par la suite, de procéder à une revue de son code, à des changements ou des ajouts effectués. 

### Commentaire constructifs
> Afin de fournir un retour positif et constructif, il est essentiel de maintenir une approche objective et de fournir des exemples précis pour illustrer le retour. Il est important de fournir un retour constructive, sans accuser ou critiquer le collaborateur. Il est tout aussi essentiel de prendre en compte la réponse du collaborateur afin de saisir son point de vue.
***
# DoD (Definition of Done)
> ![](https://th.bing.com/th/id/OIP.oQpzqqLVbZbz8oi4zjkm9wHaEZ?rs=1&pid=ImgDetMain)`
### Définition
Done est une tâche ou un élément de travail qui est achevé selon un certain niveau de qualité convenu. Elle répond à toutes les spécifications, exigences et tests nécessaires pour être considéré comme complet.

### Critères de la DoD

> * Code rédigé et vérifié
> * Documentation actualisée
> * Révision du code réalisée
> * Réussite de l'intégration continue
> * Le produit est approuvé par le responsable

### Validation de la DoD
* Demander à l'équipe de confirmer la DoD une fois qu'elle est terminée. 
* Veiller à ce que chaque membre de l'équipe ait une compréhension claire du sens de chaque critère de qualité et de son application à leur travail quotidien.
***
# Style de Code de l'Équipe

## Normes de Codage
>  ### La Syntaxe des commentaire
>  * Chaque ligne de code difficile à comprendre doit être commentée pour aider à la compréhension.
>  * Fournir une brève explication pour les autres membres de l'équipe.

>  ### Nom de variable
> Les noms des boutons doivent être explicites, permettant à n'importe qui de comprendre leur fonction.
>   * Pour nos boutons qui servent à naviguer entre les pages, nous utilisons les mots clés 'On' et 'Tapped'. Cela décrit exactement que ce bouton nous amène à une page spécifique.
    
```csharp
private async void OnInscriptionTapped(object sender, EventArgs e)
{
await Navigation.PushAsync(new InscriptionView(_localDbService));
}
```

> * Les méthodes et les noms de variables doivent être en anglais, mais il est également permis d'utiliser le français.
> * Les noms de méthodes doivent correspondre à l'action qu'elles effectuent.
>   ### Architecture
> * Obligation d'utiliser la structure MVVM
> * Obligation d'utiliser XAML .Net maui
>  ### Architecture logicielle
> * CRUD
>   - Create, Read, Update, Delete

## Outils utilisé
> - Pour le formatage, ajouter l'extension XAML Styler.
>     - Cela permet de formater automatiquement votre code.
>         - Vous pouvez également utiliser la commande CTRL K + CTRL D.
> * Limitez les couleurs aux choix de blanc, noir ou transparent.
> * Ajoutez des images pour embellir l'application.
 ***
## Exemples de Code illustrant les normes de codage

```csharp
public async Task AddStage(Stage stage)
   {
       await _connection.InsertAsync(stage);
   }
 
   public async Task UpdateStage(Stage stage)
   {
       await _connection.UpdateAsync(stage);
   }
 
   public async Task DeleteStage(Stage stage)
   {
       await _connection.DeleteAsync(stage);
   }
 
   public async Task<List<Stage>> GetStage()
   {
       return await _connection.Table<Stage>().ToListAsync();
   }
 
   
   // Méthodes CRUD pour la table Entreprise
   public async Task<List<Entreprise>> GetEntreprises()
   {
       return await _connection.Table<Entreprise>().ToListAsync();
   }
   public async Task<List<Stage>> GetStagesByEntrepriseId(int entrepriseId)
   {
       return await _connection.Table<Stage>().Where(x => x.Id_Entreprise == entrepriseId).ToListAsync();
   }
 
 
   public async Task<Entreprise> GetEntrepriseByNom(string nom)
   {
       return await _connection.Table<Entreprise>().Where(x => x.Nom_Entreprise == nom).FirstOrDefaultAsync();
   }
 
   public async Task AddEntreprise(Entreprise entreprise)
   {
       await _connection.InsertAsync(entreprise);
   }
 
   public async Task UpdateEntreprise(Entreprise entreprise)
   {
       await _connection.UpdateAsync(entreprise);
   }
 
   public async Task DeleteEntreprise(Entreprise entreprise)
   {
       await _connection.DeleteAsync(entreprise);
```
