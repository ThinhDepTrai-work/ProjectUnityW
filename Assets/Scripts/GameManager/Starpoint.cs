
using UnityEngine;

public class Starpoint : MonoBehaviour
{
    private void Awake()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position = this.transform.position;
    }

}
