-- Some notification
INSERT INTO Notification VALUES ('30mins before', 'email', 30, 'min', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('60mins before', 'email', 60, 'min', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('1 day before', 'email', 1, 'day', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('5 day before', 'email', 1, 'day', '2018-10-10 00:00:00','2018-10-10 00:00:00');

INSERT INTO Container VALUES ('Simple Container', 'Holds not reference materials', 'incubator', 'Some Content', 'Some Content', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES ('Blocked Items Container', 'Holds not delegated items', 'blocked', 'Some Content', 'Some Content', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES ('Next Actions Container', 'Holds next action items', 'next_actions', 'Some Content', 'Some Content', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES (3,'Init Project', 'Some Description', NULL, Null, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES (3,'Create Database', 'Some Description', NULL, Null, '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES ('Calendar', 'Holds appointments', 'calendar', 'Some Content', 'Some Content', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES (4,'First Milestone', 'Some Description', NULL, '2018-10-15 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (3, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (3, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES (4,'Second Milestone', 'Some Description', NULL, '2018-11-02 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (4, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (4, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES (4,'Third Milestone', 'Some Description', NULL, '2018-11-23 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (5, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (5, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES (4,'Last Milestone', 'Some Description', NULL, '2018-12-07 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (6, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (6, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');