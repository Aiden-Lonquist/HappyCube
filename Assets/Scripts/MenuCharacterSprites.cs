using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacterSprites : MonoBehaviour
{
    private string eyeSpriteSheet = "Art/HappyCubeEyes";
    private string mouthSpriteSheet = "Art/HappyCubeMouths";
    private string colourSpriteSheet = "Art/HappyCubeColours";
    public Sprite[] eyeSprites;
    public Sprite[] mouthSprites;
    public Sprite[] colourSprites;

    public GameObject characterModel, characterEyes, characterMouth;

    private int curEyesIndex, curMouthIndex, curColourIndex;

    // Start is called before the first frame update
    void Start()
    {
        eyeSprites = Resources.LoadAll<Sprite>(eyeSpriteSheet);
        mouthSprites = Resources.LoadAll<Sprite>(mouthSpriteSheet);
        colourSprites = Resources.LoadAll<Sprite>(colourSpriteSheet);

        curEyesIndex = PlayerPrefs.GetInt("EyesIndex");
        curMouthIndex = PlayerPrefs.GetInt("MouthIndex");
        curColourIndex = PlayerPrefs.GetInt("ColourIndex");

        characterEyes.GetComponent<SpriteRenderer>().sprite = eyeSprites[curEyesIndex];
        characterMouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[curMouthIndex];
        characterModel.GetComponent<SpriteRenderer>().sprite = colourSprites[curColourIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
