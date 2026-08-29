using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourGradient : MonoBehaviour
{
    public SpriteRenderer target;
    public Color startingColour, targetColour;
    public float startingPosY, endingPosY;
    public GameObject heightMeasurer;

    private float currentHeight, totalHeight, colourDifferenceR, colourDifferenceG, colourDifferenceB;
    private Color currentColour;
    // Start is called before the first frame update
    void Start()
    {
        totalHeight = endingPosY - startingPosY;
        currentColour = new Color(0f, 0f, 0f, 255f);

        //Debug.Log("total height to cover: " + totalHeight);
    }

    // Update is called once per frame
    void Update()
    {
        currentHeight = heightMeasurer.transform.position.y;

        float currentProgressPercent = (currentHeight-startingPosY) / (endingPosY-startingPosY);

        colourDifferenceR = targetColour.r - startingColour.r;
        colourDifferenceG = targetColour.g - startingColour.g;
        colourDifferenceB = targetColour.b - startingColour.b;

        currentColour.r = colourDifferenceR * currentProgressPercent + startingColour.r;
        currentColour.g = colourDifferenceG * currentProgressPercent + startingColour.g;
        currentColour.b = colourDifferenceB * currentProgressPercent + startingColour.b;

        target.color = currentColour;

        if (Input.GetKeyDown(KeyCode.P))
        {
            //Debug.Log("Starting Colour: " + startingColour);
            //Debug.Log("Target Colour: " + targetColour);
            //Debug.Log("current height: " + currentHeight);
            //Debug.Log("current progress percent: " + currentProgressPercent);
            Debug.Log("difference R: " + colourDifferenceR);
            Debug.Log("difference G: " + colourDifferenceG);
            Debug.Log("difference B: " + colourDifferenceB);
            Debug.Log("current colour: " + currentColour);
        }
        // if we start at 50 and need to get to 200 -> 50% of the way there should be 75
    }
}
