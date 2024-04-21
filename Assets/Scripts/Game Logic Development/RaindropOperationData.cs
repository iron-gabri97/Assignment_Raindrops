using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropOperationData : MonoBehaviour
{

    //ENUMS
    public enum EOperation
    {
        Sum, 
        Difference,
        Multiplication,
        Division
    }

    //DATA
    private EOperation operation;
    private int firstNumber;
    private int secondNumber;

    public EOperation Operation { get { return operation; } }
    public int FirstNumber { get {  return firstNumber; } }
    public int SecondNumber { get { return secondNumber; } }

    public int Result
    {
        get
        {
            switch (operation)
            {
                case EOperation.Sum:
                    return firstNumber + secondNumber;
                case EOperation.Difference:
                    return firstNumber - secondNumber;
                case EOperation.Multiplication:
                    return firstNumber * secondNumber;
                case EOperation.Division:
                    return firstNumber / secondNumber;
                default:
                    Debug.LogError("Invalid operation value has been provided");
                    return 0;
            }
        }
    }

    //TECHNICAL DATA FOR OPERATION
    public static Dictionary<EOperation, string> dictionaryOP = new Dictionary<EOperation, string>
    {
        {EOperation.Sum, "+"},
        {EOperation.Difference, "-"},
        {EOperation.Multiplication, "x"},
        {EOperation.Division, "/"}
    };
    
    public RaindropOperationData(int firstValue = 1, int secondValue = 1, EOperation operation = EOperation.Sum)
    {
        this.operation = operation;
        switch(operation)
        {
            case EOperation.Division:
                firstNumber = firstValue * secondValue;
                secondNumber = secondValue;
                break;
            default:
                firstNumber = firstValue;
                secondNumber = secondValue;
                break;
        }
    }

    //RANDOMIZATION
    public static EOperation GetRandomOp()
    {
        return (EOperation) UnityEngine.Random.Range(0, EOperation.GetNames(typeof(EOperation)).Length);
    }

    public static int GetRandomFirstValue(EOperation operation = EOperation.Sum)
    {
        switch(operation) 
        {
            case EOperation.Sum:
                return UnityEngine.Random.Range(0, 10);
            case EOperation.Difference:
                return UnityEngine.Random.Range(0, 10);
            case EOperation.Multiplication:
                return UnityEngine.Random.Range(0, 10);
            case EOperation.Division:
                return UnityEngine.Random.Range(1, 10);
            default:
                Debug.LogError("Invalid operation value has been provided");
                return 0;
        }
    }

    public static int GetRandomSecondValue(EOperation operation = EOperation.Sum)
    {
        return GetRandomFirstValue(operation);
    }

    public int GetRaindropScore()
    {
        switch(operation)
        {
            case EOperation.Sum:
                return 1;
            case EOperation.Difference:
                return 2;
            case EOperation.Multiplication:
                return 3;
            case EOperation.Division:
                return 4;
            default:
                Debug.LogError("Invalid operation value has been provided");
                return 0;
        }
    }
}
