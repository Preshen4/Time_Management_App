Title: POE Part2 ST10083954

Version: 2.0.0

Table of Contents: 
 A - How I Implented Feedback. 
 B - Description.
 C - How to intall the project.
 D - How to use the project.
 E - Credits.
 F - Challenges.
 G - What I would like to Add.
 H - UML.
 I - Change Log.

A) How I Implented Feedback: 

1) "Put a confirmation message. Literally the only fault" - I added a confirmation message which will let the user choose if they want to capture the details they have just entered.
2) "Some basic UI polishing needed" - Made the data grid colums adjust its size when a module is added to the datagrid, dispalyed errors to the user through the UI, added tooltips, made the overall width and height of the app smaller so it should fit most screens.
3) "Lovely stuff. Can you move more logic across?" - The library now contains the following objects: Student, Modules, StudentModules and TimeManagementAppContext. These were created throught EF Core scaffolding. The method to calculate the self study hours is now stored in the StudentModules object.
4) "Your readme file needs some minor details pre-requisites, etc. See this: https://www.freecodecamp.org/news/how-to-write-a-good-readme-file/" - This site was used to add more to my Readme file.

B) Description: 

The project is used to help students manage their times and recommend how many hours they should spend studying a module per week.	
This application was created in Visual Studio using C# and WPF.
A library called ModulesCal is added into the project. This library was created by me.
A nuget package called MahApps.Metro.IconPacks.Material was used in this project for the use of icons.
The youtube video https://youtu.be/mlmyFXJy8gQ was used for the creation of the GUI with a few edits by me.
The use of FluentValidation was used to validate user inputs and this was used as I found it to be a better way to validate user data compared to using only Regex.

C) How to intall the project:

1) First you will have to download this project.
2) Afterwards you will have to open this project in Visual Studios 2022 as it uses .Net 6.
3) If a warining shows up on the due to the library class please go to step 4, if not the project is correctly installed.
4) First you will have to download this project and the ModulesCal library 
5) Right click on the project and select the following options
![Add](https://user-images.githubusercontent.com/63053721/188342725-a2ad5026-ac42-4939-9f03-8bf672557251.JPG)
6) Go onto 'Browse' and go to the Dll folder located in the project'
7) Make sure the check box is checked 
8) The project is now installed and will work properly

D) How to use the project:

1) Click the run button in Visual Studio.

2) You will be shown the LoginWindow. Please enter the requested data and then click the 'Enter' button to continue with the application or click the 'Exit' button to close the application.

![Login](https://user-images.githubusercontent.com/63053721/198496062-18f196c5-acbd-4c2d-bfe5-c16050b6cb10.JPG)

3) If you don't have an account click the signUp button. This will take you to a form to register an account.

![SignUp](https://user-images.githubusercontent.com/63053721/198496035-7df81ed1-8bd1-424e-b13e-da0d9fa57608.JPG)

4) Errors will be displayed to the user and the error can be viewed by hovering over the highlighted text box.

![Error](https://user-images.githubusercontent.com/63053721/198496497-289c4691-cd1d-49b7-b9a1-42575a13b3f7.JPG)

5) You will be shown the main form of the applicaiton. Click on one of the 3 options on the navigation bar to continue.

6) The Dashboard has a data grid that will fill up as the user enters their modules into the Caption form. 

![DashboardNull](https://user-images.githubusercontent.com/63053721/198496133-952b23b4-05fb-48a8-9910-5c2599bea078.JPG)

![DashboardFull](https://user-images.githubusercontent.com/63053721/198496139-42b4832a-c7c6-4c5b-9a55-e25070e718c7.JPG)

7) The Capture button has a form that must be filled out so that your modules can be displayed onto the data gird in the Dashboard page.

![Capture](https://user-images.githubusercontent.com/63053721/198496187-c43d0121-bc93-4f15-ba08-3285eb6b26d5.JPG)

8) The Study button has a form that must be filled out to calculate your remaining hours of study for the week.

![Studied](https://user-images.githubusercontent.com/63053721/198496229-d7a875db-2c40-4102-893b-f16cf034501e.JPG)

9) To exit the application please select the Exit option at the bottom left.

E) Credits:

I would like to thank my PROG lecturer and tutors for input on the application and for help with the code and logic.

F) Challenges:

1) When working with EF core I noticed that the initial load to the database is much slower then using ADO.NET. In order to over come this and not have the user wait while they login in, when the application started I load the Student table into the application.
2) The data grid that displays the users modules contains values from the Module table and StudentModule table. When I created a method to return these values as an object I was recieving an error. The way I over came this is to make the return type dynamic.

G) What I would like to add:

1) Would like to add a search bar feature
2) Add animations
3) Add an API
4) Add more style to the combo box and data grid

H) UMl: 

![UML Part 2 drawio (1)](https://user-images.githubusercontent.com/63053721/199377761-d86e9da9-1dbc-4cb2-be01-d537440f31a0.png)

I) Change Log: 

1) Moved the classes folder to the library.
2) Added an interface and abstract class.
3) Used EF core.
4) Added a login and signup page for the user thats part of the shell and not a new window.
5) Removed button that takes the user to the varsity college website.
6) Used multithreading.
7) Moved more logic from the xaml.cs class the the .cs classes.
8) Added error handling.
9) Used a singleton class.
10) Removed old login page.

