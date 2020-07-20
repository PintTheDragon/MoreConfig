namespace MoreConfig
{
    using Exiled.API.Features;
    using HarmonyLib;

    public class MoreConfig : Plugin<Config>
    {
        public static MoreConfig singleton;

        private Harmony harmony;

        public override void OnEnabled()
        {
            singleton = this;

            harmony = new Harmony("MoreConfigPint");
            harmony.PatchAll();
        }

        public override void OnDisabled()
        {
            harmony.UnpatchAll();

            singleton = null;
        }
    }
}
