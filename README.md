# HTTP5101Assignment5

## Intro

This project adds update functionality to the Teachers table in our school database. With this update, the Teachers table has full CRUD functionality.

## Where to start
### Add a Teacher
To start using this project, start on the ./Teachers/List page. This will display the list of teachers on the database. At the bottom of the page is a green button that allows
users to add in new teachers. Clicking it takes users to a webform that is validated using client-side validation.
### Show and Edit a teacher
Clicking on a teacher's name on the list page brings users to a new page that shows more details about the teacher. At the top of the page are two links, one to go back to the
list page, and one to edit the teacher's details. Clicking the edit links takes users to a similar form to the add a teacher one.
### Delete a teacher
Going back to the teacher's details, there is a big red button that says "Delete?". Clicking this makes the button dissapear and gives users the option to either go back, or confirm
the deletion of the teacher.
## How it works
This project uses the Model View Controller architecture to create a dynamic webpage that is connected to a mySql database. This separates different responsibilities to different 
files in this repository. The model files creates classes which allow us to _model_ the type of data that will passed between functions, Views are the dynamically rendered html pages
that display the data within the server, and the controllers _control_ the url routing around our website, along with the functions we use to interface with the mySql database.
## References
Update functionality designed while referencing Christine Bittle's Learning C# for Web Development part 16 [https://youtu.be/o1ax8rvlFMQ].

Materials were referenced on December 16th 2020. I used this video to determine how to add in update functionality to my application. I built upon my previous assignment to add this functionality.
