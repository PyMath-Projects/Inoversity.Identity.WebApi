// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using InoversityIdentity.Distribution.WebApi.Controllers.Consent;

namespace InoversityIdentity.Distribution.WebApi.Controllers.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}