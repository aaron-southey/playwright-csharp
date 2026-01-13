namespace Config
{
    public class PlaywrightConfig
    {
        public string? Browser { get; set; }
        public string? Url { get; set; }
        public int Timeout { get; set; }
        public bool Headless { get; set; }
    }
}