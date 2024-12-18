using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    public Path path;
    private LineRenderer myLineRenderer;

   public void CreatePath()
{
    path = new Path(transform.position);
    myLineRenderer = this.GetComponent<LineRenderer>();
    if (myLineRenderer == null)
    {
        myLineRenderer = this.gameObject.AddComponent<LineRenderer>();
    }
    myLineRenderer.widthMultiplier = 0.2f;
}


    public void DrawPath(List<Vector2> points)
    {
        int count = points.Count;
        this.GetComponent<LineRenderer>().positionCount = count;
        for(int i = 0 ; i < points.Count; i++)
        {
            this.GetComponent<LineRenderer>().SetPosition(i,points[i]);
        }
    }

    
}
