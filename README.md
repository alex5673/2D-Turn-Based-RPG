# 2D-Turn-Based-RPG

Final year individual project

C# 2D turn-based RPG with a retro sprite based design made with Unity.

*Game work in progress*

This game takes inspiration from the RPGs that were released in the 90s. I wanted to include everything that I typical RPG would have such 
as: storyline progression, character progression (with stat system), turn-based battle system, suitable audio and world exploration.

So far I have implemented a start screen, world map exploration, a main menu and I am in the process of implementing the battle system.
For the menus I have used Unity's UI elemented to create the start screen as well as all the buttons and menus I need for the battle system 
and main menu. 

With the battle system, I have designed my own variation of the turn-based system which includles elements that help to introduce more 
strategy and variation. For instance, I have implemented a charge button that allows the player to decide weather to skip their turn in 
order to gain an attack boost when they do attack. Other elements which affect the battle system are item usage, which gives the player the 
chance to use an item and then make an attack or use a spell, this allows the player to quickly heal a character when needed and allow them 
to make a attack as well, keeping them in the battle.

The AI enemies in my game attack randomly and all have their own stats to make the enemies unique. I have also included a very simplified 
genetic algorithm that is based on the a Genetic algorithm I have designed before. The genetic algorithm that is used for a boss enemy that 
will use the genetic algorithm to continually evolve a strategy based on the player character's weaknesses.

Eventually I aim to have an array of different enemies for all three of the islands on the world map for my game. I am next going to 
implement a town with NPCs, as well as some story diaglogue. I also aim to create a save and load function for my game as well as audio 
that will add to the game experience.


