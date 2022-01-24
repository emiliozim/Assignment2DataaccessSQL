USE SuperHerosDb

ALTER TABLE Assistant ADD Superhero_ID int NOT NULL FOREIGN KEY (Superhero_ID) REFERENCES SuperHero(Superhero_ID);

