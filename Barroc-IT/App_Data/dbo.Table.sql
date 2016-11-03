CREATE TABLE [dbo].[appointments]
(
	[appointment_id] INT NOT NULL PRIMARY KEY, 
    [project_id] INT NOT NULL, 
    [a_date] DATE NULL, 
    [a_time_of] DATETIME NULL
)
