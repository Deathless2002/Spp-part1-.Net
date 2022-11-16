using Spp1._0.InfoModel;
using System.Xml.Linq;
using System.Xml;
using TracerLib.Interface;

namespace TracerLib.Serializers
{
    public class XmlSerializerService : ISerializer
    {
        public string Serialize(TraceResult result)
        {
            StringWriter textWriter = new();
            var string1 = SaveTraceResult(textWriter, result);
            textWriter.Close();
            return string1;
        }

        public string SaveTraceResult(StringWriter textWriter, TraceResult traceResult)
        {
            XDocument doc = new(
                new XElement("root", from threadTracerResult in traceResult.Threads
                                     select SaveThread(threadTracerResult)
                ));

            using XmlTextWriter xmlWriter = new(textWriter);
            xmlWriter.Formatting = Formatting.Indented;
            doc.WriteTo(xmlWriter);
            return textWriter.ToString();
        }

        private XElement SaveThread(ThreadInfoModel threadInfo)
        {
            return new XElement("thread",
                new XAttribute("id", threadInfo.ThreadId),
                new XAttribute("time", threadInfo.ExecutionTime + "ms"),
                from methodTracerResult in threadInfo.Methods
                select SaveMethod(methodTracerResult)
                );
        }

        private XElement SaveMethod(MethodInfoTreeModel methodInfo)
        {
            XElement savedTracedMetod = new("method",
                new XAttribute("name", methodInfo.Name),
                new XAttribute("time", methodInfo.Time + "ms"),
                new XAttribute("class", methodInfo.ClassName));

            if (methodInfo.Methods.Any())
                savedTracedMetod.Add(from innerMethod in methodInfo.Methods
                                     select SaveMethod(innerMethod));
            return savedTracedMetod;
        }
    }
}
