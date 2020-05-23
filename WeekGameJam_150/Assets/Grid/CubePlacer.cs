using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public GameObject prefab;
    Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);

                //Hide the cursor and show a selection of the grid
                Cursor.visible = false;

                //To show a square
            }
        }

        RaycastHit cursorHit;
        if(Physics.Raycast(ray,out cursorHit))
        {
            Cursor.visible = false;
        }
    }

    private void PlaceCubeNear(Vector3 point)
    {
        Vector3 finalPos = grid.GetNearestPointOnGrid(point);
        Instantiate(prefab, finalPos, Quaternion.identity);
    }
}
