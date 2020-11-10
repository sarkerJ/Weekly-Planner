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

##### Sprint-1-Goal

[**Project Card**](https://github.com/users/sarkerJ/projects/1#card-48691633)
The goal of the first sprint was to create the initial structure of the project, including the database tables and how each should link with one another. By the end of the sprint an MVP (minimal viable product) should have been created with minimal functionalities



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
		* [Creating an Activity](https://github.com/users/sarkerJ/projects/1#card-48688577)
	* [Modifying an Activity](https://github.com/users/sarkerJ/projects/1#card-48688980)
	* [Deleting an Activity](https://github.com/users/sarkerJ/projects/1#card-48689181)
	* [Viewing the Activities](https://github.com/users/sarkerJ/projects/1#card-48689317)
	* [Displaying an Activity's Information](https://github.com/users/sarkerJ/projects/1#card-48689493)
* All of the tests passed

##### Sprint 1 Retrospective

##### Overview

* Pleased with the amount of work I have achieved in one sprint but I think I spent too long trying to fix small issues which could have been easily avoided if I had named certain parts differently or put more attention to what I was doing
* When creating methods I need to always consider whether exceptions testing are required. This is something I found out later as I marked certain User Stories as complete but then had issues with some of the work afterwards which related back to exception handling. This forced me to slightly change the user stories to improve the acceptance criteria's.
* Testing was done through N Unit Testing but in some cases the acceptance criteria required tests which had to be checked manually. For example checking whether the activities information was displayed
* A few bugs did arise every so often but were quickly dealt it. In general the bugs related to naming issues or null exception errors

##### Action Plan

*  need do some quick small refactoring of the code as some parts are repeated or could be put under a switch case 
*  I have to add a User Story to deal with duplicate Activities, something which I hadn't considered earlier
* Test the GUI layer further for bugs

---

### Sprint-2

[**Project Card**](https://github.com/users/sarkerJ/projects/1#card-48841966)

##### Sprint-2-Goal:

The project goal is to continue with the user stories which mainly related the notes functionality. The aim also included preventing users from adding duplicate activities and displaying a message about the issue. 

- [x] Update README
- [x] Complete all selected User Stories
- [x] GUI is partially/fully updated based on User Stories
- [x] Make sure all the unit tests pass
- [x] Push Solution to GitHub 

##### Sprint 2 Review

- [x] All of the user stories were completed
  * [Duplicate Activities](https://github.com/users/sarkerJ/projects/1#card-48840880)
  * [Filtering Activities](https://github.com/users/sarkerJ/projects/1#card-48689764)
  * [Create a Note](https://github.com/users/sarkerJ/projects/1#card-48689870)
  * [Editing a Note](https://github.com/users/sarkerJ/projects/1#card-48689915)
  * [Deleting a Note](https://github.com/users/sarkerJ/projects/1#card-48690018)
  * [Viewing the Notes](https://github.com/users/sarkerJ/projects/1#card-48690201)
- [x] new CRUD functionalities were created and passed tests
- [x] Updated the GUI

##### Sprint 2 Retrospective

##### Overview

* Overall the sprint 2 was quite successful, however throughout the sprint I realized additional user stories were required for the Notes functionality which have been added to the project backlog. 

* Quite a few bugs also arose whilst testing the GUI in general mainly dealing with null query data due to missing read methods or due to missing updates to the current properties, all of which were quickly dealt with within a reasonable amount of time. 
* A stronger understanding on how you should create new windows and ways of accessing methods from the main window from the second one

##### Improvements

* The application now correctly informs and prevents a user from creating a duplicate activity
* Users are informed of any errors with a message box
* External activity window built to allow the filtering of activities based on a day

##### Action Plan

-  I have to ensure the notes window checks for duplicate notes
- Each note should change to its appropriate priority colour 
- Improve the overall GUI layout
- Ensure new windows open at the centre of main window
- Refactor the entirety of the project 

---

### Sprint-3

[**Project Card**](https://github.com/users/sarkerJ/projects/1#card-48977468)

##### Sprint 3 Goal:

The goal of this sprint was to improve the way a user edits an activity and a note by adding a drop down menu option. Furthermore a feature on notes would be included to automatically change the text colour of each note based on their set priority. Finally the entire project should be commented or refactored where possible and ensure the README is updated. 

##### Review

* All of the user stories were completed
  * [Duplicate Notes](https://github.com/users/sarkerJ/projects/1#card-48938840)
  * [Filtering Notes by Priority](https://github.com/users/sarkerJ/projects/1#card-48690572)
  * [Duplicate Notes](https://github.com/users/sarkerJ/projects/1#card-48938840)
  * [Prioritising a note](https://github.com/users/sarkerJ/projects/1#card-48690127)
  * [Coloured Notes](https://github.com/users/sarkerJ/projects/1#card-48977606)
  * [Improving Day Change Feature](https://github.com/users/sarkerJ/projects/1#card-48841759)
  * [Activity Limit Reminders](https://github.com/users/sarkerJ/projects/1#card-48930322)

##### Retrospective

##### Overview

* This sprint was slightly more troublesome than the other two. One of the issues I struggled to solve was how to implement a drop down menu which automatically selected a particular element based on the selected activity or note
  * The issue was finally solved by implementing a string list method that returned a list of strings rather than using the list of activity or notes that was initially created on sprint 1
* The second issue was focused more on setting a particular colour for each note title within the list box. This user story was slightly harder as I most of the solutions were more based on an XAML built in list box rather than one that was filled and set through code.
  * The issue was finally solved by tweaking the XAML list box element to include a **data layer** and a **text block** element. Through binding the data was correctly set and using binding the text block displayed the correct value and using its property **Foreground** and the **binding** option the colour of each element was finally changed
* I gained a much better understanding on Binding and how it connects data from a list to the data layer or an element within XAML. 
* Heavy focused on the documentation and improving the entire README file
* Some GUI changes were also implemented to improve its view but due time constraints not much has been changed



##### Improvements

* The GUI layer was slightly changed to correctly display when a user is selecting a button or editing text
* The notes and activity can now allow users to select a day through a drop down list and for notes it includes a drop down list for colours
* Several bugs were fixed where the drop down menus would not set the correct data or display the correct data
* Refactored a portion of the project, however some still remains
* Windows now correctly appear at the centre of the main window, removing the issue where you had to drag the window closer to use it



##### Action Plan

* End of Sprint

---

### Project-Retrospective

##### What have I learnt?

One of the major topic which I learned and gained a solid understanding of is through this project is how to use the Entity Framework to create an application. This also includes how you link and query through a database so that I can then use the data within my methods. The code first approach to create the database allowed me to gain a better understanding on how to link tables and how to represent the one to many relationship between them. At the start of the project a few issues did arise as I attempted to edit my database this was mainly due to my lack of understanding of migration and how it worked. However these obstacles have allowed me to learn quite a lot in regards to it.

The GUI aspect of the project provided me with a stronger pool of knowledge especially in terms of using list boxes, combo boxes and binding in general. Although I do feel that I still lack some knowledge I have most definitely have improved.

I also have learned to appreciate more the test driven development approach. The tests allowed me easily check and ensure each of my methods worked as intended. This greatly reduced the amount of manual tests I had to do for certain parts of the solution which in return improved the my overall performance. 

Finally understanding how to create a 3 tier application should be created and should function has provided me with a stronger foundation on how certain parts solution should interact with each other and how some methods must be implemented in order to read through data from multiple tables. 

##### What would I do differently next time?

One major point for this would be how I dealt with bugs and documented them. Overall I should have documented each bug by opening an issue on GitHub, this way I could have later checked the types of issues I encountered and how I may solved them as similar bugs have occurred multiple times during the sprints. 

##### What would I do next?

I would like to further improve the functionality of the application and further improving the overall GUI. Functionality wise I believe adding a date time for each activity would be greatly beneficial for users and building on from that adding a reminder when that work has to be done would be ideal.

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

#### Sprint-2-Board(After)

![Project-Board-Before-Sprint-2](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Sprint%202%20(after).JPG)

####  Sprint-3-Board(Before)

![Project-Board-Before-Sprint-3](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Sprint%203%20(before)..JPG)

#### Sprint-3-Board(After)

![Project-Board-After-Sprint-3](https://github.com/sarkerJ/Weekly-Planner/blob/main/Images/Sprint%203%20(after).JPG)