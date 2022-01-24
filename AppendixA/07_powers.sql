USE SuperheroesDb;

INSERT INTO Power(Name, Description)
VALUES	('Rich', 'Has alot of CASH!'),
		('Super strength',		'Has the strength of 20 men'),
		('Super speed',			'Faster the a speeding bullet'),
		('Webs',	'Can make webs');
		

 INSERT INTO SuperheroPower(SuperheroId, PowerId)
 VALUES (1, 1), 
		(2, 2), 
		(3, 2), 
		(2, 3), 
		(3, 4);
		