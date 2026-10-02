#V_art database
USE v_art;
-- First query for v_art database
INSERT INTO artist (fname, lname, dob, dod, country, local)
VALUES ('Johannes', 'Vermeer', 1632, 1674, 'Netherlands', 'N');

-- Second query for v_art database
SELECT *
FROM artist
ORDER BY lname;

-- Third query for v_art database
UPDATE artist
SET dod = 1675
WHERE artist_id = 10;

-- Fourth and last query for v_art database
DELETE FROM artist
WHERE artist_id = 10;

#Bike Database
USE bike;
-- First query for bike database
SELECT first_name, last_name, phone
FROM customer
WHERE state = 'TX' AND city = 'Houston';

-- Second query for bike database
SELECT product_name, list_price, list_price - 500 AS 'Discounted Price'
FROM product
WHERE list_price >= 5000
ORDER BY list_price DESC;

-- Third query for bike database
SELECT first_name, last_name, email
FROM staff
WHERE store_id <> 1;

-- Fourth query for bike database
SELECT product_name, model_year, list_price
FROM product
WHERE product_name LIKE '%spider%';

-- Fifth query for bike database
SELECT product_name, list_price
FROM product
WHERE list_price BETWEEN 500 AND 550
ORDER BY list_price ASC;

-- Sixth query for bike database
SELECT first_name, last_name, phone, street, city, state, zip_code
FROM customer
WHERE phone IS NOT NULL AND city LIKE '%ach%' OR phone IS NOT NULL AND city LIKE '%och%' OR last_name = 'William'
LIMIT 5;

-- Seventh query for the bike database
SELECT SUBSTRING(product_name, 1, LOCATE(' -', product_name)) AS 'Product Name Without Year'
FROM product
ORDER BY product_id ASC
LIMIT 14;

-- Eigthth query for the bike database
SELECT product_name, CONCAT('$', FORMAT(list_price / 3, 2, 'en-US')) AS 'One of 3 Payments'
FROM product
WHERE product_name LIKE '%2019';

#Magazine Database
USE magazine;
-- First query for magazine database
SELECT magazineName, ROUND(magazinePrice - 3 / 100 * magazinePrice, 2) AS '3% Off'
FROM magazine;

-- Second query for magazine database
SELECT subscriberKey, ROUND(DATEDIFF('2020-12-20', subscriptionStartDate) / 365) AS 'Years since subscription'
FROM subscription;

-- Third query for magazine database
SELECT subscriptionStartDate, 
subscriptionLength, DATE_FORMAT(DATE_ADD(subscriptionStartDate, INTERVAL subscriptionLength MONTH), '%M %e, %Y') AS 'Subscription end'
FROM subscription;