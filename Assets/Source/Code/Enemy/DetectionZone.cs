using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private string tagTarget = "Player";
    [SerializeField] private Collider2D m_Collider2D;

    public List<Collider2D> detectionObjs = new List<Collider2D>(1);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(tagTarget))
        {
            detectionObjs.Add(collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        detectionObjs.Remove(collider);
    }
}
