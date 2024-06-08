namespace Mod.CameraModule.Models
{
    public class MainProperty
    {
        public string Name { get; set; }

        public string PropertyName { get; set; }

        public string PropertyGroup { get; set; }

        public object? RelativeMax { get; set; }

        public object? RelativeMin { get; set; }

        //public object TrueValue { get; set; }

        //public object FalseValue { get; set; }

        //todo Value is object?????? - use generic 
        public string Value { get; set; }
        //Why is that of double type? 
        public double? CorrectionValue { get; set; } = null;

        //public bool NeedStopCamera { get; set; } = false;
    }
}