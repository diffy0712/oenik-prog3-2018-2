# GTD(getting things done) Application #
Simply we have containers, which contains items.
An item is like a todo. It have a title and some description.
An item also can contain a notification, which can be set if the item has at least a from_date.
A notification can have a type and some interval of when to call it(this is not implemented, could be some kind of cron task to run).  

## Layering Rules ## 
The Console App calls Logic operations, the logic forwards the CRUD operations to the Repository, the Repo calls the DbContext methods
- The Logic and the Console App MUST NOT use dbContext methods, this is only allowed for the Repository
- Every layer ONLY communicates with the layer directly below (Occassional upwards communication: with events - not needed now)
- Usage of the entity types is allowed in all layers (this is not a good thing, but this semester it is accepted…)