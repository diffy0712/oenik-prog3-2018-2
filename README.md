# GTD(getting things done) Application #

Based on David Allen's Getting things done book, this project will try to implement the ideas in the book.
Basically this will start as a simple todo app...

[A short video about GTD](https://www.youtube.com/watch?v=gCswMsONkwY)

So GTD has 5 main steps:

 - 1 Capture: Using the api capture 100% of everything that has your attention.
 - 2 Clarify: Use this [flowchart](https://blog.joefallon.net/wp-content/uploads/2012/07/GTD-Workflow-100.png)
 - 3 Organise: Put it where it belongs. Put every captured thing on the right place(list, project, contacts, calendar etc...)
 - 4 Review: Look over the places where u put your stuff as often as neccessary to determine what to do next.
 - 5 Engage: Simply do the appropriate actions.

## Layering Rules ## 
The Console App calls Logic operations, the logic forwards the CRUD operations to the Repository, the Repo calls the DbContext methods
- The Logic and the Console App MUST NOT use dbContext methods, this is only allowed for the Repository
- Every layer ONLY communicates with the layer directly below (Occassional upwards communication: with events - not needed now)
- Usage of the entity types is allowed in all layers (this is not a good thing, but this semester it is accepted…)

 

# Resources #

## StyleCop
After installing and setting up the ruleset we got some errors by default. [This helps so quicly fix them.](http://www.softwarepronto.com/2018/05/visual-studio-file-linking-using.html)
