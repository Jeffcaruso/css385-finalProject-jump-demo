# css385-finalProject-jump-demo

## Steps for tuning Jumping + floor detection:
### 1) Have "OnDrawGizmos" function turned on (not commented out)
### 2) Adjusting floor detection by:
- increasing "groundLength" variable to just barely exceed character boundaries, making the redline (gizmo) just barely sticking out the bottom
- Adjust the Offset (x) value in unity editor to match character rigidbody boundaries in X direction
### 3) Turn on "OnDrawGizmos" if desired (comment it out)
