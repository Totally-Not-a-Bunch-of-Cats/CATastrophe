using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class ItemBehaviorTreat : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] Rigidbody RB;
    [SerializeField] private int PointsValue = 100;
    [SerializeField] private float PointsMultiplier = 1;
    [SerializeField] private float BaseForce = 2000f; 
    [SerializeField] private float VelocityModifier = 1;
    [SerializeField] private VisualPoints Points;
    [SerializeField] private BoxCollider ItemCollider;
    /// <summary>
    /// detects when you slash across the screen to knock over the water glass
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        RB.AddForce(-GameManager.Instance._MatchManager.PawRight.GetComponent<PawVelocity>().Velocity.normalized * (BaseForce * VelocityModifier));
        VelocityModifier += 1;
        PointsMultiplier += .1f;
        Points.Pointss = (int)(PointsValue * PointsMultiplier);
        Points.SummonPoints();
        GameManager.Instance._MatchManager.AddPoints((int)(PointsValue * PointsMultiplier));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}