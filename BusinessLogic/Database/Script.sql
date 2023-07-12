CREATE TABLE Certifications (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE Exams (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    CertificationID INTEGER,
    Name TEXT NOT NULL,
    MinimumGrade INTEGER NOT NULL,
    FOREIGN KEY(CertificationID) REFERENCES Certifications(ID)
);

CREATE TABLE Professionals (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE ExamAttempts (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    ExamID INTEGER,
    ProfessionalID INTEGER,
    AttemptName TEXT NOT NULL,
    Grade INTEGER,
    AttemptDate DATE,
    FOREIGN KEY(ExamID) REFERENCES Exams(ID),
    FOREIGN KEY(ProfessionalID) REFERENCES Professionals(ID)
);

-- Inserting data into Certifications table
INSERT INTO Certifications (Name) VALUES ('Certified Software Developer');
INSERT INTO Certifications (Name) VALUES ('Certified Database Administrator');
INSERT INTO Certifications (Name) VALUES ('Certified Systems Analyst');

-- Inserting data into Exams table
INSERT INTO Exams (CertificationID, Name, MinimumGrade) VALUES (1, 'Software Development Basics', 70);
INSERT INTO Exams (CertificationID, Name, MinimumGrade) VALUES (2, 'Database Management Basics', 75);
INSERT INTO Exams (CertificationID, Name, MinimumGrade) VALUES (3, 'Systems Analysis Basics', 80);

-- Inserting data into Professionals table
INSERT INTO Professionals (Name) VALUES ('John Doe');
INSERT INTO Professionals (Name) VALUES ('Jane Smith');
INSERT INTO Professionals (Name) VALUES ('Richard Roe');

-- Inserting data into ExamAttempts table
INSERT INTO ExamAttempts (ExamID, ProfessionalID, AttemptName, Grade, AttemptDate) VALUES (1, 1, 'First Attempt', 85, '2023-06-01');
INSERT INTO ExamAttempts (ExamID, ProfessionalID, AttemptName, Grade, AttemptDate) VALUES (2, 2, 'First Attempt', 80, '2023-06-05');
INSERT INTO ExamAttempts (ExamID, ProfessionalID, AttemptName, Grade, AttemptDate) VALUES (3, 3, 'First Attempt', 90, '2023-06-10');
