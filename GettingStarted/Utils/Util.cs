using System;

namespace Utils
{
    public static class Util
    {
        public enum EnumExamples
        {
            ExampleBasic,
            ExampleFault,
            ExampleSession,
            ExampleAsincrono
        };

        public static EnumExamples seleccionarExample()
        {
            return EnumExamples.ExampleAsincrono;
        }
    }
}
