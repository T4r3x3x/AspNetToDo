using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace ApplicationCore.Extensions
{
	static class Extensions
	{
		public static string GetDisplayName(this System.Enum enumValue)
		{
			return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName() ?? "Неопределён";
		}
		public static IQueryable<T> WhereIf<T>(this IQueryable<T> collection, bool condition, Expression<Func<T, bool>> predicate)
		{
			if (condition)
				return collection.Where(predicate);
			return collection;
		}

		public static string ToStringHtml(this DateTime dateTime)
		{
			return dateTime.Date.ToString("yyyy-MM-dd");
		}
	}
}