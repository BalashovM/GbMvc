namespace MyLibrary
{
    public interface IScanManager
    {
        void SaveAsBmp(byte[] bytes);
        void SaveAsJpg(byte[] bytes);
    }
}
