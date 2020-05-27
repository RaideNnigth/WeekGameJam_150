using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CubePlacer : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject[] spikesPrefabs;
    public Image[] Itens;
    public Image Slote;
    public Text limitCounter;
    public int limitOne = 4;
    public int limitTwo = 4;
    public int limitThree = 2;
    public int limitFour = 2;
    public int prefabSelected = 0;
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
                if (hitInfo.collider.tag != "Traps" && hitInfo.collider.tag != "Spike" && hitInfo.collider.tag != "enemies") 
                {
                    if (prefabSelected == 0 && limitOne > 0)
                    {
                        limitOne -= 1;
                        limitCounter.text = limitOne.ToString();
                        PlaceCubeNear(hitInfo.point);
                    }

                    if (prefabSelected == 1 && limitTwo > 0)
                    {   
                        limitTwo -= 1;
                        limitCounter.text = limitTwo.ToString();
                        PlaceCubeNear(hitInfo.point);
                    }

                    if (prefabSelected == 2 && limitThree > 0)
                    {
                        limitThree -= 1;
                        limitCounter.text = limitThree.ToString();
                        PlaceCubeNear(hitInfo.point);
                    }
                    
                    if (prefabSelected == 3 && limitFour > 0)
                    {
                        limitFour -= 1;
                        limitCounter.text = limitFour.ToString();
                        PlaceCubeNear(hitInfo.point);
                    }

                    Cursor.visible = false;

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

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            prefabSelected = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            prefabSelected = 3;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (prefabSelected < prefab.Length)
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
                prefabSelected = 3;
            }
            else
            {
                prefabSelected -= 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.X))
            {
                if (prefabSelected == 0  && limitOne < 4) 
                {
                    Destroy(GameObject.FindWithTag("Spike"));
                    limitOne += 1;
                }

                if (prefabSelected == 1 && limitTwo < 4)
                {
                    Destroy(GameObject.Find("BearTrap(Clone)"));
                    limitTwo += 1;
                }
                if (prefabSelected == 2 && limitThree < 1)
                {
                    Destroy(GameObject.Find("Minion_1(Clone)"));
                    limitThree += 1;
                }
                if (prefabSelected == 3 && limitFour < 1)
                {
                    Destroy(GameObject.Find("Minion_2(Clone)"));
                    limitFour += 1;
                }

        }
        SpriteChooser();
    }

    private void PlaceCubeNear(Vector3 point)
    {
        
        if (prefabSelected == 0) // spikes(random)
        {
            int randSpike = Random.Range(0, 3);
            Vector3 finalPos = grid.GetNearestPointOnGrid(point);
            Instantiate(spikesPrefabs[randSpike], finalPos, Quaternion.identity);
            
        }
        else
        {
            Vector3 finalPos = grid.GetNearestPointOnGrid(point);
            Instantiate(prefab[prefabSelected - 1], finalPos, Quaternion.identity);
            
        }
    }

    private void SpriteChooser() 
    {
        if (prefabSelected == 0)
        {
            Itens[3].enabled = false;
            Itens[2].enabled = false;
            Itens[1].enabled = false;
            Itens[0].enabled = true;
            limitCounter.text = limitOne.ToString();
        }
        
        if (prefabSelected == 1)
        {
            Itens[3].enabled = false;
            Itens[2].enabled = false;
            Itens[1].enabled = true;
            Itens[0].enabled = false;
            limitCounter.text = limitTwo.ToString();
        }

        if (prefabSelected == 2)
        {
            Itens[3].enabled = false;
            Itens[2].enabled = true;
            Itens[1].enabled = false;
            Itens[0].enabled = false;
            limitCounter.text = limitThree.ToString();
        }
        if (prefabSelected == 3)
        {
            Itens[3].enabled = true;
            Itens[2].enabled = false;
            Itens[1].enabled = false;
            Itens[0].enabled = false;
            limitCounter.text = limitFour.ToString();
        }
    }

    public void Stop ()
    {
        
        Itens[3].enabled = false;
        Itens[2].enabled = false;
        Itens[1].enabled = false;
        Itens[0].enabled = false;
        Slote.enabled = false;
        limitCounter.enabled = false;
        Destroy(this);
        
    }
}
