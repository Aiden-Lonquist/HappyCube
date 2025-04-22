using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizationScript : MonoBehaviour
{
    public SpriteRenderer colour, eyes, mouth;

    public List<CharacterImage> eyesList = new List<CharacterImage>();
    public List<CharacterImage> mouthList = new List<CharacterImage>();
    public List<CharacterColour> colourList = new List<CharacterColour>();

    // Start is called before the first frame update
    void Start()
    {
        colour.color = colourList[PlayerPrefs.GetInt("ColourIndex")].colour;
        eyes.sprite = eyesList[PlayerPrefs.GetInt("EyesIndex")].image;
        mouth.sprite = mouthList[PlayerPrefs.GetInt("MouthIndex")].image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
