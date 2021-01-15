using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public Text headerText;
    public Text contentText;
    public LayoutElement layoutElement;
    public RectTransform rectTransform;
    public int maxCharacters;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = "")
    {
        //if it doesn't have a title, hide it
        if(string.IsNullOrEmpty(header))
        {
            headerText.gameObject.SetActive(false);
        }
        else
        {
            headerText.gameObject.SetActive(true);
            headerText.text = header;
        }

        contentText.text = content;

        //formatting
        int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;

        layoutElement.enabled = (headerLength > maxCharacters || contentLength > maxCharacters) ? true : false;
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        float pivotX = mousePos.x / Screen.width;
        float pivotY = mousePos.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = mousePos;
    }
}
