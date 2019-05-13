using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathManager : MonoBehaviour
{
    string mathType = "Decimals";
    float maxOperand = 4f;
    float minOperand = 0f;
    public Text mathProblemText;
    float operand_A = 1f;
    float operand_B = 0.0f;
    string operationType;
    float correctAnswer;
    public InputField answer;
    public MathConsole mathConsole;
    public Text mathFeedback;
    private void Start()
    {
        GenerateMathProblem();
    }
    public void GenerateMathProblem()
    {
        if (mathType == "Decimals")
        {
            operand_A = (float)System.Math.Round(Random.Range(minOperand, maxOperand),1);
            operand_B = (float)System.Math.Round(Random.Range(minOperand, maxOperand),1);

            if (Random.Range(0f, 1f) < .5f)
            {
                operationType = "+";
            }
            else operationType = "-";
        }
        mathProblemText.text = operand_A + " " + operationType + " "+ operand_B + " = X";
        FindCorrectAnswer(operand_A, operand_B, operationType);
    }
    void FindCorrectAnswer(float a, float b, string operation)
    {
        if(operation == "+")
        {
            correctAnswer = a + b;
        }
        else if(operation == "-")
        {
            correctAnswer = a - b;
        }
    }

    public void CheckAnswer()
    {
        print("CorrectAnswer = " + correctAnswer + " input = " + answer.text);
        if(Mathf.Approximately(correctAnswer ,float.Parse(answer.text)))
        {
            mathFeedback.color = Color.green;
            mathFeedback.text = "CORRECT!";
            StartCoroutine("GoBackToSequencer");
        }
        else
        {
            mathFeedback.color = Color.red;
            mathFeedback.text = "INCORRECT";
        }
    }

    IEnumerator GoBackToSequencer()
    {
        yield return new WaitForSeconds(1.0f);
        mathConsole.MathProblemSolved();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
