CREATE TABLE majors (
    id INT PRIMARY KEY AUTO_INCREMENT,
    joc VARCHAR(50) NOT NULL,
    organitzador VARCHAR(50) NOT NULL,
    pais VARCHAR(50) NOT NULL,
    nom_major VARCHAR(100) NOT NULL,
    data VARCHAR(50) NOT NULL,
    ubicacio VARCHAR(50) NOT NULL
);

CREATE TABLE classificats (
    id INT PRIMARY KEY AUTO_INCREMENT,
    top INT NOT NULL,
    diners INT NOT NULL,
    pais VARCHAR(50) NOT NULL,
    nom_equip VARCHAR(50) NOT NULL,
    major_id INT NOT NULL,
    FOREIGN KEY (major_id) REFERENCES majors (id)
);

CREATE TABLE equips (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom_equip VARCHAR(50) NOT NULL,
    diners_totals INT NOT NULL,
    top1_count INT NOT NULL,
    top2_count INT NOT NULL,
    top3_count INT NOT NULL,
    majors_jugats INT NOT NULL,
    classificats_id INT,
    FOREIGN KEY (classificats_id) REFERENCES classificats (id)
);
