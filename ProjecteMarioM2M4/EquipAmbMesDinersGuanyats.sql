DELIMITER 

CREATE PROCEDURE EquipAmbMesDinersGuanyats()
BEGIN
    SELECT nom_equip
    FROM classificats
    WHERE diners = (SELECT MAX(diners) FROM classificats);
END 

DELIMITER ;
