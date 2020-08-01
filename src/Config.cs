namespace MoreConfig
{
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description("Enables/disables the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("All config options fo SCP-939.")]
        public Scp939Config Scp939Config { get; set; } = new Scp939Config();

        [Description("All config options fo SCP-079.")]
        public Scp079Config Scp079Config { get; set; } = new Scp079Config();

        [Description("All config options fo SCP-096.")]
        public Scp096Config Scp096Config { get; set; } = new Scp096Config();
    }

    public class Scp939Config
    {
        public float minimumSilenceTime { get; set; } = 2.5f;

        public float minimumNoiseLevel { get; set; } = 2f;
    }

    public class Scp079Config
    {
        public float maxMana { get; set; } = 100f;

        public float startingMana { get; set; } = 100f;
    }

    public class Scp096Config
    {
        public float triggerBounds1 { get; set; } = 0.64f;

        public float triggerBounds2 { get; set; } = 0.1f;
    }
}