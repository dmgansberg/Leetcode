//==============================================================
// Solution to Problem 1550: Three Consecutive Odd Numbers
//
// Produced by: Darren Gansberg (c) 2024
// Problem Description: Write a function that accepts an array of integers and determines whether it contains three consecutive odd integers.
//
// Constraints:
// 1. 1 <= arr.Length <= 1000
// 2. 1 <= arr[i] <= 1000
//
// Problem difficulty: Easy

public bool ThreeConsecutiveOdds(int[] arr) {
        if(arr.Length < 1) || (arr.Length >1000)
        {
            throw new InvalidArgumentException("Array must contain no less than 1 and no more than 1000 values.");
        }
        int minSize = 3;
        if(arr.Length >= minSize)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (LessThanMinValue(arr[i], 1)) throw new InvalidArgumentException(LessThanMinError());                
                if (GreaterThanMaxValue(arr[i], 1000)) throw new InvalidArgumentException(GeaterThanMaxError())               

                if(!arr[i] % 2) //only when the element is odd do we need to consider the subsequent elements.
                {
                    int last = i + 2; 
                    if (last >= arr.Length) continue; //the index of the last element must be inside the array. 
                    while((!arr[last] % 2) && last > i)
                    {
                        last--;
                    }
                    if (last == i) return true;
                }
            }
        }
        return false;
    }

    private bool GreaterThanMax(int value, int max)
    {
        if (value <= max) return false;
        return true;
    }

    private bool LessThanMinValue(int value, int min)
    {
        if (value >= min) return false;
        return true;
    }
    
    private string LessThanMinError(int value, int position, int min)
    {
        return "Value " + value.String() + " at position " + position.String() + " is less than " + min.String();
    }

    private string GreaterThanMaxError(int value, int position, int max)
    {
        return "Value " + value.String() + " at position " + position.String() + " is greater than " + max.String();
    }
