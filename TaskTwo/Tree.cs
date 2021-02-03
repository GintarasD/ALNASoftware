using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskTwo {
	public class Tree {
		public List<Tree> Children { get; private set; }
		
		public Tree(List<Tree> children) {
			this.Children = children;
		}
		public Tree() : this(new List<Tree>()) {}

		public bool IsLeaf() { return this.Children.Count < 1; }

		public int GetHeight() {
			if (this.IsLeaf()) { return 1; } 
			return this.Children.Select(child => child.GetHeight())
								.Max() + 1;
		}

		public static void Main(string[] args) {
			Console.Write("Height of the tree to generate: ");
			int height = Int32.Parse(Console.ReadLine());
			Tree generated = Utils.GenerateRandom(height, 3);

			Console.WriteLine($"Calculated height: {generated.GetHeight().ToString()}");
			
			Utils.Display(generated);
		}
	}
}