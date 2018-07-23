
using System.Collections.Generic;

namespace Volvo.MaintenanceTool.UserInterface.Models.Shared
{
    /// <summary>
    /// A generic result object which will be returned in the JSON format into the client.
    /// </summary>
    public class JsonObjectModel
    {
        public bool Success { get; set; }
        public IEnumerable<string> InfoMessages { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public IEnumerable<string> WarningMessages { get; set; }
        public object Content { get; set; }
    }
}