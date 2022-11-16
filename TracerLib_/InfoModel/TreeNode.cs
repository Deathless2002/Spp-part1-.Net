namespace Spp1._0.InfoModel
{
    public class TreeNode<T> where T : class
    {
        public TreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        internal List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
        public TreeNode<T> Parent { get; set; }
    }
}
