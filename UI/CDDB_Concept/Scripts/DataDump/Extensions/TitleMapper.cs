using System.Collections.Generic;
using DataAccess.Infrastructure.Entities;

internal static class TitleMapper
{
    internal static IEnumerable<TitleEntity> ToEntity(this IEnumerable<TitleViewModel> viewModels)
    {
        var newObjects = new List<TitleEntity>();
        foreach (var e in viewModels)
        {
            TitleEntity element = e;
            newObjects.Add(element);
        }

        return newObjects;
    }

    internal static IEnumerable<TitleViewModel> ToViewModel(this IEnumerable<TitleEntity> entityObjects)
    {
        var newObjects = new List<TitleViewModel>();
        foreach (var e in entityObjects)
        {
            TitleViewModel element = e;
            newObjects.Add(element);
        }
        return newObjects;
    }
}