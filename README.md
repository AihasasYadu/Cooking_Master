# Cooking_Master
A prototype of Cooking Master Game
This game is a type of Local Co-op Cooking Simulator game (still in prototyping stage), where the goal is to take salad orders from customers and create salad from the vegetables available to the player and submit the order once done, the vegetables could be converted to salad by using assigned chopping station available to the players
It comprises of 2 player inputs via Unity's Input System,
        1. MovementA Action Map is for WASD controls
        2. MovementB Action Map is for Numpad controls
        
Both of these action maps consists of 4 Action,
        1. Pick
        2. Drop
        3. Serve
        4. Move


Game Core Logic :-
The game is controlled by the GameManager in regards of setting up the stage, players and customers
    1. Stage Setup - In stage setup all the different types of vegetables that are available as per level data, is setup in both the counters available on either side of the screen and caching the vegetables instantiated inside the game
    2. Player Setup - In player setup, the players are assigned with a unique player ID along with different input action maps and chopping stations, and the players are cached and stored in a list
    3. Customer Setup - In customer setup, a queue of customer is generated consisting of random orders, unique customerIds and customer initial mood, which can be later on used

Once the game is setup, the game starts as follows
    1. The customers are moved to order counter and they start waiting for a certain amount of time based on their order
    2. The players can move around and can pick a vegetable or Order if it is inside their Box Collider, the player cannot pick an order if the player is holding a vegetable and vice-versa
    3. Once the player has collected required vegetables, they can be moved to a chopping station where the vegetables could be dropped one at a time in the sequence they were picked up, once the vegetables are chopped the result is sent to the serving plate of the player
    4. Once the player is satisfied with the resulting salad, they can pick the order from plate and serve it to the most suitable customer
    5. If the order is served correctly then the player will be rewarded with rewards, else the customer would get angry and the waiting timer would speed up


Scripts :-
The scripts in the game are divided into several folder and nameespaces based on their function, such as Views scripts are responsible for all the UI related changes, VOs scripts are value object scripts that is responsible for game data or for creating scriptable objects, Core consists of core game logic scripts and so on.
The core logic classes are as follows,
    1. GameManager - Controls the setup and data manipulations for the game
    2. PlayerController - Controls the players movement and interactions
    3. VegetableChopController - Controls the chopping of vegetables based on the waiting time for current level and moves it to SaladController once done
    4. SaladController - Controls the salad on the serving plate
    5. CustomerController - Controls the customer waiting and checks and confirms if the available order is correct and sets the mood as per the result
