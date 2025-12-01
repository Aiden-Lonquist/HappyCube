using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizationScript : MonoBehaviour
{
    public SpriteRenderer colour, eyes, mouth;

    private string eyeSpriteSheet = "Art/HappyCubeEyes";
    private string mouthSpriteSheet = "Art/HappyCubeMouths";
    private Sprite[] eyeSprites;
    private Sprite[] mouthSprites;

    //public List<CharacterImage> eyesList = new List<CharacterImage>();
    //public List<CharacterImage> mouthList = new List<CharacterImage>();
    public List<CharacterColour> colourList = new List<CharacterColour>();

    // Start is called before the first frame update
    void Start()
    {
        eyeSprites = Resources.LoadAll<Sprite>(eyeSpriteSheet);
        mouthSprites = Resources.LoadAll<Sprite>(mouthSpriteSheet);

        colour.color = colourList[PlayerPrefs.GetInt("ColourIndex")].colour;
        eyes.sprite = eyeSprites[PlayerPrefs.GetInt("EyesIndex")];
        mouth.sprite = mouthSprites[PlayerPrefs.GetInt("MouthIndex")];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
