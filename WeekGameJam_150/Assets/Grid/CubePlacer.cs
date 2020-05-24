using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePlacer : MonoBehaviour
{
    public GameObject[] prefab;
    public Image[] Itens;
    int prefabSelected = 0;
    Grid grid;
    

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                

                if (hitInfo.collider.tag != "Traps") 
                {

                    PlaceCubeNear(hitInfo.point);

                    //Hide the cursor and show a selection of the grid
                    Cursor.visible = false;

                    //To show a square

                }
                
            }
        }

        RaycastHit cursorHit;
        if(Physics.Raycast(ray,out cursorHit))
        {
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            prefabSelected = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            prefabSelected = 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (prefabSelected < prefab.Length - 1)
            {
                prefabSelected += 1;
            }
            else 
            {
                prefabSelected = 0;
            }
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            if (prefabSelected == 0)
            {
                prefabSelected = 1;
            }
            else
            {
                prefabSelected -= 1;
            }

        }

        SpriteChooser();
    }

    private void PlaceCubeNear(Vector3 point)
    {
        Vector3 finalPos = grid.GetNearestPointOnGrid(point);
        Instantiate(prefab[prefabSelected], finalPos, Quaternion.identity);
    }

    private void SpriteChooser() 
    {
        if (prefabSelected == 0)
        {
            Itens[1].enabled = false;
            Itens[0].enabled = true;
        }
        
        if (prefabSelected == 1)
        {
            Itens[0].enabled = false;
            Itens[1].enabled = true;
        }
    }
}
