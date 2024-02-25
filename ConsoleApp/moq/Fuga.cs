using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.moq
{
    public class Fuga
    {
        private IHoge hoge;

        public Fuga(IHoge hoge) => this.hoge = hoge;

        public int Calculate(int val) => hoge.Calculate(val);

        public int GetValue() => hoge.Value;

        public int Calculate() => hoge.Calculate();
    }
}
