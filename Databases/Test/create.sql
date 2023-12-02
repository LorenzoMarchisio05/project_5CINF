DROP TABLE Lauerati;
DROP TABLE Quadri;
DROP TABLE Impiegati

-- Create

CREATE TABLE Lauerati (
	matricola int primary key,
	cognome varchar(75) not null,
	data_nascita date not null,
);

CREATE TABLE Quadri (
	matricola int primary key,
	cognome varchar(75) not null,
	data_nascita date not null,
);

CREATE TABLE Impiegati (
    matricola int primary key,
    cognome varchar(75) not null,
    filiale varchar(75) not null,
    stipendio money not null,
);

-- Insert 

INSERT INTO Lauerati (matricola, cognome, data_nascita) VALUES
    (1324, 'Rossi', '1990-05-15'),
    (2145, 'Bianchi', '1985-08-22'),
    (3234, 'Verdi', '1992-02-10'),
    (4145, 'Neri', '1988-11-30');

INSERT INTO Quadri (matricola, cognome, data_nascita) VALUES
    (1324, 'Rossi', '1990-05-15'),
    (2145, 'Bianchi', '1985-08-22'),
    (3234, 'Verdi', '1992-02-10'),
    (5123, 'Gialli', '1995-07-03');

INSERT INTO Impiegati (matricola, cognome, filiale, stipendio) VALUES
    (101, 'Rossi', 'Filiale A', 50000.00),
    (102, 'Bianchi', 'Milano', 62000.00),
    (103, 'Verdi', 'Filiale A', 55000.00),
    (104, 'Neri', 'Milano', 70000.00),
    (105, 'Gialli', 'Filiale B', 62000.00);
