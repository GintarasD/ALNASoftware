using System;

namespace TaskTwo {
	public class Utils {
		public static Tree GenerateRandom(int height, int maxChildren) {
			if (height < 1) { throw new ArgumentException("Trees must have a height"); }
			if (height == 1) { return new Tree(); }
			
			int childrenCount = new Random().Next(1, maxChildren);
			int childrenHeight = height - 1;
			
			Tree root = new Tree();
			for (int i = 0; i < childrenCount; i++) {
				Tree child = GenerateRandom(childrenHeight, maxChildren);
				root.Children.Add(child);
			}
			return root;
		}

		public static void Display(Tree tree) {
			Utils.Display(tree, 1);
		}
		private static void Display(Tree tree, int depth) {
			string legend = depth.ToString() + "│";
			string indent = new string(' ', (depth-1)*2);
			string treeString = tree.IsLeaf() ? "@" : tree.Children.Count.ToString();
			
			Console.WriteLine(legend + indent + treeString);

			int childrenDepth = depth + 1;
			for (int i = 0; i < tree.Children.Count; i++) {
				Display(tree.Children[i], childrenDepth);
			}
		}
	}
}