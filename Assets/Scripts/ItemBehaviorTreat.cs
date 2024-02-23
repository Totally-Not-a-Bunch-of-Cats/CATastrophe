using UnityEngine.EventSystems;
using UnityEngine;

public class ItemBehaviorTreat : MonoBehaviour, IPointerClickHandler //IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int clicks = 0;
    [SerializeField] private GameObject VisualEffect;
    /// <summary>
    /// Looks for two clicks on the item then triggers the bite function
    /// </summary>
    private void Update()
    {
        if (clicks >= 2)
        {
            Bite();
        }
    }
    /// <summary>
    /// Destroys the game object since the player did it
    /// </summary>
    void Bite()
    {
        Debug.Log("We biting");
        clicks = 0;
        Destroy(gameObject);
    }
    /// <summary>
    /// looks for mouse/finger click adds a click to the count
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //looks like it only work when you click and let go imediatly 
        clicks += 1;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}
}
