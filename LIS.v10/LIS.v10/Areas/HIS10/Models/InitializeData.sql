insert into HisEntities([Name],[Remarks],[userGroupId])
values('Matina Animal Center','Testing',1);

insert into HisInstruments([HisEntityId],[Name],[InsCode],[Description],[Specification],[Remarks],[Status])
values(1,'InsA101','101-22','Code Test Machine','V220 A2 P1200W','testin101','ACT'),
		(1,'InsB201','201-23','Acid Test Machine','V220 A2 P1500W','testin221','ACT'),
		(1,'ACER032','AC0-42','Computer Machine','V220 A2 P550W','ACER-PC','ACT');

insert into HisPhysicians([Name],[Remarks],[ContactInfo])
values('Dr Aga Mulach','Testing','09954508517'),
('Dr Juan','Hehehe','09954508517');

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


insert into HisProfiles ([Name],[Remarks],[AccntUserId],[ContactInfo])
values
	('Batch0301A','None','1','09193812657'),
	('Batch0301B','None','2','09193812657'),
	('Batch0301C','None','3','09193812657');

insert into HisIncharges ([Name],[Remarks],[ContactInfo])
values
('Freddie Roach','Trainer/consultant','09954508517'),
('Chot Reyes','Coach','09954508517'),
('Yeng Guiao','Trainer','09193812657');

insert into HisProfileReqs ([HisProfileId],[HisRequestId],[dtRequested],[dtSchedule],[dtPerformed],[Remarks], [HisPhysicianId],[HisInchargeId])
values (1,1,'3/1/2018 10:00:00','3/6/2018 10:36:00','3/6/2018 10:36:00','Initial',1,1),
	    (2,1,NULL,NULL,NULL,'Initial (sample)',1,1);

insert into HisNotifications ([RecType],[Recipient],[Message],[DtSending],[RefId],[RefTable])
values
	('Client','09279016517','Test Message','',1,'HisProfileReqs');

