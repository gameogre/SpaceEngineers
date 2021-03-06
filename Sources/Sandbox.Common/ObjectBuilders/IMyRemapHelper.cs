﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.Common.ObjectBuilders
{
    public interface IMyRemapHelper
    {
        /// <summary>
        /// Returns a new entity ID for the entity with the given old entity ID.
        /// The function will return the same new entityId only if the saveMapping argument is set to true.
        /// </summary>
        long RemapEntityId(long oldEntityId);

        /// <summary>
        /// Clears all the saved mappings from the remap helper and gets it ready for the next remapping operation.
        /// </summary>
        void Clear();
    }
}
