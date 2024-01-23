/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT Users ON;

Insert into Users (Id, Pseudo, Email, Password)

VALUES
(0, "Spirou", "spirou@mail.be", "test1234="),
(1, "Fantasio", "fantasio@mail.be", "test1234="),
(2, "Lambique", "lambique@mail.be", "test1234="),
(3, "Gaston Lagaffe", "gaston@mail.be", "test1234="),
(4, "Seccotine", "seccotine@mail.be", "test1234="),
(5, "Mademoiselle Jeanne", "mademoiselle.jeanne@mail.be", "test1234="),
(6, "Spip", "spip@mail.be", "test1234="),
(7, "Zorglub", "zorglub@mail.be", "test1234="),
(8, "Papyrus", "papyrus@mail.be", "test1234="),
(9, "Asterix", "asterix@mail.be", "test1234="),
(10, "Schtrouph Farceur", "sch_farceur@mail.be", "test1234=");

SET IDENTITY_INSERT Users OFF;