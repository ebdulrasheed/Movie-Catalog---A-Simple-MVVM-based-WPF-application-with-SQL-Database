# Movie Catalog - A Simple MVVM based WPF application with SQL Database

Movie Catalog is a simple demonstration of database based application that
lets you store a list of movies. It is developed based upon MVVM pattern. The
application stores and updates data in database with the help of stored
procedures.


## **Prerequisites**

You need the following tools in order to run/edit the solution.

- Microsoft Visual Studio (Latest recommended)

- Microsoft SQL Server (Latest recommended)

## **Getting Started**

The application requires a database to store the data. Follow the below
steps to setup database. 

1.      
Run the script 'Movie Catalog.sql' to create and
populate database (MS SQL SERVER is required)

2.      
Set the connection string

&ensp;&ensp;  i.        
  Open MovieCatalog.sln (Visual Studio is required)

&ensp;&ensp;  ii.      
  Go to Properties in Solution Explorer

&ensp;&ensp;  iii.     
  Go to Settings.settings

&ensp;&ensp;  iv.    
  Insert Name as 'connString', Type as (Connection String), Scope as Application and Value as Connection String of Database.

## **Project Structure**

**Resources:**
        
- *Assets:* Directory containing assets used in project
        
- *Fonts:* Directory containing fonts used in project

**View:**
        
- *AddPage.xaml:* Contains UI for Add Page
        
- *AddPage.xaml.cs:* Contains interaction logic for AddPage.xaml
        
- *EditPage.xaml:* UI file for Edit Page

- *EditPage.xaml.cs:* Contains interaction logic for EditPage.xaml

- *HomePage.xaml:* UI for HomePage
        
- *HomePage.xaml.cs:* Interaction logic for HomePage.xaml
        
- *MainWindow.xaml:* UI for Main Window (Parent Container)
        
- *MainWindow.xaml.cs:* Interaction logic for MainWindow

- *Search.xaml:* UI for Search Page

- *Search.xaml.cs:* Interaction logic for Search.xaml

**View Model:**
       
- *MovieViewModel.cs:* Contains code for View Model for Movie (Model)

**Model:**

- *Movie.cs:* Contains code for movie class (Model)

- *MovieRepostory.cs:* Contains database connectivity code and logic

## **Author**

[Abdul Rasheed](https://www.linkedin.com/in/ebdulrasheed)
