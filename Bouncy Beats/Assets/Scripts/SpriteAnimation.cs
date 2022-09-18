using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform myTrans;
    SpriteRenderer sr;
    public Sprite NegSprite;
    public Sprite Fisting;
    public Sprite Starfish;
    bool Decider = true;
    bool restart = true;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    //if the y is positive then do one the two poses that's not the ball and if the y is negative then make him curl into a ball
    // Update is called once per frame
    void Update()
    {
        if (myTrans.position.y > 0)
        {
            if (restart == true)
            {

                if (Decider == true)
                {
                    sr.sprite = Fisting;
                    Decider = false;
                }
                else{
                    sr.sprite = Starfish;
                    Decider = true;
                }
                restart = false;
            }
        }
        else
        {
            restart = true;
            sr.sprite = NegSprite;
        }
    }
}
