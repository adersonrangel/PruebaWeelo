using System;
using System.Collections.Generic;
using System.Text;

namespace Weelo.Transversal.Message.Service
{
    /// <summary>
    /// Abstract class for message response
    /// </summary>
    public abstract class MessageBase
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
