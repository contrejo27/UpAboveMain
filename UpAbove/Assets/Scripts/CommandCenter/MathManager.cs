using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This will contain all math generation
public class MathManager : MonoBehaviour
{
    //Math Parameters
    string mathType = "Decimals";
    float maxOperand = 4f;
    float minOperand = 0f;
    float operand_A = 1f;
    float operand_B = 0.0f;
    string operationType;
    float correctAnswer;

    //UI
    public Text mathProblemText;
    public InputField answer;
    public MathConsole mathConsole;
    public Text mathFeedback;

    private void Start()
    {
        GenerateMathProblem();
    }

    //generate a random math problem
    public void GenerateMathProblem()
    {
        if (mathType == "Decimals")
        {
            //set up operands
            operand_A = (float)System.Math.Round(Random.Range(minOperand, maxOperand),1);
            operand_B = (float)System.Math.Round(Random.Range(minOperand, maxOperand),1);

            //Randomly pick operation type
            if (Random.Range(0f, 1f) < .5f)
            {
                operationType = "+";
            }
            else operationType = "-";
        }

        //UI
        mathProblemText.text = operand_A + " " + operationType + " "+ operand_B + " = X";
        FindCorrectAnswer(operand_A, operand_B, operationType);
    }

    // Does the math problem and finds correct answer
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

    //after they press 'solve' check the answer and give feedback. TODO: Precision issue still needs to be fixed
    public void CheckAnswer()
    {
        print("CorrectAnswer = " + correctAnswer + " input = " + answer.text);
        //round and compare answers
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
}
