using Spp1._0.InfoModel;
using Spp1._0.Interface;
using System.Collections.Concurrent;

namespace TracerLib.Service
{
    public class TracerService : ITracerService
    {        
        private readonly ConcurrentDictionary<int, Tree<MethodInfoModel>> _threadMethods
            = new();
        private readonly MethodInfoModel root = new("initMethod", "initMethod");
        private readonly object locker = new();

        public MethodInfoModel GetCurrentMethod()
        {
            var tree = GetCurrentTree();
            return tree.CurrentNode.Data;
        }

        private Tree<MethodInfoModel> GetCurrentTree()
        {
            var threadId = Environment.CurrentManagedThreadId;
            if (!_threadMethods.ContainsKey(threadId))
            {
                _threadMethods.TryAdd(threadId, new Tree<MethodInfoModel>(threadId, root));
            }
            return _threadMethods[threadId];
        }

        public void AddMethodToTree(MethodInfoModel info)
        {
            var tree = GetCurrentTree();
            TreeNode<MethodInfoModel> newNode = new(info)
            {
                Parent = tree.CurrentNode,
                Data = info
            };
            lock (locker)
            {
                tree.CurrentNode.Children.Add(newNode);
            }
            tree.CurrentNode = newNode;
        }

        public void AscendTree(long time)
        {
            var tree = GetCurrentTree();
            tree.CurrentNode.Data.Time = time;
            tree.CurrentNode = tree.CurrentNode.Parent;
        }

        public TraceResult GetResult()
        {
            var methods = _threadMethods.Values.Select(x => x.ToThreadInfoModel()).ToList();
            return new TraceResult(methods);
        }
    }
}
