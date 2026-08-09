USE StuProject_PracticalDB;

-- =========================
-- 1. ROLES
-- =========================

INSERT INTO Roles (RoleName)
VALUES
('Admin'),
('Faculty'),
('Student'),
('Project Manager');


-- =========================
-- 2. USERS
-- =========================

INSERT INTO Users (Name, Email, RoleId)
VALUES
('Bhavik Parmar', 'bhavik@gmail.com', 1),
('Rahul Patel', 'rahul@gmail.com', 2),
('Amit Shah', 'amit@gmail.com', 3),
('rohit Mehta', 'rohit@gmail.com', 3),
('Neel Joshi', 'neel@gmail.com', 4);


-- =========================
-- 3. PERMISSIONS
-- =========================

INSERT INTO Permissions (PermissionName, Description)
VALUES
('Create Project', 'Allows user to create a project'),
('View Project', 'Allows user to view project details'),
('Update Project', 'Allows user to update project details'),
('Delete Project', 'Allows user to delete a project'),
('Assign Project', 'Allows user to assign project to a user');


-- =========================
-- 4. PROJECTS
-- =========================

INSERT INTO Projects
(
    ProjectName,
    Description,
    StartDate,
    EndDate
)
VALUES
(
    'Student Management System',
    'Web application for managing student information',
    '2026-08-01',
    '2026-09-30'
),
(
    'Library Management System',
    'Application for managing books and library users',
    '2026-08-05',
    '2026-10-15'
),
(
    'Online Examination System',
    'Online platform for conducting examinations',
    '2026-08-10',
    '2026-11-01'
);


-- =========================
-- 5. PROJECT TASKS
-- =========================

INSERT INTO ProjectTasks
(
    TaskName,
    Description,
    Status,
    ProjectId
)
VALUES
(
    'Database Design',
    'Design database tables and relationships',
    'Completed',
    1
),
(
    'Backend Development',
    'Develop ASP.NET Core Web API',
    'In Progress',
    1
),
(
    'Frontend Development',
    'Develop frontend user interface',
    'Pending',
    1
),
(
    'Book Module',
    'Implement book management module',
    'In Progress',
    2
),
(
    'User Module',
    'Implement library user management',
    'Pending',
    2
),
(
    'Question Module',
    'Create examination question module',
    'Pending',
    3
);


-- =========================
-- 6. PROJECT ALLOCATIONS
-- =========================

INSERT INTO ProjectAllocations
(
    ProjectId,
    UserId,
    AllocationRole
)
VALUES
(1, 1, 'Project Manager'),
(1, 3, 'Developer'),
(1, 4, 'Tester'),
(2, 2, 'Faculty Guide'),
(2, 3, 'Developer'),
(3, 2, 'Project Guide'),
(3, 5, 'Developer');


-- =========================
-- 7. DISPLAY ALL DATA
-- =========================

SELECT * FROM Roles;

SELECT * FROM Users;

SELECT * FROM Permissions;

SELECT * FROM Projects;

SELECT * FROM ProjectTasks;

SELECT * FROM ProjectAllocations;