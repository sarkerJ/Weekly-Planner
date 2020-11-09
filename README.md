# Weekly-Planner
A weekly-planner application built using Visual Studio, C#, SQL and Entity Framework

## Table of Contents

1. [Project Goal](#Project-Goal)
2. [Definition of Done](#Definition-of-Done)
3. [Sprint 1](#Sprint-1)
4. [Sprint 2](#Sprint-2)
5. [Sprint 3](#Sprint-3)
6. [Project Retrospective](#Project-Retrospective)



## Project-Goal

The project goal is to create an application that allows users to manage their weekly activities/tasks. Users will have the ability to add new task to the planner and modify them later depending on their circumstances. They can also delete them and filter through the activities when necessary. 

The application will then be extended to include a notes feature where the user can create a new notes and rank them based on their priorities. Furthermore the notes can also be set to specific days so that they differentiate further from notes they may have taken throughout the week. 

## Definition-of-Done

- [ ]  All user stories are marked as done
- [ ]  Product Backlog has been updated
- [ ]  Documentation(README) has been updated
- [ ]  Class Diagram has been updated
- [ ]  The Code is refactored and is readable
- [ ] The solution has been reviewed and approved
- [ ] All bugs have been recorded and fixed
- [ ] All the Unit Tests pass
- [ ] Unit tests account for approximately 80% of code coverage
- [ ] The final solution is pushed to GitHub by 10/11/2020 14:00
- [ ]  The presentation has been planned out and ready to be delivered  

## Sprints

### Sprint-1

##### Sprint 1 Goal:

**Sprint 1- Goals**
- [x] Get the product board approved
- [x] Create the 3 tier project layout
- [x] Create a basic README template
- [x] To create the initial structure of the database
- [x] Populate the database with some data
- [x] Create the initial methods
- [x] Create an MVP of the project with functional CRUD methods and passing tests
- [x] Make sure the all the methods are fully tested and pass
- [x] 5 User Stories

##### Sprint 1 Review

* Sprint goal was achieved
* All of the user stories that were selected were completed
* All of the tests passed

##### Sprint 1 Retrospective

* Pleased with the amount of work I have achieved in one sprint but I think I spent too long trying to fix small issues which could have been easily avoided if I had named certain parts differently or put more attention to what I was doing
* When creating methods I need to always consider whether exceptions testing are required. This is something I found out later as I marked certain User Stories as complete but then had issues with some of the other work afterwards which related back to exception handling. 
* In the Next Sprint I need do some quick small refactoring of the code as some parts are repeated or could be put under a switch case 
* In the Next Sprint I have to add a User Story to deal with duplicate Activities, something which I hadn't considered earlier

---

### Sprint-2

##### Sprint 2 Goal:

- [ ] Update README
- [x] Complete all selected User Stories
- [x] GUI is partially/fully updated based on User Stories
- [x] Make sure all the unit tests pass
- [x] Push Solution to GitHub 

##### Sprint 2 Review

The goal of this sprint was to allow users to filter all of the activities based on a day with the additional functionality for a notes section which would result in allowing users to create, edit, read and delete notes. 

- [x] All of the user stories were completed
- [x] new CRUD functionalities were created and passed tests
- [x] Updated the GUI

##### Sprint 2 Retrospective

Overall the sprint 2 was quite successful, however throughout the sprint I realized additional user stories were required for the Notes functionality which have been added to the project backlog. Quite a few bugs also arose whilst testing the GUI in general mainly dealing with null query data due to missing read methods or due to missing updates to the current properties, all of which were swiftly dealt with within a reasonable amount of time. 

- In the next sprint I have to add the following:
  -  I have to ensure the notes window checks for duplicate notes
  - Each note should change to its appropriate priority colour 
  - Improve the overall GUI layout
  - Ensure new windows open at the centre of main window
  - Refactor the entirety of the project 

---

### Sprint-3

##### Sprint 3 Goal:



##### Review

Sprint 3 Review

##### Retrospective

Sprint 3 retrospective

---

### Project-Retrospective

What have I learnt?

What would I do differently next time?

What would I do next?

---

##### Class-Diagram

![Project Class Diagram](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Class%20Diagram.JPG)

---



#### Sprint-1-Board(Before)

![Project-Board-Before-Sprint-1](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Sprint%201%20(before).JPG)

#### Sprint-1-Board(After)

![Project-Board-Before-Sprint-1](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Sprint%201%20(after).JPG)

#### Sprint-2-Board(Before)

![Project-Board-Before-Sprint-2](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Sprint%202%20(before).JPG)