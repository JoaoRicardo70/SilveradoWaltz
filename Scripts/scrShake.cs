using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class scrShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource camShake;


   public IEnumerator CameraShake(float duration, float magnitude)
   {
    Debug.Log("shake");
        Vector3 originalPos= transform.localPosition;

        float elapse = 0.0f;

        while (elapse < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x,y, originalPos.z);

            elapse+= Time.deltaTime;

            yield return null;

        }   

        transform.localPosition=originalPos;     
   }

   public void Teste()
    {
    Debug.Log("O problema é com IEnumerator"); //por usar invoke no metodo atirar IEnumerator nao vai, n sei pq
    }

    public void sourceImpulse(Vector3 power)
    {
        camShake.GenerateImpulse(power);
    }
}
