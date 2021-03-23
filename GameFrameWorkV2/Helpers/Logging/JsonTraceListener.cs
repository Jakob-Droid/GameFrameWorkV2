using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace GameFrameWorkV2.Helpers.Logging
{
    public class JsonTraceListener : TraceListener
    {
        public override void Write(string? message)
        {
            StreamWriter stream = new StreamWriter("Gamelog.json");
            using (stream)
            {
                var msg = JsonSerializer.Serialize(new {Date = DateTime.Now, Message = message});
                stream.WriteAsync(msg);
            }
        }

        public override void WriteLine(string? message)
        {
            StreamWriter stream = new StreamWriter("Gamelog.json");
            using (stream)
            {
                var msg = JsonSerializer.Serialize(new { Date = DateTime.Now, Message = message });
                stream.WriteLineAsync(msg);
            }
        }
    }
}
