using System.Collections;
using UnityEngine;

public class InOut : MonoBehaviour
{
    [Header("direction")]
    public Vector3 direction = Vector3.right;

    [Header("move time")]
    public float popDistance = 4f;    
    public float popOutSpeed = 8f;    
    public float retractSpeed = 2f;   

    [Header("wait time")]
    public float waitAfterPop = 1.5f;    
    public float waitAfterRetract = 2f;  

    private Vector3 startPos;
    private Vector3 outPos;

    void Start()
    {
        startPos = transform.position;
        outPos = startPos + direction.normalized * popDistance;

        StartCoroutine(PopLoop());
    }

    IEnumerator PopLoop()
    {
        while (true)
        {
            yield return StartCoroutine(MoveTo(outPos, popOutSpeed));

            yield return new WaitForSeconds(waitAfterPop);

            yield return StartCoroutine(MoveTo(startPos, retractSpeed));

            yield return new WaitForSeconds(waitAfterRetract);
        }
    }

    IEnumerator MoveTo(Vector3 target, float speed)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = target;
    }
}