#v_art database
USE v_art;

-- 1st query
SELECT artfile
FROM artwork
WHERE period = 'Impressionism';

-- 2nd query
SELECT artfile
FROM artwork a 
	JOIN artwork_keyword ak
    ON ak.artwork_id = a.artwork_id
    JOIN keyword k
    ON ak.keyword_id = k.keyword_id
WHERE keyword LIKE 'Flower%';

-- 3rd query
SELECT fname, lname, title
FROM artist ast
	LEFT JOIN artwork ak
    ON ast.artist_id = ak.artist_id;

#magazine datatable
USE magazine;

-- 1st query
SELECT magazineName, subscriberLastName, subscriberFirstName
FROM magazine m
	JOIN subscription sn
    ON m.magazineKey = sn.magazineKey
    JOIN subscriber s
    ON sn.subscriberKey = s.subscriberKey
ORDER BY magazineName;

-- 2nd query
SELECT magazineName
FROM magazine m
	JOIN subscription sn
    ON m.magazineKey = sn.magazineKey
    JOIN subscriber s
    ON sn.subscriberKey = s.subscriberKey
WHERE subscriberFirstName = 'Samantha' AND subscriberLastName = 'Sanders'
ORDER BY magazineName;

#employees database
USE employees;

-- 1st query
SELECT first_name, last_name
FROM employees e
	JOIN  dept_emp de
    ON e.emp_no = de.emp_no
    JOIN departments d
    ON de.dept_no = d.dept_no
WHERE dept_name = 'Customer Service'
ORDER BY last_name
LIMIT 5;

-- 2nd query
SELECT first_name, last_name, dept_name, salary, s.from_date
FROM employees e
    JOIN salaries s
    ON s.emp_no = e.emp_no
    JOIN dept_emp de
    ON de.emp_no = e.emp_no
    JOIN departments d
    ON d.dept_no = de.dept_no
WHERE first_name = 'Berni' AND last_name = 'Genin'
ORDER BY s.from_date DESC
LIMIT 1;

##
-- Summary Queries
##
-- bike Database
USE bike;

-- 1st query
SELECT ROUND(AVG(quantity))
FROM stock;

-- 2nd query
SELECT product_name
FROM product p
	JOIN stock s
    ON p.product_id = s.product_id
WHERE quantity = 0
GROUP BY product_name
ORDER BY product_name;

-- 3rd query
SELECT category_name, SUM(quantity) instock
FROM category c
	JOIN product p
    ON c.category_id = p.category_id
    JOIN stock s
    ON p.product_id = s.product_id
WHERE store_id = 2
GROUP BY category_name
ORDER BY SUM(quantity) ASC;

#employees database
USE employees;

-- 1st query
SELECT COUNT(emp_no)
FROM employees;

-- 2nd query
SELECT dept_name, FORMAT(AVG(salary), 2) AS average_salary
FROM salaries s
	JOIN employees e
    ON s.emp_no = e.emp_no
    JOIN dept_emp de
    ON e.emp_no = de.emp_no
    JOIN departments d
    ON de.dept_no = d.dept_no
GROUP BY dept_name
HAVING AVG(salary) < 60000;

-- 3rd and last query
SELECT dept_name, COUNT(gender) as 'Number of females'
FROM employees e
	JOIN dept_emp de
    ON e.emp_no = de.emp_no
    JOIN departments d
    ON de.dept_no = d.dept_no
WHERE gender = 'F'
GROUP BY dept_name;