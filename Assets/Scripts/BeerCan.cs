using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BeerCan : MonoBehaviour, IInteractable
{
    public bool isDrunk;
    public GameObject wall;

    private void Start()
    {
        isDrunk = false;
    }

    public void Interact()
    {
        if (!isDrunk)
        {
            isDrunk = true;
            ApplyDrunkEffect(isDrunk);
            Invoke("SoberUp", 5f);
            wall.SetActive(false);
        }
        else
        {
            return;
        }
    }

    private void SoberUp()
    {
        isDrunk = false;
        wall.SetActive(true);
        ApplyDrunkEffect(isDrunk) ;
    }
    private static void ApplyDrunkEffect(bool actif)
    {
        var volume = FindAnyObjectByType<Volume>();
        if (volume.profile.TryGet(out ChromaticAberration chromaticAberration))
        {
            chromaticAberration.active = actif;
        }

        if (volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            lensDistortion.active = actif;
        }

        
    }
}
