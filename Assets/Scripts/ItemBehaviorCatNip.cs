using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class ItemBehaviorCatNip : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] bool ActivilyDestroying = false;
    [SerializeField] private int PointsValue = 100;
    [SerializeField] private VisualPoints Points;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!ActivilyDestroying)
        {
            ActivilyDestroying = true;
            Destroying();
        }
    }

    public void Destroying()
    {
        Points.SummonPoints();
        GameManager.Instance._MatchManager.AddPoints(PointsValue);
        Destroy(gameObject);
    }
}
