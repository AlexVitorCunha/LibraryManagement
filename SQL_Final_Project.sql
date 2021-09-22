/*
This query is needed to create all the tables used on the LibraryManagement Windows Application
*/


CREATE TABLE [credentials]( 
[id] [int] IDENTITY(1,1)  PRIMARY KEY, 
[username] [nvarchar](50) NOT NULL, 
[password] [nvarchar](20) NOT NULL, 
[staff] [bit] NOT NULL,
);

CREATE TABLE [books](
[isbn][int] PRIMARY KEY,
[book_name][nvarchar](50) NOT NULL,
[author_name][nvarchar](50) NOT NULL,
[genre][nvarchar](50) NOT NULL,
[year][int],
[quantity][smallint] NOT NULL,
book_cover [nvarchar](100) NULL
);

CREATE TABLE [books_borrowed](
[order_number][int] IDENTITY(1,1) PRIMARY KEY,
[return_date][date],
[isbn][int],
[id][int],
FOREIGN KEY(id) REFERENCES credentials(id),
FOREIGN KEY(isbn) REFERENCES books(isbn)
);

SELECT * FROM credentials;
SELECT * FROM books;
SELECT * FROM books_borrowed;
