using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class ItemBehaviorCatNip : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler//, IPointerClickHandler
{
    [SerializeField] bool Clawing = false;
    [SerializeField] bool Clawed = false;
    [SerializeField] bool Smelled = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Clawing = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(Clawing)
        {
            Clawed = true;
            Debug.Log("claswed");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("sniffing");
        StartCoroutine(Sniffed());
        if(Smelled && Clawed)
        {
            Destroy(gameObject);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("-sniffing");
        Smelled = false;
    }

    IEnumerator Sniffed()
    {
        yield return new WaitForSeconds(.75f);
        Smelled = true;
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //looks like it only work when you click imediatly 
    //    Debug.Log("Click Cat Nip");
    //}
}
