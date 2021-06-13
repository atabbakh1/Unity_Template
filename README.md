# Unity Starter Porject

## Using 2020.3.11f1 LTS

## Demo: https://mygame.page/unitywebgldemo

This project sample was created for the Summer 2021 students in Robert Brackett III design studio at Pratt Institute's School of Architecture. The project requires no coding knowledge and is a great starting point for beginner level Unity users.

![Screenshot](/Documentation/Interface.JPG)

## To Get started:
1. Clone the repository to the desired location on your machine.
2. Using UnityHub; Open **UnityStarterProject** with *Unity 2020.3.11f1 LTS* (preffered)

## Overview
- The Project Browser contains a basic folder structure and it has two scenes: **SceneA** & **SceneB**
- An *FBXImporter preset* has been implemented in order to skip the additional material extraction step. The settings for any FBX import will be automatically adjusted to the appropriate configuration.
- A 3D Scan import sample is provided in the Model/Imports folder.

## Custom Editor Components Overview
### 1. Player Movement
Attach to the **MainCamera** GameObject and it will Provide two different modes for navigation:
        - Character Mode: Uses a *character controller* and responds to gravity
        - Flythrough Mode: Does not respond to gravity and ignores object physics.

![Screenshot](/Documentation/PlayerMovement.png)

### 2. Raycast Manager
Attach to the **MainCamera** GameObject and it will handle realtime raycasting from the camera to any objects that belong to the specified layer mask, In this case the *Interactable* layer. Choose whether you want interactable objects to be highlighted on mouse hover and provide a highlight material if so.  

![Screenshot](/Documentation/RaycastManager.png)

### 3. Interactable Object
Attach this script to any object -- that belongs to the Raycast Manager layer mask -- that you would like to interact with through mouseclick events. This script currently provides four different simple interactions. However, the crossing between the *Raycast Manager* class and the *Interactable Object* class are setup in a way that allows for easy addition of other custom interactions.

![Screenshot](/Documentation/Interactable2.png)

1. Turn object on OR off
2. Trigger an animation that belongs to an object
3. Change the color of an object
4. transition from one scene to the other

This project is a WIP and more features will be added. 
