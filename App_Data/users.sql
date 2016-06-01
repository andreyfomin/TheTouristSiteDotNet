CREATE TABLE users (
	id int IDENTITY(1,1) NOT NULL ,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	gender bit NOT NULL,
	user_name varchar(50) NOT NULL,
	password varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	phone_number varchar(50) NOT NULL
	PRIMARY KEY (id),
	UNIQUE (user_name))

INSERT INTO users
	(first_name, last_name, gender, user_name, password, email, phone_number)
VALUES
    ('Admin', 'Admin', 'True', 'admin', '123456', 'admin@gmail.com', '052-61514107')

INSERT INTO users
     (first_name, last_name, gender, user_name, password, email, phone_number)
VALUES
     ('Tom', 'Hanks', 'True', 'tomh', '111111', 'tomh@gmail.com', '045-71651651')


INSERT INTO users
     (first_name, last_name, gender, user_name, password, email, phone_number)
VALUES
     ('Arnold', 'Schwarzenegger', 'True', 'terminator', '123456', 'arnold@gmail.com', '03-948372625')