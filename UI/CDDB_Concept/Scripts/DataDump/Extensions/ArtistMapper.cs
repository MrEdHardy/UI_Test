using System.Collections.Generic;
using DataAccess.Infrastructure.Entities;

internal static class ArtistMapper
{
    internal static IEnumerable<ArtistEntity> ToEntity(this IEnumerable<ArtistViewModel> viewModels)
    {
        List<ArtistEntity> newObjects = new List<ArtistEntity>();
        foreach (var e in viewModels)
        {
            ArtistEntity element = e;
            newObjects.Add(element);
        }

        return newObjects;
    }

    internal static IEnumerable<ArtistViewModel> ToViewModel(this IEnumerable<ArtistEntity> entityObjects)
    {
        List<ArtistViewModel> newObjects = new List<ArtistViewModel>();
        foreach (var e in entityObjects)
        {
            ArtistViewModel element = e;
            newObjects.Add(element);
        }
        return newObjects;
    }
}