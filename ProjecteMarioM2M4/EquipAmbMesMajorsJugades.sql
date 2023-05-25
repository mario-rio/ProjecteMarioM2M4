DELIMITER //

CREATE PROCEDURE EquipAmbMesMajorsJugades()
BEGIN
    SELECT nom_equip
    FROM equips
    WHERE majors_jugats = (SELECT MAX(majors_jugats) FROM equips);
END //

DELIMITER ;
