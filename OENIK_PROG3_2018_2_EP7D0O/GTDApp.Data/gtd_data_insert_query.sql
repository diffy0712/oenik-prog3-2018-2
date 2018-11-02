-- Some notification
INSERT INTO Notification VALUES ('30mins before', 'email', '-30 mins', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('60mins before', 'email', '-60 mins', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('1 day before', 'email', '-1 day', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('5 day before', 'email', '-1 day', '2018-10-10 00:00:00','2018-10-10 00:00:00');


-- The Containers to start with
INSERT INTO Container VALUES (NULL,'Reference Container', 'Holds reference materials', 'reference', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Incubator Container', 'Holds not reference materials', 'incubator', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Blocked Items Container', 'Holds delegated items', 'blocked', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Next Actions Container', 'Holds next action items', 'next_actions', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Calendar', 'Holds appointments', 'calendar', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'OE', 'OE Project', 'project', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (6,'2018_2019_1', 'Holds the containers for 2018 autumn', 'project', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (7,'Prog 3', 'Prog 3', 'project', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
-- OE/2018_2019_1/Prog 3/Assignment/
INSERT INTO Container VALUES (8,'Assignment', 'Assignment', 'project', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (9,'Reference Container', 'Holds reference materials', 'reference', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Storage VALUES ('OE/2018_2019_01/Prog 3/Assignment Reference Container Storage', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_storage VALUES (9, 1, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Attachment VALUES ('Requirements', 'requirements.pdf','file', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Storage_attachment VALUES (1, 1, '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (9,'Incubator Container', 'Holds not reference materials', 'incubator', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (9,'Blocked Items Container', 'Holds not delegated items', 'blocked', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (9,'Next Actions Container', 'Holds next action items', 'next_actions', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Init Project', '', NULL, Null, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (13, 1, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Create Database', '', NULL, Null, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (13, 2, '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (9,'Calendar', 'Holds appointments', 'calendar', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('First Milestone', '', NULL, '2018-10-15 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (14, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Second Milestone', '', NULL, '2018-11-02 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (14, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Third Milestone', '', NULL, '2018-11-23 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (14, 5, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Last Milestone', '', NULL, '2018-12-07 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (14, 6, '2018-10-10 00:00:00','2018-10-10 00:00:00');