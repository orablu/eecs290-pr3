using System.Collections;

using UnityEngine;

using UnityEditor;

 

class ShowVelocity : EditorWindow

{

    [MenuItem("Window/ShowVelocity")]

    static void Init()

    {

        // Get existing open window or if none, make a new one:

        ShowVelocity sizeWindow = new ShowVelocity();

        sizeWindow.autoRepaintOnSceneChange = true;

        sizeWindow.Show(); 

    }

 

    void OnGUI () {

      GameObject thisObject = Selection.activeObject as GameObject;

      if (thisObject == null) 

      { 

          return;

      }

      Vector3 velocity = thisObject.rigidbody.velocity;

      Vector3 scale = thisObject.transform.localScale;

      GUILayout.Label("Velocity\nX: " + velocity.x + "   Y: " + velocity.y + "   Z: " + velocity.z);

   } 

 

}