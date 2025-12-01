using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CharacterImage
{
    public string name;
    public Sprite image;
}

[System.Serializable]
public class CharacterColour
{
    public string name;
    public Color colour;
}

public class CharacterCustomizationScript : MonoBehaviour
{
    // for testing if I can autoload sprites.
    private string eyeSpriteSheet = "Art/HappyCubeEyes";
    private string mouthSpriteSheet = "Art/HappyCubeMouths";
    public Sprite[] eyeSprites;
    public Sprite[] mouthSprites;

    //public List<CharacterImage> eyesList = new List<CharacterImage>();
    //public List<CharacterImage> mouthList = new List<CharacterImage>();
    public List<CharacterColour> colourList = new List<CharacterColour>();

    public TextMeshProUGUI eyesText, mouthText, colourText;

    public GameObject characterModel, characterEyes, characterMouth;

    private int curEyesIndex, curMouthIndex, curColourIndex;

    

    // Start is called before the first frame update
    void Start()
    {
        // for testing if I can auto load sprites
        eyeSprites = Resources.LoadAll<Sprite>(eyeSpriteSheet);
        mouthSprites = Resources.LoadAll<Sprite>(mouthSpriteSheet);

        curEyesIndex = PlayerPrefs.GetInt("EyesIndex");
        curMouthIndex = PlayerPrefs.GetInt("MouthIndex");
        curColourIndex = PlayerPrefs.GetInt("ColourIndex");

        // may need to replace with just index OR no name at all...
        eyesText.text = curEyesIndex.ToString();
        mouthText.text = curMouthIndex.ToString();
        colourText.text = colourList[curColourIndex].name;

        characterEyes.GetComponent<SpriteRenderer>().sprite = eyeSprites[curEyesIndex];
        characterMouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[curMouthIndex];
        characterModel.GetComponent<SpriteRenderer>().color = colourList[curColourIndex].colour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEyes(bool rightPressed)
    {
        Debug.Log("Eyes Button Pressed!");
        if (rightPressed)
        {
            curEyesIndex = (curEyesIndex + 1) % eyeSprites.Length;
        } else
        {
            curEyesIndex--;
            if (curEyesIndex < 0)
            {
                curEyesIndex = eyeSprites.Length-1;
            }
        }

        eyesText.text = curEyesIndex.ToString();
        characterEyes.GetComponent<SpriteRenderer>().sprite = eyeSprites[curEyesIndex];
        PlayerPrefs.SetInt("EyesIndex", curEyesIndex);
    }

    public void UpdateMouth(bool rightPressed)
    {
        Debug.Log("Mouth Button Pressed!");
        if (rightPressed)
        {
            curMouthIndex = (curMouthIndex + 1) % mouthSprites.Length;
        }
        else
        {
            curMouthIndex--;
            if (curMouthIndex < 0)
            {
                curMouthIndex = mouthSprites.Length - 1;
            }
        }

        mouthText.text = curMouthIndex.ToString();
        characterMouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[curMouthIndex];
        PlayerPrefs.SetInt("MouthIndex", curMouthIndex);
    }

    public void UpdateColour(bool rightPressed)
    {
        Debug.Log("Colour Button Pressed!");
        if (rightPressed)
        {
            curColourIndex = (curColourIndex + 1) % colourList.Count;
        }
        else
        {
            curColourIndex--;
            if (curColourIndex < 0)
            {
                curColourIndex = colourList.Count - 1;
            }
        }

        colourText.text = colourList[curColourIndex].name;
        characterModel.GetComponent<SpriteRenderer>().color = colourList[curColourIndex].colour;
        PlayerPrefs.SetInt("ColourIndex", curColourIndex);
    }
}

