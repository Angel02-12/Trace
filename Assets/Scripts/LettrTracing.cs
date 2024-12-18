using UnityEngine;
using System.Collections.Generic;


public class LetterTracing : MonoBehaviour
{
    public LineRenderer lineRenderer; // For drawing the letter
    public GameObject tracer; // The object the user moves
    public float tolerance = 0.1f; // Distance tolerance for tracing
    public List<Vector2> letterPath; // List of points defining the letter
    private int currentPointIndex = 0;

    private void Start()
    {
        InitializeLetterPath();
        DrawLetterPath();
    }

    void InitializeLetterPath()
    {
        // Define points for a sample letter "A" (as Vector2)
        letterPath = new List<Vector2>
        {
            new Vector2(-1, 0),
            new Vector2(0, 2),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-0.5f, 1),
            new Vector2(0.5f, 1)
        };
    }

    void DrawLetterPath()
    {
        // Set up the LineRenderer to visualize the letter
        lineRenderer.positionCount = letterPath.Count;
        for (int i = 0; i < letterPath.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(letterPath[i].x, letterPath[i].y, 0));
        }
    }

    private void Update()
    {
        HandleTracingInput();
    }

    void HandleTracingInput()
    {
        if (currentPointIndex >= letterPath.Count) return;

        // Get mouse/touch position in world coordinates
        Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the input is near the current point
        if (Vector2.Distance(inputPos, letterPath[currentPointIndex]) < tolerance)
        {
            tracer.transform.position = letterPath[currentPointIndex];
            currentPointIndex++;

            if (currentPointIndex >= letterPath.Count)
            {
                Debug.Log("Tracing Complete!");
            }
        }
    }
}
