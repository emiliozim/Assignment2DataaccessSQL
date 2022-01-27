USE SuperheroesDb;

CREATE TABLE SuperheroPower (
	SuperheroId int,
	PowerId int,
	FOREIGN KEY (SuperheroId) REFERENCES Superhero(SuperheroId),
    FOREIGN KEY (PowerId) REFERENCES Power(PowerId),
	PRIMARY KEY (SuperheroId, PowerId)
);