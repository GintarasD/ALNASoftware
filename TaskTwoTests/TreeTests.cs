using System.Collections.Generic;
using TaskTwo;
using Xunit;

namespace TaskTwoTests {
	public class UnitTest1 {
		[Fact]
		public void TestManual() {
			// The tree being created
			// *t
			// |- *t1
			// |  |- *t11
			// |- *t2
			//    |- *t21
			//    |- *t22
			//       |- *t221
			// 1  2  3  4
			Tree root = new Tree(new List<Tree> {
				new Tree(new List<Tree>{new Tree()}),
				new Tree(new List<Tree> {
					new Tree(),
					new Tree(new List<Tree> {
						new Tree()
					})
				})
			});
			Assert.Equal(4, root.GetHeight());
		}
		
		/// <summary>
		/// Not exactly a good test, since we're relying
		/// on GenerateRandom to be correct, and it's random too
		/// </summary>
		[Fact]	
		public void TestGenerated() {
			for (int i = 1; i < 10; i++) {
				Tree generated = Utils.GenerateRandom(i, 2);
				Assert.Equal(i, generated.GetHeight());
			}
		}
	}
}