using Oculus.Interaction;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Answer : MonoBehaviour
{
    public int answerIndex;
    public MultichoiceManager manager;

    private PokeInteractable pokeInteractable;

    private void Start()
    {
        pokeInteractable = GetComponent<PokeInteractable>();

        if(pokeInteractable == null)
        {
            Debug.LogError("PokeInteractable component not found on " + gameObject.name);
            return;
        }    

        Debug.Log("pokeInteractable found on " + gameObject.name);
        pokeInteractable.WhenStateChanged += OnInteractableStateChanged;
    }

    private void OnInteractableStateChanged(InteractableStateChangeArgs args)
    {
        if (args.NewState == InteractableState.Select)
        {
            OnPoke();
        }
    }

    public void OnPoke()
    {
        Debug.Log("Poke detected on answer: " + answerIndex);
        if (manager != null)
        {
            manager.SelectAnswer(answerIndex);
            Debug.Log("Selected anser index: " + answerIndex);
        }
    }
}
