using UnityEngine;

public class weaponPad : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform weaponSP;

    [SerializeField]
    private float spawnCD, timerCD;

    [SerializeField]
    private bool spawnAtStart, onSpawnPoint;

    private void Awake()
    {
        if (spawnAtStart)
        {
            onSpawnPoint = true;
            spawnWeapon();
        }
        if (!spawnAtStart)
        {
            timerCD = spawnCD;
            onSpawnPoint = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Weapon"))
        {
            timerCD = spawnCD;
            onSpawnPoint = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Weapon"))
        {
            onSpawnPoint = true;
        }
    }

    private void Update()
    {
        if (!onSpawnPoint)
        {
            timerCD -= Time.deltaTime;
            if (timerCD <= 0)
            {
                onSpawnPoint = true;
                spawnWeapon();
            }
        }
    }

    void spawnWeapon()
    {
        Instantiate(weapon, weaponSP.position, Quaternion.identity);
    }
}