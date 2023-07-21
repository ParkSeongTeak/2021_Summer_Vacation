using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetNeighbor : MonoBehaviour
{


    List<GameObject> gameObjects = new List<GameObject>();
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Obj") {
            bool haveObj = false;
            for (int i = 0; i < this.gameObjects.Count; i++)
            {
                if (this.gameObjects[i].name == collision.gameObject.name) {
                    haveObj = true;
                }
            }
            if (!haveObj)
            {
                this.gameObjects.Add(collision.gameObject);
            }
        }
    }

    public List<GameObject> neighborObj()
    {

        
        return this.gameObjects;
    }
}
