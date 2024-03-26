-- ACCOUNT table
CREATE TABLE ACCOUNT (
    username NVARCHAR(50) PRIMARY KEY,
    email NVARCHAR(100),
    password NVARCHAR(50)
);

-- MOVIE table
CREATE TABLE MOVIE (
    movie_id INT PRIMARY KEY,
    title NVARCHAR(255),
    synopsis NVARCHAR(MAX),
    duration INT,
    show_date DATE,
    show_time TIME,
    ticket_price DECIMAL(10, 2),
    status NVARCHAR(20)
);

-- SEAT table
CREATE TABLE SEAT (
    seat_id INT PRIMARY KEY,
    movie_id INT,
    seat_number NVARCHAR(20),
    availability NVARCHAR(20)
);

-- QUANTITY table
CREATE TABLE QUANTITY (
    quantity_id INT PRIMARY KEY,
    username NVARCHAR(50),
    quantity INT
);

-- BOOKING table
CREATE TABLE BOOKING (
    booking_id INT PRIMARY KEY,
    username NVARCHAR(50),
    movie_id INT,
    showtime_id INT,
    seat_id INT,
    booking_date DATETIME
);