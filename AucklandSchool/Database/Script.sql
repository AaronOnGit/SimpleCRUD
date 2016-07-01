CREATE TABLE [Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Gender] NVARCHAR(50) NOT NULL
)
CREATE TABLE [Subject]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL
)
CREATE TABLE [Teacher]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Gender] NVARCHAR(50) NOT NULL
)
CREATE TABLE [Subject_Teacher_Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SubjectId] INT NOT NULL, 
	[TeacherId] INT NOT NULL,
	[StudentId] INT NOT NULL,
    FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id]), 
    FOREIGN KEY ([TeacherId]) REFERENCES [Teacher]([Id]), 
    FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id])
)

INSERT INTO [Subject] (Name)VALUES ('Maths');
INSERT INTO [Subject] (Name)VALUES ('Physics');
INSERT INTO [Subject] (Name)VALUES ('Chemistry');
INSERT INTO [Subject] (Name)VALUES ('Information Technology');

INSERT INTO [Teacher] (FirstName, LastName, Gender)VALUES ('Amy','Brown','Female');
INSERT INTO [Teacher] (FirstName, LastName, Gender)VALUES ('John','Lee','Male');
INSERT INTO [Teacher] (FirstName, LastName, Gender)VALUES ('Ray','Lu','Male');
INSERT INTO [Teacher] (FirstName, LastName, Gender)VALUES ('Jessica','Park','Female');

INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Kay','Ellis','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Della','Rose','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Gretchen','Fox','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Violet','Massey','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Betty','Cunningham','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Theresa','Woods','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Kara','Robertson','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Jessica','Dawson','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Eloise','Cain','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Sadie','Romero','Female');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Geoffrey','Baker','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Noah','Kelly','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Alonzo','Bowen','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Toby','Obrien','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('David','Bryant','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Leon','Williamson','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Patrick','Tate','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Damon','Welch','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Ernest','Coleman','Male');
INSERT INTO [Student] (FirstName, LastName, Gender)VALUES ('Brian','Warren','Male');

INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (1,1,20);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (1,1,7);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (1,1,16);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (1,1,14);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (1,1,4);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (1,1,12);

INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (2,2,11);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (2,2,14);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (2,2,4);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (2,2,18);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (2,2,20);

INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,16);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,4);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,14);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,17);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,15);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,11);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,19);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (3,3,2);

INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,19);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,12);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,11);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,7);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,8);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,6);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,3);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,13);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,10);
INSERT INTO [Subject_Teacher_Student] (SubjectId, TeacherId, StudentId)VALUES (4,4,9);
