using System.Text.RegularExpressions;

namespace apbd_03;

public class AnimalUtils
{
    public static bool IsOrderByColumnNameValid(string orderBy)
    {
        return "name".Equals(orderBy.ToLower()) || "description".Equals(orderBy.ToLower())  ||
               "category".Equals(orderBy.ToLower())  || "area".Equals(orderBy.ToLower()) ;
    }
}