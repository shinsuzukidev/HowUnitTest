using Xunit;
using ConsoleApp;
using System.Numerics;

namespace ConsoleApp.Test
{
    /*
     * .NET Core と .NET Standard での単体テストのベスト プラクティス
     * https://learn.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-best-practices
     * 
     * xUnit.net Hands-on
     * https://github.com/csharp-tokyo/xUnit-Hands-on?tab=readme-ov-file
     * 
     * 
     * <属性>
     *      Factは一つのテスト、Theoryは複数のテスト。
     * <初期化>
     *      メソッド毎の初期化、終了処理(IDisposable)。
     *      クラス全体での初期化、終了処理(IClassFixture)。
     *      
     * 
     */

    public class Calculator_Test: IDisposable
    {
        Calculator? _calculator;

        public Calculator_Test()
        {
            _calculator = new Calculator();
        }

        public void Dispose()
        {
            _calculator = null;
        }

        /// <summary>
        /// 一つのテスト
        /// </summary>
        [Fact]
        public void AdddTest()
        {
            // act
            var actual = _calculator?.Add(1, 2);

            // assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void AssertTest()
        {
            // arrange
            var target = "abcdefgXYZ";

            // assert
            Assert.Equal("abcdefgxyz", target, ignoreCase: true);
            Assert.NotNull(target);
            Assert.NotEmpty(new List<int> { 1, 2 });
            Assert.True(true);
            Assert.False(false);
            Assert.Contains("def", target);
            Assert.StartsWith("abc", target);
            Assert.Matches("^[a-zA-Z].+XYZ", target);   // 正規表現

            // リストの比較
            var list1 = new List<int>() { 1, 2, 3, 4, 5 };
            var list2 = new List<int>() { 1, 2, 3, 4, 5 };
            Assert.Equal(list1, list2);

            // オブジェクトの比較
            var obj1 = new { name = "sato", age = 30, dic = new Dictionary<string, int>() { { "aa", 100 } } };
            var obj2 = new { name = "sato", age = 30, dic = new Dictionary<string, int>() { { "aa", 100 } } };
            Assert.Equivalent(obj1, obj2);  // test ok,オブジェクトの値が同じならtrue、型はみてない
            // Assert.Equal(obj1, obj2);    // test ng

            // 例外テスト
            var ex = Assert.ThrowsAsync<Exception>(() =>
            {
                throw new Exception("test");
            });
        }

        /// <summary>
        /// 複数のテスト
        /// </summary>
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void AdddTest2(int x, int y, int expected)
        {
            // act
            var actual = _calculator?.Add(x, y);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void AddTest3(int x, int y, int expected)
        {
            // act
            var actual = _calculator?.Add(x, y);
            // assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// テストデータ作成(public,staticであること)
        /// </summary>
        public static IEnumerable<object[]> GetNumbers()
        {
            return new List<object[]> {
                new object[] { 1, 2, 3} ,
                new object[] { 2, 3, 5 },
                new object[] { 3, 4, 7 },
            };
        }
    }
}

