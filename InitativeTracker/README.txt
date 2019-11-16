Written by Zach Phelan (11/06/2019)

This was implemented by making a custom Character object that keeps track of anything needed to know about the character, such as:
	Name, initiative, initiative modifier, PC or not, as well as other stats.

The components on the form are changed according to the values of the Character's stats and vice verse.

This is currently saving and loading from XML, but will need more work. It also changes as more stats are added.

Have seperate forms for Combat, HP, Status Effects, and the main InitiativeTracker form. I think I want to condense the HP form into the main window for ease of use somehow.



TODO:
	Improve window for changing initative. Right now it is too big, I want it to be more streamlined. 
	Maybe have a notes column that can be clicked on to expand?
	Ways to see who's turn it is and automatically go to the next character when turn is finished.
	Keep track of HP for individual monsters