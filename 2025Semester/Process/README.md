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

![GIF broken so here's a temp mp4 link](https://i.imgur.com/6MgLBJ3.mp4)

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
