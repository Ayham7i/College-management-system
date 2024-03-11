CREATE TABLE [dbo].[Studenttbl] (
    [studentid]     INT          NOT NULL,
    [studentname]   VARCHAR (50) NOT NULL,
    [studentlevel]  VARCHAR (50) NOT NULL,
    [studentsystem]   VARCHAR (50) NOT NULL,
    [studentmajor]  VARCHAR (50) NOT NULL,
    [studentgender] VARCHAR (50) NOT NULL,
    [studentphone]  VARCHAR (50) NOT NULL,
    [studentdDOB]   VARCHAR (50) NOT NULL,
    [studentfees]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([studentid] ASC)
);

