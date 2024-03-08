namespace AudioManage
{
    public struct AudioData
    {
        public static float MasterVolume;
        public static float BGMVolume;
        public static float SFXVolume;

        public static void SetDefault()
        {
            MasterVolume = 0;
            BGMVolume = 0;
            SFXVolume = 0;
        }
    }
}