
using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Transversal.Message.Service;

namespace Weelo.RealEstate.Api.Model
{
    public class ResponseViewModel<T>
    {
        public MessageError MessageError { get; set; }
        public MessageOk MessageOk { get; set; }
        public T Data { get; set; }
    }
}
