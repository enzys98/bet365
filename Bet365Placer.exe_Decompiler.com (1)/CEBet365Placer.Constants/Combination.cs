using System;
using System.Collections.Generic;
using System.Text;
using CEBet365Placer.Json;

namespace CEBet365Placer.Constants;

public class Combination
{
	private long n;

	private long k;

	private long[] data;

	public Combination(long n, long k)
	{
		if (n < 0 || k < 0)
		{
			throw new Exception("Negative parameter in constructor");
		}
		this.n = n;
		this.k = k;
		data = new long[k];
		for (long num = 0L; num < k; num++)
		{
			data[num] = num;
		}
	}

	public Combination Successor()
	{
		if (data.Length == 0 || data[0] == n - k)
		{
			return null;
		}
		Combination combination = new Combination(n, k);
		long num;
		for (num = 0L; num < k; num++)
		{
			combination.data[num] = data[num];
		}
		num = k - 1;
		while (num > 0 && combination.data[num] == n - k + num)
		{
			num--;
		}
		combination.data[num]++;
		for (long num2 = num; num2 < k - 1; num2++)
		{
			combination.data[num2 + 1] = combination.data[num2] + 1;
		}
		return combination;
	}

	public List<TennisTip> ApplyTo(List<TennisTip> strarr)
	{
		if (strarr.Count != n)
		{
			throw new Exception("Bad array size");
		}
		List<TennisTip> list = new List<TennisTip>();
		for (int i = 0; i < strarr.Count; i++)
		{
			try
			{
				list.Add(strarr[Utils.parseToInt(data[i].ToString())]);
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	public static long Choose(long n, long k)
	{
		if (n < 0 || k < 0)
		{
			throw new Exception("Invalid negative parameter in Choose()");
		}
		if (n < k)
		{
			return 0L;
		}
		if (n == k)
		{
			return 1L;
		}
		long num;
		long num2;
		if (k < n - k)
		{
			num = n - k;
			num2 = k;
		}
		else
		{
			num = k;
			num2 = n - k;
		}
		long num3 = num + 1;
		for (long num4 = 2L; num4 <= num2; num4++)
		{
			num3 = checked(num3 * (num + num4)) / num4;
		}
		return num3;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ ");
		for (long num = 0L; num < k; num++)
		{
			stringBuilder.AppendFormat("{0} ", data[num]);
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
