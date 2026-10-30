10/24/2026

- started by playing in the given 3D playground with the controller to get a feel of how it works
- inspired by Until Dawn's snowy night mountainous environment and will try to recreate something similar
- tried to created 2D assets for the mountains and trees but was not satisfied with them
- discovered 3D terrains, so I made a 3D terrain and painted some mountains onto it 
- found external assets for the snow and rock textures along with a skybox for ambiance
	- https://assetstore.unity.com/packages/2d/textures-materials/4-snow-materials-high-quality-materials-collection-69201?srsltid=AYCX9vIIX7AgEaNEWCCRlh5up2CRfZcLr0NwI-IGI8amzLORtETkjH41
	- https://assetstore.unity.com/packages/2d/textures-materials/sky/stylized-skyboxes-free-302248
- added the rock material as the default layer and painted a layer of snow on top of the rocks
- still need to fix the layer painting to make the snow feel more natural and have the rocks stand out more
- can look for some pine tree assets to paint the snow onto them as well + find a natural snow falling asset to put into my scene 
- added a flashlight attached to the player camera but needs to be adjusted to fit the scene (either needs to be brighter or overall scene needs to be darker)
- still have a ways to go but is very fun so far!

10/25/2026

- fixed the player's flashlight to be much brighter (intensity) and much wider so it emits enough light to be able to be seen in front of the player
- edited the global volume to adjust the post-tint color to be a dark blue, lowered the saturation, and increased the contrast so the mountains in the distance stand out and don't fade into the darkness
- also played with the shadows and midtones to create that dark blue-grey atmosphere that's similar to Until Dawn's 
- tweaked the fog's settings to change it to a linear fog in order to adjust the depth of it, made it feel more dense, change it's color to match the blue-grey atmosphere
- edited the player camera to have a dark outer ring via implementing a vignette to make the flashlight stand out more
- created a snow particle system and adjusted its values (size, shape, speed, amount, depth, emission, velocity, wind speed/intensity) until i was satisfied 
- playing around with various skyboxes to find one that matches that cloudy night sky illuminated by the moon. considering making it using Unity's tools but still need to do research on it
	- https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014
- found snowy tree assets to use for the scene
	- https://assetstore.unity.com/packages/3d/vegetation/nature-pack-low-poly-trees-bushes-210184

10/26/2026

- gathered all of the tree assets to use from the asset pack and added them to the paint trees tab in the terrain inspector and painted them randomly scattered across the terrain
- gathered the following sounds from Pixabay and imported them into my project:
	- [https://pixabay.com/sound-effects/search/blizzard/](https://pixabay.com/sound-effects/search/blizzard/ "https://pixabay.com/sound-effects/search/blizzard/")
	- [https://pixabay.com/sound-effects/search/wind/](https://pixabay.com/sound-effects/search/wind/ "https://pixabay.com/sound-effects/search/wind/")
	- [https://pixabay.com/sound-effects/search/trees/](https://pixabay.com/sound-effects/search/trees/ "https://pixabay.com/sound-effects/search/trees/")
	- [https://pixabay.com/sound-effects/search/footsteps%20in%20the%20snow/](https://pixabay.com/sound-effects/search/footsteps%20in%20the%20snow/ "https://pixabay.com/sound-effects/search/footsteps%20in%20the%20snow/")
	- [https://pixabay.com/music/search/horror%20ambience/](https://pixabay.com/music/search/horror%20ambience/ "https://pixabay.com/music/search/horror%20ambience/")

10/28/2026

- went back into unity and added the blizzard, wind, trees, footsteps, and ambiance sounds into the project playing at varying volume levels within the scene
- need to adjust the footsteps sound since it continues to play despite the player remaining still and has almost a stacking effect when the player begins walking again (audio file plays again creating a stacking/replaying effect)
- need to look to improve skybox still + figuring out how to add a trail of footsteps in the snow behind the player

10/30/2026

- added the following code to the FP Footsteps script to disable the sound if the player is not actively moving:
	- if (_audioSource.isPlaying) { _audioSource.Stop(); }
- fixed my skybox issue by changing the background type for the first person camera from color to skybox, allowing the skybox to be visible how i wanted it to be, thus adding that eerie nighttime ambiance i was searching for
- also made the scope of the player flashlight a lot more intense and wider to emit overall more light and enabled shadows on it so that when it flashes light on an object it emits a soft shadow