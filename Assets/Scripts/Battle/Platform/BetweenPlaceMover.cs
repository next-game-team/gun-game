public static class BetweenPlaceMover<T> where T : AbstractPlace<T>
{
    public static bool MoveTo(PlaceObject<T> placeObject, DirectionEnum directionEnum)
    {
        T newPlace;
        var result = placeObject.CurrentPlace.Neighbors.DirectionDictionary.TryGetValue(directionEnum, out newPlace);
        // Check if can move to new place
        if (!result || newPlace == null || !newPlace.IsFree)
        {
            return false;
        }

        placeObject.CurrentPlace.Empty();
        placeObject.MoveTo(newPlace);
        newPlace.SetCurrentObject(placeObject);
        return true;
    }
}
