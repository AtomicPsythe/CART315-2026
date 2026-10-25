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
