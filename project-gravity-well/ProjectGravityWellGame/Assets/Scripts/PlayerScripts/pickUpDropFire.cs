using UnityEngine;
using UnityEngine.InputSystem;

//Find way to give weapon horizontal velocity when dropping.

public class pickUpDropFire : MonoBehaviour
{
    // For input system
    private InputActionAsset playerControls;
    private InputActionMap player;

    // Bools that determine weapon states
    [SerializeField]
    private bool inRange = false;
    [SerializeField]
    public bool weaponSlotFull = false;

    // Reference to gunHolder on player prefab
    [SerializeField]
    private Transform gunHolder;

    // References to weapon prefab & components
    [SerializeField]
    private GameObject inHandItem;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Collider2D coll;

    // Scripts attached to the gun
    [SerializeField]
    private fireProjectileGun gunScript;
    [SerializeField]
    private weaponDespawn despawnScript;

    [SerializeField]
    private int numInRange = 0;

    GameManager gameManager;

    [SerializeField] private AudioSource DeadSound;

    // when the player gets enabled give them access to interact and fire controls
    private void OnEnable()
    {
        player.FindAction("Interact").started += Interact;
        player.FindAction("Fire").started += Fire;
        player.Enable();
    }

    // when OnDisable is called disable the player
    private void OnDisable()
    {
        player.Disable();
    }

    // On Awake 
    void Awake()
    {
        playerControls = this.GetComponent<PlayerInput>().actions;
        player = playerControls.FindActionMap("Player");
    }

    // If player dies drops held weapon if has one
    // Called in PlayerHealth.cs
    public void dropDead()
    {
        DeadSound.Play();
        if (weaponSlotFull)
        {
            weaponSlotFull = false;
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            coll.enabled = true;
            despawnScript.equipped = false;
            //despawnScript.countDown = despawnScript.timeToDespawn;
            despawnScript.countDown = 2;
        }
    }

    // If player is in range of a weapon sets inRange to true
    // If outside of range sets to false
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Weapon"))
        {
            inRange = true;
            numInRange++;
            if (!weaponSlotFull)
            {
                inHandItem = collider.gameObject;
                rb = collider.GetComponent<Rigidbody2D>();
                coll = collider.GetComponent<CapsuleCollider2D>();
                gunScript = collider.GetComponent<fireProjectileGun>();
                despawnScript = collider.GetComponent<weaponDespawn>();
            }
        }
        
    }

    // Checks to see if the player is not in range of a weapon
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Weapon"))
        {
            numInRange--;
            if (numInRange <= 0) // if the player is not in range set their hands to null or nothing
            {
                inRange = false;
                if (!weaponSlotFull)
                {
                    inHandItem = null;
                    rb = null;
                    coll = null;
                    gunScript = null;
                    despawnScript = null;
                }
            }
        }
    }

    // Checks to see if the player is in range of the weapon
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Weapon"))
        {
            if (numInRange > 0 && !weaponSlotFull) // gets the components of the weapon when in range
            {
                inHandItem = collider.gameObject;
                rb = collider.GetComponent<Rigidbody2D>();
                coll = collider.GetComponent<CapsuleCollider2D>();
                gunScript = collider.GetComponent<fireProjectileGun>();
                despawnScript = collider.GetComponent<weaponDespawn>();
            }
        }
    }

    private void Update()
    {
        //Bug fix that kept weapon from staying in the correct while in player hands
        if (weaponSlotFull)
        {
            if (inHandItem.transform.position != gunHolder.transform.position || inHandItem.transform.rotation != gunHolder.transform.rotation)
            {
                inHandItem.transform.position = gunHolder.transform.position;
                inHandItem.transform.rotation = gunHolder.transform.rotation;
            }

        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        // If player doesn't have a weapon equipped and is in range of weapon
        // then pick up weaon and place into gunHolder
        if (!weaponSlotFull && inRange)
        {
            weaponSlotFull = true;
            inHandItem.transform.position = Vector3.zero;
            inHandItem.transform.rotation = Quaternion.identity;
            inHandItem.transform.SetParent(gunHolder.transform, false);
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            coll.enabled = false;
            despawnScript.equipped = true;
            if (gunScript.isFlag)
            {
                inHandItem.GetComponent<flagRespawn>().playerHeld = gameObject;
            }
            return;
        }
        // If player has a weapon equipped, then drop weapon
        if (weaponSlotFull)
        {
            weaponSlotFull = false;
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            coll.enabled = true;
            despawnScript.equipped = false;
            if (!gunScript.isFlag)
            {
                despawnScript.countDown = despawnScript.timeToDespawn;
            }
            return;
        }
    }

    // Fires gun from fireProjectileGun.cs
    private void Fire(InputAction.CallbackContext context)
    {
        if (weaponSlotFull)
        {
            if (gunScript.isFlag)
            {
                weaponSlotFull = false;
                inHandItem.transform.SetParent(null);
                inHandItem = null;
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
                coll.enabled = true;
                // When dropped begin despawn timer for weapon
                despawnScript.equipped = false;
                despawnScript.countDown = despawnScript.timeToDespawn;
                return;
            }
            StartCoroutine(gunScript.Shoot(gameObject));
        }
    }
}