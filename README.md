# Squashanoid
 
This is a simple pong-like prototype. It only has 2 levels, but more can be easily added, since most elements are prefabs.

### Racket script
Makes the racket follow mouse movement

### Ball script
Locks the ball to the racket position before the launch, then makes it play sounds when colliding with anything

### Level manager
Is a singleton, responsible for storing the score, counting the blocks in the level and loading the next scene

Since the score is stored in the singleton Level Manager Script, and it is not destroyed upon scene loading, the score is saved between levels.
