namespace TV_Slideshow_Config_Editor.ConfigInterface
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON Object")]
    public class Configurations
    {
        public Defaults defaults { get; set; }
        public TimeDisplay showTime { get; set; }
        public Site[] sites { get; set; }
        public Notification[] notifications { get; set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON Object")]
    public class Defaults
    {
        public Durations durations { get; set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON Object")]
    public class Durations
    {
        public int site { get; set; }
        public int slide { get; set; }
        public int notification { get; set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON Object")]
    public class TimeDisplay
    {
        public int duration { get; set; }
        public int interval { get; set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON Object")]
    public class Site
    {
        public string url { get; set; }
        public object height { get; set; }
        public int duration { get; set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON Object")]
    public class Notification
    {
        public object schedule { get; set; }
        public string audioFile { get; set; }
        public string message { get; set; }
        public int duration { get; set; }
    }

}
