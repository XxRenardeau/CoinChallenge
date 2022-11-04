using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPltCtrl : MonoBehaviour
{
    public bool IsLooping;
    public int NmbrLoop; //0 is error
    public float Endpointx;
    public float Endpointz;
    public float Endpointy;
    bool collided = false;
    void FixedUpdate()
    {
        MovingPlatform();
    }
    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        Debug.Log("collision nuage avec" + col.gameObject.name);
        collided = true;
    }
    void MovingPlatform()
    {
        if (collided)
        {
            Debug.Log("test");
            if (IsLooping)
            {
                if (NmbrLoop > 0)
                {
                    for (int i = NmbrLoop; i > 0; i--)
                    {
                        transform.Translate(Endpointx, Endpointy, Endpointz);
                        transform.Translate(-Endpointx, -Endpointy, -Endpointz);

                    }

                }
                else Debug.Log("veulliez mettre un nombre de boucle");

            }
            else transform.Translate(Endpointx, Endpointy, Endpointz);
            // marche pas ? je sais pas pk


        }
    }


}
