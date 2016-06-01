CREATE TABLE tours(
	id int IDENTITY(1,1) NOT NULL,
	info varchar(50) NOT NULL,
	image varchar(50) NOT NULL,
	description varchar(max) NOT NULL,
	PRIMARY KEY (id))

INSERT INTO tours
	(info, image, description)
VALUES
    ('tour1', 'Images/tour1.jpg', 'description1')

INSERT INTO tours
	(info, image, description)
VALUES
    ('tour2', 'Images/tour2.jpg', 'description2')

INSERT INTO tours
	(info, image, description)
VALUES
    ('tour3', 'Images/tour3.jpg', 'description3')

INSERT INTO tours
	(info, image, description)
VALUES
    ('tour4', 'Images/tour4.jpg', 'description4')
