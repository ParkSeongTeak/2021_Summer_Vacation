using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opacity : MonoBehaviour
{
    public float activetime = 0.8f;
    float timer = 0.0f;
    bool first = true;
    float firstTime;
    Image spr;
    Color color;



    void Start()
    {
        
        spr = this.gameObject.GetComponent<Image>();

        this.color = spr.color;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        this.timer += Time.deltaTime;

        if (timer > activetime)
        {
            if (spr.color.a <1) {
                this.color.a += 0.03f;
                spr.color = this.color;
                //Debug.Log("Up" + spr.color.a);
            }
            else 
            {
                if (first)
                {
                    first = false;
                    firstTime = timer;

                }
                else
                {
                    if(timer > firstTime + 0.4f)
                    {
                        if (this.color.a >= 0)
                        {
                            this.color.a -= 0.03f;
                            spr.color = this.color;
                            //Debug.Log("Up" + spr.color.a);
                        }
                    }
                }
            }
            if(timer > firstTime + 1f)
            {
                timer = 0f;
            }
            
        }
    }
}
