using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{
    List<GameObject> gameObjects = new List<GameObject>();
    private void OnCollisionEnter(Collision collision)
    {
        bool haveObj = false;
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].name == collision.gameObject.name) {
                haveObj = true;
            }
        }
        if (!haveObj)
        {
            gameObjects.Add(collision.gameObject);
        }

        Debug.Log("Test      " + collision.gameObject.name);
    }

    public List<GameObject> neighborObj()
    {

        for(int i = 0; i < gameObjects.Count; i++)
        {
            Debug.Log("In Test neighor  "+ gameObjects.GetType().Name);
        }

        return gameObjects;
    }
}
