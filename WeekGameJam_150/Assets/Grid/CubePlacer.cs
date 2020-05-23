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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 point)
    {
        Vector3 finalPos = grid.GetNearestPointOnGrid(point);
        Instantiate(prefab, finalPos, Quaternion.identity);
    }
}
