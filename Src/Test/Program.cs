using System;

namespace Test
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(StringEnumExtension.GetDescription<TestEnum>(TestEnum.Unknow));
            Console.ReadKey();
        }
    }
}