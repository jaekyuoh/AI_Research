Behavior Library
================

BehaviorLibrary is a framework for creating behavior trees for game AI. It is free to use, modify, and redestribute as covered under the attached License (FreeBSD).

New
---

Added Utility components, see Utility Test cases for test examples.

The basic point is to use a vector of floating numbers representing weights/values that will be paired with a BehaviorComponent object. When a UtilitySelector is called, it will execute a function that returns a UtilityVector that will then be compared against the BehaviorComponents' paired vectors (via a dot product) and select the pair that best matches and execute its Behavior. 


Example
-------

It is simple to use and with that simplicity comes performance.

Example of a simple A* following AI on a tilemap

	//setup all coniditionals and their delegate functions
	Coniditional tooClose = new Conditional(isTooClose);
	Coniditional targetMoved = new Conditional(hasTargetMoved);
	Coniditional pathFound = new Conditional(hasPathBeenFound);
	Coniditional reachedCell = new Conditional(hasReachedCell);
	Coniditional reachedTarget = new Conditional(hasReachedTarget);
	Coniditional isNewPath = new Conditional(hasNewPath);

	//setup all actions and their delegate functions
	BehaviorAction moveToCell = new BehaviorAction(moveTowardsCell);
	BehaviorAction calcPath = new BehaviorAction(calculatePath);
	BehaviorAction initPathfinder = new BehaviorAction(initializePathfinder);
	BehaviorAction getNextCell = new BehaviorAction(getNextPathCell);
	BehaviorAction setPath = new BehaviorAction(setNewPath);
	BehaviorAction getPath = new BehaviorAction(getCurrentPath);
	BehaviorAction updatePosition = new BehaviorAction(updateTargetPosision);
	BehaviorAction reset = new BehaviorAction(resetPathfinder);
	BehaviorAction animate = new BehaviorAction(updateAnimation);

	//setup an initilization branch
	ParallelSequence initialize = new ParallelSequence(initPathfinder, calcPath);

	//if the target has moved, reset and calculate a new path
	ParallelSelector ifMovedCreateNewPath = new ParallelSelector(new Inverter(targetMoved), new Inverter(reset), calcPath);
	ParallelSelector ifPathFoundGetPath = new ParallelSelector(new Inverter(pathFound), getPath);
	ParallelSelector ifPathNewUseIt = new ParallelSelector(new Inverter(isNewPath), setPath);
	ParallelSelector ifReachedCellGetNext = new ParallelSelector(new Inverter(reachedCell), getNextCell);
	ParallelSelector ifNotReachedTargetMoveTowardsCell = new ParallelSelector(reachedTarget, moveToCell);
            
	//follow target so long as you're not too close and then animate
	ParallelSequence follow = new ParallelSequence(new Inverter(tooClose), updatePosition, ifMovedCreateNewPath, ifPathFoundGetPath, ifPathIsNewUseIt, ifReachedCellGetNext, ifNotReachedTargetMoveTowardsCell, animate);

	//setup root node, choose initialization phase or pathing/movement phase
	RootSelector root = new RootSelector(switchBehaviors, initialize, follow);

	//set a reference to the root
	Behavior behavior = new Behavior(root);
	
	//to execute the behavior
	behavior.Behave();
		
