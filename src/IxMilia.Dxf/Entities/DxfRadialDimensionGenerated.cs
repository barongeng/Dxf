// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;

namespace IxMilia.Dxf.Entities
{

    /// <summary>
    /// DxfRadialDimension class
    /// </summary>
    public partial class DxfRadialDimension : DxfDimensionBase
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Dimension; } }

        public DxfPoint DefinitionPoint2 { get; set; }
        public double LeaderLength { get; set; }

        public DxfRadialDimension()
            : base()
        {
        }

        internal DxfRadialDimension(DxfDimensionBase other)
            : base(other)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.DimensionType = DxfDimensionType.Radius;
            this.DefinitionPoint2 = DxfPoint.Origin;
            this.LeaderLength = 0.0;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
            base.AddValuePairs(pairs, version, outputHandles);
            pairs.Add(new DxfCodePair(100, "AcDbRadialDimension"));
            pairs.Add(new DxfCodePair(15, DefinitionPoint2?.X ?? default(double)));
            pairs.Add(new DxfCodePair(25, DefinitionPoint2?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(35, DefinitionPoint2?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(40, (this.LeaderLength)));
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 15:
                    this.DefinitionPoint2.X = pair.DoubleValue;
                    break;
                case 25:
                    this.DefinitionPoint2.Y = pair.DoubleValue;
                    break;
                case 35:
                    this.DefinitionPoint2.Z = pair.DoubleValue;
                    break;
                case 40:
                    this.LeaderLength = (pair.DoubleValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }

}
