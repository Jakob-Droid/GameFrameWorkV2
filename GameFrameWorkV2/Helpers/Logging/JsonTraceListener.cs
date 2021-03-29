using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

#nullable enable
namespace GameFrameWorkV2.Helpers.Logging
{
    public class JsonTraceListener : TraceListener
    {
        private string _logPath;
        public JsonTraceListener(string logPath = "Gamelog.json")
        {
            _logPath = logPath;
        }

        public override void Write(string? message)
        {
            StreamWriter stream = new StreamWriter("_logPath", true);
            using (stream)
            {
                var msg = JsonSerializer.Serialize(new { Date = DateTime.Now, Message = message });
                stream.Write(msg);
                stream.Flush();
            }
        }

        public override void WriteLine(string? message)
        {
            StreamWriter stream = new StreamWriter(_logPath, true);
            using (stream)
            {
                var msg = JsonSerializer.Serialize(new { Date = DateTime.Now, Message = message });
                stream.WriteLine(msg);
                stream.Flush();

            }
        }
    }
}
