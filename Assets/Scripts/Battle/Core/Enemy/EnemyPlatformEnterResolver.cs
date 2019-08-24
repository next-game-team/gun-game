public class EnemyPlatformEnterResolver : PlatformEnterResolver
{
    public override void Resolve(Platform place)
    {
        place.SetType(PlatformType.Empty);
    }
}