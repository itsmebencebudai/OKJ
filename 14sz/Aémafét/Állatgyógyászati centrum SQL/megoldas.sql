/* 1. feladat:  */
CREATE DATABASE centrum DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_c

/* 3. feladat:  */
SELECT id, kezdet, veg, dij FROM kezeles
-- SELECT
--     kezeles.kezdet,
--     kezeles.veg,
--     kezeles.dij
-- FROM
--     kezeles

/* 4. feladat:  */
SELECT nev, kerulet FROM gazda WHERE kerulet = 17 OR kerulet = 10 ORDER BY kerulet, nev
-- SELECT
--     gazda.nev,
--     gazda.kerulet
-- FROM
--     gazda
-- WHERE
--     gazda.kerulet BETWEEN 17 and 18 
-- ORDER BY
--     gazda.kerulet,
--     gazda.nev

/* 5. feladat:  */
SELECT kezelestipus.jelleg, COUNT(kezeles.kezelestipusId) FROM kezeles INNER JOIN kezelestipus ON kezeles.kezelestipusId = kezelestipus.id GROUP BY    kezeles.kezelestipusId ORDER BY kezelestipus.jelleg
-- SELECT
--     kezelestipus.jelleg,
--     COUNT(kezeles.kezelestipusId) AS "darabszám"
-- FROM
--     kezeles
-- INNER JOIN kezelestipus ON kezeles.kezelestipusId = kezelestipus.id
-- GROUP BY
--     kezeles.kezelestipusId
-- ORDER BY
--     kezelestipus.jelleg

/* 6. feladat:  */
SELECT kezelestipus.jelleg FROM kezelestipus INNER JOIN kezeles ON kezelestipus.id = kezeles.kezelestipusId WHERE kezeles.veg <= '2017/12/31' AND kezeles.veg >= '2017/10/01' AND kezelestipus.jelleg LIKE "%gyógy%" GROUP BY kezelestipus.jelleg
-- SELECT
--     kezelestipus.jelleg
-- FROM
--     kezelestipus
-- INNER JOIN kezeles ON kezelestipus.id = kezeles.kezelestipusId
-- WHERE
--     kezeles.veg <= '2017/12/31' AND kezeles.veg >= '2017/10/01' AND kezelestipus.jelleg LIKE "%gyĂłgy%"
-- GROUP BY
--     kezelestipus.jelleg

/* 7. feladat:  */
SELECT gazda.nev AS nev, COUNT(kezeles.id) AS alkalom, SUM(kezeles.dij) AS összesen FROM kezeles INNER JOIN kutya ON kezeles.kutyaId = kutya.id INNER JOIN gazda ON gazda.id = kutya.gazdaId WHERE gazda.nev LIKE "%Medgyessy%" GROUP BY gazda.nev ORDER BY COUNT(kezeles.id) DESC
-- SELECT
--     gazda.nev AS "nev",
--     COUNT(kezeles.id) AS "alkalom",
--     SUM(kezeles.dij) AS "összesen"
-- FROM
--     kezeles
-- INNER JOIN kutya ON kezeles.kutyaId = kutya.id
-- INNER JOIN gazda ON gazda.id = kutya.gazdaId
-- WHERE
--     gazda.nev LIKE "%Medgyessy%"
-- GROUP BY
--     gazda.nev
-- ORDER BY
--     COUNT(kezeles.id)
-- DESC
    
