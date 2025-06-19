using TMPro;
using UnityEngine;

public class MultichoiceManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public TextMeshProUGUI questionText;
        public GameObject[] options;
        public int correctIndex;
    }

    public Question[] questions;
    private int currentQuestionIndex = 0;

    public TextMeshProUGUI resultTextMesh;

    private bool isAnswering = true;

    public void Start()
    {
        Debug.Log("Start game");
        ShowQuestion();
    }

    public void SelectAnswer(int selectedIndex)
    {
        Debug.Log("Called");
        if (!isAnswering) return;

        var q = questions[currentQuestionIndex];

        if (selectedIndex == q.correctIndex)
        {
            resultTextMesh.text = "<color=green>Correct!</color>";
            isAnswering = false;
            Invoke(nameof(NextQuestion), 1f);
        }
        else
        {
            resultTextMesh.text = "<color=red>Wrong! Try again.</color>";
        }
    }

    private void NextQuestion()
    {
        currentQuestionIndex++;
        isAnswering = true;

        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            resultTextMesh.text = "Completed all questions!";
        }
    }

    public void ShowQuestion()
    {
        var q = questions[currentQuestionIndex];
        resultTextMesh.text = "";

        Debug.Log("Câu hỏi: " + q.questionText.text);
        for (int i = 0; i < q.options.Length; i++)
        {
            Debug.Log($"[{i}] {q.options[i].name}");
        }
    }
}
