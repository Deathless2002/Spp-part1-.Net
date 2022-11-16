using Spp1._0.Interface;

namespace TracerTests.TestClasses
{
    public class TestClass
    {
        private ITracer _tracer;

        public TestClass(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Method0()
        {
            Method1();
        }

        private void Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            Method2();
            Method2();
            _tracer.StopTrace();
        }

        private void Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            Method3();
            Method3();
            _tracer.StopTrace();
        }

        private void Method3()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}
