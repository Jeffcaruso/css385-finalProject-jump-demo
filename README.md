# css385-finalProject-jump-demo
### A prototpe of player movement (with jumping and spring shoes options) to eventualy be integrated in final project.

### NOTE: Instructions below not fully updated yet (as of 4-28). Still a good starting place, but a few more nuances, see code comments, will close rest of gap.

### Link to [Play a WebGL Build of this Demo](https://jeffcaruso.github.io/css385-finalProject-jump-demo/)


## Key variables to influence jumping characteristics
### vertical movement
- **jumpForce** - normal jump force
- **runningJumpForce** - how much extra power you get for a running jump (may end up wanting to reduce this...)
- **jumpDelay** - Giving the player a 'fudge' factor, where they can press the key early

### Misc
- **linearDrag** - slowing you down
- **gravity** -  higher means more gravity
- **fallMultiplier** - impacting gravity (for falling faster), another aspect of manipulating gravity in a limited capacity. Useful so you can quickly fall after a longer distance jump covering the distance the player wants out of it.


## Steps for tuning floor detection (for jumping) Needs to be re-done when Hero sprite is changed:
### 1) Have "OnDrawGizmos" function turned on (not commented out)
### 2) Adjusting floor detection by:
- increasing "groundLength" variable to just barely exceed character boundaries (at bottom, by .02 is about right), making the redline (gizmo) just barely sticking out the bottom
- Adjust the Offset (x) value in unity editor to match character rigidbody boundaries in X direction
### 3) Turn on "OnDrawGizmos" if desired (comment it out)


### Final Note to Notice when configuring Hero:
- Make sure Hero Box Collider 2D has a slightly reduce collider size, with a slight (like .05 Edge Radius), such that for the edges the collider is perfectly aligned with hero dimensions. Note that the corners will not have the hitbox there, which when these are maintained as small fixes the issue of the box being supported by the ledge it is on even though it is not touching it!
