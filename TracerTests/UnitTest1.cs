using Spp1._0.Interface;
using TracerLib.Service;
using TracerTests.TestClasses;

namespace TracerTests
{
    [TestClass]
    public class UnitTest1
    {
        private ITrackService trackService;
        private ITracerService tracerService;
        private ITracer tracer;
        private TestClass testClass;

        [TestInitialize()]
        public void SetUp()
        {
            trackService = new TrackService();
            tracerService = new TracerService();
            tracer = new Tracer(tracerService, trackService);
            testClass = new TestClass(tracer);
        }

        [TestMethod]
        public void Trace_Single_Thread_Method_with_Inner_Method_Call()
        {
            testClass.Method0();

            var traceResult = tracer.GetTraceResult();
            var threads = traceResult.Threads;

            Assert.AreEqual(1, threads.Count);            //single thread

            var methods = threads[0].Methods;

            Assert.AreEqual(1, methods.Count);            //one base method call

            string methodName = methods[0].Name;
            string methodClassName = methods[0].ClassName;

            Assert.AreEqual("Method1", methodName);
            Assert.AreEqual("TestClass", methodClassName);

            Assert.AreEqual(2, methods[0].Methods.Count);  //two inner method calls
            Assert.AreEqual("Method2", methods[0].Methods[0].Name);
            Assert.AreEqual("Method2", methods[0].Methods[1].Name);
        }

        [TestMethod]
        public void Trace_Multiple_Thread_Method_with_Inner_Method_Call()
        {
            Task.Run(() => testClass.Method0());
            testClass.Method0();

            var traceResult = tracer.GetTraceResult();
            var threads = traceResult.Threads;

            Assert.AreEqual(2, threads.Count);                   //multiple threads

            var methodsThread1 = threads[0].Methods;
            var methodsThread2 = threads[1].Methods;

            Assert.AreEqual(1, methodsThread1.Count);            //one base method call
            Assert.AreEqual(1, methodsThread2.Count);            //one base method call

            string methodNameThread1 = methodsThread1[0].Name;
            string methodClassNameThread1 = methodsThread1[0].ClassName;
            string methodNameThread2 = methodsThread2[0].Name;
            string methodClassNameThread2 = methodsThread2[0].ClassName;

            Assert.AreEqual("Method1", methodNameThread1);
            Assert.AreEqual("TestClass", methodClassNameThread1);

            Assert.AreEqual("Method1", methodNameThread2);
            Assert.AreEqual("TestClass", methodClassNameThread2);

            Assert.AreEqual(2, methodsThread1[0].Methods.Count);  //two inner method calls
            Assert.AreEqual("Method2", methodsThread1[0].Methods[0].Name);
            Assert.AreEqual("Method2", methodsThread1[0].Methods[1].Name);

            Assert.AreEqual(2, methodsThread2[0].Methods.Count);  //two inner method calls
            Assert.AreEqual("Method2", methodsThread2[0].Methods[0].Name);
            Assert.AreEqual("Method2", methodsThread2[0].Methods[1].Name);
        }
    }
}