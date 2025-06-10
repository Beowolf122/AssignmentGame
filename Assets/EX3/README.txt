For tasks labeled EX they will be done in the EX3 Scene
For tasks labeled HW they will be done in the HW3 Scene

-----------------------------------------------------------------------------------------------------------------------------
EX 3.0: Health Regen: 
- Create a new Script called “HealthRegen”
- Declare 2 public variables called “currentHealth” and “healthRegen” (both float values)
- Every frame this script should:
- Increase currentHealth by healthRegen amount
- Print out the value of currentHealth, using Debug.Log()

-----------------------------------------------------------------------------------------------------------------------------
EX 3.1: Rotate & Scale-X:
Rotate a GameObject:
- Create a new script called “RotateInput”
- Declare a public float variable called “rotationSpeed”
- This script should slowly rotate the GameObject it is given to based on the rotationSpeed variable
	- You should also be able to set rotationSpeed to a negative value and have it rotate in the opposite direction
Scale up a GameObject:
- Create another new script called “ScaleInput”
- Declare a public float variable called “scaleSpeed”
- This script should slowly scale up the x variable of the GameObject based on the scaleSpeed variable
	- You should also be able to set scaleSpeed to a negative value and have it shrink the x variable

-----------------------------------------------------------------------------------------------------------------------------
EX 3.2: Controlling Scaling and Rotation
Allow us to control which direction of rotation and scaling:
- In our previous scripts called “RotateInput” & “ScaleInput”
- Declare a public boolean variable called “reverseDirection” with the default value equal to false
- Using if statements and the reverseDirection variable do the following:
	- For “RotateInput” script:
		- “if reverseDirection is true, then rotate the GameObject counter-clockwise, else rotate it clockwise”
	- For “ScaleInput” script:
		- “if reverseDirection is true, then shrink the x scale of the GameObject, else increase the x scale of the GameObject”

-----------------------------------------------------------------------------------------------------------------------------
EX 3.3: Health Clamp
Limiting regeneration to max health value:
- In our previous script called “Health”
- Declare a public float variable called “maxHealth” 
- Using comparators limit currentHealth to never go above maxHealth when regenerating
Limiting poison damage:
- In the same script “Health”
- Declare a public float variable called “poisonDamage”
- Decrease the currentHealth by poisonDamage every frame and make this value larger than the healthRegen value
- Same as the previous task, using comparators limit currentHealth to never go below 0 when taking poison damage

-----------------------------------------------------------------------------------------------------------------------------
HW 3: “Mini-Game Controller”
Taking the “RotationInput” and “ScaleInput” scripts we made during this lesson add it to the blue block in the center of this game and give it the following controls
- These are the controls:
	- A or Left Arrow: rotates the block counter-clockwise
	- D or Right Arrow: rotates the block clockwise
	- W or Up Arrow: increases the x scale
	- S or Down Arrow: decreases the x scale
- Also clamp the x-scale of the block so it can’t go below 0