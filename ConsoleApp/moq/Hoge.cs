using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.moq
{
    public interface IHoge
    {
        public int Value { get; set; }
        public int Calculate(int value);
        public int Calculate();
    }

    public class Hoge: IHoge
    {
        public int Value { get; set; }

        public int Calculate(int val) => val * 2;

        public int Calculate() => Calculate(Value);
    }
}
