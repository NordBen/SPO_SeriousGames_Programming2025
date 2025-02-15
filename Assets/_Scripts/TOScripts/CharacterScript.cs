using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float distance = 0f;
    public float vectorAB = 0f;

    public bool IsPlayer = false;

    public Transform targetObject;
    public Transform thisObject;

    Vector3 a;
    Vector3 b;

    private void OnDrawGizmos()
    {
        if (a != thisObject.transform.position)
        {
            a = thisObject.transform.position;
        }
        if (b != targetObject.transform.position)
        {
            b = targetObject.transform.position;
        }

        if (IsPlayer)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, Vector3.zero);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.forward, Vector3.forward + new Vector3(0f, 0f, 10f));

            Vector3 forwardVec = this.transform.TransformDirection(Vector3.forward);
            Vector3 NormVectorAB = Vector3.Normalize(b - a);

            if (Vector3.Dot(forwardVec, NormVectorAB) > 0)
            {
                Debug.Log("Enemy is infront of player");
            }
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, Vector3.zero);
        }
        distance = Vector3.Distance(a, b);
        vectorAB = (a - b).magnitude;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(a, b);

     //   Debug.Log(this.name + "Distance from a to b: " + distance);

        if (vectorAB == distance)
        {
        //    Debug.Log("VectorAB and distance are equal");
        }    

        //LineRaycastCheck();

        
    }

    public void LineRaycastCheck()
    {
        
        RaycastHit hit;

        if (Physics.Raycast(a, this.transform.forward, out hit, 100))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy is infront");
            }
        }
    }
}