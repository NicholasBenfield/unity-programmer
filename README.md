unity-programmer

This project is for the SAIC Unity Programmer position. Prior to an inteview the following project must be worked on.

- Opening Scene: Introduction and User Instructions
- Next Scene: Stationary Camera is in a set position
Camera is in a set Position
Objects come in and out of the scene for the user to click on/shoot
Objects drop where they were clicked/shot
- Next Scene: Walk around (can be first or third person perspecitve)
User collects items that dropped
Item Collection: 
Either a basic inventory (showing how many of each object was collected)
Or a score that is updated based on what items were collected
- Final Scene: Closing Scene with Final Inventory/Score


The following assets were given to use, but I'm able to use my own if needed. Will need to create a zip of the project when completed along with a compiled EXE version of the game. 

Normally I'd use a kaban style board to track issues, instead I've just jotted down each task with information on it.

1. Multiple scenes, 2 scenes should be matching in design, other 2 are standard main menu and end game with information.

2. Main menu scene.
Information how to play the game, left and right arrows to be able to go forward and back.
One inital arrow change to being exit game 
Once all instructions have been passed,load the next scene

3. First Static scene.
Camera must be in a static position
Obejects within the map, will spawn and move across the view of the player
Player is able to click on objects, when clicked, object stops moving and drops to ground. (When they land, the objects change state to not being destoryed on load for the next scene) 
Include a timer to allow completion onto the next scene
4. Movement Scene.
Camera changes from static to being able to move. When the player moves over the objects, they get collected (Object gets destroyed and added to the counter for the type of object)
User hits a button and an inventory displays
Once all the objects have been completed, the games moves to the next scene.

5. Final Scene.
Will display the final inventory and score. 


2/17/2020
After setting up a couple of scenes and a couple of the providied Unity Test Project Towns. Worked on getting spawners to generate an item and move it across the view of the camera. Initally looked at having them spawn at certain points within the map. Created a basic spawner that moved items across the camera. Worked on getting it to drop when getting clicked. Setup a spawn rate for the spawner so I can adjust them individually when they get placed all over the map.

2/18/2020
Now that Items have dropped, they need to be transfered into the next scene.Created a gameobject to hold all the items that were dropped.Made it so that when an object is clicked it shifts them forward/backwards by 1 unit to avoid collisions. Also have it so the collisions between spawn rates don't collide and push them along faster. Created a basic timer to have the game timed.

2/19/2020
Created a game manager to handle the flow between scenes. Created a basic movement controller. Item pickup has been done, Game Manager holds the the values of the objects. Have a basic camera that follows the player around, but doesn't rotate. Created an inventory that when E is pressed displays and disappears accordinly. 

2/21/2020
Created a final scene and a tutorial scene. Fixed some of the bugs that were happening. Finished up the game. 