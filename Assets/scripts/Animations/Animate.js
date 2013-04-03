var animationSpeed : float = 2;
var frameCounter = 0.0;
var frameOne : Texture2D;
var frameTwo : Texture2D;

var standingStill : Texture2D;
function Start () {

}

function Update () {
	switch(Mathf.FloorToInt(frameCounter)){
		case 0:
			renderer.material.mainTexture = frameOne;
		break;
		case 1: 
			renderer.material.mainTexture = frameTwo;
		break;
		case 2: 
			renderer.material.mainTexture = frameOne;
		break;
		
}

// If the the player is not moving than superguy stands still.
	
	
	

//when player presses right key, move superguy forward.
	
		
			frameCounter = frameCounter +Time.deltaTime * animationSpeed;
					

		
	if (frameCounter>4)
	frameCounter = 0;
			}
