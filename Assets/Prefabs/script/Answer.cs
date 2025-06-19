using Oculus.Interaction;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Answer : MonoBehaviour
{
    public int answerIndex; 
    public MultichoiceManager manager;

    private void Awake()
    {
        if (GetComponent<XRBaseInteractable>() == null)
        {
            gameObject.AddComponent<PokeInteractable>();
        }
    }

    public void OnPoke()
    {
        if (manager != null)
        {
            manager.SelectAnswer(answerIndex);
        }
    }
}
