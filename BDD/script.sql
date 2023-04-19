CREATE TABLE departement(
   id_dep INT IDENTITY (1,1) ,
   nom_dep VARCHAR(250) NOT NULL,
   reg_dep VARCHAR(250),
   PRIMARY KEY(id_dep)
);

CREATE TABLE specialite(
   id_spe INT IDENTITY (1,1),
   lib_spe VARCHAR(100) NOT NULL,
   PRIMARY KEY(id_spe)
);

CREATE TABLE users(
   id_users INT IDENTITY(1,1),
   pseudo_users VARCHAR(25) NOT NULL,
   mdp_users VARCHAR(15) NOT NULL,
   PRIMARY KEY(id_users)
);

CREATE TABLE medecin(
   id_med INT IDENTITY (1,1),
   nom_med VARCHAR(50) NOT NULL,
   pre_med VARCHAR(50) NOT NULL,
   adr_med VARCHAR(250) NOT NULL,
   tel_med VARCHAR(50) NOT NULL,
   _FK_id_spe INT,
   _FK_id_dep INT NOT NULL,
   PRIMARY KEY(id_med),
   FOREIGN KEY(_FK_id_spe) REFERENCES specialite(id_spe),
   FOREIGN KEY(_FK_id_dep) REFERENCES departement(id_dep)
);
