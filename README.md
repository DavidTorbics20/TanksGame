# __TanksGame__

This repository will contain all the files connected to my project, Tanks.

## __My diary begins here__

### __Description:__

The game will consist of two gamemodes. First, a local one vs one. Second an online PvP with up to 10 players. In each of these a maze will be generated in which the players are spread out randomly. The players than have to navigate through the maze and shoot each other. The last man standing wins.

### __Progress__

Here are some rules I will apply to the Builds:

- XX.0.0. -> means something big happened like for example a new gamemode has been added
- 0.XX.0. -> new things added to the game but not gamebreaking, for example new animations
- 0.0.XX. -> just some minor changes like bug fixes

### __02.03.2022 - The Beginning__

I started with setting up the environment in Unity.
Also tried to make the first steps towards the maze generation. 
I decided on the recursive implementation but will change the way it works later on.

### __04.03.2022 - Maze Generation__

# describe how the generator works in detail 

I used _Recursive Backtracking_ algorithm. For this I used three scripts: 

![maze_scripts](./pics/Maze_Scripts.PNG) 
1. MazeCell.cs --> defines the walls (top, right, bottom, left), x and y coordinates, cell sprite and a boolean if the cell is visited or not.  
2. MazeGenerator.cs --> is responsible for the generation of the maze; carves path, sets edge walls.
3. MazeManager.cs --> starts and restart the MazeGenerator script

A (almost) finished maze should look something like this:

![finished maze](./pics/Solved_Maze_Unfinished.PNG)

I still need to break some walls inbetween to create new paths. This maze generation will be just as larg as in the picture for the local games. For the PvP version I intend to make it 4 or 5 times larger.

### __06.03.2022 - Main Menu__

The main menu consists of a big title and some buttons, for now. To make it a bit more interessting I added bots that drive around in the background. They spawn outside of the field of view of the camera and start moving in one direction. not far from this zone is a death zone where these bots are destroyed to save resources. 

# for later: describe the animation
# describe the random bots