using Spp1._0.InfoModel;

namespace TracerLib.Service
{
    public static class Mapper
    {
        public static MethodInfoTreeModel ToMethodInfoTreeModel(this MethodInfoModel method)
        {
            return new MethodInfoTreeModel(
                method.Id,
                method.Name,
                method.ClassName,
                method.Time
            );
        }

        public static ThreadInfoModel ToThreadInfoModel(this Tree<MethodInfoModel> tree)
        {
            var node = tree.Root;
            var result = new MethodInfoTreeModel();

            MethodToTreeModel(node, result);

            return new ThreadInfoModel(
                tree.Id,
                tree.Root.Children.Sum(x => x.Data.Time),
                result.Methods
            );
        }

        private static void MethodToTreeModel(TreeNode<MethodInfoModel> methodInfo, MethodInfoTreeModel result)
        {
            result.Methods = methodInfo.Children.Select(
                x => x.Data.ToMethodInfoTreeModel()).ToList().AsReadOnly();

            for (int i = 0; i < methodInfo.Children.Count; i++)
            {
                MethodToTreeModel(methodInfo.Children[i], result.Methods[i]);
            }
        }
    }
}
