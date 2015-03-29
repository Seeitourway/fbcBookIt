use BookInventory;

INSERT INTO DBO.FormatType(FormatTypeId, FormatDescription, Active, Category)
Values (1, 'Braille Contracted',1,'B'),
(2, 'Braille Interpoint',1,'B'),
(3, 'Braille Single-Sided',1,'B'),
(4, 'Large Print',1,'B'),
(5, 'E-File PDF',1,'E'),
(6, 'E-File ePub',1,'E'),
(7, 'E-File Braille',1,'E'),
(8, 'Standard Print',1,'B');
GO

insert into dbo.CopyStatus	
(CopyStatusId, StatusDescription, Active)
Values
(1, 'Available',1),
(2,'Discarded',1),
(3,'Superceded',1),
(4,'Other',1)
;
GO

Insert into dbo.RequestStatus (
RequestStatusId, StatusDescription, Active)
Values
(1,'New',1),
(2,'Processing',1),
(3,'Purchasing',1),
(4,'Production',1),
(5,'Fulfilled',1),
(6,'Cancelled',1);
GO

Insert into dbo.LoanStatus (
LoanStatusId, StatusDescription, Active)
Values
(1,'Pending',1),
(2,'Over-Due',1),
(3,'Closed',1),
(4,'Active',1)
GO