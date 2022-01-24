USE SuperHerosDb

CREATE TABLE SuperheroPower (
	SuperheroID int FOREIGN KEY REFERENCES SuperHero(Superhero_ID),
    PowerID int FOREIGN KEY REFERENCES Power(Power_ID),
	PRIMARY KEY (SuperheroID, PowerID)
);
