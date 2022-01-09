using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data.Ultitity
{
	public static class MethodExtend
	{
		public static string RemoveQuotes(this string Value)
		{
			return Value.Replace("\"", "");
		}
	}
}
