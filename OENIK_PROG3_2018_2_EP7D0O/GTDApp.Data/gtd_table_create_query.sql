IF OBJECT_ID('Item_notification') IS NOT NULL DROP TABLE Item_notification;
IF OBJECT_ID('Item') IS NOT NULL DROP TABLE Item;
IF OBJECT_ID('Notification') IS NOT NULL DROP TABLE Notification;
IF OBJECT_ID('Container') IS NOT NULL DROP TABLE Container;
GO

CREATE TABLE Notification
(
    notification_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name nvarchar(50) NOT NULL,
    type nvarchar(50) NOT NULL,
    amount int NOT NULL,
    unit nvarchar(100) NOT NULL,
    created_at date NOT NULL,
	updated_at date NOT NULL
);

CREATE TABLE Container
(
	container_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name nvarchar(50) NOT NULL,
    purpose nvarchar(500) NOT NULL,
    type nvarchar(50) NOT NULL,
    principles nvarchar(1000) NOT NULL,
    invisioned_outcome nvarchar(1000) NOT NULL,
    created_at date NOT NULL,
	updated_at date NOT NULL
);

CREATE TABLE Item
(
    item_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	container_id int NOT NULL FOREIGN KEY REFERENCES Container(container_id),
    title nvarchar(50) NOT NULL,
    description nvarchar(MAX) NOT NULL,
	from_date date,
    to_date date,
	created_at date NOT NULL,
	updated_at date NOT NULL
);

CREATE TABLE Item_notification
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	item_id int NOT NULL FOREIGN KEY REFERENCES Item(item_id),
	notification_id int NOT NULL FOREIGN KEY REFERENCES Notification(notification_id),
	created_at date NOT NULL,
	updated_at date NOT NULL
);