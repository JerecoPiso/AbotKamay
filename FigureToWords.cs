using System;
using System.Text;

public class FigureToWords
{
    private static readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    private static readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    private static readonly string[] Thousands = { "", "Thousand", "Million", "Billion", "Trillion" };

    public  string Convert(decimal number)
    {
        if (number == 0)
            return "Zero";

        StringBuilder result = new StringBuilder();

        // Handling the integer part
        int integerPart = (int)number;
        int groupIndex = 0;
        while (integerPart > 0)
        {
            int group = integerPart % 1000;
            if (group > 0)
            {
                if (groupIndex > 0)
                    result.Insert(0, Thousands[groupIndex] + " ");
                result.Insert(0, ConvertGroup(group));
            }
            integerPart /= 1000;
            groupIndex++;
        }

        // Handling the decimal part (if any)
        int decimalPart = (int)((number - Math.Floor(number)) * 100); // Get two decimal digits
        if (decimalPart > 0)
        {
            result.Append(" and ");
            result.Append(ConvertGroup(decimalPart));
            result.Append(" Cents");
        }

        return result.ToString().Trim();
    }

    private  string ConvertGroup(int number)
    {
        StringBuilder groupResult = new StringBuilder();

        if (number >= 100)
        {
            groupResult.Append(Ones[number / 100] + " Hundred ");
            number %= 100;
        }

        if (number >= 20)
        {
            groupResult.Append(Tens[number / 10] + " ");
            number %= 10;
        }

        if (number >= 10)
        {
            groupResult.Append(Teens[number - 10] + " ");
            number = 0;
        }

        if (number > 0)
        {
            groupResult.Append(Ones[number] + " ");
        }

        return groupResult.ToString().Trim();
    }

}
