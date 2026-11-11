using UnityEngine;
using UnityEngine.UI;

public class ShowClickedBG : MonoBehaviour
{
    public Image ImageDisplayGameObject;

    public Sprite ImageToActive;

    private Sprite previousSprite;

    public void ShowImage()
    {
        if (ImageDisplayGameObject != null)
        {
            previousSprite = ImageDisplayGameObject.sprite;
            ImageDisplayGameObject.sprite = ImageToActive;
        }
        
    }

    public void HideImage()
    {
        if (ImageDisplayGameObject != null && previousSprite != null)
        {
            ImageDisplayGameObject.sprite = previousSprite;
        }
    }
}
