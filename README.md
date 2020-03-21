
SPACE SURVIVAL
Submitted by Saraswathi Shanmugamoorthy

Summary:

This goal of this project was to design and develop a 3d space shooter style game using Unity 3D. In this game the player tries to score as much as possible by collecting energy potions while also dodging attacking enemy ships and asteroids in the way. The player will be given a spaceship using which he navigates through space while avoiding asteroids. The player will also have to dodge attacks from enemy ships which spawn at random places and timings. The player scores points by collecting or consuming energy potions which are placed at random locations. The goal of this game is to score as high as possible by collecting energy potions, and also try to stay alive as long as possible by dodging enemy attacks.
Description of work:
This game is developed using Unity game engine and C#. My work includes creating a grid of asteroids that simulate space. These asteroids are assigned random dimensions making them look natural. The asteroids are also spawned at random locations. The asteroids also rotate at random (X,Y,Z) angles - which helps to simulate lack of gravity in space. I have also implemented movements for the player and enemy spaceships which allows them to freely move and rotate in 3d space. I have also added trails for the spaceships to show motion and thrusting effects. The player spaceship is equipped with multiple lasers that helps it to shoot and consume energy potions, it can also shoot asteroids creating an explosion. Similarly the enemy spaceships are also equipped with multiple lasers using which it can shoot and damage the player spaceship.
I have also added features to the ships that simulate collisions when coming into contact with other objects in space. I have added scripts to simulate explosion when attacked by enemies. I have created energy potions at random location which must be consumed by the player spaceship to score points. The player spaceship either shoots or drives through the energy potion to consume it. I have also implement a user friendly GUI and scoring system. This gaming also has a background theme music. And specific sound effects are added for collision, explosion and laser shooting.
This game also uses AI pathfinding techniques which helps the enemy ships to find the player spaceship and avoid asteroids (and other objects), which makes it very interesting. The follow camera used in this project uses Slerp and Lerp techniques to give a good view of the game.

Results:

I. Implementing player movements and Spawning asteroids in space : All the movements associated with the player spaceship such as move forward and rotate in 3d space are implemented. Thus the spaceships will be able to fly forward, backward or any direction desired. Next, we create asteroids in space which have random rotation, and are also scaled randomly to simulate space. The asteroids are also spawned at random locations on a grid.

![Screen%20Shot%202019-12-02%20at%201.38.13%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.38.13%20AM.png)
Asteroids spawned at random locations in a grid


II. Implementing a follow cam using Slerp, Lerp and SmoothDamp: In this project I have implemented a follow cam that will follow the player spaceship smoothly with help of Slerp and Lerp techniques. The previous techniques were also compared with smoothDamp.

![Screen%20Shot%202019-12-02%20at%201.40.02%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.40.02%20AM.png)
Camera view implemented using Slerp techniques


III. Rendering Trails when the spaceship moves: In this project I have used Trail Renderers to give a sense of movement to our spaceships. I have also added visual components to show thrusting of the spaceship.

![Screen%20Shot%202019-12-02%20at%201.43.34%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.43.34%20AM.png)
Trail rendered for player spaceship, shows visual effects for motion


IV. Adding Lasers to shoot & using Raycasting to detect objects in front of the ship: I have used Line Renderers to simulate lasers emited from the spaceship. I have also added lights to the ship for glow effect and the lights also glow on nearby objects as the ship is moving. Raycasting technique is used to detect objects that are within a certain angle range of the spaceship's view.

![Screen%20Shot%202019-12-02%20at%201.44.51%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.44.51%20AM.png)
Player spaceship shooting an asteroid


V. Simulating explosions and collisions: I have also simulated explosions when the enemy attacks our ship, or if the player spaceship collides with asteroids or enemy ships or other objects.

![Screen%20Shot%202019-12-02%20at%201.48.40%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.48.40%20AM.png)
Player spaceship colliding with an asteroid which causes it to change directions


VI. Sound Effects: I have also added sound effects for this game. The game has background theme music. And specific sound effects are added for collision, explosion and laser shooting. The different sound effects are triggered based on different events. Collision sound is triggered whenever any two objects collide. Explosion is triggered when the player spaceship dies, or when a spaceship gets exploded by an asteroid. And a different shooting sound is added when the laser fires.

![Screen%20Shot%202019-12-02%20at%201.57.12%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.57.12%20AM.png)
Player spaceship exploding as enemy ships have completely damaged it


VII. Spawning Enemy ships at random locations at different timings: I have added scripts for enemy movements and also for spawning enemy ships at different locations and at different timings during the game.

![Screen%20Shot%202019-12-02%20at%201.53.11%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.53.11%20AM.png)
Enemy spaceship spawning from a location


VIII. AI pathfinding for enemies: This technique helps the enemy spaceships to find path to the player through not only 3d space but also through obstacles like asteroids and debris. The AI system will check if there is anything above, below, or to the left, right of our enemy ship. If any objects are present in the way, then the enemy ship will turn away from them to take a different path.

![Screen%20Shot%202019-12-02%20at%201.56.27%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.56.27%20AM.png)
Enemy spaceship using pathfinding techniques to find and attack player spaceship


IX. Generating health monitor: In this game I have created a player health monitor that is initialized to a fixed score. Every time the player spaceship takes a hit we lose one point and the shields will regenerate 1 point every 2 seconds. The health monitor is visually represented at the bottom left of the screen. Green bar indicates good health and red bar indicates damage. Initially the health monitor is fully green, when the player spaceship is completely damaged the health monitor becomes fully red.

![Screen%20Shot%202019-12-02%20at%201.55.15%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%201.55.15%20AM.png)
Player health monitor becoming red as player spaceship collides with an asteroid


 X. GUI and scoring system for the game: I have also created a GUI system for the game and also implemented a scoring system for the player. Whenever the player spaceship collects or consumes a energy potion its score increases a fixed amount (100). The goal of the game is to score as much as possible while also trying to survive as long as possible by avoiding being shot and killed by the enemies. The player spaceship either shoots or drives through the energy potion to consume it.
 
 ![Screen%20Shot%202019-12-02%20at%202.26.55%20AM.png](https://github.com/Leonid369/Unity-3D--Space-Shooter-game/blob/master/gaming-final-screenshots/Screen%20Shot%202019-12-02%20at%202.26.55%20AM.png)
 Player spaceship trying to increase score by consuming energy potions

 
 Also GUI showing:
• Current score in the left top corner 
• Timer in the top middle
• Highest score in the top right corner



Analysis of work:
The aim of the project was to develop a fun game based on spacing shooting and survival with defined graphics which was achieved in this project.
I got the opportunity to learn about developing 3D games using Unity game engine and its features like the use of Scenes, Prefabs, Physics engine, Joints, Collisions, Animations and so on.
The designed game is a good start which can be improved by adding more sophisticated features.
Future improvements that can be made to the game include the following,
1. Adding Lens to the player spaceship when aiming at targets.
2. Adding features to turn this into a multiplayer game where players attack each other, and also can gain scores by salvaging the fallen/dead player’s energy potion collections.
3. Adding planets and other space bodies, which could have gravitational effects on spaceships which come into contact.
I have successfully created a fully functional prey predator type 3d space shooter game. The goals proposed in the proposal are met on time.

 
 
