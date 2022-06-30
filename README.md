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

![onetwo](https://user-images.githubusercontent.com/81720436/176589610-978cc6eb-04b2-43ae-9fa5-ab1116b004bf.png)

When you load in the scene, the first thing you will see is probably a gorilla model with both of it's arms extending outwards.
In the scene, there are also two exporter GameObjects. Follow the path shown in the Hierarchy to access the objects.

![left right](https://user-images.githubusercontent.com/81720436/176589755-c12150fb-c44e-4504-acf0-c9ef3622f766.png)

When these objects are exported, everything inside of them is exported too.
This means nearly every object and component will get exported with the exporter object.

![comp](https://user-images.githubusercontent.com/81720436/176591533-9263d38c-ea8b-4f24-a950-d0405028aa7d.png)

Inside of each of the exporter objects, there is a script called the Descriptor.
The Descriptor is what tells Gorilla Tag the holdable's info, the name, author, etc.

![desc](https://user-images.githubusercontent.com/81720436/176591224-fd64b168-19d5-47a5-baf0-d530fb7473dd.png)

When you're done making your holdable, go to the topbar of the screen, Holdable Pad > Holdable Exporter.
Once you click Holdable Exporter, a new Unity Window will pop up, find which exporter you're exporting, and make sure it has the following:
- A name
- An author
- A description
- If you're exporting the LEFT exporter, check the "Left Hand" box.

![righthandmenu](https://user-images.githubusercontent.com/81720436/176590737-551bc6cc-5e9c-4d91-acbd-ed717b6e21b8.png)

When you have made sure it has exported, click the "Export (Holdable Name)" button and it will export.

![namehand](https://user-images.githubusercontent.com/81720436/176590757-8c5c6414-4c43-4142-ab88-39846408031a.png)

Don't know where it was exported? Go back to that "Project" tab earlier, a new folder should be there called "ExportedHoldables"

![exporterd](https://user-images.githubusercontent.com/81720436/176590902-45fbfe6c-26db-4077-a4cc-786e735bf6f1.png)

If it's there, you should be able to spot your holdable .holdable file! Right click it > Show In Explorer, copy the file, and do whatever with it!
You can either put it in your Gorilla Tag folder > BepInEx > Plugins > HoldablePad > CustomHoldables or upload it to my Discord: https://discord.gg/3qf7J8KkQD
After all of this, you are done! Now go take a small break and enjoy the rest of your day! :)
