CREATE TABLE selected_tours(
	id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	tour_id int NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (user_id) REFERENCES users(id),
	FOREIGN KEY (tour_id) REFERENCES tours(id)
	)

INSERT INTO selected_tours
	(user_id, tour_id)
VALUES
    (2, 1)

INSERT INTO selected_tours
	(user_id, tour_id)
VALUES
    (2, 3)

INSERT INTO selected_tours
	(user_id, tour_id)
VALUES
    (2, 4)

INSERT INTO selected_tours
	(user_id, tour_id)
VALUES
    (3, 1)

INSERT INTO selected_tours
	(user_id, tour_id)
VALUES
    (3, 2)