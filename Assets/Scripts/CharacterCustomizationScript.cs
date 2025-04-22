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
    public List<CharacterImage> eyesList = new List<CharacterImage>();
    public List<CharacterImage> mouthList = new List<CharacterImage>();
    public List<CharacterColour> colourList = new List<CharacterColour>();

    public TextMeshProUGUI eyesText, mouthText, colourText;

    public GameObject characterModel, characterEyes, characterMouth;

    private int curEyesIndex, curMouthIndex, curColourIndex;

    

    // Start is called before the first frame update
    void Start()
    {
        curEyesIndex = PlayerPrefs.GetInt("EyesIndex");
        curMouthIndex = PlayerPrefs.GetInt("MouthIndex");
        curColourIndex = PlayerPrefs.GetInt("ColourIndex");

        eyesText.text = eyesList[curEyesIndex].name;
        mouthText.text = mouthList[curMouthIndex].name;
        colourText.text = colourList[curColourIndex].name;

        characterEyes.GetComponent<SpriteRenderer>().sprite = eyesList[curEyesIndex].image;
        characterMouth.GetComponent<SpriteRenderer>().sprite = mouthList[curMouthIndex].image;
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
            curEyesIndex = (curEyesIndex + 1) % eyesList.Count;
        } else
        {
            curEyesIndex--;
            if (curEyesIndex < 0)
            {
                curEyesIndex = eyesList.Count-1;
            }
        }

        eyesText.text = eyesList[curEyesIndex].name;
        characterEyes.GetComponent<SpriteRenderer>().sprite = eyesList[curEyesIndex].image;
        PlayerPrefs.SetInt("EyesIndex", curEyesIndex);
    }

    public void UpdateMouth(bool rightPressed)
    {
        Debug.Log("Mouth Button Pressed!");
        if (rightPressed)
        {
            curMouthIndex = (curMouthIndex + 1) % mouthList.Count;
        }
        else
        {
            curMouthIndex--;
            if (curMouthIndex < 0)
            {
                curMouthIndex = mouthList.Count - 1;
            }
        }

        mouthText.text = mouthList[curMouthIndex].name;
        characterMouth.GetComponent<SpriteRenderer>().sprite = mouthList[curMouthIndex].image;
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

