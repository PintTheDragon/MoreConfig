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
    }

    public class Scp939Config
    {
        public float minimumSilenceTime { get; set; } = 2.5f;

        public float minimumNoiseLevel { get; set; } = 2f;
    }
}