Written by Zach Phelan (10/07/2019)

This was implemented by making a custom Character object that keeps track of anything needed to know about the character, such as:
	Name, initiative, initiative modifier, PC or not. I might add more stats later.

These Characters are added to an ArrayList. Whenever an operation is done on it, the list is modified and the ListView is redrawn to display the changes.

There are two ways of modifying the list: 
	Right-clicking a Character on the listView.
	Interacting with the UI to add a character or change an initiative value.


	The first way is expensive because we only get the Name of the character, so we have to figure out which Character object that is referring to before doing any operations.
Once we do that, we have to delete the character, make any changes, then add the character again. I would guess O(N^2).

	The second way is cheaper, as we just locate where the object is and change its object's values accordingly. I estimate O(N). Which isn't great, but should be fine for 
small character lists, which will be most likely true. 


Currently implemented:
	Adding and removing characters
	Distinguishing between PCs and NPCs by deleting NPCs at the beginning of battle and having the option to automatically roll for NPCs for initiative.
	Right-clicking the list to remove characters / change their initiative.

TODO:
	Improve window for changing initative. Right now it is too big, I want it to be more streamlined. 
	Add support for initiative modifier, such as one based on Dex. initiative Modifier is already tracked in Character object, just need to figure out how to implement.
	Maybe have a notes column that can be clicked on to expand?
	Ways to see who's turn it is and automatically go to the next character when turn is finished.
	Keep track of HP for individual monsters