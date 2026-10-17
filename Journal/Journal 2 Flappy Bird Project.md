10/5/2026

	The first day of development for the second prototyping project began with deciding which template to work with as well as ideation. Deciding which template to persue was fairly simple for me, since only one of the three stood out to me gameplay-wise which was Flappy Bird. In going with said template, I had began coming up with potential ideas for revamping it. The first idea was one that I had thought of during the first week of the class being a 2D platformer where the player is a butterfly who has to jump from flower to flower, each possessing unique behaviours, to reach the end of a garden. The second idea followed the same garden theme, except it would be an auto-scrolling story game about the history of a lavender field I visited in Hawaii. The third was a cat café style game, similar in gameplay to the mobile game Cooking Fever, where the player is a cat waiter at a cat café trying to manage the customers, while impressing and tending to the Cat Café Critic (CCC). Upon further reflection, I chose to persue the first idea, as the build of Flappy Bird can easily be molded into the flower platformer, whilst adding visual and story elements of the lavender field idea to add a layer of sentimentality. 

	Once this stage was completed, it was time to write a formal synopsis of the game, which roughly goes as follows:
	
	"A 2D auto-scrolling platformer where the player controls a butterfly navigating a garden by landing on flowers with unique behaviors. Each flower species has a distinct rhythm or movement pattern that the player must learn. Players progress through hand-designed stages containing randomized flower arrangements and collect a nectar-like collectible upon completing each stage. At the end of each stage, the player collects a piece of nectar that contributes to a Nectar Bloom Heart. Collecting all three pieces allows the player to complete the final stage and beat the game."

	From this I slowly began working in Unity to construct the template to fit my idea. I initially began with designing the butterfly and sunflower sprites myself, which I later imported into the program. Following that, I edited the player's movement to allow them to be able to move side to side as well using A and D or the left and right arrow keys. This was done to stay true to the gameplay style of platformers, which generally allow the player to move in all directions to reach the next platform. To continue, I proceeded with swapping out the default pipes with my sunflowers, for thematic purposes, and later played around with the way they spawned. Instead of having flowers spawn from above and below the player, like the pipes in Flappy Bird, I bounded them to spawn on the ground only, as flowers normally would, with random varying distances apart from each other to add an element of unpredictability and challenge. 

	Following these developments, my next goal would be to make a playable level with a beginning and ending and the ability to move onto a second level, even if it hasn't been built yet. Additionally, I would like to look into adding 2-3 more flower variants for some diversity in platforms. 

10/8/2026

	Today's project advancements were quite minimal compared to Day 1. After having built and implemented the opening and closing of the flower, I decided to draw the ending platform for each level, being a leaf. The reason for it being a leaf is to have the butterfly go back to it's home ground after collecting all of the nectar from the flowers. After drawing and uploading the file, I tried to place it within the game so that it would appear once the flowers stopped spawning. This proved to be much harder than I intended, as I have to stop both the parallax and the flower spawner from being active in order to have the leaf platform appear naturally into the scene. Only having discovered this after, all that I tried was unsuccessful prompting me to move onto another aspect of the game, being implementing a heart collectible animation as a sign of completing a level. I had found and sourced a heart collectible from a creator on itch.io (https://axiale.itch.io/2d-heart-assets) and uploaded it to my file. I tried utilzing the sprite editor to upload it but it did not work, meaning I need to do research to try to figure out how to implement it properly. The next steps I need to take are to properly place the leaf platform and the heart collectible at the end of the level, have the behave as they are supposed to, and prompt the player to advance to the second level when they interact with both the heart collectible and the platform. 

10/13/2026

	Many goals in the development of the project were achieved today! The first few changes were aesthetic ones, like giving the game a name, being Bloombound, changing the default game over, level complete, and title images into my own made TextMeshPro text, and creating my own start and next level buttons! These changes were all mostly done to make the game feel more personalized and to drift away from the Flappy Bird template. 
	
	Following the dead ends from the last work session, I retackled the leaf platform and heart collectible issues. Starting with the leaf platform, this required a lot of trial and error for many hours. At first, I tried to figure out how to manually stop the parallax from moving, but any attempt I made resulted in the parallax simply not working at all. This prompted me to seek out some YouTube videos on parallaxes. Most of them stated that in order to stop the parallax from function after a certain point, it needed to work on a timer-based system adjacent to the scroll duration. This made it so that I had to constantly have the parallax's timer update in the Update() function so that when it reached a certain time it stopped moving. A similar approach was taken with spawning the flowers, except this time a Coroutine was needed. They also had to spawn on a timer-based system, where after a certain time they would stop spawning. The Coroutine came into play because this continuous spawning of the flowers was happening over time, and the only way to pause its execution was by using a Coroutine. After playing around with the time intervals, I found that the flowers should stop spawning 2 seconds before the parallax stops in order to give time for the leaf platform to appear. Luckily, the leaf platform did appear after the flowers stopped spawning! However, I ran into the issue of if the player fails the level once the leaf platform is on screen, then it would not despawn and would remain there through the player's new attempt. This issue stuck with me for many hours, as I wasn't sure which variable or line of code was triggering this error from happening. I discovered that the issue lied in the fact that I never reset the leaf platform's position when the level restarted. After changing some lines of code to fix that issue, everything was working well! 

	Lastly, the heart collectible was another issue I had to tackle. However, a quick google search on moveable sprites helped me resolve this problem! Since the heart animation I sourced came pre-sliced in the sprite editor, all I needed to do was to write a proper Update() function in a new script for the heart collectible that constantly calculated its floadSpeed and floatAmplitude over time, allowing it to move up and down on the leaf platform. Once it was able to move independently, I also added an OnTriggerEnter2D function that destroyed the collectible once the player interacted with it so that it was "claimed". The last thing I needed to do to make the heart collectible and leaf platform work together was to make the heart a child of the leaf platform in order for it to look like the heart is rested upon the leaf. I tested the game after these changes and everything worked amazingly! To end off this session of work, I created the scene for Level 2 and connected the end of Level 1 to the beginning of Level 2!

	Many changes were done today that were difficult, but I perservered through them and am extremely proud of the result! The next goals for development are to provide an incentive for the player to land onto the flower instead of just permanently fluttering above them, to design and implement the next flower type for Level 2, and look to change the background and ground images to fit the theme of my game!

10/14/2026

	

	- designed the tulip (open and close)
	- added the stamina bar and mechanic (recharges when you land on the flower)
	- had issue where the game over wasn't triggering when you landed on a closed flower, had to come up with a solution
	- tried to make a shaking animation before flowers closed but did not work
	- needed to look into solving how to trigger the game over for level 2 when interacting with a closed tulip
	- fix the sunflower box collider size for level 1 since it would trigger the game over while there is a good distance between the player and the closed sprite image

10/15/2026

	- added flashing lights trigger before the flowers' close
	- fixed colliders for the butterfly, opening/closing of both flower types so now they trigger the game over's properly and at a reasonable distance
	- issue with polygon collider and box collider not working together well but resolved it (had to add a polygon collider variable in the code)
	- fixed game over trigger issue
	- created level 3, but encountered an issue with using both the sunflower and tulip spawners and that the flowers overlap
	- replaced the heart collectibles on levels 1 and 2 with a 1/3 completed heart and 2/3 completed heart, respectively, and having level 3 be a completed heart

10/16/2026

	- designed the main menu and controls scenes
	- created a custom image for the background of the main menu
	- created 3 distinct backgrounds, grounds, player sprite, flower sprites, and leaf platforms for each level aligning with different times of day (daylight, afternoon, dusk)
	- still need to fix overlapping spawning issue in level 3
	- considering making a contextual story element before level 1 and after completing level 3 (ending of level 3/contextual story after level 3 completion can lead back to the main menu)