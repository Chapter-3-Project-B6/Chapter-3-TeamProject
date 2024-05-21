using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_Type
{
    IT_Power,
    IT_Boom,
    IT_Heart
}

public class Item : MonoBehaviour
{
    [SerializeField]
    private Item_Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            switch (type)
            {
                case Item_Type.IT_Heart:
                    if (collision.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
                        healthSystem.ChangeHealth(3);
                        break;
            }
        }
    }
}
