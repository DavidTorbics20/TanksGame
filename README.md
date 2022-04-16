# __TanksGame__

This repository will contain all the files connected to my project, Tanks.

## __Description:__

The project started on 1.3.2022 and I work with the 2019.4.4f1 version von Unity.  

The game will consist of two gamemodes. First, a local one vs one. Second an online PvP with up to 10 players. In each of these a maze will be generated in which the players are spread out randomly. The players than have to navigate through the maze and shoot each other. The last man standing wins.


## __Progress__

Here are some rules I will apply to the Builds:

- XX.0.0. -> means something big happened like for example a new gamemode has been added or a playable version is created
- 0.XX.0. -> new things added to the game but not gamebreaking, for example new animations or not fully playable builds
- 0.0.XX. -> just some minor changes like bug fixes

Not all updates will be mentioned because they only exist for testing purpose and are insignificant otherwise. Only the complete version of an update will be noted. The version not mentioned here are still playable in the ./Tanks - Projekt/Builds/ folder. 

The title are as follows: | Date of the start | Activity | The final version of the activity |

## __01.03.2022 - The Beginning__

I started with setting up the environment in Unity.
Also tried to make the first steps towards the maze generation. 
I decided on the recursive implementation but will change the way it works later on.

## __02.03.2022 - Maze Generation - 0.0.1__

# describe how the generator works in detail 

I used _Recursive Backtracking_ algorithm. For this I used three scripts: 

![maze_scripts](./pics/Maze_Scripts.PNG) 
1. MazeCell.cs --> defines the walls (top, right, bottom, left), x and y coordinates, cell sprite and a boolean if the cell is visited or not.  
2. MazeGenerator.cs --> is responsible for the generation of the maze; carves path, sets edge walls.
3. MazeManager.cs --> starts and restart the MazeGenerator script

_A (almost) finished maze should look something like this:_

![almost finished maze](./pics/Solved_Maze_Unfinished.PNG)

I still need to break some walls inbetween to create new paths. This maze generation will be just as larg as in the picture for the local games. For the PvP version I intend to make it 4 or 5 times larger.

_This is what a finished maze should look like:_

![finished maze](./pics/Solved_Maze_Finished.PNG)

## __04.03.2022 - Main Menu - 0.1.1__

The main menu consists of a big title and some buttons, for now. To make it a bit more interessting I added bots that drive around in the background. They spawn outside of the field of view of the camera and start moving in one direction. not far from this zone is a death zone where these bots are destroyed to save resources. 

At spawn each bot gets its own random color.

![BotColors.cs](./pics/BotColores.cs.PNG)

SpriteRendere[] botSprite; refers to the different section of each bot.

![bot sprite white](./pics/Bot_sprite_white.PNG) 

The body of the tank is completelly white and the different sections like the barrel or the main body are separated into 6 pieces. Like this I can color each of the 6 sprites indevidually to give the bots some perosnality.

## __07.03.2022 - Scene Transitions - 0.1.5.1__

So to make the pace of the game smoother I made a little animation between scenes. A wall of sprites just like the player itself moves from left to right and leaves a dark background behind it. This indicates the end of a scene. At the start almost the same thing happens just with the dark screen going first and the wall of tanks after it.

_When the player exists a scene:_
![scene end](./pics/Scene_Transition_End.PNG)

_when the player enters a scene:_
![scene start](./pics/Scene_Transition_Start.PNG)

## __11.03.2022 - Local Game -__

I started working on the local game. When the player joins on the "Local Game" button in the main menu he/she will be sent to the LocalGameLobby scene. Then a table will show up in which the last 10 or so game will be displayed with the players that played that game and their points. Below that two input fields for the player names and a Next button. The Next button leads to the actual game. The same maze that was already mentioned before will be generated here as well. 

### __12.03.2022 Pregame Menu__

The first canvas the player sees is the PreGameCanvas that holds the score table ans is responsible for the player name input. The name can not be longer than 10 characters. 

![local game objects](./pics/LocalGameSceneObjects.PNG) ![player name handler](./pics/PlayerNameManager.PNG)

In version _0.2.1_ the player name input system is working. You can enter a name end it will show in the game canvas. Version _0.2.2_ fixed a problem with the fonts where everything was 100% black. In _0.2.3_ an exit button was added and the pause menu is woeking. Now I have to write the script to save the games. 

To make the game more colorful the player can choose a color for its tank right above the name input field. These changes will appear in version 0.3.1. The Sprite the player chooses here will be translated to the GameCanvas and implemented as a spinning object to distinguish the players not only by name but alos by color.

### __16.03.2022 Game__

In the game a 10 by 10 field will be created. There I will have to  spawn the players on random locatios. The player movement is pretty simple with the players beeing able to move back and forth and rotate around themselves. Also the player can shoot a bullet which is still a little buggy because it just pushes everything aroung and doesn't get destroyed when colliding with a player. These changes are visible mainly in the version _0.4.1_. 

In _0.4.2_ the player can move around and shoot the enemy. After a hit he/she gets +1 to the score. After that the players are relocated and the "round" starts again. There are some things that have to be fixed like for example the player should not jitter when colliding with a wall, the bullet should despawn after the round and an animation has to be added when the round ends and maybe an explosion animation right at the score when the it increases and after the explosion the new score will be revealed.

_0.4.3_ hopefully fixed the but with the bullet acting not apropriatelly. Now it should not push away players. Update: it's not.
Also maybe I should put the "pregame menu" and "game" in differnt scenes to make the maze generation and animations easier.

_0.5.1_ The LocalGame has been separetad into two scenes to make the canvas cleaner and the replayability more efficient. Now all the values like playerSprite or playerName are stored into the PlayerPrefs folder. With this update the bug that happened before is fixed, when the player presses "New Game" the maze gets destroyed and the user gets sent back to the LocalGameLobby scenes. At this point the game works on a basic level but the score has to still be saved and a scoreboard has to be added as well.

_0.5.2_ The maze generation is not visible when loading new game round. The scene transition after the round is delayed by 1,5 seconds. Also the player gets the color he or she really chose.

_0.6.1_ I added a timer to later see the time spent playing a round. Also fixed the name length to 10 characters for both players.

_0.6.2_ Bot tanks no longer have white lines showing inbetween sprites.

_0.6.3_ Player sprites bug fixed: now the skin that the player chooses in the lobby is the actual skin of the player even if nothing is changed. And blue skin will no longer be skipped when cycling to the left. Player score bug fixed: now when new game is started the score is set to zero.

_0.6.4_ Added a Composite Collider 2D to the Maze prefab and changed the BoxCollider2D on of the cell walls. With this unwanted movement of the ball should be cancelled.

![composite collider](./pics/CompositeCollider.PNG) ![box collider of a wall](./pics/BoxCollider2D%20of%20a%20wall.PNG) 

_0.6.5_ Added a button that gets the player back to the main menu in the LocalGameLobby scene. Also fixed some sizes of items on the canvas.

_0.6.6_ Changed some button textures. The exit button and the button back to the main menu in the local game lobby now look like this:

- Exit: 

![exit](./pics/fueltankpiskel.png) 
- Back to main menu:

![back to main menu](./pics/arrow-back.png)

I pickd the fuel can because I thought it looked cool and it implies that it's time to refule, aka quit the game.

_0.6.7_ Timer added to the game which will also be displayed in the "Previous Games" table. Also started working on the database that stores the data from previous games. For that I created a "Plugins" folder that contains necessary files for an SQLite database. 

![plugins](./pics/Plugins.PNG)

_0.7.1_ Scores can be saved into a database. With "DB Browser for SQLite" you can even see the score. Update: This didn't work.

_0.7.2_ 

_future updates_ make the data saver and scoreboard | add timer at the top of the screen and save it later (time played) | add an "exit to main menu" button
to the local game lobby. 

## - How To Play - 

Here you can scroll through some pages and view what the game has to offer and how it works. First the basic stuff like movement, score and items. Next the extra stuff for the local game and after tha for the online game. 

My idea of visualising this  page would look something like this:

    (button left - previous) (content - the information) (button right - next)

    (# --- # --- # --- # --- tank sprite --- # --- # --- # --- # --- # --- #) 

where the --- represent a path and the # a stop where information will be shown.

# ideas for the future 

## local game

These names and scores will then be saved in localgames.db 

at the same time the previously played games will be displayed with tha 5 latest games: with it the names of the players and sroce as well 

## local and online game

so to make the game more exciting i will ad a "lucky box" where you can get new weapons from. for example instead of shooting a regular shot you shoot 4 slighly smaller bullets aka a shotgun.
so on and so forth. i will still collet ideas but for now its just important to remember this

Weapons ideas:

- shotgun 
- laserbeam 
- item that makes you invulnerable for 1 second
- rapid fire (10 - 15 really small bullets)
- landmine 
- shrapnell bullet
- heavyshot 