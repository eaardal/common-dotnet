namespace Historian
{
    public static class CompileConfigurationMode
    {
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#endif
            return false;
        }
    }
}
