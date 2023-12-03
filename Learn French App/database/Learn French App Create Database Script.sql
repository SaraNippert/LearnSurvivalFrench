USE master;
GO

IF DB_ID('LearnFrenchAppDB') IS NOT NULL
BEGIN
	ALTER DATABASE LearnFrenchAppDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE LearnFrenchAppDB;
END
GO

CREATE DATABASE LearnFrenchAppDB;
GO

USE LearnFrenchAppDB
GO

-------------------------------------------------------------------------------------------------

--Create Vocabulary Table

CREATE TABLE [Vocab] (
    id				INT				NOT NULL IDENTITY (1,1),
	theme_id		INT				NOT NULL,
	sub_theme_id	INT				NOT NULL,
    english			NVARCHAR (150)	NOT NULL,
	french			NVARCHAR (150)	NOT NULL,
);

--Create Theme Name Table:

CREATE TABLE [Themes] (
    theme_id		INT				NOT NULL PRIMARY KEY,
	sub_theme_id	INT				NOT NULL,
	theme_name		NVARCHAR(150)	NOT NULL,
	sub_theme_name	NVARCHAR(150)	NOT NULL,
);

-------------------------------------------------------------------------------------------------
--Voabulary Inserts

INSERT INTO [Vocab] ([theme_id], [sub_theme_id], [english], [french]) 
VALUES 
	--Introductions, Greetings
	(1, 1, 'Hello', 'Bonjour'),
   (1, 1, 'Good Evening', 'Bonsoir'),
   (1, 1, 'Goodbye','Au revoir'),
   (1, 1, 'Hi/Bye','Salut'),
   (1, 1, 'Hey','Coucou'),
   (1, 1, 'Later','A plus'),
   (1, 1, 'What''s up?','Quoi de neuf ?'),

   --Introductions, Mood
	(1, 2, 'How''s it going?', 'Ca va ?'),
   (1, 2, 'It''s going', 'Ca va'),
   (1, 2, 'it''s going good','Ca va bien'),
   (1, 2, 'it''s going bad','Ca va mal'),
   (1, 2, 'How are you?', 'Comment allez-vous ?'),
   (1, 2, 'I''m doing well', 'Je vais bien'),
   (1, 2, 'I''m doing bad', 'Je vais mal'),
   (1, 2, 'And you? (informal)','Et toi ?'),
   (1, 2, 'And you? (formal)','Et vous ?'),

	--Introductions, Names
	(1, 3, 'What''s your name? (informal)', 'Comment tu t''appelles ?'),
	(1, 3, 'What''s your name? (formal)','Comment vous applez-vous ?'),
	(1, 3, 'My name is','Je m''appelle'),
	(1, 3, 'Who''s that?','C''est qui ?'),
	(1, 3, 'What''s his name?','Il s''appelle comment ?'),
	(1, 3, 'His name is','Il s''appelle'),
	(1, 3, 'What''s her name?','Elle s''appelle comment ?'),
	(1, 3, 'Her name is','Elle s''appelle'),
	(1, 3, 'Here is', 'Voila'),

	--Introductions, Sentences
	(1, 4, 'Good evening, how''re you?', 'Bonsoir, comment allez-vous ?'),
	(1, 4, 'Here is Pierre.', 'Voila Pierre.'),
	(1, 4, 'Hey, how''s it going?', 'Coucou, ca va ?'),
	(1, 4, 'My name is Julie.', 'Je m''appelle Julie.'),
	(1, 4, 'Her name is Manon.', 'Elle s''appelle Manon.'),
	(1, 4, 'Nice to meet you. (m)','Enchante.'),
	(1, 4, 'Nice to meet you. (f)','Encantee.'),

	--Plans, Base
	(2, 1, 'Do you want to?', 'Tu veux ?'),
	(2, 1, 'go out', 'sortir'),
	(2, 1, 'to go', 'aller'),
	(2, 1, 'Yes', 'Oui'),
	(2, 1, 'No','Non'),
	(2, 1, 'I can.','Je peux.'),
	(2, 1, 'I can''t.','Je ne peux pas.'),
	(2, 1, 'I want to.','Je veux.'),
	(2, 1, 'I''m sick.','Je suis malade.'),

	--Plans, Places
	(2, 2, 'to the beach', 'a la plage'),
	(2, 2, 'to the movies', 'au cinema'),
	(2, 2, 'to the cafe', 'au cafe'),
	(2, 2, 'to the park', 'au parc'),
	(2, 2, 'to the bar','au bar'),
	(2, 2, 'to the restaurant','au resto'),

	--Plans, Frequency
	(2, 3, 'today', 'aujourd''hui'),
	(2, 3, 'tomorrow','demain'),
	(2, 3, 'morning','matin'),
	(2, 3, 'afternoon','apres-midi'),
	(2, 3, 'night','soir'),
	(2, 3, 'later','plus tard'),
	(2, 3, 'now','maintenant'),

	--Plans, Sentences
	(2, 4, 'Do you want to go to the movies?', 'Tu veux aller au cinema ?'),
	(2, 4, 'Do you want to go out later?','Tu veux sortir plus tard ?'),
	(2, 4, 'Yes, I want to.','Oui, je veux.'),
	(2, 4, 'No, I can''t.','Non, je ne peux pas.'),
	(2, 4, 'No, I I''m sick.','Non, je suis malade.'),
	(2, 4, 'I can''t, I''m sick.','Je ne peux pas, je suis malade.'),
	(2, 4, 'I want to go to the park now.','Je veux aller au parc maintenant.'),

	--Resto, Host Stand
	(3, 1, 'To go or for here?', 'A emporter ou sur place ?'),
	(3, 1, 'To go.','A emporter.'),
	(3, 1, 'Please.', 'S''il vous plait.'),
	(3, 1, 'Thank you.', 'Merci.'),
	(3, 1, 'What would you like?','Qu''est-ce que vous voulez ?'),
	(3, 1, 'I would like','Je voudrais'),
	(3, 1, 'To drink?','A boire ?'),

	--Resto, For Here
	(3, 2, 'For here.', 'Sur place.'),
	(3, 2, 'How many people?','Combien de personnes ?'),
	(3, 2, 'one (m)', 'un'),
	(3, 2, 'one (f)', 'une'),
	(3, 2, 'two','deux'),
	(3, 2, 'three', 'trois'),
	(3, 2, 'four', 'quatre'),
	(3, 2, 'Table for two.', 'Une table pour deux personnes.'),
	(3, 2, 'Follow me.', 'Suivez-moi.'),

	--Resto, Food
	(3, 3, 'a glass of wine', 'un verre de vin'),
	(3, 3, 'a soda', 'un soda'),
	(3, 3, 'water', 'l''eau'),
	(3, 3, 'a meal', 'un repas'),
	(3, 3, 'I have an allergy to','J''ai une allergie a'),
	(3, 3, 'dessert','un dessert'),
	(3, 3, 'check','l''addition'),

	--Resto, Sentences
	(3, 4, 'Table for three please.', 'Une table pour deux personnes.'),
	(3, 4, 'To go, please.','A emporter, s''il vous plait.'),
	(3, 4, 'I would like water, please.','Je voudrais l''eau, s''il vous plait'),
	(3, 4, 'I would like two desserts, please.','Je voudrais deux desserts, s''il vous plait.'),
	(3, 4, 'Hello, what would you like?','Bonjour, qu''est-ce que vous voulez ?'),

	--Interests, Base
	(4, 1, 'What do you like to do?', 'Qu''est-ce que tu aimes faire ?'),
	(4, 1, 'I like','J''aime'),
	(4, 1, 'I love','J''adore'),
	(4, 1, 'I hate','Je deteste'),
	(4, 1, 'to read','lire'),
	(4, 1, 'to exercise','faire de l''exercise'),
	(4, 1, 'to go out','sortir'),
	(4, 1, 'to play games','jouer aux jeux'),
	(4, 1, 'and','et'),
	(4, 1, 'but','mais'),

	--Interests, Positive
	(4, 2, 'often', 'souvent'),
	(4, 2, 'usually','d''habitude'),
	(4, 2, 'sometimes','quelquefois'),
	(4, 2, 'I read.','Je lis.'),
	(4, 2, 'I exercise.','Je fais de l''exercise.'),
	(4, 2, 'I exercise often.','Je fais souvent de l''exercise.'),
	(4, 2, 'I go out.','Je sors.'),
	(4, 2, 'I go out sometimes.','je sors quelquefois.'),
	(4, 2, 'I play games.','Je joue aux jeux.'),
	(4, 2, 'I sometimes play games.','Je joue quelquefois aux jeux.'),

	--Interests, Negative
	(4, 3, 'never', 'jamais'),
	(4, 3, 'rarely','rarement'),
	(4, 3, 'to study','etudier'),
	(4, 3, 'I study.','J''etudie.'),
	(4, 3, 'I don''t study.','Je n''etudie pas.'),
	(4, 3, 'I never study.','J''etudie rarement.'),
	(4, 3, 'to draw','dessiner'),
	(4, 3, 'I draw.','Je dessine'),
	(4, 3, 'I don''t draw.','Je ne dessine pas.'),
	(4, 3, 'I rarely draw.','Je dessine rarement.'),

	--Interests, Sentences
	(4, 4, 'I often go out.', 'Je sors souvent.'),
	(4, 4, 'I hate to play games.','Je deteste jouer aux jeux.'),
	(4, 4, 'I love to study, but I hate to exercise.','J''adore etudier, mais je deteste faire de l''exercise.'),
	(4, 4, 'I rarely go out, but I often read.','Je sors rarement, mais je lis souvent.'),
	(4, 4, 'I don''t draw, but I go out.','Je ne dessine pas, mais je sors.')

--INSERT INTO [Themes] ([theme_id], [sub_theme_id], [theme_name], [sub_theme_name]) 
--VALUES
--	(1, 1, 'Introductions', 'Greetings'),
--	(1, 2, 'Introductions','Mood'),
--	(1, 3, 'Introductions','Names'),
--	(1, 4, 'Introductions','Sentences'),
--	(2, 1, 'Mood', ''),
--	(2, 2, 'Mood', ''),
--	(2, 3, 'Mood', ''),
--	(2, 4, 'Mood', ''),
--	(3,'Restaurant'),
--	(4,'Interests')

----------------------------------------------------------------------------------------------------
--Add Foreign Keys 

----ALTER TABLE [Vocab] ADD CONSTRAINT [FK_theme_id] FOREIGN KEY (theme_id) REFERENCES [Themes](theme_id);
--ALTER TABLE [Themes] ADD CONSTRAINT [FK_theme_id] FOREIGN KEY (theme_id) REFERENCES [Vocab](theme_id);
----ALTER TABLE [Vocab] ADD CONSTRAINT [FK_sub_theme_id] FOREIGN KEY (sub_theme_id) REFERENCES [Sub_Themes](sub_theme_id);
--ALTER TABLE [Sub_Themes] ADD CONSTRAINT [FK_sub_theme_id] FOREIGN KEY (sub_theme_id) REFERENCES [Vocab](sub_theme_id);

