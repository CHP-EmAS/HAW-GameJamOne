using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

#if UNITY_EDITOR
     
using UnityEditor;
     
#endif

[CustomEditor(typeof(FOV))]
public class FOVEditor : Editor
{
#if UNITY_EDITOR
   private void OnSceneGUI()
   {
      FOV fov = (FOV)target;
      Handles.color = Color.yellow;
      Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.left,360, fov.viewRadius);
      Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
      Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);
      
      Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
      Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

      Handles.color = Color.red;
      foreach (Transform visibleTarget in fov.visibleTargets)
      {
         Handles.DrawLine(fov.transform.position, visibleTarget.position);
      }
   }
#endif
}
