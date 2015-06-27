//Author : Amina Khalique
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ObjectiveItem : MonoBehaviour 
{
    public Text ObjectiveText;
    public Image CrossOutImage;
    public Text DescriptionText;
    public Image DescriptionImage;
	void Start () 
    {
        CrossOutImage.canvasRenderer.SetAlpha(0.0f);
        DescriptionImage.canvasRenderer.SetAlpha(0.0f);
        DescriptionText.gameObject.SetActive(false);
	}
    public void ShowLine()
    {
        //Debug.Log(ObjectiveText.text + " ->ShowLine Being Called");
        CrossOutImage.canvasRenderer.SetAlpha(1.0f);
        //Debug.Log(CrossOutImage.canvasRenderer.GetAlpha());
    }
    public void SetObjectiveText(string Text)
    {
        ObjectiveText.text = Text;
    }
    public void SetObjectiveDescription(string Text)
    {
        DescriptionText.text = Text;
    }
    public void ShowDescription()
    {
        // Make sure none of them are showing first
        foreach(Transform Child in GameObject.Find("ObjectiveItemHolder").GetComponentInChildren<Transform>())
        {
            Child.gameObject.GetComponent<ObjectiveItem>().HideDescription();
        }
        DescriptionText.gameObject.SetActive(true);
        DescriptionImage.canvasRenderer.SetAlpha(1.0f);
    }
    public void HideDescription()
    {
        DescriptionText.gameObject.SetActive(false);
        DescriptionImage.canvasRenderer.SetAlpha(0.0f);
    }
}
