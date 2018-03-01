insert into HisEntities([Name],[Remarks],[userGroupId])
values('Kwak Medical Center','Testing',1);

insert into HisInstruments([HisEntityId],[Name],[InsCode],[Description],[Specification],[Remarks],[Status])
values(1,'InsA101','101-22','Code Test Machine','V220 A2 P1200W','testin101','ACT'),
		(1,'InsB201','201-23','Acid Test Machine','V220 A2 P1500W','testin221','ACT'),
		(1,'ACER032','AC0-42','Computer Machine','V220 A2 P550W','ACER-PC','ACT');

insert into HisPhysicians([Name],[Remarks])
values('Dr Ning Kwak','Testing'),
('Dra Pak Kwak','Hehehe');

insert into HisOrderTypes([Description],[Remarks])
values('BugTest','Testing202'),
('BloodTest','Hehehe101');

insert into HisResultFields([HisOrderTypeId],[AddForType],[Name],[Desc],[SeqNo],[minValue],[maxValue],[Uom])
values (1,0,'Test01','testing',10,'40','60','CM'),
		(1,0,'Test02','testing',20,'40','60','MM'),
		(1,0,'Test03','testing',30,'40','60','mM'),
		(2,0,'A 01','test A',10,'40','60','CM'),
		(2,0,'B 01','test B',20,'40','60','CM'),
		(2,0,'C 01','test C',30,'40','60','CM');


insert into HisRequests([Title],[Description])
values ('Test 101','General Test checkup'),
('Vacc 101','Standard Vaccination'),
('Med 101','General Medication'),
('Vas 101','Vascu Exercises'),
('Ther 101','Theraphy 101')


insert into HisProfiles ([Name],[Remarks],[AccntUserId])
values
	('Patient1','None','1'),
	('Patient2','None','2'),
	('Patient3','None','3');

insert into HisProfileReqs ([HisProfileId],[HisRequestId],[dtRequested],[dtSchedule],[dtPerformed],[Remarks])
values (1,1,'3/1/2018 10:00:00','3/1/2018 10:36:00','3/1/2018 10:36:00','none'),
	    (2,1,'3/1/2018 10:00:00','3/1/2018 10:36:00','3/1/2018 10:36:00','none');

insert into HisNotifications ([RecType],[Recipient],[Message],[DtSending],[RefId],[RefTable])
values
	('Client','09279016517','Test Message','',1,'HisProfileReqs');

