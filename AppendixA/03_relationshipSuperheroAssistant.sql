USE SuperheroesDb;

ALTER TABLE Assistant
ADD SuperheroId int,
CONSTRAINT FK_Superhero_Assistant
FOREIGN KEY (SuperheroId) REFERENCES Superhero(SuperheroId);