using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathDrawer))]

public class PathEditor : Editor
{
   PathDrawer creator;
   Path path => creator.path;

    private void OnEnable() {
        creator = (PathDrawer)target;

        if (creator == null )
        {
            creator.CreatePath();
        } 

    
   }

   private void OnSceneGUI() {

    HandleInput();
    DrawPoints();
    
   }
   private void HandleInput()
   {
    Event guiEvent = Event.current;
    Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

    if(guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
    {
        Undo.RecordObject(creator, "Add Segment");
        path.AddSegment(mousePos);

    }
   }
private void DrawPoints()
{
    creator.DrawPath(path.points);

    Handles.color = Color.red;
    for (int i = 0; i < path.NumPoints; i++)
    {

         var fmh_49_59_638700438632701770 = Quaternion.identity; Vector2 newPos = Handles.FreeMoveHandle(path[i], 0.05f, Vector2.zero, Handles.CylinderHandleCap);
        

        if (path[i] != newPos)
        {
            Undo.RecordObject(creator, "Move Point");
            path.MovePoint(i, newPos);
        }
    }
}



}
