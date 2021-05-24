using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Common
{
    public interface ICommonService
    {
        IDatetimeService DatetimeService { get; }
        IEncryptionService EncryptionService { get; }
    }
}
