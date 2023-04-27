# css385-finalProject-jump-demo

## Key variable to influence jumping characteristics
### vertical movement
jumpForce - normal jump force
runningJumpForce - how much extra power you get for a running jump (may end up wanting to reduce this...)
jumpDelay

### Misc
linearDrag - slowing you down
gravity -  higher means more gravity
fallMultiplier - impacting gravity (for falling faster), another aspect of manipulating gravity in a limited capacity. Useful so you can quickly fall after a longer distance jump covering the distance the player wants out of it.


## Steps for tuning floor detection (for jumping):
### 1) Have "OnDrawGizmos" function turned on (not commented out)
### 2) Adjusting floor detection by:
- increasing "groundLength" variable to just barely exceed character boundaries (at bottom, by .05 is about right), making the redline (gizmo) just barely sticking out the bottom
- Adjust the Offset (x) value in unity editor to match character rigidbody boundaries in X direction
### 3) Turn on "OnDrawGizmos" if desired (comment it out)
