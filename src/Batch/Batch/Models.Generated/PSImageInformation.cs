﻿// -----------------------------------------------------------------------------
﻿//
﻿// Copyright Microsoft Corporation
﻿// Licensed under the Apache License, Version 2.0 (the "License");
﻿// you may not use this file except in compliance with the License.
﻿// You may obtain a copy of the License at
﻿// http://www.apache.org/licenses/LICENSE-2.0
﻿// Unless required by applicable law or agreed to in writing, software
﻿// distributed under the License is distributed on an "AS IS" BASIS,
﻿// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
﻿// See the License for the specific language governing permissions and
﻿// limitations under the License.
﻿// -----------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:5.0.15
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Batch.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Batch;
    
    
    public partial class PSImageInformation
    {
        
        internal Microsoft.Azure.Batch.ImageInformation omObject;
        
        private IReadOnlyList<System.String> capabilities;
        
        private PSImageReference imageReference;
        
        internal PSImageInformation(Microsoft.Azure.Batch.ImageInformation omObject)
        {
            if ((omObject == null))
            {
                throw new System.ArgumentNullException("omObject");
            }
            this.omObject = omObject;
        }
        
        public System.DateTime? BatchSupportEndOfLife
        {
            get
            {
                return this.omObject.BatchSupportEndOfLife;
            }
        }
        
        public IReadOnlyList<System.String> Capabilities
        {
            get
            {
                if (((this.capabilities == null) 
                            && (this.omObject.Capabilities != null)))
                {
                    List<System.String> list;
                    list = new List<System.String>();
                    IEnumerator<System.String> enumerator;
                    enumerator = this.omObject.Capabilities.GetEnumerator();
                    for (
                    ; enumerator.MoveNext(); 
                    )
                    {
                        list.Add(enumerator.Current);
                    }
                    this.capabilities = list;
                }
                return this.capabilities;
            }
        }
        
        public PSImageReference ImageReference
        {
            get
            {
                if (((this.imageReference == null) 
                            && (this.omObject.ImageReference != null)))
                {
                    this.imageReference = new PSImageReference(this.omObject.ImageReference);
                }
                return this.imageReference;
            }
        }
        
        public string NodeAgentSkuId
        {
            get
            {
                return this.omObject.NodeAgentSkuId;
            }
        }
        
        public Microsoft.Azure.Batch.Common.OSType? OSType
        {
            get
            {
                return this.omObject.OSType;
            }
        }
        
        public Microsoft.Azure.Batch.Common.VerificationType? VerificationType
        {
            get
            {
                return this.omObject.VerificationType;
            }
        }
    }
}
