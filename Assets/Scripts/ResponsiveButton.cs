using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class ResponsiveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float defaultSize, maxSize, scaleSpeed;
    public bool mouseOver;
    public RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver && rt.localScale.x < maxSize)
        {

            rt.localScale += (new Vector3(1, 1, 0) * scaleSpeed * Time.deltaTime);
        } else if (!mouseOver && rt.localScale.x > defaultSize)
        {
            rt.localScale -= (new Vector3(1, 1, 0) * scaleSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}
