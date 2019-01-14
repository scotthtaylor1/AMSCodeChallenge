using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IComplianceMapService
    {
        List<string> CreateComplianceMap(List<char[]> mapArray, int rows, int columns, int step);
        void WriteComplianceMap(List<string> complianceMapData);
    }
}
