using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class ItemBehaviorTreat : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] Rigidbody RB;
    [SerializeField] private int PointsValue = 100;
    [SerializeField] private VisualPoints Points;
    [SerializeField] private BoxCollider ItemCollider;
    /// <summary>
    /// detects when you slash across the screen to knock over the water glass
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        print(GameManager.Instance._MatchManager.PawRight.GetComponent<Rigidbody>().position);
        RB.AddForce(GameManager.Instance._MatchManager.PawRight.GetComponent<Rigidbody>().velocity.normalized * 5000f); //tranform.up
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        Points.SummonPoints();
        GameManager.Instance._MatchManager.AddPoints(PointsValue);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
