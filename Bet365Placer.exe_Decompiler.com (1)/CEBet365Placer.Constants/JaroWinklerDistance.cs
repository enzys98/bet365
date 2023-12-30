using System;

namespace CEBet365Placer.Constants;

public static class JaroWinklerDistance
{
	private static readonly double mWeightThreshold = 0.7;

	private static readonly int mNumChars = 4;

	public static double distance(string aString1, string aString2)
	{
		return 1.0 - proximity(aString1, aString2);
	}

	public static double proximity(string aString1, string aString2)
	{
		int length = aString1.Length;
		int length2 = aString2.Length;
		if (length == 0)
		{
			if (length2 != 0)
			{
				return 0.0;
			}
			return 1.0;
		}
		int num = Math.Max(0, Math.Max(length, length2) / 2 - 1);
		bool[] array = new bool[length];
		bool[] array2 = new bool[length2];
		int num2 = 0;
		for (int i = 0; i < length; i++)
		{
			int num3 = Math.Max(0, i - num);
			int num4 = Math.Min(i + num + 1, length2);
			for (int j = num3; j < num4; j++)
			{
				if (!array2[j] && aString1[i] == aString2[j])
				{
					array[i] = true;
					array2[j] = true;
					num2++;
					break;
				}
			}
		}
		if (num2 == 0)
		{
			return 0.0;
		}
		int num5 = 0;
		int k = 0;
		for (int l = 0; l < length; l++)
		{
			if (array[l])
			{
				for (; !array2[k]; k++)
				{
				}
				if (aString1[l] != aString2[k])
				{
					num5++;
				}
				k++;
			}
		}
		int num6 = num5 / 2;
		double num7 = num2;
		double num8 = (num7 / (double)length + num7 / (double)length2 + (double)(num2 - num6) / num7) / 3.0;
		if (num8 <= mWeightThreshold)
		{
			return num8;
		}
		int num9 = Math.Min(mNumChars, Math.Min(aString1.Length, aString2.Length));
		int m;
		for (m = 0; m < num9 && aString1[m] == aString2[m]; m++)
		{
		}
		if (m == 0)
		{
			return num8;
		}
		return num8 + 0.1 * (double)m * (1.0 - num8);
	}
}
