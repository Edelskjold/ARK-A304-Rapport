
SELECT Book.title AS Title,
      COUNT(*) AS Authors
FROM  Book
JOIN  Book_author
WHERE price > 100.00
GROUP BY Book.title;

<!-- Ovenstående kode kunne printe nedenstående datastruktur --> 

Title                  Authors
---------------------- -------
SQL Examples and Guide 4
The Joy of SQL         1
An Introduction to SQL 2
Pitfalls of SQL        1
