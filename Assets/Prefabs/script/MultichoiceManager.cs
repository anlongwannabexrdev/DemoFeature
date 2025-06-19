using TMPro;
using UnityEngine;

public class MultichoiceManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public TextMeshProUGUI questionText;
        public TextMeshProUGUI[] options;
        public int correctIndex;
    }

    public Question[] questions;
    private int currentQuestionIndex = 0;

    public TextMeshProUGUI resultTextMesh;

    public void SelectAnswer(int selectedIndex)
    {
        var q = questions[currentQuestionIndex];

        if (selectedIndex == q.correctIndex)
            resultTextMesh.text = "<color=green>Correct!</color>";
        else
            resultTextMesh.text = "color=red>Wrong!</color>";

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            Debug.Log("Completed all question");
        }
    }

    public void ShowQuestion()
    {
        var q = questions[currentQuestionIndex];
        Debug.Log("Cau hoi: " + q.questionText);
        for (int i = 0; i < q.options.Length; i++)
        {
            Debug.Log($"[{i}] {q.options[i]}");
        }
    }
}
