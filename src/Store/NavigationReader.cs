using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

static class NavigationReader
{
    public static Dictionary<Type, List<Navigation>> GetNavigationProperties(EdmModel model)
    {
        return model
            .EntityTypes
            .ToDictionary(
                x =>
                {   // x.ClrType
                    return Type.GetType(x.FullName);
                },
                GetNavigations);
    }

    static List<Navigation> GetNavigations(EntityType entity)
    {
        var type = Type.GetType(entity.FullName);
        var navigations = entity.NavigationProperties;
        return navigations
            .Select(x => new Navigation(x.Name, GetNavigationType(x, type)))
            .ToList();
    }

    static Type GetNavigationType(NavigationProperty navigation, Type declaringType)
    {
        // var navigationType = navigation.ClrType;
        var navigationType = declaringType?.GetProperty(navigation.Name)?.PropertyType;
        var collectionType = navigationType?
            .GetInterfaces()?
            .SingleOrDefault(x => x.IsGenericType &&
                                  x.GetGenericTypeDefinition() == typeof(ICollection<>));

        if (collectionType == null)
        {
            return navigationType;
        }

        return collectionType.GetGenericArguments().Single();
    }
}