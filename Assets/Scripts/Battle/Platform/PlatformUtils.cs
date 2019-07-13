public static class PlatformUtils
{
    public static Platform GetRandomPlatformForCollectable()
    {
        // Find free platforms to generate
        var freePlatformsWithoutCollectable = PlatformMap.Instance
            .FreePlatforms
            .FindAll(platform => platform.CollectableObject == null);
        
        // Return from the method if not found free platform
        if (freePlatformsWithoutCollectable.Count == 0) return null;
        
        // Pick random free platform
        return RandomUtils.GetRandomObjectFromList(freePlatformsWithoutCollectable);
    }
}