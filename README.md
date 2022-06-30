# Guide
This is the official HoldablePad guide on how to make your own holdables.

## Requirements 
Before you start, you are going to need a few things:
- Unity Hub
- Unity 2019.3.15
- HoldablePad's Unity Project

Unity Hub
Download: https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe

Unity 2019.3.15
Download: https://unity3d.com/get-unity/download/archive

HoldablePad's Unity Project
Download: https://github.com/developer9998/HoldablePadUnityProject/archive/refs/heads/main.zip

If you don't know how to install Unity Hub or Unity 2019.3.15, watch this video:
https://www.youtube.com/watch?v=gg9Mb9xH7MY

Along with this, if you don't know how to open projects with Unity Hub, watch this video:
https://www.youtube.com/watch?v=IqjSMlk1-30

## The Project
When you open up HoldablePad's Unity Project, go to the "Project" tab, double click both "Scenes" and then "SampleScene". 

IMAGE

When you load in the scene, the first thing you will see is probably a gorilla model with both of it's arms extending outwards.
In the scene, there are also two exporter GameObjects. Follow the path shown in the Hierarchy to access the objects.

IMAGE

When these objects are exported, everything inside of them is exported too.
This means nearly every object and component will get exported with the exporter object.

IMAGE

Inside of each of the exporter objects, there is a script called the Descriptor.
The Descriptor is what tells Gorilla Tag the holdable's info, the name, author, etc.

IMAGE

When you're done making your holdable, go to the topbar of the screen, Holdable Pad > Holdable Exporter.
Once you click Holdable Exporter, a new Unity Window will pop up, find which exporter you're exporting, and make sure it has the following:
- A name
- An author
- A description
- If you're exporting the LEFT exporter, check the "Left Hand" box.

IMAGE

When you have made sure it has exported, click the "Export (Holdable Name)" button and it will export.

IMAGE

Don't know where it was exported? Go back to that "Project" tab earlier, a new folder should be there called "ExportedHoldables"

IMAGE

If it's there, you should be able to spot your holdable .holdable file! Right click it > Show In Explorer, copy the file, and do whatever with it!
You can either put it in your Gorilla Tag folder > BepInEx > Plugins > HoldablePad > CustomHoldables or upload it to my Discord: https://discord.gg/3qf7J8KkQD
After all of this, you are done! Now go take a small break and enjoy the rest of your day! :)