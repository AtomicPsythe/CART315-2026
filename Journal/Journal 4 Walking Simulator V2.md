11/7/2026

- duplicated the walking sim project to make v2
- brainstormed some possible improvements and ideas
- came up with the following:
	- make paths in the forest with gates that open and close at will (look at what we did during class) -> like until dawn opening and closing gates
	- add piles of snow, leaves blowing in the wind, branches on the ground and make paths of snow where people have walked
	- make decisions appear in certain areas in the environment
	- sound goes mute when you are in a specific area in the scene
	- stamina bar
	- toggleable flashlight
- after thinking on these improvements, i decided to go with the toggleable flashlight, improving the environment look with piles of snow, leaves blowing in the wind and branches and leaves on the ground, and add an explorable cabin in the distance maybe. 
- i first started with the toggleable flashlight, where i created a script that would slowly tick down the flashlight's battery over time when its in use and would dim when the flashlight is below 30% and would turn off when it reaches 0%. i made it toggleable using the F key so it isn't on all the time
- i used the following click sound effect for when it turns on and off
	- https://pixabay.com/sound-effects/technology-turning-on-and-off-a-flashlight-click-sound-502512/
- i also added a panting noise for whenever the player is in motion to make the experience feel more real and alive
	- https://pixabay.com/sound-effects/film-special-effects-panting-7108/
- when making the flashlight, I thought to myself if there should be a way where the player can recharge their battery, so I decided to add floating battery collectibles around the map. the battery collectible was used via the following asset from the unity asset store
	- https://assetstore.unity.com/packages/3d/props/simple-gems-and-items-ultimate-animated-customizable-pack-73764
- i also added a spot light to the battery so it looks like its shining in the distance to attract the player towards it. in doing so, i also added a battery collectible script so that it can be collected and naturally recharge the flashlight's battery
- the next improvements that i need to work on are to scatter the batteries across the map, look into potentially adding a script to make the weather feel more random, add more piles of snow and scatter leaves and sticks/branches around the map, and potentially look into adding a cabin somewhere in the terrain
- i also need to solidify my gameplay element for the project

11/8/2026

- scattered 6 batteries across the terrain
- duplicated the blizzard twice, made one version more erratic and chaotic and made the other version more serene and calm so that the blizzard looks and feels more realistic and less calculated and organized
- after testing the walking simulator, I am satisfied with the way the panting is already being translated, so that is no longer an edit that needs to be done
- have to search for piles of snow, rocks, leaves, and branches assets to add and scatter across the terrain 

11/9/2026

- had a potential idea for a gameplay goal for the player, where 3-4 parts of a note are scattered along the terrain and the player has to find them in order to "complete" the walking simulator. work in progress idea but can be fun to implement
- imported the following asset pack into the project, as it contains a lot of useful environmental elements that are already covered in snow and a low poly cabin and chest that I can use for the the player to explore and find collectibles
	- https://assetstore.unity.com/packages/3d/environments/landscapes/lowpoly-forest-pack-winter-129565
- scattered some snowy grass, rocks, and tree stumps around the environment to make it look more real and natural. added a well in the center of the terrain and a cabin with a chest inside for the player to find and explore. 
- will look into adding more rocks/trees/logs/tree stumps around the terrain
- have to look into making/finding the note asset to scatter around the terrain for the player to find to reveal some kind of hidden message
- still need to figure out how to add piles/lumps of snow on the terrain (can also be an asset that I can find)

11/10/2026

- 

11/11/2026

- 