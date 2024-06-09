using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FingersAndAction
{
    public static List<FingerName> activeFingers=new List<FingerName>();
    public static HandAction handAction=HandAction.AngleUp;


    public static void SetActiveFingers(List<string> newActiveFingers)
    {
        activeFingers.Clear();
        foreach (var finger in newActiveFingers)
        {
            activeFingers.Add(EnumHelper.GetEnumValueFromString<FingerName>(finger));
        }

    }
    public static void SetSelectedAction(string newAction)
    {
        handAction=EnumHelper.GetEnumValueFromString<HandAction>(newAction);
    }


}
public class EnumHelper
{
    public static T GetEnumValueFromString<T>(string value) where T : Enum
    {
        foreach (T enumValue in Enum.GetValues(typeof(T)))
        {
            if (enumValue.ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return enumValue;
            }
        }
        throw new ArgumentException($"No enum value found for string '{value}' in {typeof(T).Name}");
    }
}

public enum HandAction
{
    Close,
    Open,
    AngleUp,
    AngleDown
}