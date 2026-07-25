public interface ILevelUp
{
    void LevelUp(CharacterData data, int level);
    int MinLevel { get; }
}
