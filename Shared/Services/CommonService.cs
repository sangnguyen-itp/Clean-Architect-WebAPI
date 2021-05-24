using Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructures.Shared.Services
{
    public class CommonService : ICommonService
    {
        public IDatetimeService DatetimeService { get; }
        public IEncryptionService EncryptionService { get;}


        public CommonService(
                IDatetimeService datetimeService,
                IEncryptionService encryptionService
            )
        {
            DatetimeService = datetimeService;
            EncryptionService = encryptionService;
        }
    }
}
