using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFallenCheker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCar>(out EnemyCar enemyCar))
        {
            enemyCar.gameObject.SetActive(false);
        }
    }
}
