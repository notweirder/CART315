# May 9, 2025
## Iteration 5

Question: How can terrain effects be placed in a way is entertaining and also doesn't break the game

I figured it would make sense to drag and drop these effects on the map with the mouse, so I found a [tutorial](https://www.youtube.com/watch?v=izag_ZHwOtM) online to help me out. 

After a bunch of messy coding, I came up with the following: The terrain effects spawn in and pulse to notify that they're interactive. When you grab one, it becomes larger to signify it's currently held, and then when it drops it is placed on the ground of the scene and is interacted with the cars as normal. From there, after a ten second timer the terrain effect starts to fade out, and at the end of that they delete themselves. 

![](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExN3U0ODZmcW5jNXFrN2RscWFucGJiMnpneTg4NGtwbml2azBpMzU5dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/dzcmrLYzJ8M3sCFN2f/giphy.gif)

In a perfect world, I would have a separate UI where you could drag down the terrain effects from a menu bar, but time does not allow for that. I settled for random spawn locations that the user then drags to a location of their choosing. I initially capped the max amount of terrain effects at four but that was quite boring. I crave chaos so I doubled the limit to eight. I also reduced the spawn rate from five seconds down to three. However, that felt a bit much so instead I put the spawn rate back up to five seconds and kept the terrain effects on screen longer (so there could be more on screen at once). With that, I was pretty much done!

![](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExbmI1YXkzNWgzaGt6bjZ6cXpiYXE3dGVjaXplOWV3Yjl6bjZ0NmZtbCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/dzcmrLYzJ8M3sCFN2f/giphy.gif)

The good sign is that I'm having some fun playing it myself. It's goofy in just the ways I wanted: lining up several water effects to get the cars dashing into a void, or having them trudge through mud only before scrambling them and having the cars go the exact opposite direction. Good stuff!



# May 8, 2025
## Iteration 4

Question: How can I add weather effects into the game?

This iteration is implementing what I've had in mind for a while. I need there to be something spicy to this game so the ideas I have are the following:
- Rain that speeds up the cars
- Mud that slows down the cars
- Boulders that block cars from moving
- Black holes that delete cars
- UFOs that scramble the car destinations

Wow, this actually worked exactly how I hoped it would! I'm not sure why I love switch cases so much at the moment but they feel super satisfying to implement
![](https://i.imgur.com/7yEyMg5.png)

Something helpful about the prototyping phase is that I can see what happens when I add these terrain effects into the game. First of all, they're very fun! Second of all, since I ended up adding a simulated rigid body in, the cars ended up bouncing up against each other, so when one suddenly switched directions because of the scramble effect, it created a traffic jam. This is exactly the kind of silliness I wanted so I'm over the moon to see this in action. However, this traffic jam does make the game unplayable, so I need to create a more complex terrain for the cars to move through so they have alternative paths. Time to do that!

![](https://i.imgur.com/PfgyFwu.png)

The more complex environment is done! Look pretty good too :) Something I noticed was there was too much traffic jams for my liking so I decreased the car size by half which is a lot more reasonable. I also tweaked the code for the scrambler so that it couldn't randomize to the same destination as before. One more change to make is that object pathing can butt heads with each other, so to prevent that I will increase the resolution of the grid, giving more options for the cars (hopefully reducing the odds of this). Update: It still happens but it's kinda funny so I'll leave it in as an intentional bug. 

![](https://i.imgur.com/j1V2tT5.png)

Question: How can I add weather effects into the game?

Answer: Pretty easily, but they're going to mess with the way the cars drive so you have to redo the map and the size of the cars to prevent infinite traffic jams. 

# May 7, 2025
## Iteration 3

After reflecting on my ideations from last week, I have settled on a good solution for this next session. I will be testing the size of the game map, with three sizes: small, medium, and large. To start this, I need to do some more skeletal work which means getting a spawner system working.

Something I assumed would be fine was the fact that the cars can move in the same lane and moving past each other. If this is supposed to be a simulation of road infrastructure (albeit a silly one), it certainly doesn't feel like it. I have a few options going forward
1) Ignore this completely
2) Retheme the game to make these errors canonical
3) Fix these errors (which I'm realizing will be difficult because local avoidance is a pro feature)

For now, I'm not sure what to do so I'm going to keep trucking along with this prototyping session and keep that as a note for the future (and hope it doesn't come back to bite me). Okay, on to actually prototyping

## Finding the right size

![](https://i.imgur.com/rOkai84.png)

I can tell the large scale map is too much work for what I want to do. I hate connecting all these paths together in unity. Maybe a proper level editor would make things easier but for now I just don't have the time. I've been trying to get the GameObject paintbrush working but it's just a complete nightmare. I actually think a large-ish map would look quite nice, but for the sake of this prototype I don't have the time and I am going to be working on the small scale map for now. 

I understand this is a weird way to prototype, but I'm going to build the prototype in such a way that it's modular and can adapt to a larger map size in the future. I guess this iteration is complete? I need to move on anyways. 

- Question: What map looks good?
- Answer: Slightly smaller than large, but it's currently unfeasible. 





# May 6, 2025
## Iteration 2

Things are starting to take shape. I started out by creating square pathways for the cars to move along, acting as roads. One straight path, one corner and one t-junction. It took a few attempts to get these paths to align with each other, but once they lined up it was as if I was playing with legos. 

Below: Corner piece
![Corner piece](https://i.imgur.com/3sXpCgu.png)

Initially the car would cut corners on its way to its destination because it would stick too close to the walls, and that looked bad. 
![](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExeDlkN3NiZW93cjZnbXB5YjIxaXkyM3FneXd5emsydDZzbmJqYXY4aCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/A5J03gZyh946GCt39p/giphy.gif)
After some toying around, I realized I could add some extra space around the walls if I increased the pathfinder grid resolution. 
![](https://i.imgur.com/1ukaXtI.png)

From there it was code/logic time. Things are slightly out of order so you're already seeing it implemented in the previous gif, but the plan was to spawn a car with a random destination (that matched its colour). To get it working with a prefabricated object (the cars), I had to create a singleton to keep track of all the destinations, and then when the prefab was instantiated I would take a random destination from the singleton and set it as the point for the prefab to move towards. I kinda understand why singletons are dangerous but in this context I think it's fine. There's some other work I did as well but that's the gist of it.  

## *Thinking about* iteration 2

I'm wondering if I'm doing this whole iteration thing correctly. Things are going to plan which means I'm just trucking along. When I hear the word iteration I think seeing what works and what doesn't, and then correcting your course accordingly. In other words, a "yes, but". If I'm being kind to myself, I think it's fine for things to work out, otherwise I'd be faking things going wrong which would be weird! Another thing is that I'm still building out the game, and it's simple enough that I know it's possible. Whether or not it's enjoyable is another question, and I won't know if that's the case until I keep building the skeleton of this game. Perhaps the real iteration comes once that skeleton is complete. Anyways that was a ramble to end this iteration log, treating it like a blog at this point. 

-Eric


# May 3, 2025
## Iteration 1

For this iteration, I want to get path navigation working. It was a bit of a mess trying to figure out how to do it on my own since the navmesh agent was just for 3D projects. Luckily the lord and saviour Brackeys has a tutorial explaining how to accomplish exactly what I wanted to do, leading me to find A* Pathfinding by Aron Grandberg. Turns out games like Darkwood, Cult of the Lamb and Void Bastards all use it! The documentation is super thorough which is a godsend, and has turned what would be a ten hour process into less than an hour of work. The purpose of this iteration was to simply see if my idea was possible, and good news: it is!

![Simple footage of a green ball heading towards a red ball while avoiding walls](https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExNHI0cWxhd3IzdzJ3MWs2M2huZWdobHdmZW54cG14YmF1d2g1a3ZieiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/SE5zavbpST9MVAiZ7W/giphy.gif)

Now it's time to flesh out the game..

# April 26, 2025
## Catching up on Design Values

I believe it would be smart for me to read through Colleen Macklin and John Sharp's [article/chapter](https://www.informit.com/articles/article.aspx?p=2697997) on design values in order to go in to my ideation session with an informed mindset, since it's been a few weeks since the lecture on said topic. Done. Something I didn't think about much was how the design values are the main north star when designing a game. I'm not quite at the level of a pro game designer so I'm going to do some handholding and break down the design values one by one. Unfortunately I have no idea if I should come up with my design values or concepts first, so I'm going to vaguely state my intentions and then go into more detail for each idea. Maybe this is my NYU Game Center jealousy speaking but I kinda want to take a stab at a digital toy. Games like [ODDADA](https://store.steampowered.com/app/1627870/ODDADA/) , [Nour: Play with Your Food](https://store.steampowered.com/app/1141050/Nour_Play_with_Your_Food/), [Hideko](https://store.steampowered.com/app/3256030/Hideko/) or [Plaything](https://www.vam.ac.uk/dundee/info/plaything)[^1] (and to a lesser extent [Placid Plastic Duck Simulator](https://store.steampowered.com/app/1999360/Placid_Plastic_Duck_Simulator/)). While I can't answer every design value without knowing my theme, I can start pointing towards some goals. I want the game to be low challenge, and to be bold I'll state that I want it to have no lose condition. Drawing from Plaything, I want this to have the feel of a web game, akin to something you'd play on a bespoke website dedicated to it. With those two out the way, I am going to ideate on the concept so I can fill in the following design values: experience, theme, point of view, decision-making, skill and emotions. 

Pool:
- Swimming pool
- Objects pooling together
- Pool game
- Putting money together
- Carpooling
- Rich people
- Changing seasons
- Filling with different liquids
- Scrooge McDuck swimming in money
- Pool balls
- Poodle?
- Poo? (No)
- Water
- Chlorine
- Floaties
- Lifeguards
- Lazy rivers

Cleaning:
- Reverse splatoon
- Swiffer
- Moving objects away
- Unpacking (video game)
- OCD
- Marie Kondo
- Removing digital artifacts
- At ease
- Physical effort
- Mom
- Sorting items
- Uncovering objects
- Gloves
- Smell (good and bad)
- Washing machine
- Dishwasher
- Soap

Because this is a unity class, I plugged the two lists into a script and had them spit out every possible combination. From there it was just a case of scrolling through the list and picking out random combos that sounded interesting. 

Carpooling + Removing digital artifacts

Rich people + Smell (good and bad)

Pool balls + Swiffer

It's surprisingly hard to come up with a good game idea, even when the concepts are narrowed down. I know I want to make a digital toy, but that's so vague, and these three concepts don't inherently lend themselves to that idea. I'm trying to think what I want to put into the world. I'm pretty into the idea of carpooling because I like the idea of cars moving on their own, and you have control over some aspect of them. Maybe the roads, the traffic, the environment, the drivers, the passengers, or maybe the cars themselves. 

My problem statement will be as follows: How can I make a game where road infrastructure feels like a toy?

Three offshoots off of this idea are as follows
- You create your own paths and cars automatically populate on them (like Townscaper of Tiny Glade)
- There's pre-existing infrastructure that you wreck havoc on (meteors, potholes, etc.)
- You make your own cars and then watch them go about their day

Emotion: I want this game to make people smile, and my pipe dream is to make them laugh
Decision-making: Players will have an empty canvas with various options presented in front of them, restricted in some sort (e.g. a grid)
Point of view: This will be top down (birds eye view), a sort of "god game" to quote peter molyneux. The game will be represented through abstract shapes, similar to Mini Motorways. 
Theme: A broad description would be "light chaos", delivered through systemic interactions in the world. 
Experience: The player will be able to shape this small world in a way they see fit. The interactions will be light and bubbly (reflected in the UI), with bright colours to make them feel at ease. 
Skill/chance. Uncertainty will develop from the option presented to the players (e.g. you will have to pick between a meteor or a flood for one event), as well as no indication as to what anything does. You have to experiment to see what happens, similar to how no toy has a paragraph of text on it. 

I feel like I now have a better north star to point towards so it's time to get prototyping!

![](https://i.imgur.com/QVHSLii.jpeg)

Quick paper sketch of the idea for the game



[^1]: Side note: I randomly stumbled upon Plaything a few weeks ago and not only is it a really great experience but it was also made in part by one of the Despelote devs, *and* I learned that the curator of the project (Marie Foulston) has unsurprisingly worked with Pippin in the past.


# April 25, 2025

## Redo from last week

So far this project has been pretty simple. I've copied code from the breakout script to instantiate pool balls and added a random colour to them (thanks to to Alex09 on [stackoverflow](https://stackoverflow.com/a/48844708) ). Currently the main thing bothering me is that the balls aren't centered. I found a unity [forum post](https://discussions.unity.com/t/centering-instantiated-gameobjects-grid-to-the-center-of-the-screen/826171) that seems to have the solution but I don't totally understand it right now. I have decided to switch to a triangle instead of a grid because that seems to make more sense for a pool game. After several hours of trying to get the pyramid to centre itself, I realized I could just build one on it's side and then rotate it 45 degrees which is kinda easier. I then have to shift it over manually which is bothering me to no end because of my hatred for hardcoding (if i change the number of rows from 3->4 it gets off-centre again) but whatever, it is what it is. They're also not perfectly centred, but again, whatever. Now it's getting the balls to have a proper weight from them. It's now the next day and I got it working (or close enough)! 

When you start the game, it places the pool balls in a triangle, and then you are free to launch the cue ball at them. Every time you sink the ball into a hole, the balls delete themselves and the global score goes up. 
![Start screen](https://i.imgur.com/zWKnEKX.png)
![Hit balls](https://i.imgur.com/HbJMJHs.png)
![Hit balls again](https://i.imgur.com/ctdjQjY.png)For whatever reason unity was giving me errors with Random, so while I could in theory set the pool balls to have different point values, for the sake of this prototype I just needed to submit it, so I set them all to be worth one point. Last time I said it felt nice to just have *something*, but it feels extra nice to actually have something that's kinda fun! I can see myself turning this into a more fleshed out game, and I might further develop this for my final project. Also for this class maybe it's not so bad to hardcode some positions in, considering that's what was done for the breakout example. This isn't the best game in the world but it pretty much accomplishes what I wanted to do. I still got stuck in a rut trying to get the pyramid positioning to work, but I spent the same amount of time getting this whole project done as I did just trying to get the pool cue to hit the ball. Honing in on just the fundamentals

# April 21, 2025

## Catching up on Breakout

Being overconfident in my Unity skills, I skipped the Breakin' Out tutorial section so I am now spending time going through it to understand what was taught in that class (namely singletons).

## Exploration Prototype 3

For this prototype I would like to expand on my previous project and create a game of pool. There are some twists that I would like to apply in order to learn about timers, singletons, spawning children with different variables, and object rotation with quaternions. The idea is a normal game of pool except the balls only show their colours/point values when they have collided with other game objects, and then fade back to black. 

I have attempted to get the pool cue to rotate with the mouse but the position of the mouse is set to the entire world, not the local world. Doing some research, it appears Camera.ScreenToWorldPoint will work...and it does! That's a good feeling

----
Update: It's been about five days since I started working on this project and I think I need to call it quits on this one. I got very lost in the sauce attempting to figure out how to rotate the pool cue and then launch it. I don't exactly know what's happening here with the mouse movement, it wasn't rotating correctly though.

![Pool cue rotating around centre based on mouse movement, but it is not rotating correctly](https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExMXRmM2tyc243eGd1NGp4azN3aXl1cmE5Z3M5dDB4ZTQ4Nnc3MDMzdyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/Ekf7OYTHIluA7V97Kk/giphy.gif)

I then tried to learn rigidbodies and hinge joints which had their own set of issues, namely the cue not launching when i wanted it to. 


![Cue rotating around cue ball  but not launching correctl](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExNXh5cXRtZ215OGJ0MW5xZG9vODNoZnl4YmhsYzQyazl2eWhhbm54biZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/4Mbl6zgZWnvTg5h0wl/giphy.gif)

In hindsight, I may have been overambitious yet again. The rotation would have been nice, but it didn't have anything to do with singletons or spawning variables so spending all my time on that was a mistake (not to say I learned nothing). I still like the idea, so I'll be using the next exploration prototype as a redo of sorts. Thinking about it now..maybe I should just have made it so the ball was controlled directly, instead of the cue.

# April 14, 2025

I Decided to start using Obsidian to write down my journals, this app rules! 
## Catching up on classes (put genuinely not intended)
Starting this journal by stating that reread through [Chapter 26 of IGDPAD](https://learning-oreilly-com.lib-ezproxy.concordia.ca/library/view/introduction-to-game/9780136619918/ch26.xhtml#ch20lev1sec7), and some of [Chapter 27](). I wanted to refresh myself on classes in C# and realized I had last opened the Boids project from Chapter 27 about a month ago... At the time I understood *most* of the text but was very confused at why the author had to create two instances of the boidSettings class. I now understand it was because you can't set static variables in the inspector (which I read before but never clicked until now). I still have more questions about serialization, why the class is able to be accessed without a constructor, and why `this.GameObject.GetComponent<>` is the same as `GetComponent<>`but I have to put that on the back burner for now.

## Exploration Prototype 2

### Process

For this prototype I believe a simple way to explore physics, scoring and tags would be to create a simple shuffleboard game (in 2D). At the time of writing (before starting), I believe what I need to accomplish is the following
- Create a disc with friction that charges up it's force while the mouse is held down
- Create multiple target zones (with tags?), detect what zone the disc is in
- Score points and reset
I realize this is quite similar to Pawng but I don't intend to reuse much code from that class lesson.

I attempted to do friction from the top down but that didn't exactly work because it would either a) push the board or b) go right over it. Reddit posts I found suggested simply slowing down the velocity over time and that made sense. 

---
Well that kind of worked! It's honestly quite boring but it works so there's that. The big issue I ran into was getting the zones to work since the disc could overlap into multiple ones at the same time (e.g. medium and hard difficulty). When this occurred it appeared to be a coin toss for what Unity decided. I'm sure there's a proper solution to this problem but I'm already getting lost in trying to solve this so I need to stop and be okay with it not working perfect. My duct tape solution is to reduce the size of the puck so that the odds of overlapping are reduced.

Image: I implemented a switch case which felt nice, a lot cleaner than a bunch of if statements 
![](https://i.imgur.com/dmRN0VH.png)

GIF: "Finished" Game

![Example Gameplay](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExdXdmbWpyZHl3Nzh3bXdxa2x6Mmk2ZDY5cndvM3gxcjl6NnlobXQ3MSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/Udu2SV6LXg0uKd07Yc/giphy.gif)

### Reflection

While this was a decent way to get to grips with Unity, I'm realizing that this exploration was more of a technical exercise than a creative one. I'm very much not pushing the limits of game design by recreating shuffleboard. Still, I'm glad I decided to create something from scratch instead of reusing a template. One important lesson I learned from this exploration was understanding that it's possible for me to create  a smaller scoped project and feel fine with it. I purposely stopped myself from spending too much time and getting too attached. While that may be creatively unfulfilling (and is something I can work on balancing), it feels nice to have a small project completed for once in my life. Future iterations of this shuffleboard game could include multiplayer, fixed collision detection and UI elements. Future exercises could be improved by setting creative and technical goals.



# March 20, 2025
Starting this off by mentioning I'm going to be writing multiple entries per week, and am now starting off with specific dates (e.g. "March 20, 2025") rather than "Week 1", "Week 2" etc. There is a lot of catching up I have to do and it's easier to sporadically write entries than have to figure out the math of "Week 8.17" etc.

## Where I've been
Here's the rundown of where I've been so far: The first week or so of this course was fine, but afterwards up until mid-February I was quite busy with a class from the previous semester I had received an extension for (CART 351). It consumed most of my time trying to wrap everything up and once that was done I had taken the week off for myself, as of a reward for having that weight off my shoulders. From there it was reading week, which I was pretty busy most of the time (though I did squeeze in a good amount of playing Keep Driving) Early March I had planned to start a big catch-up in this course, and just my luck...I caught the flu (so I was out for a week). Now..finally it's March 20th and the catch-up truly begins now. I had struggled to read the textbook but recently made a commitment to getting through it a short while ago and have been making steady progress. I am currently finished chapter 28, and have to get through chapter 25 (Debugging) & chapter 7 (Acting Like a Designer). 
There's also ADHD stuff I'm working through and that's been a whole thing. There's a fine line of mental health issues taking over my life and things genuinely being my fault and I don't know which side of that line I'm on (is that the right metaphor?)
 
## Exploration Prototype #1

### Concept
As someone who has had issues with scope and figuring out an idea that I won't get lost in for weeks, I decided to cheat and use a tip taught later in the course: brain dumping. I gave myself a two minute timer, and generated the following ideas on how to tweak the fallingAsleep project:
- Bounce balls back up
- Change color of paddle to ball
- Spawn balls from all sides, dodge
- Spawn pellets you have to collect (pac-man)
- Physics simulation, drop ball along slopes and the ball changes color
- Push block into goal (sokoban)
- Sort colours into blocks (Mario party)

I decided on the last idea, which was actually *not* from Mario Party, but from Wii Fit Plus (deep pull I know). The image below is a screenshot from the game. It's pretty simple, you just tilt a paddle to sort the colour of the ball into the matching pipe. What makes it tricky in the Wii U game is you have to tilt the balance board but I digress... 

![](https://static.wikia.nocookie.net/wiisportsresortwalkthrough/images/3/30/TiltCity.jpg)

(Image from wiikipedia.fandom.com/wiki/Tilt_City)
### Process


![A](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExemZtMWkxMHR5NW5sZWl2NDM1NHNhZXE4enBjMHMzaHFodjh5dDVjaSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/VfAhyMpHAf9RY5eiNu/giphy.gif)


I started off by rotating the paddle around in place with the arrow keys

TEMP MP4 LINK: https://imgur.com/a/4fV9tC1

Then I changed the ball dropper to randomly assign a ball a "left" or "right" tag and change the colour depending on which tag it had. From there it was as simple as creating two box colliders and adding tags to them as well, then checking if they matched through C# code. If they did, the score would increase. Easy, right?

![A](https://i.imgur.com/UjabeTu.png)

Because I'm smart, I decided to attach the *global* score values to the *instanced* balls. For some random reason that was totally not my fault, they were only logging their individual scores, hence I was just getting -1s or +1s.

![A](https://i.imgur.com/kiJuJCU.png)

To fix this, instead of creating two separate box colliders, I would have one large box collider and then just check what side each ball was on. Instead of assigning a score to an instanced ball, I would instead assign a global score to just this one one box collider. I know hard coding isn't great...but it works, and for the first exploration that's good enough!

![](https://i.imgur.com/BHly04e.gif)It works! Not sure why imgur is adding all these dots though so just ignore that 



# Week 1.5 - Explore Unity
Going to be honest, this was a stressful week! A lot going on with other courses and life(tm) made it difficult to get any work done. I have nothing to show for today * but * hopefully this evening or tomorrow a Week 2 post will appear of me actually doing this week's assignment. I should note that I do take a bit of accountability for pushing this week's work off til the last minute, one of these days I'll fix that...

# Week 1 - Make A Thing
I was surprised at how much using Bitsy was an exercise in frustration. While the focus of the platform is on how restricted your toolset is, the lack of quality of life features felt like an oversight rather than an intentional decision. Having no option to rotate tiles meant that what could have been a quick one and done process became a task I had to repeat four times, which also took away from productivity as I had to sort through three duplicate tiles in my tileset.

 *Two of the same tiles "rotated" are really just two seperately drawn tiles*


<img src="media/1_duplicatedTiles.PNG" width ="100"></img>



In addition, the platform was significantly glitchier than I had expected. Tiles would randomly swap with each other, the game would occasionally appear to have reverted to the default template, and more. This became a struggle against the system, instead of with it.

*The tiles were not updating, giving the appearance that nothing changed. On reload, the random clicks I had made suddenly displayed*

 <img src="media/1_introRoomBug2.png" width ="200"> 


My procrastination meant that I had put off the project until the last minute, so I had to make something quick and scrappy. I wished I had a bit more “gameplay” instead of walking around and clicking on sprites but even still, there were some keen observations I had noticed through playtesting. The first is that while I had thought it would be best to make the avatar and background sprites the same colour for consistency, it was surprisingly hard to tell the two apart. In addition, I should have been more careful with the tile size limits. Representing a beach with a volleyball court could be done, but I was a little too sloppy with the pixel art and as a result players had a hard time telling what was what. In addition, there was the expectation that players could enter said volleyball court, which I intentionally made not the case. In the future I should do a better job communicating what is interactable and what is not.

*This volleyball court isn't actually explorable*

 <img src="media/1_volleyball.PNG" width ="200"> 
