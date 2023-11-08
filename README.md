# HoldablePadUnityProject
**HoldablePadUnityProject** is the official Unity project for the [HoldablePad](https://github.com/developer9998/HoldablePad) mod for creating your own holdables. This Unity project does not reflect off of my current work I do currently, and may be lower quality.

## Requirements 
Before creating your own holdables, you will need to get:
- The ["Unity Hub"](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe) application
- Unity 2022.3.2 (Located in the [Unity Archive](https://unity3d.com/get-unity/download/archive) page)

## Download
[This link](https://github.com/developer9998/HoldablePadUnityProject/archive/refs/heads/main.zip) will download the HoldablePad Unity Project onto your device. Make sure the file for the project is extracted before you open it in Unity.

## Opening
In Unity Hub, click on "Open" and redirect Unity to the extracted folder of the project. I recommend keeping this folder somewhere safe, such as the Desktop or Documents folder. If you're still unsure about how to open Unity projects, [this video](https://www.youtube.com/watch?v=IqjSMlk1-30) may help assist you with doing so.

## Scene Location
In the Unity project, there is a scene included which is the base for creating holdables. The scene is located in the "Scenes" folder, located in the "Project" tab.

## Scene Information
When the scene has been opened, it contains a Gorilla model from the game, both arms are extending outwards for easier creation of holdables. Using the Hierarchy window, you should spot two objects with the name "Left Hand" & "Right Hand", in each of these objects there is an additional "Exporter" object, with a descriptor.

## Descriptor Information
A descriptor is used to inform the HoldablePad information relating to your holdables. Make sure your objects used for your holdable are put in the appropriate descriptor, for instance a holdable for the right hand will go in the descriptor object for the right hand. A descriptor has multiple different options such as:

- **Name**  
  This is the name of your holdable.
- **Author**  
  This is the author of your holdable.
- **Descriptor**  
  This is the description of your holdable. It can be used to inform the player of what your holdable is, or any credit for your holdable.
- **Left Hand**  
  This box is very important when it comes to placing the holdable in the hands of the player, check this box if the holdable your exporting should go in your left hand.
- **Custom Colour**  
  This box is very important when it comes to customization for your holdable. Any valid colour properties for the materials of the holdable will match the colour of the player.
- **Gun Mechanics**  
  This box informs the mod your holdable should be dealt with as a gun, and not just some ordinary holdable. With this more options appear which all have to be configured before exporting.

## Exporter Information
An exporter is a window used to export your objects and convert them into ``.holdable`` files. The exporter can be opened by clicking the "Holdable Pad" dropdown on the top of the Unity editor window, and clicking on the "Holdable Exporter" item. The exporter contains a list of valid holdables found in the scene, where each could be exported.

## Exporting Information
When exporting, you will need to assign a valid path for your holdable, perhaps try your Downloads folder if you're new, or if you know your way around the Gorilla Tag folder, try out the Holdables folder for the mod. When the holdable has finished exporting, the location for the holdable should automatically be opened. 

## Sharing Information
If you would like other modders to use your holdable, you can post it to my [Discord Server](https://discord.gg/dev9998) under the "#holdable-download" channel. When uploading, make sure you attach your holdable and an in-game screenshot of the holdable being used.
