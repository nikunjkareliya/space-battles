# space-battles
Classic space shooter game prototype

![image](https://user-images.githubusercontent.com/4095369/221378457-4c9dae5e-dc30-409d-b83f-a5da3e790eae.png)

Game is inspired by classical arcade space shooter games of nineties.

Objective:

Goal of player is to avoid waves of enemy ships and score maximum possible points in single play.


Assets Manifest:

•	Spaceship, enemies & particle effects:
https://opengameart.org/content/complete-spaceship-game-art-pack
https://opengameart.org/content/space-ship-construction-kit

•	Space background:

https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606

•	GUI pack:

https://assetstore.unity.com/packages/2d/gui/sci-fi-gui-skin-15606

•	Fonts:

https://fonts.google.com/specimen/Carter+One#standard-styles

•	Background music:

https://freesound.org/people/joshuaempyre/sounds/251461/


Prototype Instructions:

•	In order to play the game, open the build folder generated from Unity and open executable file.

•	We’ll see windowed game output having resolution of 1024 x 768 px ie. Landscape mode

•	Press ‘Play’ button to enter directly into play area

•	Use arrow keys or W, A, S & D to move space ship around world

•	Play fires bullets automatically, it does not require player input

•	Score more points by killing coming enemy ships


Player Experience:

•	Game will be challenging & addictive for any player either beginner or skilled player.

•	Integrated simple user interface that is easy to understand, provides clean layouts & provides friendly user experience to end users.


Characteristics:

Game starts with easily avoidable enemies. Each successive waves become more stronger than before. Each enemy wave have pool of enemies, some of them are AI enemies. There are variations of patterns of moving enemy ships. Easy wave of enemy have it’s unique pattern and characteristic of moving.

Implementation & Execution:

•	Game is divided into multiple level or waves
•	Core mechanic contains getting input from player for moving player’s ship, as per keyboard input player ship update’s it’s position in world
•	Used Serializable Class to hold properties & parameters of each wave
•	Added prefabs for Player ship, enemy ships & bullets as it’s too frequently spawns
•	Memory optimization is done using object pooling
•	Sprite sheets animations created for explosions using Unity’s animation window
•	Implemented enemy ship spawning frequency using Unity’s coroutines
•	Managers have been used for managing Game state, GUI, Data & Sounds
•	Added Unity’s physics, ie. rigidbody, colliders to detect collision between game elements.
•	Singleton design pattern used to keep track of instance of class and make sure easily accessible from another class.
•	After a wave survived, we’re showing a prompt to let player know next wave is just starting
•	After hitting to enemy ship, game over prompt is showing with total score and player can able to restart the game.
