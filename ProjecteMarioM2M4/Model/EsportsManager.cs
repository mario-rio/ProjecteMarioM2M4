using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjecteMarioM2M4.Database;
using ProjecteMarioM2M4.Model;

namespace ProjecteMarioM2M4
{
    public static class EsportsManager
    {
        public static bool CarregarModel(string filePath, DatabaseConnection dbConnection)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                var majors = xmlDoc.Root.Elements("major")
                    .Select(majorElement => new Majors
                    {
                        Joc = (string)majorElement.Attribute("joc"),
                        Organitzador = (string)majorElement.Attribute("organitzador"),
                        Pais = (string)majorElement.Attribute("pais"),
                        NomMajor = (string)majorElement.Element("nom_major").Value,
                        Data = (string)majorElement.Element("data"),
                        Ubicacio = (string)majorElement.Element("ubicacio"),
                        Classificats = majorElement.Element("classificats").Elements("equip")
                            .Select(equipElement => new Classificats
                            {
                                Top = (int)equipElement.Attribute("top"),
                                Diners = (int)equipElement.Attribute("diners"),
                                Pais = (string)equipElement.Attribute("pais"),
                                NomEquip = (string)equipElement.Value
                            }).ToList()
                    }).ToList();

                foreach (var major in majors)
                {
                    string query = $"INSERT INTO majors (joc, organitzador, pais, nom_major, data, ubicacio) VALUES " +
                                   $"('{major.Joc}', '{major.Organitzador}', '{major.Pais}', '{major.NomMajor}', '{major.Data}', '{major.Ubicacio}');";

                    dbConnection.ExecuteQuery(query);

                    int majorId = GetLastInsertedId(dbConnection);

                    foreach (var classificat in major.Classificats)
                    {
                        query = $"INSERT INTO classificats (top, diners, pais, nom_equip, major_id) VALUES " +
                                $"({classificat.Top}, {classificat.Diners}, '{classificat.Pais}', '{classificat.NomEquip}', {majorId});";

                        dbConnection.ExecuteQuery(query);
                    }
                }

                InsertEquipsData(dbConnection);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading XML data: " + ex.Message);
                return false;
            }
        }

        private static int GetLastInsertedId(DatabaseConnection dbConnection)
        {
            string query = "SELECT LAST_INSERT_ID();";
            object result = dbConnection.ExecuteScalarQuery(query);
            if (result != null && int.TryParse(result.ToString(), out int lastInsertedId))
                return lastInsertedId;
            return -1;
        }

        private static void InsertEquipsData(DatabaseConnection dbConnection)
        {
            string query = @"
                INSERT INTO equips (nom_equip, diners_totals, top1_count, top2_count, top3_count, majors_jugats)
                SELECT c.nom_equip,
                       SUM(c.diners) AS diners_totals,
                       COUNT(CASE WHEN c.top = 1 THEN 1 END) AS top1_count,
                       COUNT(CASE WHEN c.top = 2 THEN 1 END) AS top2_count,
                       COUNT(CASE WHEN c.top = 3 THEN 1 END) AS top3_count,
                       COUNT(DISTINCT m.id) AS majors_jugats
                FROM classificats c
                JOIN majors m ON c.major_id = m.id
                GROUP BY c.nom_equip
                ON DUPLICATE KEY UPDATE
                    diners_totals = VALUES(diners_totals),
                    top1_count = VALUES(top1_count),
                    top2_count = VALUES(top2_count),
                    top3_count = VALUES(top3_count),
                    majors_jugats = VALUES(majors_jugats);";

            dbConnection.ExecuteQuery(query);
        }
    }
}