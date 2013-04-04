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
    frameCounter = frameCounter +Time.deltaTime * animationSpeed;
	if (frameCounter>4)
        frameCounter = 0;
}
