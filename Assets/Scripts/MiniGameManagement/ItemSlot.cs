using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    
    public Image IceCream1;
    public Image IceCream2;
    public Image IceCream3;
    public Image IceCream4;
    public Image IceCream;

    private string answer;

    private void Awake()
    {
        IceCream = GameObject.Find("AnswerImage").GetComponent<Image>();
        int rnd = Random.Range(1, 5);
        Debug.Log(rnd);
        switch (rnd)
        {
            case 1:
                IceCream.sprite = IceCream1.sprite;
                answer = "IceCream1";
                break;
            case 2:
                IceCream.sprite = IceCream2.sprite;
                answer = "IceCream2";
                break;
            case 3:
                IceCream.sprite = IceCream3.sprite;
                answer = "IceCream3";
                break;
            case 4:
                IceCream.sprite = IceCream4.sprite;
                answer = "IceCream4";
                break;
            default:
                break;
        }
    }
    

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.name.Contains(answer))
            {
                GameObject.Find("AnswerImage").name = "ImageDone";
                GameObject.Find("GamePlay").GetComponent<GameplayHandler>().GetScore();
                this.gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }
}
