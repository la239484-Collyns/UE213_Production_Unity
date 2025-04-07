using PathCreation.Examples;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathFollower))]
public class PathFollowerEditor : Editor
{
   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PathFollower myScript = (PathFollower)target;
    }
}
