using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInfiniteAmmo : MonoBehaviour
{

    public float duration;
    public int fullClip;

    public BuffUI buffUI;
    public BuffText infiniteAmmoText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RangeAttack reload = other.GetComponent<RangeAttack>();
            InfiniteAmmoEffect effect = other.GetComponentInChildren<InfiniteAmmoEffect>();
            fullClip = reload.GetFullClip();
            StartCoroutine(InstantReload(other, reload, effect));
        }
    }

    IEnumerator InstantReload(Collider player, RangeAttack reload, InfiniteAmmoEffect effect)
    {
        FindObjectOfType<AudioManager>().Play("Infinite Ammo");
        buffUI.IncreaseCount();
        infiniteAmmoText.Show();
        effect.Show();

        reload.isInfiniteAmmo(true);
        reload.setAmmoFull();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        reload.isInfiniteAmmo(false);
        buffUI.DecreaseCount();
        infiniteAmmoText.Disappear();
        effect.Disappear();

        Destroy(gameObject);
    }
}
