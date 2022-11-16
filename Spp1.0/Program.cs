using Spp1._0.Interface;
using Spp1._0.TestClasses;
using System.Xml.Serialization;
using TracerLib.Interface;
using TracerLib.Serializers;
using TracerLib.Service;

public class Program
{
    public Tracer tracer { get; set; }
    public ITrackService trackService { get; set; }
    public ITracerService tracerService { get; set; }
    static void Main()
    {
        Program program = new();
        program.trackService = new TrackService();
        program.tracerService = new TracerService();
        program.tracer = new Tracer(program.tracerService, program.trackService);

        TestClass testClass = new TestClass(program.tracer);
        Task.Run(() => testClass.Method0());
        testClass.Method0();

        var result = program.tracer.GetTraceResult();


        IResultWriter consoleWriter = new ConsoleResultWriter();
        IResultWriter jsonWriter = new FileResultWriter("Results/result.json");
        IResultWriter xmlWriter = new FileResultWriter("Results/result.xml");

        ISerializer jsonSerializer = new JsonSerializerService();
        ISerializer xmlSerializer = new XmlSerializerService();

        var jsonResult = jsonSerializer.Serialize(result);
        var xmlResult = xmlSerializer.Serialize(result);

        jsonWriter.WriteResult(jsonResult);
        xmlWriter.WriteResult(xmlResult);

        consoleWriter.WriteResult(jsonResult);
        consoleWriter.WriteResult(xmlResult);
    }
}