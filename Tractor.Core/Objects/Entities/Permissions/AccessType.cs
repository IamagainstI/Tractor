using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities.Permissions
{
    [Flags]
    public enum AccessType : ulong
    {
        None                = 0b0_0_000_000_000_000_000,
        OwnerAdd            = 0b0_0_000_000_000_000_001,
        PerformerAdd        = 0b0_0_000_000_000_000_010,
        Add                 = 0b0_0_000_000_000_000_111,
        OwnerView           = 0b0_0_000_000_000_001_000,
        PerformerView       = 0b0_0_000_000_000_010_000,
        View                = 0b0_0_000_000_000_111_000,
        OwnerEdit           = 0b0_0_000_000_001_000_000,
        PerformerEdit       = 0b0_0_000_000_010_000_000,
        Edit                = 0b0_0_000_000_111_000_000,
        OwnerRemove         = 0b0_0_000_001_000_000_000,
        PerformerRemove     = 0b0_0_000_010_000_000_000,
        Remove              = 0b0_0_000_111_000_000_000,
        OwnerComplete       = 0b0_0_001_000_000_000_000,
        PerformerComplete   = 0b0_0_010_000_000_000_000,
        Complete            = 0b0_0_111_000_000_000_000,
        ParticipantsControl = 0b0_1_000_000_000_000_000,
        PermissionsControl  = 0b1_0_000_000_000_000_000,
        All                 = 0b1_1_111_111_111_111_111,
    }
}
