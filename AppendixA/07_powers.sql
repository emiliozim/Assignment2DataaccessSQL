USE SuperheroesDb;

INSERT INTO Power(Name, Description)
VALUES	('Rich', 'Has alot of CASH!'),
		('Super strength',		'Has the strength of 20 men'),
		('Super speed',			'Faster the a speeding bullet'),
		('Webs',	'Can make webs');

 INSERT INTO SuperheroPower(PowerId, SuperheroId)
 VALUES (1, 1), 
		(2, 2), 
		(2, 3), 
		(3, 2), 
		(4, 3);
		