# XRCityBuilder
## Test Project for Infinity Games

This project has been built in Unity using XR Interaction Toolkit 3.1.2. It was tested using Oculus Quest 2 and played with the Quest 2 controllers.
### City Development
1 - Built the city using various assets from the asset store in a modular form, after I had already built it, I made a grid system to make the city more modular like a Lego City, unfortunately it was at a later stage of the project, so the city is built without taking the grid into consideration.
### User Interface (UI)
2 - There is a UI interface always open in the world, we can select from some objects (House,Tree and a Lamp Post). There is also a menu to get the same objects that can be activated by rotating the controller toward yourself.
### Object Placement
3 - The objects can be grabbed from the UI, turning into small 2D icons in the world. This is achieved by grabbing the UI icon and instantly instantiating a new 2D game object as the icon in the player's hand while destroying the old UI icon, making it look seamless. The player can then move the icon around and go to the city and drop it, the icon will turn into a 3D object and slowly drop into the floor of the city. If the player wants, they can grab the 3D object again and drop it in a grid formation, since it will quickly snap onto the closest tile to the 3D object.
### Satisfying Transition
4 - I used Unity's particle system to make a simple transition effect, tried using Unity's VFX Graph, but was confronted by problems trying to change the project to HDRP.
### Physical Interaction
5 - As a physical interaction I added a train and some train stations that the player can use to move the train around along the tracks by clicking the buttons on the stations, the player can also choose where the train goes on bifurcations by clicking the button and a light will appear showing where the train will go. The train works with a really simple state machine and follows a linked list of nodes to go around the tracks freely.

### Challenges & Reflections
This project was a challenge to make, not because of coding problems, but because of the XR Interaction Toolkit 3.1.2, as it is a very complex system that gave me many problems when trying to understand the documentation, and how every action was working behind the scenes. The complex system was also joined by this last version of the toolkit being very recent and completely different from older iterations, making it difficult to find information online, as it was not yet available besides Unity's documentation. I later got a bit more the hang of the toolkit but as time was ticking, I ended up not writing the best code I could, which turned more into a quick prototype that works over a nice well-designed code full of extensibility. To show a bit of extensibility, I used some older code from a project I made for the grid System with minor changes. As for the train code, I'm not proud of it" and would probably remake the whole thing if I had a bit more time, as it is very rough coding for my standards.
