using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Data.Ultitity
{
	public static class MethodExtend
	{
		public static string RemoveQuotes(this string Value)
		{
			return Value.Replace("\"", "");
		}
		public static float TwoDecimals(this float Value)
		{
			return Mathf.Round(Value * 1000.0f) / 1000.0f;
		}
	}
}
