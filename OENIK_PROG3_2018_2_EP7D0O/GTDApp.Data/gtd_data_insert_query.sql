-- Some notification
INSERT INTO Notification VALUES ('30mins before', 'email', '-30 mins', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('60mins before', 'email', '-60 mins', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('1 day before', 'email', '-1 day', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Notification VALUES ('5 day before', 'email', '-1 day', '2018-10-10 00:00:00','2018-10-10 00:00:00');


-- The Containers to start with
INSERT INTO Container VALUES (NULL,'Assignment', 'Assignment', 'project', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Storage VALUES ('Assignment Reference Container Storage', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_storage VALUES (1, 1, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Attachment VALUES ('Requirements', 'requirements.pdf','file', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Storage_attachment VALUES (1, 1, '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Simple Container', 'Holds not reference materials', 'incubator', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Blocked Items Container', 'Holds not delegated items', 'blocked', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Next Actions Container', 'Holds next action items', 'next_actions', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Init Project', '', NULL, Null, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (4, 1, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Create Database', '', NULL, Null, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (4, 2, '2018-10-10 00:00:00','2018-10-10 00:00:00');
INSERT INTO Container VALUES (NULL,'Calendar', 'Holds appointments', 'calendar', '', '', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('First Milestone', '', NULL, '2018-10-15 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (5, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Second Milestone', '', NULL, '2018-11-02 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (5, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Third Milestone', '', NULL, '2018-11-23 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (5, 5, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item VALUES ('Last Milestone', '', NULL, '2018-12-07 00:00:00', '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 4, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Item_notification VALUES (1, 3, '2018-10-10 00:00:00','2018-10-10 00:00:00');
	INSERT INTO Container_item VALUES (5, 6, '2018-10-10 00:00:00','2018-10-10 00:00:00');