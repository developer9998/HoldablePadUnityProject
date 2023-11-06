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
In the Unity project, there is a scene included which is the base for creating holdables. To open the scene, click on the "Scenes" folder located in the "Project" window, the scene should be located in that folder under the name "Scene".

## Scene Information
When the scene has been opened, it contains a Gorilla model from the game, both arms are extending outwards for easier creation of holdables. Using the Hierarchy window, you can inspect this model which reveals two objects inside, "Left Hand" and "Right Hand", additionally both have an exporter object in them.     

## Descriptor Information
Inside of each of the exporter objects, there is a script called the Descriptor.                
The Descriptor is what tells Gorilla Tag the holdable's info, the name, author, etc.                

![image](https://user-images.githubusercontent.com/81720436/177212634-2d030b7f-8fd5-44d8-8f65-6f0db3536b69.png)

When you're done making your holdable, go to the topbar of the screen, Holdable Pad > Holdable Exporter.                
Once you click Holdable Exporter, a new Unity Window will pop up, find which exporter you're exporting, and make sure it has the following:                
- A name
- An author
- A description
- If you're exporting the LEFT exporter, check the "Left Hand" box.
- If you want the holdable colours to be yours ingame, check the "Custom Colours" box.

![image](https://user-images.githubusercontent.com/81720436/177212438-91bb98c2-fcaf-4a79-bd02-8a8f6ab797be.png)

When you have made sure it has exported, click the "Export (Holdable Name)", select your path, and it will export.

![image](https://user-images.githubusercontent.com/81720436/177212737-b7eb1378-f761-41d3-92b3-77983cc29cc4.png)

After you clicked "OK", a new instance of the File Explorer should open directing you to the holdable.
              
You can either put it in your Gorilla Tag folder > BepInEx > Plugins > HoldablePad > CustomHoldables or upload it to my Discord: https://discord.gg/3qf7J8KkQD       
After all of this, you are done! Now go take a small break and enjoy the rest of your day! :)                
