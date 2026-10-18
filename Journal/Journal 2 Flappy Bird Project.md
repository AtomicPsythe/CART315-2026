10/5/2026

            The first day of development for the second prototyping project began with deciding which template to work with as well as ideation. Deciding which template to pursue was fairly simple for me, since only one of the three stood out to me gameplaywise which was Flappy Bird. In going with said template, I had begun coming up with potential ideas for revamping it. The first idea was one that I had thought of during the first week of the class being a 2D platformer where the player is a butterfly who has to jump from flower to flower, each possessing unique behaviors, to reach the end of a garden. The second idea followed the same garden theme, except it would be an auto-scrolling story game about the history of a lavender field I visited in Hawaii. The third was a cat café style game, similar in gameplay to the mobile game Cooking Fever, where the player is a cat waiter at a cat café trying to manage the customers, while impressing and tending to the Cat Café Critic (CCC). Upon further reflection, I chose to pursue the first idea, as it reminded me of my time when I would stay at my grandmother's house when I was younger and used to collect little flowers from around the neighborhood and gift her them in a small bouquet tied with some string. Butterflies are also my favorite insect so utilizing that as the player character is very special to me. Additionally, the build of Flappy Bird can easily be molded into the flower platformer, whilst adding visuals that pay homage to my childhood memory, adding a layer of sentimentality.

            Once this stage was completed, it was time to ideate and write a formal synopsis of the game, which went as follows.

            PROTOTYPING 2
-          Title: Bloombound
-          Synopsis:
		A 2D auto-scrolling platformer where the player controls a butterfly navigating a garden by landing on flowers with unique behaviors. Each flower species has a distinct rhythm or movement pattern that the player must learn. Players progress through hand-designed stages containing randomized flower arrangements and collect a nectar-like collectible upon completing each stage. At the end of each stage, the player collects a piece of nectar that contributes to a Nectar Bloom Heart. Collecting all three pieces allows the player to complete the final stage and beat the game.

-          Controls:
		Move
			Left and right arrow keys
			A and D keys (left and right)
		Jump/flutter
			Spacebar

	Finishing a level grants you flower nectar (can be 3 pieces of nectar that come together to form a heart) that you can use to move onto the next level. Completing 2 levels brings you to the final (hardest) level where completing it completes the Nectar Bloom Heart, beating the game.

-          Flower types:
			Sunflower
				Large surface area
				Slow opening/closing cycle
				Remains open for a while
				Introductory flower (level 1)
                        Tulip
	                        Smaller surface area
	                        Faster opening/closing cycle
	                        Doesn’t stay open for a long time
                        Rose
	                        Moderate surface area
	                        Maybe has thorns on the edges?
	                        Petals fall off fast = have to act fast?
	                        Reverse controls?
                        Lavender
	                        Smaller surface area
	                        Sways back and forth instead of opening and closing
                        Hibiscus
	                        Moderate surface area
	                        Acts as a bounce pad
-          Main character:
			Monarch butterfly
				8-bit visual style
					3 frames of animation (normal, wings flapped up, wings flapped down)
				Is okay to fall off flower
				Can flap wings with the space bar to try to get back onto the flower
				If you fall out of bounds, the level just restarts
-          Levels:
		Level 1
			Flowers:
				Sunflower
				Tulip
			Purpose: 
				Introductory level
			Player learns:
				Movement
				Fluttering
				Landing
				Opening/closing flowers
				Recovery after falling
			1/3 Nectar Bloom Heart
			Difficulty: 2/5
		Level 2
			Flowers:
				Sunflower
				Tulip
				Rose
				Lavender
			Player learns:
				Precision
				Moving flowers
				Optional risk
			2/3 Nectar Bloom Heart
			Difficulty: 4/5
		Level 3
			Flowers:
				Sunflower
				Tulip
				Rose
				Lavender
				Hibiscus
			Player learns:
				Movement
				Fluttering
				Landing
				Opening/closing flowers
				Recovery after falling
				Precision
				Moving flowers
				Optional risk
			3/3 Nectar Bloom Heart
			Difficulty: 5/5
                                    
	From this I slowly began working in Unity to construct the template to fit my idea. I initially began with designing the butterfly and sunflower sprites myself, which I later imported into the program. Following that, I edited the player's movement to allow them to be able to move side to side as well using A and D or the left and right arrow keys. This was done to stay true to the gameplay style of platformers, which generally allow the player to move in all directions to reach the next platform. To continue, I proceeded with swapping out the default pipes with my sunflowers, for thematic purposes, and later played around with the way they spawned. Instead of having flowers spawn from above and below the player, like the pipes in Flappy Bird, I bounded them to spawn on the ground only, as flowers normally would, with random varying distances apart from each other to add an element of unpredictability and challenge.

            Following these developments, my next goal would be to make a playable level with a beginning and ending and the ability to move onto a second level, even if it hasn't been built yet. Additionally, I would like to look into adding 2-3 more flower variants for some diversity in platforms.

10/8/2026

            Today's project advancements were quite minimal compared to Day 1. After having built and implemented the opening and closing of the flower, I decided to draw the ending platform for each level, being a leaf. The reason for it being a leaf is to have the butterfly go back to its home ground after collecting all of the nectar from the flowers. After drawing and uploading the file, I tried to place it within the game so that it would appear once the flowers stopped spawning. This proved to be much harder than I intended, as I have to stop both the parallax and the flower spawner from being active in order to have the leaf platform appear naturally into the scene. Only having discovered this after, all that I tried was unsuccessful prompting me to move onto another aspect of the game, being implementing a heart collectible animation as a sign of completing a level. I had found and sourced a heart collectible from a creator on itch.io (https://axiale.itch.io/2d-heart-assets) and uploaded it to my file. I tried utilizing the sprite editor to upload it, but it did not work, meaning I need to do research to try to figure out how to implement it properly. The next steps I need to take are to properly place the leaf platform and the heart collectible at the end of the level, have the behave as they are supposed to, and prompt the player to advance to the second level when they interact with both the heart collectible and the platform.

10/13/2026

            Many goals in the development of the project were achieved today! The first few changes were aesthetic ones, like giving the game a name, being Bloombound, changing the default game over, level complete, and title images into my own made TextMeshPro text, and creating my own start and next level buttons! These changes were all mostly made to make the game feel more personalized and to drift away from the Flappy Bird template.

            Following the dead ends from the last work session, I retackled the leaf platform and heart collectible issues. Starting with the leaf platform, this required a lot of trial and error for many hours. At first, I tried to figure out how to manually stop the parallax from moving, but any attempt I made resulted in the parallax simply not working at all. This prompted me to seek out some YouTube videos on parallaxes. Most of them stated that in order to stop the parallax from function after a certain point, it needed to work on a timer-based system adjacent to the scroll duration. This made it so that I had to constantly have the parallax's timer update in the Update() function so that when it reached a certain time it stopped moving. A similar approach was taken with spawning the flowers, except this time a Coroutine was needed. They also had to spawn on a timer-based system, where after a certain time they would stop spawning. The Coroutine came into play because this continuous spawning of the flowers was happening over time, and the only way to pause its execution was by using a Coroutine. After playing around with the time intervals, I found that the flowers should stop spawning 2 seconds before the parallax stops in order to give time for the leaf platform to appear. Luckily, the leaf platform did appear after the flowers stopped spawning! However, I ran into the issue of if the player fails the level once the leaf platform is on screen, then it would not de-spawn and would remain there through the player's new attempt. This issue stuck with me for many hours, as I wasn't sure which variable or line of code was triggering this error from happening. I discovered that the issue lied in the fact that I never reset the leaf platform's position when the level restarted. After changing some lines of code to fix that issue, everything was working well!

            Lastly, the heart collectible was another issue I had to tackle. However, a quick google search on moveable sprites helped me resolve this problem! Since the heart animation I sourced came pre-sliced in the sprite editor, all I needed to do was to write a proper Update() function in a new script for the heart collectible that constantly calculated its floadSpeed and floatAmplitude over time, allowing it to move up and down on the leaf platform. Once it was able to move independently, I also added an OnTriggerEnter2D function that destroyed the collectible once the player interacted with it so that it was "claimed". The last thing I needed to do to make the heart collectible and leaf platform work together was to make the heart a child of the leaf platform in order for it to look like the heart is rested upon the leaf. I tested the game after these changes, and everything worked amazingly! To end off this session of work, I created the scene for Level 2 and connected the end of Level 1 to the beginning of Level 2!

            Many changes were made today that were difficult, but I persevered through them and am extremely proud of the result! The next goals for development are to provide an incentive for the player to land onto the flower instead of just permanently fluttering above them, to design and implement the next flower type for Level 2 and look to change the background and ground images to fit the theme of my game!

10/14/2026

            Today's development focused a lot on developing the second level of the game. To begin, I drew and designed the opened and closed sprites for the second flower type, a tulip. Once that was made, I uploaded it into the project files to import it into the scene. I followed the same conventions for the parallax and spawner from level 1, except the tulip's unique mechanic was that it has a smaller surface area to land on, while opening and closing at a faster pace. To achieve that, I just tweaked the numbers of the minimum and maximum opening times for when the image changes from the opened to closed sprite when it spawns. I added the leaf platform and the heart collectible on top of it as normal and the second level was made!

            One thought I've had at the back of my mind since finishing level 1 was, is there even a reason for the player to interact with the flowers at all since they can flutter forever? This made me consider some options including influencing the player to actually interact with the flowers. Two ideas came to mind: one was to add a sort of wall-like object on the top part of the screen forcing the player to land on the flowers, the second was to include a stamina bar and have the flowers restore stamina. After reflecting on it and inquiring with other creatives on the matter, I decided to pursue the idea of the stamina bar. However, I was unsure on how to include such a thing, as I have never coded something like this before. This prompted me to seek out assistance from a friend of mine, Alissia Bocarro, who is familiar with C# and assisted me in implementing this mechanic, while also referencing the following video: https://www.youtube.com/watch?v=ju1dfCpDoF8.

            With that implemented, the player now has to land on the flower to regain stamina in order to complete the level! While creating the stamina bar with Alissia, she suggested the idea of including a visual cue on the flowers to alert the player that they will close, as it was unfair to the player to have them close randomly without a warning. At first, I considered adding a slight shaking animation to the flower before it closed, but after hours of coding and troubleshooting it ended up not being successful for me. This led me to put the thought on the backburner as I continued the project's development, since it was not a crucial problem that needed to be fixed immediately. One problem that I encountered as I was playtesting the levels was that the player would trigger the game over when they are a fair distance away from the closed flower, due to the collider size of both objects. Upon figuring this out, I adjusted the collider sizes of the flowers and the player, making the game over trigger feel more natural. During the next day of development, my goals are to come up with a visual cue for the flower before they close, create level 3 and think about what it's flower mechanic can be, and begin thinking about the design of the backgrounds and ground objects to replace the Flappy Bird assets.

10/15/2026

            Today's development day began with reflecting on the goals I set to achieve today after I finished working yesterday. Primarily, I thought a lot about what a nice visual trigger for the flowers can be, since the shaking animation was unsuccessful. I thought of overhauling the images and making them into animations myself, but I am unfamiliar on how to work with animations in Unity, let alone coding it in C#, so I decided not to pursue that idea. One idea that seemed feasible was for the flowers to flash a color before closing. Now, while real flowers don't flash colors, in a game sense for what I am trying to achieve it felt adequate to try to include it. The process for this was quite simple, as I had done a flashing light mechanic in a previous game of mine in a different coding language, so I approached it with that same mindset and it ended up working! Once the trigger was coded, I implemented it to the sunflower and tulip prefabs I had in their respective levels, and the inclusion was seamless! The flashing lights' colors matched each flower type, a darker orange for the sunflower and a darker purple for the tulip.

            The next order of business involved revisiting a previous problem that I thought was resolved, being the player and flower collider issue. Upon playtesting the levels after the trigger inclusion, I saw that the colliders would work for some flowers but not all of them, which confused me since I thought I had resolved the problem. I then began to do some research on 2D colliders and see if there was any way to make the collider more accurate to my image. Through my research, I discovered polygon colliders, which allow you to create the collider shape into whatever you like by creating and moving collider vertices. Upon discovering this, I tried it immediately with one of the flower assets and it made the collision much more accurate! I added it to the code as well, which was not too bad since it followed roughly the same conventions as a box or circle collider would. This led me to adding the polygon collider to the flowers, leaf platform, and the player. I do wonder if and how I can add it to the closed flower sprites, but that would have to be something I have to look into. I played tested the levels again with the new colliders and it worked great!

            This prompted me to move onto level 3's creation and development! I sat on the thought of what level 3's mechanic would be for many hours. At first during ideation, I wanted to have 3 different flower types: a sunflower, a tulip, and a hibiscus, one for each level. However, seeing how intricate it was to create and troubleshoot the flower scripts, I opted to have the last level spawn both sunflowers and tulips instead of a third new flower type. In doing so, it puts the player's skills to the test to see if they can conquer both flower types in one level and creates a nice closing to the game. However, after adding both the spawners from the previous levels to level 3, I saw that the flowers would spawn normally, but they would often spawn on top of one another. This issue puzzled me a bit since I wasn't sure this was even possible. I'm not sure exactly how to solve it at the moment so I added all of the remaining elements, being the leaf platform and the heart collectible, and tested if it was playable to which it was!

            The last changes for the day were about general gameplay and said heart collectible. I found that when starting each new level, it began very abruptly and pushed the player into it immediately without any preparation. This led me to refer to my Prototype 1 code, where I implemented a countdown system before the Pong level began! I decided to use and reference that same code in Prototype 2 and have each level begin with a 3-2-1-GO! countdown to ease the player into the stages. After playing, I found that the transition between scenes to be much more seamless and less abrupt, improving the gameplay experience and quality of life.

            Next, during ideation, I had noted down that the Nectar Bloom Heart would steadily be completed over time in thirds, but that wasn't necessarily reflected in the visuals of the heart in game. Therefore, I went back into each level and changed the visual of the heart to only contain a third per level, steadily increasing with each new level. Now, level 1 shows 1/3 of the heart, level 2 shows 2/3 of the heart, and level 3 shows the completed heart for more clarity! Now that all of the levels are completed all that is needed to be done next is to fix the spawner issue in level 3 and begin replacing the remaining flappy bird assets with my own assets!

10/16/2026

            From there, the design work began! I created the appropriate scenes for the main menu and controls and created the layout for each with their appropriate text and buttons as needed. From there I went into my drawing application and began to draw out the background for the main menu, which was tall blades of grass and a white picketed fence and a blue sky. This design approach was taken in order to contextualize the player and convey how small the scale was of the butterfly and the flowers in comparison to normal-sized objects for humans in the real world. As I was working on the sky specifically, I came up with the idea of having the time-of-day change with each level, from morning to afternoon to nighttime, to show the natural day progression as the days go on. Naturally, the ground, flowers, leaf platform, and player assets needed to match the time of day and appropriately needed a filter placed on each of the assets. From there, I completed the design of the main menu background and went to work on the level backgrounds.

             Since the level backgrounds matched the visuals of the main menu background, the design process was fairly quick, as only the time of day needed to be changed. Once that was done, I saved each file and uploaded them onto Unity, made each parallax background its unique material and applied them to their appropriate scenes! Once that was done, it was time to go back into my player, flower, and leaf platform assets and add the afternoon and nighttime filters to all of them. Subsequently, I saved the assets and uploaded them onto Unity where I replaced them in an appropriate level just like the backgrounds. The last asset that needed to be made was the ground and since the background was blades of grass, naturally the ground had to be dirt. So, I drew out the dirt with some rocks, added the time-of-day filters, uploaded them to Unity and placed them each in their appropriate scenes.

            After all this design work was completed, I tested the game and the new assets made the game feel so immersive and felt like I really was in the world amongst the grass and dirt! I'm really proud of how the game has turned out! However, the issue with the overlapping spawners still remained and I wasn't really sure how to fix it still. Will have to be something I take the time to resolve in the coming days! Once I tested the game, the passing thought came to mind of adding a contextual story element before playing level 1 and after completing level 3. I think this can really help immerse the player in the world and environment of the game but will be something that is done once all other primary issues and tasks have been completed!

10/17/2026

            Today's day of work was very minor. I had noticed that I was lacking on doing commits throughout my working process, so I took the time to sort through all of my assets, code, materials, and scripts and remove and clean up everything that was and was not needed in order to send out a large late commit on what was completed. Additionally, I was also lacking on the journal updates, so I formally wrote out each entry after simply having point forms written for each day. I got way too carried away with the development! With all of that done, I didn't have much time to look at the spawner issue nor think about including the contextual story elements. The spawner will be a priority issue to look at tomorrow as it needs to be resolved before submitting! Depending on how efficiently I can get that done, the story inclusion will come after as an added bonus! If the story cannot be written, there will be a short credits section closing the game after completing level 3 before leading the player back to the main menu, inducing an element of replayability.

10/18/2026

             Today marks the final day of development! The first order of business was to tackle the level 3 spawner issue once and for all. I decided to duplicate my code script so that I have a copy of the original before working on a newer version. In doing so, I tweaked some of the original code before going in and trying to find a way to prevent the flowers from overlapping. For instance, the flower prefabs that the code was getting the flowers from was rewritten to [SerializeField] private Flower[] flowerPrefabs;, since both prefabs take from the Flower class. From there, I watched many different videos on randomly spawning objects in both 2D and 3D and found that since the prefabs are assigned in an array, they are naturally numbered from 0, 1, 2, 3 etc. As a result, after performing a safety check to ensure it is in the inspector, all I had to do was to randomly pick an integer from the array and have it spawn from the global level 3 spawner. To prevent them from overlapping, I just needed to check the spawn manager first, to ensure that the flowers appropriately don't overlap, since the code I had done previously of Time.time - lastSpawnTime >= globalSpawnCooldown, was correct but was just not working with the previous GameObject array that I had. Once that change was made and some testing and tweaking had been done with the flowers themselves, level 3 was completed!

            This finally brought me to the final stretch of the project where I was able to get creative and write some contextual story for the prologue and epilogue of the game that would appear before level 1 and after level 3, respectively. The prologue and epilogue naturally has scenes to pair with each of them, and I added them to the build profiles of the project in their appropriate spots. Since all of the functioning elements of the game were completed, it was now time to clean up the files, scripts, and unused objects and assets. During this process, I fully ridden all of the old Flappy Bird assets, tweaked the colors, sizes, and shapes of some buttons and text, ridden of any unused assets, scripts, or objects and made sure everything was proper.

            All in all, doing this project was extremely challenging and took a lot of time and energy from me. I am extremely proud of the result, however getting to that point was very hard due to the many coding hurdles I had to overcome, like the flowers, spawners, and colliders. In the future, I would like some more time to explain and be taught some coding in C#, since I am still unfamiliar with the language fully and the possibilities of what it can achieve are equally fascinating as they are endless!