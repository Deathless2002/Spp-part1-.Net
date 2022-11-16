namespace Spp1._0.InfoModel
{
    public class Tree<T> where T : class
    {
        public Tree(int id, T root)
        {
            Id = id;
            Root = new TreeNode<T>(root);
            CurrentNode = Root;
        }

        public int Id { get; set; }
        public TreeNode<T> Root { get; }
        public TreeNode<T> CurrentNode { get; set; }
    }
}
