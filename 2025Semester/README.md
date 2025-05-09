# Eric's car prototype
![](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExbmI1YXkzNWgzaGt6bjZ6cXpiYXE3dGVjaXplOWV3Yjl6bjZ0NmZtbCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/dzcmrLYzJ8M3sCFN2f/giphy.gif)
-- 
Eric's car prototype is a toy in which you gain control over the terrain in a city and can mess with it as you please (within reason). The game is built around three pillars: Cars, Destinations, and Terrain Effects

Cars:

Cars are little dots that use Aron Granberg's excellent [A* Pathfinding Project](https://arongranberg.com/astar/documentation/stable/index.html) package to be on their way. Each car is instantiated from one of eight spawn points with a Destination, and has a colour to match said Destination. Cars have rigidbodies which means they can collide with each other. Unfortunately, they do not have local avoidance as that is a Pro feature of A* Pathfinding Project, so they can butt heads with each other. Often, this gets resolved in a few seconds by another car colliding into others. 

Destinations: 
Destinations are where Cars move towards. When a Car gets to its corresponding Destination, it gets despawned. 

Terrain Effects:
Terrain Effects are squares that change Car behaviour. There are four Terrain Effects currently implemented: Rain, Mud, Scramble and Void. Rain doubles the speed of Cars while Mud halves them. Scramble changes the destination of a Car and Void deletes a Car. This all happens when a Car enters the Terrain Effect and stops happening on exit (with exception of Scramble and Void, which happen once on enter). Terrain Effects are spawned every five seconds at random places on the screen. From there, the user drags and drops the Terrain Effect wherever they please, and then that Terrain Effect is active for around ten seconds before it starts to fade out. The maximum amount of Terrain Effects is currently eight. 

