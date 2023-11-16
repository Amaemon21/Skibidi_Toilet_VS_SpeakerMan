using System.Collections;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int timer = 5;

    void Start()
    {
        StartCoroutine(TutorilaWasd());
    }

    IEnumerator TutorilaWasd()
    {
        animator.SetBool("isActive" , true);

        yield return new WaitForSeconds(timer);

        animator.SetBool("isActive", false);
    }
}