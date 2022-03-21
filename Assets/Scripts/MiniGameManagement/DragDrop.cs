using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour , IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public GameObject iceCreamPrefab;

    private ItemSlot itemSlot;

    private GameObject gameIn;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gameIn = GameObject.Find("CustomerBox");
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        spawnIceCream();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (!GameObject.Find("GamePlay").GetComponent<GameplayHandler>().timerIsRunning)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        /*if (this.transform.position.x >= (gameIn.transform.position.x - 21) && this.transform.position.x <= (gameIn.transform.position.x + 21) && this.transform.position.y >= (gameIn.transform.position.y - 27) && this.transform.position.y <= (gameIn.transform.position.y + 27))
        {
            Debug.Log("a");
        }*/

        this.gameObject.SetActive(false);
        Destroy(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void spawnIceCream()
    {
        GameObject newIce = Instantiate(iceCreamPrefab, this.transform.position,  this.transform.rotation) as GameObject;
        newIce.transform.SetParent(GameObject.Find("IceCreamCanvas").transform, false);
        newIce.transform.position = this.transform.position;

    }
    
}
