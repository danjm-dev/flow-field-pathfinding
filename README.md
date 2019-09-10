# Unity flowfield pathfinding implementation
**Developed for assignment 1 of COMP313 at Victoria University of Wellington**

![Video demonstration/explanation of implementation](https://youtu.be/7r3ZhVH5DXM)

* **Background**

    Pathfinding is an important component of AI in games, enabling agents to navigate the game world. 
    Algorithms such as A* or dijkstras are commonly used for this, however run into a problem when too many 
    agents are active. A* and dijstras are implemented on each agent to pathfind for only that agent, resulting in
    an increase in computational requirements for each new agent added to the scene.
    

* **Details of the approach**
    
    A solution to this problem is a flow field grid. A flow field grid calculates pathfinding once for the whole map. It splits the map into a grid,
    and calculates a 2d vector for each grid point/node, in the direction of a neibouring node that is closer to the destination.
    Agents are not required to run individual pathfinding algoritms, and can follow the path of vectors on each node from their location to the destination.
    (Full description of how the flow field algorithm works is in the video demonstration).
    

* **Optional variations**

    The way agents follow the vectors in a flowfield can differ. In this implementation rigidbody physics is used to push each agent through the map. Due to agents drifting and 
    physically interacting with each other/obsticals, agent movement is more dynamic and appears fluid. 
    Alternatives such as translating the agent could have also been used. This may have been less computationally expensive, 
    however look less natural (more robotic). The best method for moving agents through a flowfield grid depends on the context of the game, and its priorities.
    
    This iteration of a flowfield grid is relatively simple. There are many additions which could be made to improve it depending on the context, including:
    *   Flocking Behaviour
    *   Pre-emptive collision avoidance
    *   Flow Field Tiling (only storing relevant portions of map in grid to save memory)
        
**Sources:**

* Explanation about flowfield pathfinding
    * https://gamedevelopment.tutsplus.com/tutorials/understanding-goal-based-vector-field-pathfinding--gamedev-9007
* Helpful resourses used to develop this implementation
    * https://howtorts.github.io/2014/01/04/basic-flow-fields.html
    * https://www.youtube.com/watch?v=AKKpPmxx07w&list=LLftw25yiNrxq-9MAcTbWE5A&index=9&t=774s




