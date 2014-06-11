using System.Diagnostics;

namespace blog.Codes.DTO
{
  [DebuggerDisplay("Status = {Status}")]
  public class OperationStatus
  {
    public bool Status { get; set; }
    public string Message { get; set; }
  }
}