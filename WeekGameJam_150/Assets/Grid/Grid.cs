using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int size;
    public GameObject selectionPlane;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cursorHit;

        if (Physics.Raycast(ray, out cursorHit))
        {
            //Hide the cursor and show a selection of the grid
            Cursor.visible = false;
            selectionPlane.transform.position = GetNearestPointOnGrid(cursorHit.point);
            selectionPlane.SetActive(true);
        }
        else
        {
            Cursor.visible = true;
            selectionPlane.SetActive(false);
        }
    }

    public Vector3 GetNearestPointOnGrid(Vector3 pos)
    {
        pos -= transform.position;

        int xCount = Mathf.RoundToInt(pos.x / size);
        
        int zCount = Mathf.RoundToInt(pos.z / size);

        Vector3 result = new Vector3(xCount * size, 0, zCount * size);
        result += transform.position;
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int x = 0; x < 40; x += size)
        {
            for (int z = 0; z < 40; z += size)
            {
                Vector3 pos = GetNearestPointOnGrid(new Vector3(x, 0, z));
                Gizmos.DrawSphere(pos, 0.1f);
            }
        }
    }
}